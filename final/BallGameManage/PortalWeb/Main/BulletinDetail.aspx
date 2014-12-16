<%@ Page Title="" Language="C#" MasterPageFile="~/Main/MasterPage.master" AutoEventWireup="true" CodeBehind="BulletinDetail.aspx.cs" Inherits="BallGameManage.Main.BulletinDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
     <div class="content-t-l" style="float:left; width:232px; height:auto;">
            	<h1 class="content-title">
                	<strong>通知公告</strong>
                </h1>
                <ul class="content-t-l-list">
                	<li><a href="BulletinList.aspx" title="会务信息">通知公告</a></li>
                </ul>
            </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="content-t-l" style="float:left; width:100%;">
            	<h1 class="content-title">
                	<strong><asp:Label ID="HeadTitle" runat="server" Text=""></asp:Label></strong>
                </h1>
                  <div style=" text-align:center">
    <div class="div_bigtitle">
        <asp:Label ID="title" runat="server" Text=""></asp:Label></div>
        <div class="div_Ttiletime">
        发布时间：<asp:Label ID="ReleaseDate" runat="server" Text=""></asp:Label>
            <br />
    </div>
            </div>
             <div style=" width:96%; margin-left:5px;">
             <asp:Label ID="Content" runat="server" Text=""></asp:Label>
        </div>
        <div style=" margin-bottom:0px; text-align:center;"><a href="javascript:history.go(-1);">[返回]</a></div>
        </div>
</asp:Content>
