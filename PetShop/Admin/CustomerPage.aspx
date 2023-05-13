﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MyMasterPage.Master" AutoEventWireup="true" CodeBehind="CustomerPage.aspx.cs" Inherits="PetShop.Admin.CustomerPage" %>

<%@ Register Src="~/Admin/LeftMenu.ascx" TagPrefix="uc1" TagName="LeftMenu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:LeftMenu runat="server" ID="LeftMenu" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <input id="TxtSearch" runat="server" placeholder="输入用户名或者密码" type="text"/>
    <asp:Button ID="ButSearch" runat="server" onclick="ButSearch_Click" Text="查询" CausesValidation="False"/><br/>
    <asp:GridView ID="GridView1" Width="100%" runat="server" AutoGenerateColumns="False" AutoGenerateDeleteButton="True" AutoGenerateEditButton="True" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowDataBound="GridView1_RowDataBound" PageSize="2">
        <Columns>
            <asp:BoundField HeaderText="用户ID" ReadOnly="True"/>
            <asp:BoundField DataField="Name" HeaderText="姓名" />
            <asp:BoundField DataField="Password" HeaderText="密码" />
            <asp:BoundField DataField="Email" HeaderText="邮箱" />
        </Columns>
</asp:GridView>
          <table style="border-collapse: collapse;">
    <tr>
      <td class="tdcenter" colspan="2">添加新用户</td>
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
        <asp:Button ID="btnReg" runat="server" Text="添加" OnClick="btnReg_Click" />
      </td>
    </tr>
    <tr>
      <td>
        <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label></td>
    </tr>
    </table>

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
</asp:Content>
