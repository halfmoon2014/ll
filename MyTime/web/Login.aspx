<%@ Page Title="登录" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Login.aspx.cs" Inherits="Account_Login" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        登录
    </h2>
    <div class="accountInfo">
        <fieldset class="login">
            <legend>帐户信息</legend>
            <table>
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server">用户名:</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="UserName" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server">密码:</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </fieldset>
        <p class="submitButton">
            <asp:Button Text="login" runat="server" OnClick="LoginButton_Click" />
        </p>
    </div>
</asp:Content>
