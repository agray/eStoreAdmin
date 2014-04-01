<%@ Page Title="Manage Department Image" Language="C#" MasterPageFile="~/MasterPages/eStoreAdminMaster.Master" AutoEventWireup="true" CodeBehind="ManageImage.aspx.cs" Inherits="eStoreAdminWeb.Web.Merchandise.Department.ManageImage" %>
<%@ MasterType VirtualPath="~/MasterPages/eStoreAdminMaster.Master" %>
<%@ Import Namespace="eStoreAdminWeb" %>
<%@ Import Namespace="phoenixconsulting.common.handlers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <%if (SessionHandler.isSessionTimedOut(Context, Page)) { %>
        <%FormsAuthentication.RedirectToLoginPage(); 
      } %>
    <% if(DepartmentImageListView.Items.Count != 0) {%>
        <h1>Manage <%=Request["DepName"] %> Department Image</h1>
        <div>
            <asp:HyperLink ID="BackToHyperlink" runat="server">
                < Back to Departments
            </asp:HyperLink>
        </div>
        <asp:ListView ID="DepartmentImageListView" runat="server" 
                      DataKeyNames="ID" 
                      DataSourceID="ImagesODS" 
                      GroupItemCount="4"
                      OnItemCommand="DepartmentImageListView_ItemCommand">
            <ItemTemplate>
                <div class="<%#getDivClass("Department", Eval("IsDefault").ToString(), false)%>">
                    <asp:Image ID="DepartmentImage" runat="server"
                               ImageUrl='<%#Eval("ImgPath")%>'
                               BorderWidth="0px"
                               Height="130px"
                               Width="150px"/>
                    <p class="clear">
                        <asp:LinkButton ID="btnEdit" runat="server" 
                                        Text="Make Image Default" 
                                        CommandName="MakeDefault"
                                        CommandArgument='<%#Eval("ID")%>'
                                        Visible='<%#setEditVisibility(Eval("IsDefault").ToString())%>' />
                    </p>
                </div>
            </ItemTemplate>
            <EditItemTemplate>
                There are no images for this Department.
            </EditItemTemplate>
            <LayoutTemplate>
                <div ID="groupPlaceholder" runat="server"></div>
            </LayoutTemplate>
            <GroupTemplate>
                <div ID="itemPlaceholder" runat="server"></div>
            </GroupTemplate>
        </asp:ListView>
    <%} else { %>
        <h1>There are no images for this Department. Add category and products first.</h1>
    <%} %>
    <asp:ObjectDataSource ID="ImagesODS" runat="server" 
                          TypeName="eStoreAdminBLL.ImagesBLL"
                          OldValuesParameterFormatString="original_{0}" 
                          SelectMethod="GetImageByDepartment">
        <SelectParameters>
            <asp:QueryStringParameter Name="ID" 
                                      QueryStringField="DepID" 
                                      Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
