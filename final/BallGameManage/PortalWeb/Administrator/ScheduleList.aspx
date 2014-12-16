<%@ Page Title="" Language="C#" MasterPageFile="~/Administrator/AdminMasterPage.master" AutoEventWireup="true" CodeBehind="ScheduleList.aspx.cs" Inherits="BallGameManage.Administrator.ScheduleList" %>
<%@ Register TagPrefix="uc" TagName="pageList" Src="~/UserControls/PageList.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="~/styles/indexcss.css" rel="stylesheet" type="text/css" />  
<script src="../scripts/jquery-1.8.2.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="contentcontainer">
        <div class="headings altheading">
            <h2>
                赛程列表
                </h2>
        </div>
        <div class="contentbox">
        <asp:Button  ID="btn_addLike" runat="server" Text="添加赛程" CssClass="btn" 
                onclick="btn_addLike_Click"  />
            <table width="100%">
                <thead>
                    <tr>
                        <th>
                            赛程名称
                        </th>
                        <th>
                           创建时间
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
                                    <%# Eval("Name")%>
                                </td>
                                <td>
                                    <%# Eval("CreaterTime")%>
                                </td>
                                <td>
                                  <asp:ImageButton ID="ImageButton1" runat="server" PostBackUrl='<%# "MatchList.aspx?sid="+Eval("sid") %>'
                                         ImageUrl="../img/icons/add.png" CommandName="ADD" ToolTip="查看比赛" />
                                    <asp:ImageButton ID="Edit" runat="server" PostBackUrl='<%# "addSchedule.aspx?type=update&sid="+Eval("sid") %>'
                                        ImageUrl="../img/icons/icon_edit.png" CommandName="Edit" ToolTip="修改赛程" />
                                    <asp:ImageButton ID="Delete" runat="server" CommandArgument='<%# Eval("sid") %>' ToolTip="删除赛程"
                                        ImageUrl="../img/icons/icon_delete.png" CommandName="Delete"  />
                                </td>
                            </tr>
                        </ItemTemplate>
                        <AlternatingItemTemplate>
                            <tr class="alt">
                                <td>
                                    <%# Eval("Name")%>
                                </td>
                                 <td>
                                    <%# Eval("CreaterTime")%>
                                </td>
                                <td>
                                    <asp:ImageButton ID="ImageButton1" runat="server" PostBackUrl='<%# "MatchList.aspx?sid="+Eval("sid") %>'
                                         ImageUrl="../img/icons/add.png" CommandName="ADD" ToolTip="查看比赛" />
                                    <asp:ImageButton ID="Edit" runat="server" PostBackUrl='<%# "addSchedule.aspx?type=update&sid="+Eval("sid") %>'
                                         ImageUrl="../img/icons/icon_edit.png" CommandName="Edit" ToolTip="修改赛程" />
                                      <asp:ImageButton ID="Delete" runat="server" CommandArgument='<%# Eval("sid") %>' ToolTip="删除赛程"
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