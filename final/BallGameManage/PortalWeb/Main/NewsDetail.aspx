<%@ Page Title="" Language="C#" MasterPageFile="~/Main/MasterPage.master" AutoEventWireup="true" CodeBehind="NewsDetail.aspx.cs" Inherits="BallGameManage.NewsDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="content-t-l" style="float: left; width: 100%; height:auto;">
        <h1 class="content-title">
            <strong>
                <asp:Label ID="HeadTitle" runat="server" Text=""></asp:Label></strong>
        </h1>
        <div style="text-align: center">
            <div  class="div_bigtitle">
                <asp:Label ID="title" runat="server" Text=""></asp:Label>
            </div>
            <div class="div_Ttiletime">
                发布时间：<asp:Label ID="ReleaseDate" runat="server" Text=""></asp:Label>
            </div>
        </div>
        <div style=" width:96%; margin-left:5px;">
            <asp:Label ID="Content" runat="server" Text=""></asp:Label>
        </div>
        <div style=" margin-bottom:0px; text-align:center;"><a href="javascript:history.go(-1);">[返回]</a></div>
    </div>
</asp:Content>
