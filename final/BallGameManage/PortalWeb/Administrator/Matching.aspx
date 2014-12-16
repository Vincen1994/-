<%@ Page Title="" Language="C#" MasterPageFile="~/Administrator/AdminMasterPage.master"
    AutoEventWireup="true" CodeBehind="Matching.aspx.cs" Inherits="BallGameManage.Administrator.Matching" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="~/styles/indexcss.css" rel="stylesheet" type="text/css" />
    <script src="../scripts/jquery-1.8.2.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="contentcontainer">
        <div class="headings altheading">
            <h2>
                比赛进行时
            </h2>
        </div>
        <div class="contentcontainer mei left">
            <div class="headings alt">
                <h2>
                    <asp:Label ID="lab_zhu" runat="server" Text="Label"></asp:Label>
                </h2>
            </div>
            <div class="contentbox">
                <div style="padding: 20px 0px 0px 20px;">
                    <asp:Button ID="btn_1" runat="server" CssClass="btnalt" Text="+1分" 
                        onclick="btn_1_Click" />&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btn_2" runat="server" CssClass="btnalt" Text="+2分" 
                        onclick="btn_2_Click" />&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btn_3" runat="server" CssClass="btnalt" Text="+3分" 
                        onclick="btn_3_Click" />
                </div>
                <div style="padding: 20px 0px 0px 20px;">
                    <h3>
                        总分:</h3>
                    <asp:TextBox ID="tbx_Fraction1" runat="server" CssClass="inputbox"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="contentcontainer jie right">
            <div class="headings">
                <h2 class="left">
                    <asp:Label ID="lab_ke" runat="server" Text="Label"></asp:Label></h2>
            </div>
            <div class="contentbox">
                <div style="padding: 20px 0px 0px 20px;">
                    <asp:Button ID="btn_11" runat="server" CssClass="btnalt" Text="+1分" 
                        onclick="btn_11_Click" />&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btn_22" runat="server" CssClass="btnalt" Text="+2分" 
                        onclick="btn_22_Click" />&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btn_33" runat="server" CssClass="btnalt" Text="+3分" 
                        onclick="btn_33_Click" /></div>
                <div style="padding: 20px 0px 0px 20px;">
                    <h3>
                        总分:</h3>
                    <asp:TextBox ID="tbx_Fraction2" runat="server" CssClass="inputbox"></asp:TextBox></div>
            </div>
        </div>
        <div style="clear: both;">
        </div>
        <div  style="width: 100%; text-align: center;">
            <asp:Button ID="btn_Submit" runat="server" CssClass="btn" Text="结束比赛" 
                onclick="btn_Submit_Click" />
        </div>
    </div>
</asp:Content>
