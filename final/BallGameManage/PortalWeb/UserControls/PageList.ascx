<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PageList.ascx.cs" Inherits="BallGameManage.UserControls.PageList" %>
<style type="text/css" >
    .page_nav1,.page_nav2,.page_nav3,.page_nav4,.page_nav5{
	border:none;
	cursor:pointer;
	width:55px;
	height:20px;
}
.page_nav1{
	background:url(../img/page_nav_03.gif) no-repeat;
	width:20px;
}
.page_nav2{
	background:url(../img/page_nav_05.gif) no-repeat;
}
.page_nav3{
	background:url(../img/page_nav_07.gif) no-repeat;
}
.page_nav4{
	background:url(../img/page_nav_09.gif) no-repeat;
}
.page_nav5{
	background:url(../img/page_nav_11.gif) no-repeat;
}
</style>
<div style="vertical-align: middle; width:100%;" >
    <div id="pagelistleft" style=" width:30%; float:left; padding-top:5px;">
        第<asp:Label ID="LbCurrentPage" runat="server"
            Text="Label">1</asp:Label>页/共<asp:Label ID="Lbpagecount" runat="server"
            Text="Label">1</asp:Label>页 | 共<asp:Label ID="LbRecordCount" runat="server"
            Text="Label">0</asp:Label> 条记录
    </div>
    <div id="pagelistright" style=" width:69%; float:right; text-align:right;">
        每页<asp:DropDownList ID="DDLpageindex" runat="server" OnSelectedIndexChanged="DDLpageindex_SelectedIndexChanged"
            AutoPostBack="True">
            <asp:ListItem Value="10">10</asp:ListItem>
            <asp:ListItem Value="15">15</asp:ListItem>
            <asp:ListItem Value="20">20</asp:ListItem>
            <asp:ListItem Value="50">50</asp:ListItem>
            <asp:ListItem Value="100">100</asp:ListItem>
            <asp:ListItem Value="50000000">全部</asp:ListItem>
        </asp:DropDownList>
        条数据&nbsp;第<asp:TextBox ID="TBPage" runat="server" Width="30px"></asp:TextBox>
        页
        <asp:Button ID="BtnGo" runat="server" CssClass="page_nav1" Text="" OnClick="BtnGo_Click"
            Enabled="False" />
        &nbsp;
        <asp:Button ID="BtnPageTop" runat="server" OnClick="BtnPageTop_Click" Enabled="False"
            Text=" " CssClass="page_nav2" />
        &nbsp;<asp:Button ID="BtnPageUp" OnClick="BtnPageUp_Click" runat="server" Enabled="False"
            Text=" " CssClass="page_nav3" />
        &nbsp;<asp:Button ID="BtnPageDown" OnClick="BtnPageDown_Click" runat="server" Enabled="False"
            Text=" " CssClass="page_nav4" />
        &nbsp;<asp:Button ID="BtnPageLast" OnClick="BtnPageLast_Click" runat="server" Enabled="False"
            Text=" " CssClass="page_nav5" />
        <br />
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TBPage"
            ErrorMessage="您输入的页数信息不正确" ValidationExpression="[1-9][0-9]{0,}" ForeColor="Red"></asp:RegularExpressionValidator>
    </div>
</div>