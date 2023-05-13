<%@ Page Title="" Language="C#" MasterPageFile="~/MyMasterPage.Master" AutoEventWireup="true" CodeBehind="newuser.aspx.cs" Inherits="PetShop.newuser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%-- <asp:Label runat="server" Text="注册"></asp:Label><br />
    <asp:Label runat="server" Text="用户名:"></asp:Label>
    <asp:TextBox runat="server"></asp:TextBox><br />
    <asp:Label runat="server" Text="邮箱:"></asp:Label>
    <asp:TextBox runat="server"></asp:TextBox><br />
    <asp:Label runat="server" Text="密码:"></asp:Label>
    <asp:TextBox runat="server"></asp:TextBox><br />
    <asp:Label runat="server" Text="确认密码:"></asp:Label>
    <asp:TextBox runat="server"></asp:TextBox><br />
    <asp:Label runat="server" Text="立即注册"></asp:Label><br />
    <asp:HyperLink runat="server">立刻登录</asp:HyperLink>--%>
       <table style="border-collapse: collapse;">
    <tr>
      <td class="tdcenter" colspan="2">注册</td>
    </tr>
    <tr>
      <td class="auto-style1">用户名:</td>
      <td>
        <asp:TextBox ID="txtName" runat="server"></asp:TextBox></td>
      <td>
        <asp:RequiredFieldValidator ControlToValidate="txtName" Display="Dynamic" ForeColor="Red" ID="rfvName" runat="server" ErrorMessage="必填"></asp:RequiredFieldValidator>
      </td>
    </tr>
    <tr>
      <td class="auto-style1">邮箱:</td>
      <td>
        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox></td>
      <td>
        <asp:RequiredFieldValidator ControlToValidate="txtEmail" Display="Dynamic" ForeColor="Red" ID="rfvEmail" runat="server" ErrorMessage="必填"></asp:RequiredFieldValidator>
      </td>
    </tr>
    <tr>
      <td class="tdright" colspan="2">
        <asp:RegularExpressionValidator ID="revEmail" runat="server" ErrorMessage="邮箱格式不正确！" ControlToValidate="txtEmail" Display="Dynamic" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">
        </asp:RegularExpressionValidator>
      </td>
    </tr>
    <tr>
      <td class="auto-style1">密码:</td>
      <td>
        <asp:TextBox ID="txtPwd" runat="server" TextMode="Password"></asp:TextBox></td>
      <td>
        <asp:RequiredFieldValidator ControlToValidate="txtPwd" Display="Dynamic" ForeColor="Red" ID="rfvPwd" runat="server" ErrorMessage="必填"></asp:RequiredFieldValidator>
      </td>
    </tr>
    <tr>
      <td class="auto-style1">确认密码:</td>
      <td>
        <asp:TextBox ID="txtPwdAgain" runat="server" TextMode="Password"></asp:TextBox></td>
      <td>
        <asp:RequiredFieldValidator ControlToValidate="txtPwdAgain" Display="Dynamic" ForeColor="Red" ID="rfvPwdAgain" runat="server" ErrorMessage="必填"></asp:RequiredFieldValidator>
      </td>
    </tr>
    <tr>
      <td class="tdright" colspan="2">
        <asp:CompareValidator ControlToValidate="txtPwdAgain" ControlToCompare="txtPwd" Display="Dynamic" ForeColor="Red" ID="cvPwd" runat="server" ErrorMessage="2次密码不一致"></asp:CompareValidator>
      </td>
    </tr>
    <tr>
      <td class="tdright" colspan="2">
        <asp:Button ID="btnReg" runat="server" Text="立即注册" OnClick="btnReg_Click"  />
      </td>
    </tr>
    <tr>
      <td class="auto-style2"><a href="LoginPage.aspx">我要登录</a></td>
      <td>
        <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label></td>
    </tr>
  </table>




</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
</asp:Content>
