<%@ Page Title="" Language="C#" MasterPageFile="~/Administrator/AdminMasterPage.master" AutoEventWireup="true" CodeBehind="UpdateAdmin.aspx.cs" Inherits="BallGameManage.Administrator.UpdateAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="contentcontainer med left">
        <div class="headings alt">
            <h2>
                修改管理员信息</h2>
        </div>
        <div class="contentbox">
            <p>
                <asp:TextBox ID="adminID" runat="server" CssClass="inputbox" Visible="false" Enabled="False"></asp:TextBox>
                <label for="textfield">
                    <strong>管理员帐号:</strong></label>
                <asp:TextBox ID="adminName" runat="server" CssClass="inputbox" Enabled="false"></asp:TextBox><br />
                <asp:RequiredFieldValidator ID="rfv_adminName" runat="server" ErrorMessage="用户名不能为空"
                    ControlToValidate="adminName" ForeColor="Red" ValidationGroup="Verification"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="rev_adminName" runat="server" ControlToValidate="adminName"
                    ErrorMessage="管理员帐号必须是以字母为开头" ForeColor="Red" ValidationExpression="^[A-Za-z][A-Za-z0-9]*$"
                    ValidationGroup="Verification"></asp:RegularExpressionValidator>
                <br />
                <label for="textfield">
                    <strong>管理员密码:</strong></label>
                <asp:TextBox ID="adminPwd" runat="server" CssClass="inputbox" TextMode="Password"></asp:TextBox><br />
                <asp:RegularExpressionValidator ID="rev_adminPWD" runat="server" ControlToValidate="adminPwd"
                    ErrorMessage="密码必须是6-16位的字母或数字" ForeColor="Red" ValidationExpression="^[a-zA-Z0-9]{6,16}$"
                    ValidationGroup="Verification"></asp:RegularExpressionValidator>
                <br />
                <label for="textfield">
                    <strong>真实姓名:</strong></label>
                <asp:TextBox ID="realName" runat="server" CssClass="inputbox"></asp:TextBox><br />
                <asp:RequiredFieldValidator ID="rfv_realName" runat="server" ErrorMessage="真实姓名不能为空"
                    ControlToValidate="realName" ForeColor="Red" ValidationGroup="Verification"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="rev_RealName" runat="server" ControlToValidate="realName"
                    ErrorMessage="姓名必须是2到4个汉字" ForeColor="Red" ValidationExpression="[\u4e00-\u9fa5]{2,4}"
                    ValidationGroup="Verification"></asp:RegularExpressionValidator>
                <br />
            </p>
            <asp:Button ID="Submit" runat="server" Text="确定修改" CssClass="btn" OnClick="Submit_Click"
                ValidationGroup="Verification" />&nbsp;&nbsp;
            <asp:Button ID="Reset" runat="server" Text="重置" CssClass="btn" OnClick="Reset_Click" />
        </div>
    </div>
</asp:Content>
