<%@ Page Title="" Language="C#" MasterPageFile="~/Administrator/AdminMasterPage.master" AutoEventWireup="true"  validateRequest="false" CodeBehind="UpdateNews.aspx.cs" Inherits="BallGameManage.Administrator.UpdateNews" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" src="../scripts/jquery-1.8.2.js"></script>
    <script type="text/javascript" charset="utf-8" src="../kindeditor-4.1.10/kindeditor.js"></script>
    <script type="text/javascript" charset="utf-8" src="../kindeditor-4.1.10/lang/zh_CN.js"></script>
    <script charset="utf-8" src="../kindeditor-4.1.10/plugins/code/prettify.js"></script>
    <script type="text/javascript" charset="utf-8" src="../scripts/My97DatePicker/WdatePicker.js"></script>
    <script src="../scripts/dateUtil.js"></script>
    <script type="text/javascript">
        var editor1;
        KindEditor.ready(function (K) {
            editor1 = K.create('#<%= newsContent.ClientID %>', {
                cssPath: '../kindeditor-4.1.10/plugins/code/prettify.css',
                uploadJson: '../kindeditor-4.1.10/asp.net/upload_json.ashx',
                fileManagerJson: '../kindeditor-4.1.10/asp.net/file_manager_json.ashx',
                allowFileManager: true,
                filterMode: true, // true:开启过滤模式, false:关闭过滤模式
                afterCreate: function () {
                    var self = this;
                }
            });
            prettyPrint();
        });
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#mySubmit').click(function (event) {
                editor1.sync();
                var data = $("#<%= newsContent.ClientID %>").val();
                data = $.trim(data);
                if (data.length < 1) {
                    $('#error').show();
                    event.preventDefault();
                } else {
                    $('#error').hide();
                }

                var newstitle = $('#<%=newsName.ClientID %>').val();
                newstitle = $.trim(newstitle);
                if (newstitle.length < 1) {
                    $('#errortitle').show();
                    event.preventDefault();
                } else {
                    $('#errortitle').hide();
                }
                newsAuthor = $.trim(newsAuthor);
                if (newsAuthor.length < 1) {
                    $('#error_Author').show();
                    event.preventDefault();
                } else {
                    $('#error_Author').hide();
                }
                newsSource = $.trim(newsSource);
                if (newsSource.length < 1) {
                    $('#error_Source').show();
                    event.preventDefault();
                } else {
                    $('#error_Source').hide();
                }
                newsPublishTime = $.trim(newsPublishTime);
                if (newsPublishTime.length < 1) {
                    $('#error_PublishTime').show();
                    event.preventDefault();
                } else {
                    $('#error_PublishTime').hide();
                }

            });
        });  
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="contentcontainer">
        <div class="headings altheading">
            <h2>
                修改新闻</h2>
        </div>
        <div class="contentbox">
            <p>
                <label for="textfield">
                    <strong>新闻标题:</strong></label>
                <asp:TextBox ID="newsName" runat="server" CssClass="inputbox"></asp:TextBox><br />
                <span id="errortitle" style="color: Red; display: none;">新闻标题不能为空</span>
                <label for="textfield">
                    <strong>新闻内容:</strong></label>
                <textarea id="newsContent" name="newsContent" runat="server" cols="100" rows="8"
                    style="width: 95%; height: 200px; visibility: hidden;"></textarea><br />
                <span id="error" style="color: Red; display: none;">新闻内容不能为空</span>
                 <label for="textfield">
                    <strong>创建时间:</strong></label>
                <input id="CreateTime" runat="server" class="inputbox" onclick="selectddy()" /><br />
                <asp:Panel ID="ImgPanel" runat="server">
                <label for="textfield">
                    <strong>添加图片:</strong></label>
                <asp:FileUpload ID="FileUpload" CssClass="inputbox" runat="server" />
                <asp:Button ID="upload" runat="server" CssClass="btn" Text="上传" OnClick="upload_Click" />
                </asp:Panel>
            </p>
            <asp:Panel ID="Panel" runat="server">
                <div id="imgDiv" style="width: 120px; height: 140px;">
                    <div>
                        <asp:Image ID="Image" runat="server" Style="width: 120px; height: 120px;" /></div>
                    <asp:LinkButton ID="linkbtn_select" runat="server" Style="float: left;" OnClick="linkbtn_select_Click">查看</asp:LinkButton><asp:LinkButton
                        ID="linkbtn_delete" runat="server" Style="float: right;" OnClick="linkbtn_delete_Click">删除</asp:LinkButton>
                </div>
            </asp:Panel>
            <asp:Button ID="Submit" runat="server" Text="确定修改" CssClass="btn" OnClick="Submit_Click"
                ValidationGroup="Verification" />&nbsp;&nbsp;
            <asp:Button ID="Reset" runat="server" Text="重置" CssClass="btn" OnClick="Reset_Click" />
        </div>
    </div>
</asp:Content>
