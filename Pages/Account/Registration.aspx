﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Registration.aspx.cs" Inherits="Pages_Account_Registration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            width: 348px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table>
        <tr>
            <td>Ім'я:</td>
            <td class="auto-style1">
                <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Прізвище:</td>
            <td class="auto-style1">
                <asp:TextBox ID="txtSurname" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtSurname" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>E-mail:</td>
            <td class="auto-style1">
                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtEmail" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Пароль:</td>
            <td class="auto-style1">
                <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPassword" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Повторіть пароль:</td>
            <td class="auto-style1">
                <asp:TextBox ID="txtConfirmPass" runat="server"></asp:TextBox>
                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtConfirmPass" ControlToValidate="txtPassword" ErrorMessage="Паролі не співпадають" ForeColor="Red"></asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td>Телефон:</td>
            <td class="auto-style1">
                <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
                <asp:regularexpressionvalidator runat="server" errormessage="Введіть номер у такому форматі: 0683647235" ControlToValidate="txtPhone" ForeColor="Red" ValidationExpression="\d{10}"></asp:regularexpressionvalidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnRegister" runat="server" Text="Зареєструватися" OnClick="btnRegister_Click" />
                <br />
                <br />
                <asp:Label ID="lblResult" runat="server" Text=""></asp:Label>
            </td>
        </tr>
    </table>

</asp:Content>
