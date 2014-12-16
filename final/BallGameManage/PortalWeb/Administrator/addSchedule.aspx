<%@ Page Title="" Language="C#" MasterPageFile="~/Administrator/AdminMasterPage.master" AutoEventWireup="true" CodeBehind="addSchedule.aspx.cs" Inherits="BallGameManage.Administrator.addSchedule" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="contentcontainer">
        <div class="headings altheading">
            <h2>
        <asp:Label ID="lab_type" runat="server" Text=""></asp:Label>赛程</h2>
        </div>
        <div class="contentbox">
            <p>
                <label for="textfield">
                    <strong>赛程名称:</strong></label>
                <asp:TextBox ID="tbx_Name" runat="server" CssClass="inputbox"></asp:TextBox><br />
                <asp:RequiredFieldValidator ID="rfv_name" runat="server" 
                    ErrorMessage="赛程名称不能为空" ControlToValidate="tbx_Name" ForeColor="Red" 
                    ValidationGroup="Verification"></asp:RequiredFieldValidator>
            </p>
            <asp:Button ID="Submit" runat="server" Text="确定添加" CssClass="btn" 
                OnClick="Submit_Click" ValidationGroup="Verification" />&nbsp;&nbsp;
            <asp:Button ID="Reset" runat="server" Text="重置" CssClass="btn" OnClick="Reset_Click" />
        </div>
    </div>
</asp:Content>
