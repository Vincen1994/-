<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ImageShow.aspx.cs" Inherits="BallGameManage.Main.ImageShow" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>汕头市金平区工商业联合会(总商会)</title>
    <link rel="stylesheet" href="../styles/reset.css" />
    <link rel="stylesheet" href="../styles/common.css" />
    <link rel="stylesheet" href="../styles/index.css" />
    <script src="../scripts/move.js"></script>
    <script type="text/javascript">
        var initializationTime = (new Date()).getTime();
        function showLeftTime() {
            var now = new Date();
            var year = now.getYear();
            var month = now.getMonth();
            var day = now.getDate();
            var hours = now.getHours();
            var minutes = now.getMinutes();
            var seconds = now.getSeconds();
            document.all.show.innerHTML = "" + year + "年" + month + "月" + day + "日 " + hours + ":" + minutes + ":" + seconds + "";
            //一秒刷新一次显示时间
            var timeID = setTimeout(showLeftTime, 1000);
        }

        function Open(url) {
            window.open(url);
        }
</script>
</head>
<body style="height: 900px"  onload="showLeftTime()">
    <form id="form1" runat="server">
    <div id="container" style="height: 900px;">
        <!-- header start -->
        <div id="header">
            <div class="banner">
                <img src="../img/images/banner.png"></div>
            <div id="menu">
                <ul class="menu-list">
                    <li class="menu-list-child"><a href="Index.aspx" title="首页">
                        <img src="../img/images/menu-list-1.png" /></a> </li>
                    <li class="menu-list-child"><a href="NewsDetail.aspx?type=jj" title="商会简介">
                        <img src="../img/images/menu-list-2.png" /></a> </li>
                    <li class="menu-list-child"><a href="Aspectlist.aspx?type=hwxx" title="商会纵横">
                        <img src="../img/images/menu-list-3.png" /></a> </li>
                    <li class="menu-list-child"><a href="Lawlist.aspx?type=zcfg" title="政策法规">
                        <img src="../img/images/menu-list-4.png"></a> </li>
                    <li class="menu-list-child"><a href="Dynamiclist.aspx?type=hyhwxx" title="行业动态">
                        <img src="../img/images/menu-list-5.png"></a> </li>
                    <li class="menu-list-child"><a href="Memberlist.aspx?type=qyfc" title="会员风采">
                        <img src="../img/images/menu-list-6.png"></a> </li>
                    <li class="menu-list-child"><a href="Economylist.aspx?type=jjxx" title="经济信息">
                        <img src="../img/images/menu-list-7.png"></a> </li>
                    <li class="menu-list-child"><a href="Proceedingslist.aspx?type=1" title="商会会刊">
                        <img src="../img/images/menu-list-8.png"></a> </li>
                </ul>
                <span id="show" class="date"></span>
            </div>
        </div>
        <!-- header end -->
        <!-- content start --->
        <div id="content" style="width: 1000px; margin-top: 10px;">
            <div class="content-t-l" style="float: left; width:998px; text-align:center;">
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
        <table width="998">
            <tr>
                <td>
                    <asp:ImageButton ID="img_btn1" runat="server" ImageUrl="~/img/l.gif" 
                        onclick="img_btn1_Click"  />
                </td>
                <td style=" width:860px;">
                    <asp:DataList ID="ImageList" runat="server" RepeatDirection="Horizontal" 
                    RepeatColumns="1">
                        <ItemTemplate>
                            <div style="width: 860px; text-align:center;">
                                <asp:Image ImageUrl='<%# Eval("url")%>' Width="860px" ID="img_paperwork"
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
            
        </div>
        <!-- content end --->
        <div id="footer">
         地址：广东省汕头市金平区龙眼路93号 &nbsp;&nbsp;&nbsp;&nbsp;电话：0754-88617539<br />
            Copyright(c)2013 版权所有 汕头市金平区工商业联合会(总商会)
        </div>
    </div>
    </form>
</body>
</html>
