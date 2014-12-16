<%@ Page Title="" Language="C#" MasterPageFile="~/Administrator/AdminMasterPage.master" AutoEventWireup="true" CodeBehind="selectdAdmin.aspx.cs" Inherits="BallGameManage.Administrator.selectdAdmin" %>
<%@ Register TagPrefix="uc" TagName="pageList" Src="~/UserControls/PageList.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="~/styles/indexcss.css" rel="stylesheet" type="text/css" />  
<script src="../scripts/jquery-1.8.2.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="contentcontainer">
        <div class="headings altheading">
            <h2>
                管理员列表</h2>
        </div>
        <div class="contentbox">
            <table width="100%">
                <thead>
                    <tr>
                        <th>
                            <input type="checkbox" value="" id="CKB" />全选
                        </th>
                        <th>
                            管理员帐号
                        </th>
                        <th>
                            真实姓名
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
                    <asp:Repeater ID="Repeater" runat="server" OnItemCommand="Repeater_ItemCommand">
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <input class="cb" type="checkbox" id="checkbox" runat="server" value='<%# Eval("sid") %>' />
                                </td>
                                <td>
                                    <%# Eval("userID")%>
                                </td>
                                <td>
                                    <%# Eval("RealName") %>
                                </td>
                                <td>
                                    <%# Eval("CreatedTime")%>
                                </td>
                                <td>
                                    <asp:ImageButton ID="Edit" runat="server" PostBackUrl='<%# "UpdateAdmin.aspx?id="+Eval("sid") %>'
                                        ImageUrl="../img/icons/icon_edit.png" CommandName="Edit" />
                                    <asp:ImageButton ID="Delete" runat="server" CommandArgument='<%# Eval("sid") %>'
                                        ImageUrl="../img/icons/icon_delete.png" CommandName="Delete" />
                                </td>
                            </tr>
                        </ItemTemplate>
                        <AlternatingItemTemplate>
                            <tr class="alt">
                                <td>
                                    <input type="checkbox" id="checkbox" class="cb" runat="server" value='<%# Eval("sid") %>' />
                                </td>
                                <td>
                                    <%# Eval("userID")%>
                                </td>
                                <td>
                                    <%# Eval("RealName") %>
                                </td>
                                <td>
                                    <%# Eval("CreatedTime")%>
                                </td>
                                <td>
                                    <asp:ImageButton ID="Edit" PostBackUrl='<%# "UpdateAdmin.aspx?id="+Eval("sid") %>'
                                        runat="server" ImageUrl="../img/icons/icon_edit.png" CommandName="Edit" />
                                    <asp:ImageButton ID="Delete" runat="server" CommandArgument='<%# Eval("sid") %>'
                                        ImageUrl="../img/icons/icon_delete.png" CommandName="Delete" />
                                </td>
                            </tr>
                        </AlternatingItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
            <div class="extrabottom">
               <div style=" width:15%; float:left;">
                <ul>
                    <li>
                        <asp:ImageButton ID="IMG_btn_batchDelete" runat="server" ImageUrl="../img/icons/icon_delete.png"
                            OnClick="batchDelete_Click" AlternateText="批量删除" />
                            <asp:LinkButton ID="lk_btn_batchDelete" runat="server" 
                            onclick="lk_btn_batchDelete_Click">批量删除</asp:LinkButton></li>
                </ul>
                </div>
               <div style=" width:84%;float:right;">
                
                   <uc:pageList ID="pagelist" runat="server"  Onpagelistchang="pagelist_chang"/>
               </div>
            </div>
            <div style="clear: both;">
           
            </div>
        </div>
    </div>
</asp:Content>
