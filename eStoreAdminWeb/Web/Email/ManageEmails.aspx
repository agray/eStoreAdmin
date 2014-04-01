<%@ Page Title="Manage Emails" Language="C#" MasterPageFile="~/MasterPages/eStoreAdminMaster.Master" AutoEventWireup="true" CodeBehind="ManageEmails.aspx.cs" Inherits="eStoreAdminWeb.ManageEmails" %>
<%@ MasterType VirtualPath="~/MasterPages/eStoreAdminMaster.Master" %>
<%@ Import Namespace="eStoreAdminWeb" %>
<%@ Import Namespace="phoenixconsulting.common.handlers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <%if (SessionHandler.isSessionTimedOut(Context, Page)) { %>
        <%FormsAuthentication.RedirectToLoginPage(); 
      } %>
    <h1>Manage Emails</h1>
    <table width="100%">
        <tr>
            <td valign="top">
                <asp:GridView ID="EmailGridView" runat="server" 
                              DataSourceID="EmailsODS" 
                              DataKeyNames="ID"
                              AutoGenerateColumns="False" 
                              BackColor="White" 
                              BorderColor="#999999" 
                              BorderStyle="None" 
                              BorderWidth="1px" 
                              CellPadding="3" 
                              GridLines="Vertical" 
                              AllowPaging="True"
                              PageSize="10"
                              AllowSorting="True">
                    <Columns>
                        <asp:CommandField ShowSelectButton="True" />
                        <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" 
                                        ReadOnly="True" SortExpression="ID" Visible="False" />
                        <asp:BoundField DataField="CustomerName" HeaderText="Customer Name" 
                                        SortExpression="CustomerName" />
                        <asp:BoundField DataField="EmailAddress" HeaderText="EmailAddress" 
                                        SortExpression="EmailAddress" Visible="False" />
                        <asp:BoundField DataField="Subject" HeaderText="Subject" 
                                        SortExpression="Subject" />
                        <asp:BoundField DataField="Message" HeaderText="Message" 
                                        SortExpression="Message" Visible="False" />
                        <asp:BoundField DataField="DateReceived" HeaderText="Date Received" 
                                        SortExpression="DateReceived" />
                        <asp:BoundField DataField="ReplyMessage" HeaderText="ReplyMessage" 
                                        SortExpression="ReplyMessage" Visible="False" />
                        <asp:BoundField DataField="DateSent" HeaderText="DateSent" 
                                        SortExpression="DateSent" Visible="False" />
                    </Columns>
                    <EmptyDataTemplate>
                        There are no Emails.
                    </EmptyDataTemplate>
                </asp:GridView>
            </td>
            <td valign="top" align="right">
                <asp:FormView ID="EmailFormView" runat="server" 
                              DataSourceID="EmailODS" 
                              DataKeyNames="ID" 
                              BackColor="White" 
                              BorderColor="#999999" 
                              BorderStyle="None" 
                              BorderWidth="1px" 
                              CellPadding="3" 
                              GridLines="Vertical">
                    <ItemTemplate>
                        <table>
                            <tr>
                                <td>Name:</td>
                                <td align="left">
                                    <asp:Label ID="IDLabel" runat="server" 
                                               Text='<%# Bind("ID") %>'
                                               Visible="false" />
                                    <asp:Label ID="CustomerNameLabel" runat="server" 
                                               Text='<%# Bind("CustomerName") %>' />
                                </td>
                            </tr>
                            <tr>
                                <td>Email Address:</td>
                                <td align="left">
                                    <asp:Label ID="EmailAddressLabel" runat="server" 
                                               Text='<%# Bind("EmailAddress") %>' />
                                </td>
                            </tr>
                            <tr>
                                <td>Subject:</td>
                                <td align="left">
                                    <asp:Label ID="SubjectLabel" runat="server" 
                                               Text='<%# Bind("Subject") %>' />
                                </td>
                            </tr>
                            <tr>
                                <td>Message:</td>
                                <td align="left">
                                    <asp:TextBox ID="MessageTextBox" runat="server"
                                                 TextMode="MultiLine"
                                                 Rows="10"
                                                 Columns="40" 
                                                 Text='<%# Bind("Message", "{0}") %>'
                                                 ReadOnly="true" 
                                                 Enabled="false"/>
                                </td>
                            </tr>
                            <tr>
                                <td>Date Received:</td>
                                <td align="left">
                                    <asp:Label ID="DateReceivedLabel" runat="server" 
                                               Text='<%# Bind("DateReceived") %>' />
                                </td>
                            </tr>
                            <tr>
                                <td>Reply Message:</td>
                                <td align="left">
                                    <asp:TextBox ID="ReplyMessageTextBox" runat="server"
                                                 TextMode="MultiLine"
                                                 Rows="10"
                                                 Columns="40" 
                                                 Text='<%# Bind("ReplyMessage", "{0}") %>'
                                                 Enabled='<%# System.Convert.IsDBNull(Eval("DateSent"))%>' />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:RequiredFieldValidator ID="ReplyMessageTextBoxRequiredFieldValidator" runat="server" 
                                                                ErrorMessage="Reply Message is a Required Field"
                                                                ControlToValidate="ReplyMessageTextBox">
                                    </asp:RequiredFieldValidator>
                                    <asp:Label ID="ErrorMessage" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td>Date Sent:</td>
                                <td align="left">
                                    <asp:Label ID="DateSentLabel" runat="server" 
                                               Text='<%# Bind("DateSent") %>' />
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2">
                                    <asp:Label ID="ReplySentLabel" runat="server" 
                                               Text="Reply sent." 
                                               ForeColor="Green"
                                               Visible="false"/>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:Button ID="ReplyLinkButton" runat="server" 
                                    CommandArgument='<%# Eval("ID", "{0}") %>' 
                                    Visible='<%# Eval("DateSent") == System.DBNull.Value%>'
                                    Text="Send Reply"
                                    OnCommand="SendReply" />
                        <asp:HyperLink ID="SampleReplyHyperLink" runat="server"
                                       Text="Sample Reply"
                                       NavigateUrl="SampleEmail.aspx"
                                       Target="_blank" />
                    </FooterTemplate>
                </asp:FormView>
            </td>
        </tr>
    </table>

    <asp:ObjectDataSource ID="EmailsODS" runat="server" 
                          OldValuesParameterFormatString="original_{0}" 
                          SelectMethod="GetEmails" 
                          TypeName="eStoreAdminBLL.EmailBLL">
    </asp:ObjectDataSource>
    
    <asp:ObjectDataSource ID="EmailODS" runat="server" 
                          OldValuesParameterFormatString="original_{0}" 
                          SelectMethod="GetEmailById" 
                          TypeName="eStoreAdminBLL.EmailBLL">
        <SelectParameters>
            <asp:ControlParameter ControlID="EmailGridView" 
                                  Name="ID" 
                                  PropertyName="SelectedValue" 
                                  Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>