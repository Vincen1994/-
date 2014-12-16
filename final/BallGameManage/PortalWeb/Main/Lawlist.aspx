<%@ Page Title="" Language="C#" MasterPageFile="~/Main/MasterPage.master" AutoEventWireup="true" CodeBehind="Lawlist.aspx.cs" Inherits="BallGameManage.Main.Lawlist" %>

<%@ Register TagPrefix="uc" TagName="pageList" Src="~/UserControls/PageList.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="content-t-l" style="float:left; width:100%;">
            	<h1 class="content-title">
                	<strong><asp:Label ID="HeadTitle" runat="server" Text=""  ></asp:Label></strong>
                </h1>
                <div class="div_list" style=" margin-top:20px;">
                  <table width="100%" cellpadding="0" cellspacing="0" style=" border:0px;">
                <tbody>
                    <asp:Repeater ID="Repeater" runat="server" >
                        <ItemTemplate>
                            <tr style="border-bottom:1px dashed black; margin-top:10px;">
                                <td align="left" style="border-bottom:1px dashed black; width:750px; height:100px;">
                                <%#Eval("name") %>  
                                
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
            </div>
            
            </div>

</asp:Content>
