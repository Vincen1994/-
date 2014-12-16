<%@ Page Title="" Language="C#" MasterPageFile="~/Administrator/AdminMasterPage.master" AutoEventWireup="true" CodeBehind="selectImage.aspx.cs" Inherits="BallGameManage.Administrator.selectImage" %>
<%@ Register TagPrefix="uc" TagName="pageList" Src="~/UserControls/PageList.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        function Open(url) {
            window.open(url);
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="contentcontainer">
        <div class="headings altheading">
            <h2>
                <asp:Label ID="lab_huikan" runat="server" Text=""></asp:Label></h2>
        </div>
        <div class="contentbox">
                  <div >
                            <asp:LinkButton ID="lk_btn_add" runat="server" onclick="lk_btn_add_Click">添加图片</asp:LinkButton>
                            &nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:ImageButton ID="IMG_btn_batchDelete" runat="server" ImageUrl="../img/icons/icon_delete.png"
                                OnClick="batchDelete_Click" AlternateText="批量删除" Width="16px" />
                            <asp:LinkButton ID="lk_btn_batchDelete" runat="server" OnClick="lk_btn_batchDelete_Click">批量删除</asp:LinkButton>
                     </div>
        <asp:DataList ID="ImageList" runat="server" RepeatDirection="Horizontal" 
                RepeatColumns="5">
                        <ItemTemplate>
                            <div style="width: 100px; height: 130px;">
                                <asp:Image ImageUrl='<%# Eval("url")%>' Height="100px" Width="100px" ID="img_paperwork"
                                    runat="server" />
                                <br />
                                 <input type="checkbox" id="checkbox" class="cb" runat="server" value='<%# Eval("sid") %>' />
                                      <asp:LinkButton ID="lnkSel" CssClass="btnC_right"  CommandName="select" OnCommand="lnk_Command"
                                    CommandArgument='<%# Eval("sid") %>' runat="server"><span class="btnC_left">查看</span></asp:LinkButton>
                                <asp:LinkButton ID="lnkDel" CssClass="btnC_right"  CommandName="delete" OnCommand="lnk_Command"
                                    CommandArgument='<%# Eval("sid") %>' runat="server"><span class="btnC_left">删除</span></asp:LinkButton>
                            </div>
                        </ItemTemplate>
                    </asp:DataList>
            </div>
             <div class="bulkactions">
                    <uc:pageList ID="pagelist" runat="server"  Onpagelistchang="pagelist_chang"/>
                </div>
    </div>
</asp:Content>
