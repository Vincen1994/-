<%@ Page Title="" Language="C#" MasterPageFile="~/Main/MasterPage.master" AutoEventWireup="true" CodeBehind="NewList.aspx.cs" Inherits="BallGameManage.Main.NewList" %>
<%@ Register TagPrefix="uc" TagName="pageList" Src="~/UserControls/PageList.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link rel="Stylesheet" href="styles/indexcss.css" />
    <style type="text/css">
        #listMenu
        {
            margin: 0px;
        }
        #listMenu li
        {
            border-bottom-style: dashed;
            border-bottom-width: 1px;
            font-size: 12px;
        }
        #listMenu li
        {
            padding: 5px;
        }
        #listMenu li span
        {
            float: right;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="content-t-l" style="float: left; width: 100%;">
        <h1 class="content-title">
            <strong>
                公告</strong>
        </h1>
        <div class="div_list">
            <table width="100%" cellpadding="0" cellspacing="0" style="border: 0px;">
                <tbody>
                    <asp:Repeater ID="Repeater" runat="server">
                        <ItemTemplate>
                            <tr style="border-bottom: 1px dashed black; margin-top: 10px;">
                                <td align="left" style="border-bottom: 1px dashed black;">
                                    <a href='NewListDetail.aspx?id=<%#Eval("sid") %> %>'>
                                        <%# Eval("title")%></a>
                                </td>
                                <td align="right" style="border-bottom: 1px dashed black;">
                                    [<%# Eval("CreateTime")%>]
                                </td>
                            </tr>
                        </ItemTemplate>
                        <AlternatingItemTemplate>
                            <tr class="alt" style="border-bottom: 1px dashed black; margin-top: 10px;">
                                <td align="left" style="border-bottom: 1px dashed black;">
                                    <a href='NewListDetail.aspx?id=<%#Eval("sid") %> %>'>
                                        <%# Eval("title")%></a>
                                </td>
                                <td align="right" style="border-bottom: 1px dashed black;">
                                    [<%# Eval("CreateTime")%>]
                                </td>
                            </tr>
                        </AlternatingItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </div>
        <div class="bulkactions">
            <uc:pageList ID="pagelist" runat="server" Onpagelistchang="pagelist_chang" />
        </div>
    </div>
</asp:Content>
