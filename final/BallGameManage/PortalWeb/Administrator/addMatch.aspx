<%@ Page Title="" Language="C#" MasterPageFile="~/Administrator/AdminMasterPage.master"
    AutoEventWireup="true" CodeBehind="addMatch.aspx.cs" Inherits="BallGameManage.Administrator.addMatch" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" charset="utf-8" src="../scripts/My97DatePicker/WdatePicker.js"></script>
    <script src="../scripts/dateUtil.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="contentcontainer">
        <div class="headings altheading">
            <h2>
                <asp:Label ID="titleName" runat="server" Text=""></asp:Label>比赛</h2>
        </div>
        <div class="contentbox">
            <p>
                <label for="textfield">
                    <strong>赛程名:</strong></label>
                <input id="tbx_saiName" runat="server" class="inputbox" onclick="selectdddy()" /><br />
                <label for="textfield">
                    <strong>主队:</strong></label>
                <asp:DropDownList ID="ddl_zhudui" runat="server" CssClass="inputbox">
                </asp:DropDownList>
                <label for="textfield">
                    <strong>客队:</strong></label>
                <asp:DropDownList ID="ddl_kedui" runat="server" CssClass="inputbox">
                </asp:DropDownList>
                <label for="textfield">
                    <strong>开始时间:</strong></label>
                <input id="CreateTime" runat="server" class="inputbox" onclick="selectddy()" /><br />
                <asp:RequiredFieldValidator ID="rfv_CreateTime" runat="server" ErrorMessage="开始时间不能为空"
                    ControlToValidate="CreateTime" ForeColor="Red" ValidationGroup="Verification"></asp:RequiredFieldValidator>
            </p>
            <asp:Button ID="Submit" runat="server" Text="确定" CssClass="btn" ValidationGroup="Verification"
                OnClick="Submit_Click" />&nbsp;&nbsp;
        </div>
    </div>
</asp:Content>
