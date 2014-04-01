<%@ Page Title="Manage Category Image" Language="C#" MasterPageFile="~/MasterPages/eStoreAdminMaster.Master" AutoEventWireup="true" CodeBehind="ManageImage.aspx.cs" Inherits="eStoreAdminWeb.Web.Merchandise.Category.ManageImage" %>
<%@ MasterType VirtualPath="~/MasterPages/eStoreAdminMaster.Master" %>
<%@ Import Namespace="eStoreAdminWeb" %>
<%@ Import Namespace="phoenixconsulting.common.handlers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <%if (SessionHandler.isSessionTimedOut(Context, Page)) { %>
        <%FormsAuthentication.RedirectToLoginPage(); 
      } %>
    <% if(CategoryImageListView.Items.Count != 0) {%>
        <h1>Manage <%=RequestHandler.Instance.CategoryName %> Category Image</h1>
        <div>
            <asp:HyperLink ID="BackToHyperlink" runat="server">
                < Back to <%=RequestHandler.Instance.DepartmentName%> Department
            </asp:HyperLink>
        </div>
        <asp:ListView ID="CategoryImageListView" runat="server" 
                      DataKeyNames="ID" 
                      DataSourceID="ImagesODS" 
                      GroupItemCount="4"
                      OnItemCommand="CategoryImageListView_ItemCommand">
            <ItemTemplate>
                <div class="<%#getDivClass("Category", Eval("IsDefault").ToString(), false)%>">
                    <asp:Image ID="CategoryImage" runat="server"
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
                There are no images for this Category.
            </EditItemTemplate>
            <LayoutTemplate>
                <div ID="groupPlaceholder" runat="server"></div>
            </LayoutTemplate>
            <GroupTemplate>
                <div ID="itemPlaceholder" runat="server"></div>
            </GroupTemplate>
        </asp:ListView>
    <%} else { %>
        <h1>There are no images for this Category. Add one.</h1>
    <%} %>
    <asp:ObjectDataSource ID="ImagesODS" runat="server" 
                          TypeName="eStoreAdminBLL.ImagesBLL"
                          OldValuesParameterFormatString="original_{0}" 
                          SelectMethod="GetImageByCategory">
        <SelectParameters>
            <asp:QueryStringParameter Name="ID" 
                                      QueryStringField="CatID" 
                                      Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>