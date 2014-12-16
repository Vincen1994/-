<%@ Page Title="" Language="C#" MasterPageFile="~/Main/MasterPage.master" AutoEventWireup="true" CodeBehind="Proceedingsdetail.aspx.cs" Inherits="BallGameManage.Main.Proceedingsdetail" %>

<%@ Register TagPrefix="uc" TagName="pageList" Src="~/UserControls/PageList.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="content-t-l" style="float: left; width: 100%; text-align:center;">
        <h1 class="content-title">
            <strong>
                <asp:Label ID="HeadTitle" runat="server" Text=""></asp:Label></strong>
        </h1>
        <div style="text-align: center">
            <asp:LinkButton ID="link_shang" runat="server" onclick="link_shang_Click">←上一页</asp:LinkButton>
           　总共 <%=count %>页，当前【<%=page%> / <%=count %>】　 
            <asp:LinkButton ID="link_xia" runat="server" onclick="link_xia_Click">下一页→</asp:LinkButton>
             　跳转到第<asp:DropDownList  AutoPostBack="true"
                ID="ddl_" runat="server" 
                onselectedindexchanged="ddl__SelectedIndexChanged">
            </asp:DropDownList>
            页
        </div>
        <table>
            <tr>
                <td>
                    <asp:ImageButton ID="img_btn1" runat="server" ImageUrl="~/img/l.gif" 
                        onclick="img_btn1_Click"  />
                </td>
                <td>
                    <asp:DataList ID="ImageList" runat="server" RepeatDirection="Horizontal" 
                    RepeatColumns="1">
                        <ItemTemplate>
                            <div style="width: 600px; height:800px; text-align:center;">
                                <asp:Image ImageUrl='<%# Eval("url")%>' Height="725px" Width="564px" ID="img_paperwork"
                                    runat="server" />
                            </div>
                        </ItemTemplate>

                    </asp:DataList>
                </td>
                <td>
                    <asp:ImageButton ID="img_btn2" runat="server" ImageUrl="~/img/r.gif" 
                        onclick="img_btn2_Click"  />
                </td>
            </tr>
        </table>
            
        <div style="margin-bottom: 0px; text-align: center;">
            <a href="javascript:history.go(-1);">[返回]</a></div>
    </div>
</asp:Content>
