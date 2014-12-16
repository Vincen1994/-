<%@ Page Title="" Language="C#" MasterPageFile="~/Main/MasterPage.master" AutoEventWireup="true" CodeBehind="Economylist.aspx.cs" Inherits="BallGameManage.Main.Economylist" %>
<%@ Register TagPrefix="uc" TagName="pageList" Src="~/UserControls/PageList.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="content-t-l" style="float:left; width:100%;">
            	<h1 class="content-title">
                	<strong>赛事</strong>
                </h1>
                <div class="div_list">
                  <table width="100%" cellpadding="0" cellspacing="0" style=" border:0px;">
                <tbody>
                    <asp:Repeater ID="Repeater" runat="server" >
                        <ItemTemplate>
                            <tr style="border-bottom:1px dashed black; margin-top:10px;">
                                <td align="left" style="border-bottom:1px dashed black;">
                                 <a href="Economydetail.aspx?id=<%# Eval("SID")%>" title=""> <%# Eval("HomeCourtName")%> 对阵  <%# Eval("awayName")%>
                                           </a>

                                </td>
                                <td align="right" style="border-bottom:1px dashed black;">
                                    [<%# Eval("StartTime")%>]
                                </td>
                            </tr>
                        </ItemTemplate>
                        <AlternatingItemTemplate>
                            <tr class="alt"  style="border-bottom:1px dashed black;margin-top:10px;">
                                <td align="left" style="border-bottom:1px dashed black;">
                                 <a href="Economydetail.aspx?id=<%# Eval("SID")%>" title=""> <%# Eval("HomeCourtName")%> 对阵  <%# Eval("awayName")%>
                                           </a>

                                </td>
                                <td align="right" style="border-bottom:1px dashed black;">
                                    [<%# Eval("StartTime")%>]
                                </td>
                            </tr>
                        </AlternatingItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
            </div>
            <div class="bulkactions">
                    <uc:pageList ID="pagelist" runat="server"  Onpagelistchang="pagelist_chang"/>
                </div>
            </div>
</asp:Content>
