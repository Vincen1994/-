<%@ Page Title="" Language="C#" MasterPageFile="~/Administrator/AdminMasterPage.master" AutoEventWireup="true" CodeBehind="addAdmin.aspx.cs" Inherits="BallGameManage.Administrator.addAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="contentcontainer">
        <div class="headings altheading">
            <h2>
                添加新的管理员</h2>
        </div>
        <div class="contentbox">
            <p>
                <label for="textfield">
                    <strong>管理员帐号:</strong></label>
                <asp:TextBox ID="adminName" runat="server" CssClass="inputbox"></asp:TextBox><br />
                <asp:RequiredFieldValidator ID="rfv_name" runat="server" 
                    ErrorMessage="帐号不能为空" ControlToValidate="adminName" ForeColor="Red" 
                    ValidationGroup="Verification"></asp:RequiredFieldValidator>
                <label for="textfield">
                    <strong>管理员密码:</strong></label>
                <asp:TextBox ID="adminPwd" runat="server" CssClass="inputbox" 
                    TextMode="Password"></asp:TextBox><br />
                    <asp:RequiredFieldValidator ID="rfv_adminPWD" runat="server" 
                    ErrorMessage="密码不能为空" ControlToValidate="adminPwd" ForeColor="Red" 
                    ValidationGroup="Verification"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="rev_adminPWD" runat="server" 
                    ErrorMessage="密码必须是6-16位的字母或数字" ControlToValidate="adminPwd" ForeColor="Red" 
                    ValidationExpression="^[a-zA-Z0-9]{6,16}$" ValidationGroup="Verification"></asp:RegularExpressionValidator>
                <label for="textfield">
                    <strong>确认密码:</strong></label>
                <asp:TextBox ID="confirmPwd" runat="server" CssClass="inputbox" 
                    TextMode="Password"></asp:TextBox><br />
                    <asp:RequiredFieldValidator ID="rfv_confirmPwd" runat="server" 
                    ErrorMessage="确认密码不能为空" ControlToValidate="confirmPwd" ForeColor="Red" 
                    ValidationGroup="Verification"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="cv_confirmPwd" runat="server" 
                    ControlToCompare="adminPwd" ErrorMessage="确认密码必须跟密码一致" ForeColor="Red" 
                    ValidationGroup="Verification" ControlToValidate="confirmPwd"></asp:CompareValidator>
                     <label for="textfield">
                    <strong>真实姓名:</strong></label>
                <asp:TextBox ID="realName" runat="server" CssClass="inputbox"></asp:TextBox><br />
                <asp:RequiredFieldValidator ID="rfv_realName" runat="server" 
                    ErrorMessage="真实姓名不能为空" ControlToValidate="realName" ForeColor="Red" 
                    ValidationGroup="Verification"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="rev_realName" runat="server" 
                    ErrorMessage="真实姓名必须是2-4的汉字" ControlToValidate="realName" ForeColor="Red" 
                    ValidationExpression="[\u4e00-\u9fa5]{2,4}" ValidationGroup="Verification"></asp:RegularExpressionValidator>
            </p>
            <asp:Button ID="Submit" runat="server" Text="确定添加" CssClass="btn" 
                OnClick="Submit_Click" ValidationGroup="Verification" />&nbsp;&nbsp;
            <asp:Button ID="Reset" runat="server" Text="重置" CssClass="btn" OnClick="Reset_Click" />
        </div>
    </div>
</asp:Content>
