<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListFriends.aspx.cs" Inherits="FaceLessBook.WebForms.Member.ListFriends" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1><%: ViewModel.ViewTitle %></h1>
    <asp:HiddenField ID="sortedHiddenField" runat="server" />

    <asp:Label ID="lblError" runat="server" Text="" ForeColor="Red"></asp:Label>

    <asp:Repeater ID="friendsRepeater" runat="server">
        <HeaderTemplate>
            <table>
            <tr>
                <td></td>
                <td>
                    <asp:LinkButton ID="nameSort" runat="server" Text="Name" OnClick="Sort_Click" />
                </td>
            </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td> 
                <a id="A1" href='<%# "~/member/FriendDetail.aspx?fid=" + Eval("Id") %>' runat="server">View Friend</a></td>
                <td><%# Eval("FullName") %></td>
            </tr>
        </ItemTemplate> 
        <FooterTemplate> </table> </FooterTemplate>
    </asp:Repeater>
</asp:Content>
