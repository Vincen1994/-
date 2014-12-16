<%@ Page Title="" Language="C#" MasterPageFile="~/Administrator/AdminMasterPage.master" AutoEventWireup="true" CodeBehind="MatchList.aspx.cs" Inherits="BallGameManage.Administrator.MatchList" %>
<%@ Register TagPrefix="uc" TagName="pageList" Src="~/UserControls/PageList.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="~/styles/indexcss.css" rel="stylesheet" type="text/css" />  
<script src="../scripts/jquery-1.8.2.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="contentcontainer">
        <div class="headings altheading">
            <h2>
                比赛列表
                </h2>
        </div>
        <div class="contentbox">
        <asp:Button  ID="btn_addLike" runat="server" Text="添加比赛" CssClass="btn" 
                onclick="btn_addLike_Click"  />
            <table width="100%">
                <thead>
                    <tr>
                        <th>
                            主队
                        </th>
                        <th>
                           主队分数
                        </th>
                        <th>
                            客队
                        </th>
                        <th>
                          客队分数
                        </th>
                        <th>
                            比赛开始时间
                        </th>
                        <th>
                           比赛结束时间
                        </th>
                        <th>
                            状态
                        </th>
                        <th>
                            操作
                        </th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="Repeater" runat="server"   onitemcommand="Repeater_ItemCommand_nimei">
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <%# Eval("HomeCourtName")%>
                                </td>
                                <td>
                                    <%# Eval("HomeCourt_Fraction")%>
                                </td>
                                 <td>
                                    <%# Eval("awayName")%>
                                </td>
                                <td>
                                    <%# Eval("away_Fraction")%>
                                </td>
                                 <td>
                                    <%# Eval("StartTime")%>
                                </td>
                                 <td>
                                    <%# Eval("EndTime")%>
                                </td>
                                 <td>
                                    <%# Eval("hh_State")%>
                                </td>
                                <td>
                                 <asp:ImageButton ID="ball" runat="server"  CommandArgument='<%# Eval("sid") %>'
                                         ImageUrl="../img/icons/sport_basketball.png" CommandName="ball" ToolTip="比赛" />

                                     <asp:ImageButton ID="Edit" runat="server"  CommandArgument='<%# Eval("sid") %>'
                                         ImageUrl="../img/icons/icon_edit.png" CommandName="Edit" ToolTip="修改比赛" />
                                    <asp:ImageButton ID="Delete" runat="server" CommandArgument='<%# Eval("sid") %>' ToolTip="删除比赛"
                                        ImageUrl="../img/icons/icon_delete.png" CommandName="Delete"  />
                                </td>
                            </tr>
                        </ItemTemplate>
                        <AlternatingItemTemplate>
                            <tr class="alt">
                                 <td>
                                    <%# Eval("HomeCourtName")%>
                                </td>
                                <td>
                                    <%# Eval("HomeCourt_Fraction")%>
                                </td>
                                 <td>
                                    <%# Eval("awayName")%>
                                </td>
                                <td>
                                    <%# Eval("away_Fraction")%>
                                </td>
                                 <td>
                                    <%# Eval("StartTime")%>
                                </td>
                                 <td>
                                    <%# Eval("EndTime")%>
                                </td>
                                 <td>
                                    <%# Eval("hh_State")%>
                                </td>
                                <td>
                                 <asp:ImageButton ID="ball" runat="server"  CommandArgument='<%# Eval("sid") %>'
                                         ImageUrl="../img/icons/sport_basketball.png" CommandName="ball" ToolTip="比赛" />

                                    <asp:ImageButton ID="Edit" runat="server"  CommandArgument='<%# Eval("sid") %>'
                                         ImageUrl="../img/icons/icon_edit.png" CommandName="Edit" ToolTip="修改比赛" />
                                      <asp:ImageButton ID="Delete" runat="server" CommandArgument='<%# Eval("sid") %>' ToolTip="删除比赛"
                                        ImageUrl="../img/icons/icon_delete.png" CommandName="Delete" />
                                </td>
                            </tr>
                        </AlternatingItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
            <div class="extrabottom">
               <div style=" width:100%;float:right;">
                
                   <uc:pageList ID="pagelist" runat="server"  Onpagelistchang="pagelist_chang"/>
               </div>
            </div>
            <div style="clear: both;">
           
            </div>
        </div>
    </div>
</asp:Content>