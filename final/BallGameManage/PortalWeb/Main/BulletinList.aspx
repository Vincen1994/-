<%@ Page Title="" Language="C#" MasterPageFile="~/Main/MasterPage.master" AutoEventWireup="true" CodeBehind="BulletinList.aspx.cs" Inherits="BallGameManage.Main.BulletinList" %>
<%@ Register TagPrefix="uc" TagName="pageList" Src="~/UserControls/PageList.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
    .style1
    {
        height: 18px;
    }
</style>
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
                	<strong><asp:Label ID="HeadTitle" runat="server" Text=""  ></asp:Label></strong>
                </h1>
                <div class="div_list">
                  <table width="100%" cellpadding="0" cellspacing="0" style=" border:0px;">
                <tbody>
                    <asp:Repeater ID="Repeater" runat="server">
                        <ItemTemplate>
                            <tr style="border-bottom:1px dashed black; margin-top:10px;">
                                <td align="left" style="border-bottom:1px dashed black;">
                                <a href='BulletinDetail.aspx?id=<%#Eval("sid") %>'><%# Eval("title")%></a>
                                </td>
                                <td align="right" style="border-bottom:1px dashed black;">
                                    [<%# Eval("CreateTime")%>]
                                </td>
                            </tr>
                        </ItemTemplate>
                        <AlternatingItemTemplate>
                            <tr class="alt"  style="border-bottom:1px dashed black;margin-top:10px;">
                                <td align="left" style="border-bottom:1px dashed black;">
                                  <a href='BulletinDetail.aspx?id=<%#Eval("sid") %>'><%# Eval("title")%></a>
                                </td>
                                 <td align="right" style="border-bottom:1px dashed black;">
                                    [<%# Eval("CreateTime")%>]
                                </td>
                            </tr>
                        </AlternatingItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
            </div>
            <div class="bulkactions">
                    <uc:pagelist ID="pagelist" runat="server" Onpagelistchang="pagelist_chang" />
                </div>
            </div>
</asp:Content>
