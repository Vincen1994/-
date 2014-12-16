// JavaScript Document
$(function() {
  function noticeChangge() {
    var _wrap = $('ul.line'); //瀹氫箟婊氬姩鍖哄煙
    var _interval = 2000; //瀹氫箟婊氬姩闂撮殭鏃堕棿
    var _moving; //闇€瑕佹竻闄ょ殑鍔ㄧ敾
    _wrap.hover(function() {
      clearInterval(_moving); //褰撻紶鏍囧湪婊氬姩鍖哄煙涓椂,鍋滄婊氬姩
    },
    function() {
      _moving = setInterval(function() {
        var _field = _wrap.find('li:first'); //姝ゅ彉閲忎笉鍙斁缃簬鍑芥暟璧峰澶�,li:first鍙栧€兼槸鍙樺寲鐨�
        var _h = _field.height(); //鍙栧緱姣忔婊氬姩楂樺害
        _field.animate({
          marginTop: -_h + 'px'
        },
        600,
        function() { //閫氳繃鍙栬礋margin鍊�,闅愯棌绗竴琛�
          _field.css('marginTop', 0).appendTo(_wrap); //闅愯棌鍚�,灏嗚琛岀殑margin鍊肩疆闆�,骞舵彃鍏ュ埌鏈€鍚�,瀹炵幇鏃犵紳婊氬姩
        })
      },
      _interval) //婊氬姩闂撮殧鏃堕棿鍙栧喅浜巁interval
    }).trigger('mouseleave'); //鍑芥暟杞藉叆鏃�,妯℃嫙鎵цmouseleave,鍗宠嚜鍔ㄦ粴鍔�
  }

  function photoChange(wraper, prev, next, img, speed, or) {
    var wraper = $(wraper);
    var prev = $(prev);
    var next = $(next);
    var img = $(img).find('ul');
    var w = img.find('li').outerWidth(true);
    var s = speed;
    next.click(function() {
      img.animate({
        'margin-left': -w
      },
      function() {
        img.find('li').eq(0).appendTo(img);
        img.css({
          'margin-left': 0
        });
      });
    });
    prev.click(function() {
      img.find('li:last').prependTo(img);
      img.css({
        'margin-left': -w
      });
      img.animate({
        'margin-left': 0
      });
    });
    if (or == true) {
      ad = setInterval(function() {
        next.click();
      },
      s * 1000);
      wraper.hover(function() {
        clearInterval(ad);
      },
      function() {
        ad = setInterval(function() {
          next.click();
        },
        s * 1000);
      });
    }
  }
	function headerBgChange(){
		var headerBgUrl=$(".header").css("background-image");
		if(headerBgUrl.indexOf('topBannerBg1')){
			$(".header").css("background-image","url(../images/topBannerBg2.jpg)")
			}
		}
	// 鍥剧墖杞挱鎻掍欢
$.fn.UISlide = function(options){
var defaults = {
playTime :2000, // 闂撮殧鏃堕棿
duration :800, // 寤惰繜鏃堕棿
direction :'left', // 鏂瑰悜
easing :'easeInOutQuad', // 鑷姩鎾斁鏃� easing 鏂瑰紡
clickEasing :'easeOutCubic' // 鐐瑰嚮鏃� easing 鏂瑰紡
};
var opts = $.extend({}, defaults, options); // 鍙傛暟鍚堝苟
var slide = {
// 鎾斁璋冪敤鍙婁竴浜涘彉閲忕殑鍒濆鍖�
play: function(opts, me){
var that = this,
isPlay;
that.me = me;
that.picList = me.find('ul'); // 鍥剧墖鍒楄〃
that.title = me.find('div').find('a'); // 鍥剧墖鏍囬
that.oNum = me.find('dl'); // 鏁板瓧鎸夐挳
that.lis = that.picList.find('li'); // li
that.size = that.lis.length; // 鍥剧墖鐨勬暟閲�
that.lisWidth = that.lis.width();
that.isPlay = isPlay; // 鏄惁鑷姩鎾斁
for (var p in opts) { // opts 缁戝畾鍒� slide
that[p] = opts[p];
}
that.setNums().setTitle();
if(that.size > 1){ // 濡傛灉鍥剧墖鏁伴噺澶т簬鍒欒疆鎾�
that.autoPlay().slideEvent();
}
},
// 璁剧疆鎸夐挳
setNums: function(){
var that = this,
links, // 鍥剧墖鐨勯摼鎺�
me = that.me,
size = that.size,
oNum = that.oNum, // 鎸夐挳瀵硅薄
arrTemp = [];
links = that.picList.find('a').first();
that.title.html(links[0].title).attr('href', links[0].href); // 鎶婇摼鎺ョ殑 title 鍐呭鏀惧埌鏍囬鏍忎笂鏄剧ず
for(var i=1; i<=size; i++){
arrTemp.push('<dd>' + i + '</dd>');
}
oNum.append(arrTemp.join(''));
that.slideNum = oNum.find('dd');
that.numWidth = (that.slideNum.width() + parseInt(that.slideNum.css('margin-right')) + 2) * size + 1; // 鏁板瓧鎸夐挳瀹藉害
that.setTitle();
return that;
},
// 鑷姩鎾斁
autoPlay: function(){
var that = this,
activePos,
direction = that.direction,
picList = that.picList,
slideNum = that.slideNum,
playTime = that.playTime;
that.isPlay = setInterval(function (){
activePos = that.oNum.find('.active').index();
if(direction == 'left'){
if(activePos == (that.size - 1)){
direction = 'right';
activePos --;
} else {
activePos ++;
}
} else {
if(activePos == 0){
direction = 'left';
activePos ++;
} else {
activePos --;
}
}
picList.stop().animate({'margin-left': 0 - activePos * (that.lisWidth + 3)}, {duration: that.duration, easing: that.easing});
slideNum.removeClass('active').eq(activePos).addClass('active');
var links = picList.find('a').eq(activePos);
that.title.html(links[0].title).attr('href', links[0].href);
}, playTime);
return that;
},
// 璁剧疆鏍囬
setTitle: function(){
var that = this;
that.oNum.width(that.numWidth + 2); // 璁剧疆鏁板瓧鎸夐挳瀹藉害
that.picList.width((that.lisWidth + 3) * that.size); // 璁剧疆鍥剧墖瀹瑰櫒鎬诲搴�
that.slideNum.first().addClass('active');
return that;
},
// 缁戝畾鏁板瓧鎸夐挳浜嬩欢
slideEvent: function(){
var that = this,
slideNum = that.slideNum;
slideNum.click(function(){
var thisNum = $(this).index();
that.picList.stop().animate({"margin-left":0 - thisNum * (that.lisWidth + 3)}, {duration:that.duration, easing:that.clickEasing});
slideNum.removeClass('active').eq(thisNum).addClass('active');
var links = that.picList.find('a').eq(thisNum);
that.title.html(links[0].title).attr('href', links[0].href);
});
// 榧犳爣鍒扮敾闈�腑浠绘剰浣嶇疆锛屽仠姝㈡挱鏀�
that.me.hover(function(){
clearInterval(that.isPlay);
}, function(){
that.autoPlay();
})
return that;
}
};
return this.each(function(){ // $(a,b) 鏂瑰紡璋冪敤
slide.play(opts, $(this));
});
}
  //headerBgChange();
  noticeChangge(); //鏈€鏂板叕鍛�
  $('.slide_wrap').UISlide();//鍟嗕細绾垫í鍥剧墖杞崲
  photoChange('.picShow', '.left', '.right', '.photoList', 2, true); // 澶村儚杞崲
});