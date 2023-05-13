<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Login.ascx.cs" Inherits="ThreeClass.Login" %>
    <asp:Label ID="Label1" runat="server" Text="用户名"></asp:Label>
    <asp:TextBox ID="UserName" runat="server"></asp:TextBox>
   <br /> <asp:Label ID="Label2" runat="server" Text="密码"></asp:Label>
    <asp:TextBox ID="Password" TextMode="Password" runat="server"></asp:TextBox>
   <br /> <asp:Button ID="Button1" runat="server" Text="登录" OnClick="Button1_Click" />