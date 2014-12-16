<%@ Page Title="" Language="C#" MasterPageFile="~/Main/MasterPage.master" AutoEventWireup="true" CodeBehind="NewListDetail.aspx.cs" Inherits="WebApplication1.Main.NewListDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <div class="content-t-l" style="float: left; width: 232px;">
        <h1 class="content-title">
            <strong>商会简介</strong>
        </h1>
        <ul class="content-t-l-list">
            <li><a href="NewsDetail.aspx?type=zc" title="章程">章程</a></li>
            <li><a href="NewsDetail.aspx?type=jj" title="简介">简介</a></li>
            <li><a href="NewList.aspx?type=hyjj" title="行业简介">行业简介</a></li>
            <li><a href="NewsDetail.aspx?type=jgnsjg" title="机关内设机构">机关内设机构</a></li>
            <li><a href="NewList.aspx?type=ldcy" title="领导成员">领导成员</a></li>
        </ul>
    </div>
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
