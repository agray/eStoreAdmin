<%@ Page Title="Manage Testimonials" Language="C#" MasterPageFile="~/MasterPages/eStoreAdminMaster.Master" AutoEventWireup="true" CodeBehind="ManageTestimonials.aspx.cs" Inherits="eStoreAdminWeb.ManageTestimonials" %>
<%@ MasterType VirtualPath="~/MasterPages/eStoreAdminMaster.Master" %>
<%@ Import Namespace="eStoreAdminWeb" %>
<%@ Import Namespace="phoenixconsulting.common.handlers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <%if (SessionHandler.isSessionTimedOut(Context, Page)) { %>
        <%FormsAuthentication.RedirectToLoginPage(); 
      } %>
    <h1>Manage Testimonials</h1>
    <%if(Roles.IsUserInRole("Manager")) { %>
        <asp:HyperLink ID="ManagerHomeHyperlink" runat="server"
                       NavigateUrl="SettingsManagerHome.aspx"
                       Text="Back to Settings Home"/>
    <%} else { %>
        <asp:HyperLink ID="AdminHomeHyperlink" runat="server"
                       NavigateUrl="SettingsAdminHome.aspx"
                       Text="Back to Settings Home"/>
    <%} %>
    <table width="100%">
        <tr>
            <td valign="top">
                <asp:GridView ID="TestimonialsGridView" runat="server" 
                              EnableViewState="False"
                              AutoGenerateColumns="False" 
                              AllowPaging="True" 
                              AllowSorting="True"
                              PagerSettings-Mode="Numeric"
                              PageSize="20"
                              BackColor="White" 
                              BorderColor="#999999" 
                              BorderStyle="None" 
                              BorderWidth="1px" 
                              CellPadding="3" 
                              GridLines="Vertical"
                              OnDataBound="TestimonialsGridView_DataBound" 
                              DataKeyNames="ID" 
                              DataSourceID="TestimonialsODS" >
                    <Columns>
                        <asp:CommandField ShowSelectButton="True" />
                        <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" 
                                        ReadOnly="True" SortExpression="ID" Visible="False" />
                        <asp:BoundField DataField="CustomerName" HeaderText="Customer Name" 
                                        SortExpression="CustomerName" />
                        <asp:BoundField DataField="CustomerCountry" HeaderText="Customer Country" 
                                        SortExpression="CustomerCountry" />
                        <asp:BoundField DataField="TestimonialText" HeaderText="Testimonial Text" 
                                        SortExpression="TestimonialText" />
                    </Columns>
                    <EmptyDataTemplate>
                        There are no Testimonials.
                    </EmptyDataTemplate>
                </asp:GridView>                    
                <asp:ObjectDataSource ID="TestimonialsODS" runat="server"
                                      SelectMethod="GetTestimonials" 
                                      OldValuesParameterFormatString="original_{0}"  
                                      TypeName="eStoreAdminBLL.TestimonialBLL" >
                </asp:ObjectDataSource>
            </td>
            <td valign="top" align="right">
                <asp:FormView ID="TestimonialFormView" runat="server" 
                              DataSourceID="TestimonialODS"
                              DataKeyNames="ID" 
                              BackColor="White" 
                              BorderColor="#999999" 
                              BorderStyle="None" 
                              BorderWidth="1px" 
                              CellPadding="3" 
                              GridLines="Vertical" 
                              OnItemDeleted="TestimonialFormView_ItemDeleted" 
                              OnItemInserted="TestimonialFormView_ItemInserted" 
                              OnItemUpdated="TestimonialFormView_ItemUpdated">
                    <EditItemTemplate>
                        <table>
                            <tr>
                                <td>Customer Name:</td>
                                <td><asp:TextBox ID="CustomerNameEditTextBox" runat="server" 
                                                Text='<%# Bind("CustomerName") %>' />
                                </td>
                                <td><asp:RequiredFieldValidator ID="CustomerNameEditRFV" runat="server" 
                                                                ControlToValidate="CustomerNameEditTextBox" 
                                                                ErrorMessage="Required"
                                                                ValidationGroup="TestimonialGroup"
                                                                Display="Dynamic" />
                                    <asp:RegularExpressionValidator ID="CustomerNameEditREV" runat="server"
                                                                    ControlToValidate="CustomerNameEditTextBox"
                                                                    ValidationExpression="^[a-zA-Z ]*$"
                                                                    ValidationGroup="TestimonialGroup"
                                                                    ErrorMessage="Invalid Customer Name"
                                                                    Display="Dynamic" />
                                </td>
                            </tr>
                            <tr>
                                <td>Customer Country:</td>
                                <td><asp:TextBox ID="CustomerCountryEditTextBox" runat="server" 
                                                 Text='<%# Bind("CustomerCountry") %>' />
                                </td>
                                <td><asp:RequiredFieldValidator ID="CustomerCountryEditRFV" runat="server" 
                                                                ControlToValidate="CustomerCountryEditTextBox" 
                                                                ErrorMessage="Required"
                                                                ValidationGroup="TestimonialGroup"
                                                                Display="Dynamic" />
                                    <asp:RegularExpressionValidator ID="CustomerCountryEditREV" runat="server"
                                                                    ControlToValidate="CustomerCountryEditTextBox"
                                                                    ValidationExpression="^[a-zA-Z ]*$"
                                                                    ValidationGroup="TestimonialGroup"
                                                                    ErrorMessage="Invalid Country"
                                                                    Display="Dynamic" />
                                </td>
                            </tr>
                            <tr>
                                <td>Testimonial:</td>
                                <td><asp:TextBox ID="TestimonialTextEditTextBox" runat="server"
                                                 MaxLength="8000"
                                                 TextMode="MultiLine" 
                                                 Rows="20" 
                                                 Columns="50" 
                                                 Font-Size="X-Small"
                                                 Text='<%# Bind("TestimonialText") %>' />
                                </td>
                                <td><asp:RequiredFieldValidator ID="TestimonialTextEditRFV" runat="server" 
                                                                ControlToValidate="TestimonialTextEditTextBox" 
                                                                ErrorMessage="Required" 
                                                                Display="Dynamic" />
                                </td>
                                
                            </tr>
                        </table>
                        <asp:Button ID="UpdateButton" runat="server" 
                                    CausesValidation="True" 
                                    CommandName="Update"
                                    ValidationGroup="TestimonialGroup" 
                                    Text="Update" />&nbsp;
                        <asp:Button ID="UpdateCancelButton" runat="server" 
                                    CausesValidation="False" 
                                    CommandName="Cancel" 
                                    Text="Cancel" />
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <table>
                            <tr>
                                <td>Customer Name:</td>
                                <td><asp:TextBox ID="CustomerNameAddTextBox" runat="server" 
                                                Text='<%# Bind("CustomerName") %>' />
                                </td>
                                <td><asp:RequiredFieldValidator ID="CustomerNameAddRFV" runat="server" 
                                                                ControlToValidate="CustomerNameAddTextBox" 
                                                                ErrorMessage="Required"
                                                                ValidationGroup="TestimonialGroup" 
                                                                Display="Dynamic" />
                                    <asp:RegularExpressionValidator ID="CustomerNameAddREV" runat="server"
                                                                    ControlToValidate="CustomerNameAddTextBox"
                                                                    ValidationExpression="^[a-zA-Z ]*$"
                                                                    ValidationGroup="TestimonialGroup"
                                                                    ErrorMessage="Invalid Customer Name"
                                                                    Display="Dynamic" />
                                </td>
                            </tr>
                            <tr>
                                <td>Customer Country:</td>
                                <td><asp:TextBox ID="CustomerCountryAddTextBox" runat="server" 
                                                 Text='<%# Bind("CustomerCountry") %>' />
                                </td>
                                <td><asp:RequiredFieldValidator ID="CustomerCountryAddRFV" runat="server" 
                                                                ControlToValidate="CustomerCountryAddTextBox" 
                                                                ErrorMessage="Required"
                                                                ValidationGroup="TestimonialGroup"
                                                                Display="Dynamic" />
                                    <asp:RegularExpressionValidator ID="CustomerCountryAddREV" runat="server"
                                                                    ControlToValidate="CustomerCountryAddTextBox"
                                                                    ValidationExpression="^[a-zA-Z ]*$"
                                                                    ValidationGroup="TestimonialGroup"
                                                                    ErrorMessage="Invalid Country"
                                                                    Display="Dynamic" />
                                </td>
                            </tr>
                            <tr>
                                <td>Testimonial:</td>
                                <td><asp:TextBox ID="TestimonialTextAddTextBox" runat="server" 
                                                 Text='<%# Bind("TestimonialText") %>' />
                                </td>
                                <td><asp:RequiredFieldValidator ID="TestimonialTextAddRFV" runat="server" 
                                                                ControlToValidate="TestimonialTextAddTextBox" 
                                                                ErrorMessage="Required" 
                                                                Display="Dynamic" />
                                </td>
                            </tr>
                        </table>
                        <asp:Button ID="InsertButton" runat="server" 
                                    CausesValidation="True"
                                    ValidationGroup="TestimonialGroup" 
                                    CommandName="Insert" 
                                    Text="Insert" />&nbsp;
                        <asp:Button ID="InsertCancelButton" runat="server" 
                                    CausesValidation="False" 
                                    CommandName="Cancel" 
                                    Text="Cancel" />
                    </InsertItemTemplate>
                    <ItemTemplate>
                        <table>
                            <tr>
                                <td>Customer Name:</td>
                                <td><asp:Label ID="CustomerNameLabel" runat="server" 
                                               Text='<%# Bind("CustomerName") %>' />
                                </td>
                            </tr>
                            <tr>
                                <td>Customer Country:</td>
                                <td><asp:Label ID="CustomerCountryLabel" runat="server" 
                                               Text='<%# Bind("CustomerCountry") %>' />
                                </td>
                            </tr>
                            <tr>
                                <td>Testimonial:</td>
                                <td><asp:Label ID="TestimonialTextLabel" runat="server" 
                                               Text='<%# Bind("TestimonialText") %>' />
                                </td>
                            </tr>
                        </table>
                        <asp:Button ID="EditButton" runat="server" CausesValidation="False" 
                                    CommandName="Edit" Text="Edit" />&nbsp;
                        <asp:Button ID="DeleteButton" runat="server" CausesValidation="False" 
                                    CommandName="Delete" Text="Delete"
                                    OnClientClick="return confirm('Are you sure you want to delete this testimonial?')" />&nbsp;
                        <asp:Button ID="NewButton" runat="server" CausesValidation="False" 
                                    CommandName="New" Text="New" />
                    </ItemTemplate>
                </asp:FormView>
                <asp:ObjectDataSource ID="TestimonialODS" runat="server" 
                                      OldValuesParameterFormatString="original_{0}" 
                                      SelectMethod="GetTestimonialById" 
                                      TypeName="eStoreAdminBLL.TestimonialBLL" 
                                      DeleteMethod="DeleteTestmonial" 
                                      InsertMethod="AddTestimonial" 
                                      UpdateMethod="UpdateTestimonial">
                    <DeleteParameters>
                        <asp:Parameter Name="original_ID" Type="Int32" />
                    </DeleteParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="original_ID" Type="Int32" />
                        <asp:Parameter Name="customerName" Type="String" />
                        <asp:Parameter Name="customerCountry" Type="String" />
                        <asp:Parameter Name="testimonialText" Type="String" />
                    </UpdateParameters>
                    <SelectParameters>
                        <asp:ControlParameter ControlID="TestimonialsGridView" 
                                              DefaultValue="0" 
                                              Name="ID" 
                                              PropertyName="SelectedValue" 
                                              Type="Int32" />
                    </SelectParameters>
                    <InsertParameters>
                        <asp:Parameter Name="customerName" Type="String" />
                        <asp:Parameter Name="customerCountry" Type="String" />
                        <asp:Parameter Name="testimonialText" Type="String" />
                    </InsertParameters>
                </asp:ObjectDataSource>
            </td>
        </tr>
    </table>
</asp:Content>