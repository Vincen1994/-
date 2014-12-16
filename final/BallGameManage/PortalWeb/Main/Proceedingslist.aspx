<%@ Page Title="" Language="C#" MasterPageFile="~/Main/MasterPage.master" AutoEventWireup="true" CodeBehind="Proceedingslist.aspx.cs" Inherits="BallGameManage.Main.Proceedingslist" %>
<%@ Register TagPrefix="uc" TagName="pageList" Src="~/UserControls/PageList.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="content-t-l" style="float:left; width:100%;">
            	<h1 class="content-title">
                	<strong><asp:Label ID="HeadTitle" runat="server" Text=""  ></asp:Label></strong>
                </h1>
                  <asp:DataList ID="ImageList" runat="server" RepeatDirection="Horizontal" 
                    RepeatColumns="4">
                        <ItemTemplate>
                            <div style="width: 150px; height: 240px; margin-left:20px; margin-right:20px; margin-top:20px;">
                                <asp:LinkButton ID="lnkSel" CssClass="btnC_right"  CommandName="select"  OnCommand="lnk_Command"
                                    CommandArgument='<%# Eval("sid") %>' runat="server">
                                <asp:Image ImageUrl='<%# Eval("url")%>' Height="200px" Width="150px" ID="img_paperwork"
                                    runat="server" />
                                <asp:Label ID="lbl_imageName" runat="server" Text='<%# Eval("name")%>'></asp:Label>
                                    </asp:LinkButton>
                            </div>
                        </ItemTemplate>
                    </asp:DataList>

            <div class="bulkactions">
                    
                </div>
            </div>
</asp:Content>
