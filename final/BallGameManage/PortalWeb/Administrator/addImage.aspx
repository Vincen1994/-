<%@ Page Title="" Language="C#" MasterPageFile="~/Administrator/AdminMasterPage.master" AutoEventWireup="true" CodeBehind="addImage.aspx.cs" Inherits="BallGameManage.Administrator.addImage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="contentcontainer">
        <div class="headings altheading">
            <h2>
                <asp:Label ID="lab_huikan" runat="server" Text=""></asp:Label></h2>
        </div>
        <div class="contentbox">
            <p>
                <label for="textfield">
                    <strong>上传图片:</strong></label>
                <asp:FileUpload ID="FileUpload" runat="server" CssClass="inputbox" />
            </p>
            <asp:Button ID="Submit" runat="server" Text="确定添加" CssClass="btn" 
                OnClick="Submit_Click" ValidationGroup="Verification" />&nbsp;&nbsp;
            <asp:Button ID="btn_fanhui" runat="server" Text="返回" CssClass="btn" 
                onclick="btn_fanhui_Click"  />
            </div>
    </div>
    
</asp:Content>
