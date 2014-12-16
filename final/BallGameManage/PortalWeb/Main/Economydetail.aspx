<%@ Page Title="" Language="C#" MasterPageFile="~/Main/MasterPage.master" AutoEventWireup="true"
    CodeBehind="Economydetail.aspx.cs" Inherits="BallGameManage.Main.Economydetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="content-t-l" style="float: left; width: 100%;">
        <h1 class="content-title">
            <strong>比赛结果</strong>
        </h1>
        <div style="text-align: center">
            <div class="div_bigtitle">
                <asp:Label ID="title" runat="server" Text=""></asp:Label></div>
            <div class="div_Ttiletime">
                分数：<asp:Label ID="lab_one" runat="server" Text=""></asp:Label>--分数：<asp:Label ID="lab_two"
                    runat="server" Text=""></asp:Label>
                <br />
            </div>
            <div class="div_Ttiletime">
                开始时间：<asp:Label ID="ReleaseDate" runat="server" Text=""></asp:Label>--结束时间：<asp:Label
                    ID="ReleaseDate2" runat="server" Text=""></asp:Label>
                <br />
            </div>
            <div class="div_Ttiletime">
                <asp:Label ID="lab_zt" runat="server" Text=""></asp:Label>
                <br />
            </div>
        </div>
        <div style="margin-bottom: 0px; text-align: center;">
            <a href="javascript:history.go(-1);">[返回]</a></div>
    </div>
</asp:Content>
