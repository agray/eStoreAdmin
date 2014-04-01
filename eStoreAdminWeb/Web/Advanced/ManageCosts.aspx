<%@ Page Title="Manage Costs" Language="C#" MasterPageFile="~/MasterPages/eStoreAdminMaster.Master" AutoEventWireup="true" CodeBehind="ManageCosts.aspx.cs" Inherits="eStoreAdminWeb.Web.Advanced.ManageCosts" %>
<%@ MasterType VirtualPath="~/MasterPages/eStoreAdminMaster.Master" %>
<%@ Import Namespace="eStoreAdminWeb" %>
<%@ Import Namespace="phoenixconsulting.common.handlers" %>

<%@ Register TagPrefix="zone" TagName="ZoneDDL" Src="~/Controls/ZoneDDL.ascx" %>
<%@ Register TagPrefix="mode" TagName="ModeDDL" Src="~/Controls/ModeDDL.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <%if (SessionHandler.isSessionTimedOut(Context, Page)) { %>
        <%FormsAuthentication.RedirectToLoginPage(); 
      } %>
    <h1>Manage Costs</h1>
    <table>
        <tr>
            <td>Zone:</td>
            <td>
                <zone:ZoneDDL ID="ZoneDDL" runat="server"
                              AppendDataBoundItems="true"
                              AutoPostBack="True"
                              OnSelectedIndexChanged="ZonesDropDownList_SelectedIndexChanged">
                    <Items>
                        <asp:ListItem Text="--Choose a Zone--" Value="-1" />
                    </Items>
                </zone:ZoneDDL>
             </td>
        </tr>
        <tr>    
            <td>Mode:</td>
            <td>
                <mode:ModeDDL ID="ModeDDL" runat="server"
                              AppendDataBoundItems="true"
                              AutoPostBack="True">
                    <Items>
                        <asp:ListItem Text="--Choose a Mode--" Value="-1" />
                    </Items>
                </mode:ModeDDL>
             </td>
        </tr>
    </table>
    <asp:ListView ID="CostList" runat="server" 
                  DataSourceID="CostsODS" 
                  DataKeyNames="ID"
                  OnItemUpdated="CostList_ItemUpdated"
                  OnItemDeleting="CostList_ItemDeleting">
        <LayoutTemplate>
            <table width="75%" border="1">
                <thead>
                    <td>Max Weight</td>
                    <td>Price</td>
                    <td>Actions</td>
                </thead>
                <div ID="groupPlaceholder" runat="server" />
            </table>
        </LayoutTemplate>
        <GroupTemplate>
            <tr>
                <div ID="itemPlaceholder" runat="server" />
            </tr>
        </GroupTemplate>
        <EmptyDataTemplate>
            <div id="EmptyListDiv" runat="server">There are no items in this list yet. Add one.</div>
        </EmptyDataTemplate>
        <ItemTemplate>
            <td style="text-align:left">
                <asp:Label ID="WeightLabel" runat="server" Text='<%#Eval("MaxWeight")%>'/>
            </td>
            <td style="text-align:left">
                <asp:Label ID="PriceLabel" runat="server" Text='<%#Eval("Price")%>'/>
            </td>
            <td style="text-align:right">
                <asp:Button ID="btnEdit" runat="server" CssClass="linkButton" Text="Edit" CommandName="Edit" />
                <asp:Button ID="btnDelete" runat="server" CssClass="linkButton" Text="Delete" CommandName="Delete" OnClientClick="return confirm('Are you sure you want to delete this item?')" />
            </td>
        </ItemTemplate>
        <EditItemTemplate>
            <td style="text-align:left">
                <asp:TextBox ID="MaxWeightEditTextBox" runat="server" Text='<%# Bind("MaxWeight")%>' />
                <asp:RequiredFieldValidator ID="MaxWeightEditRFV" runat="server" 
                                            ControlToValidate="MaxWeightEditTextBox" 
                                            ErrorMessage="Required"
                                            ValidationGroup="EditGroup"
                                            Display="Dynamic" />
            </td>
            <td style="text-align:left">
                <asp:TextBox ID="PriceEditTextBox" runat="server" Text='<%# Bind("Price")%>' />
                <asp:RequiredFieldValidator ID="PriceEditRFV" runat="server" 
                                            ControlToValidate="PriceEditTextBox" 
                                            ErrorMessage="Required"
                                            ValidationGroup="EditGroup"
                                            Display="Dynamic" />
            </td>
            <td style="text-align:right">
                <asp:Button ID="btnSave" runat="server" CssClass="linkButton" Text="Save" CommandName="Update" ValidationGroup="EditGroup"/>
                <asp:Button ID="btnCancel" runat="server" CssClass="linkButton" Text="Cancel" CommandName="Cancel" />
            </td>
        </EditItemTemplate>
    </asp:ListView>
    <hr id="AddHR" runat="server" />
    <asp:TextBox runat="server" ID="MaxWeightAddTextBox"/>
    <asp:RequiredFieldValidator ID="MaxWeightAddRFV" runat="server" 
                                    ControlToValidate="MaxWeightAddTextBox" 
                                    ErrorMessage="Required"
                                    ValidationGroup="AddGroup"
                                    Display="Dynamic" />
    <asp:RegularExpressionValidator ID="MaxWeightAddREV" runat="server"
                                    ControlToValidate="MaxWeightAddTextBox"
                                    ValidationExpression="^[0-9]*$"
                                    ValidationGroup="AddGroup"
                                    ErrorMessage="Numeric Only"
                                    Display="Dynamic" />
    <asp:TextBox runat="server" ID="PriceAddTextBox"/>
    <asp:RequiredFieldValidator ID="PriceAddRFV" runat="server" 
                                ControlToValidate="PriceAddTextBox" 
                                ErrorMessage="Required"
                                ValidationGroup="AddGroup"
                                Display="Dynamic" />
    <asp:RegularExpressionValidator ID="PriceAddREV" runat="server"
                                    ControlToValidate="PriceAddTextBox"
                                    ValidationExpression="^[0-9]*$"
                                    ValidationGroup="AddGroup"
                                    ErrorMessage="Numeric Only"
                                    Display="Dynamic" />
    <asp:Button ID="btnAdd" runat="server" 
                CssClass="linkButton" 
                Text="Add" 
                OnClick="AddNewItem" 
                ValidationGroup="AddGroup" />
    <asp:ObjectDataSource ID="CostsODS" runat="server" 
                          TypeName="eStoreAdminBLL.CostsBLL" 
                          OldValuesParameterFormatString="original_{0}" 
                          SelectMethod="GetCosts"
                          UpdateMethod="UpdateCost"
                          DeleteMethod="DeleteCost">
        <SelectParameters>
            <asp:ControlParameter ControlID="ZoneDDL:ZoneDropDownList" DefaultValue="1" 
                                  Name="ZoneID" PropertyName="SelectedValue" Type="Int32" />
            <asp:ControlParameter ControlID="ModeDDL:ModeDropDownList" DefaultValue="1" 
                                  Name="ModeID" PropertyName="SelectedValue" Type="Int32" />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="original_ID" Type="Int32" />
            <asp:Parameter Name="maxWeight" Type="Double" />
            <asp:Parameter Name="price" Type="Double" />
        </UpdateParameters>
        <DeleteParameters>
            <asp:Parameter Name="original_ID" Type="Int32" />
        </DeleteParameters>
    </asp:ObjectDataSource>
</asp:Content>
