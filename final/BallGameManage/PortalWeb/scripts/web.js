window.onload = function(){

	/*
	var aList = getClass("menu","menu-list-child");
	var aDiv = getClass("menu","child-inner");
	var i=0;
	var oTimer = null;
	alert(aList.length);
	for(i=0;i<aList.length;i++){
		aList[i].index = i;
		aDiv[i].index = i;
		aList[i].onmouseover = function(){
			
			console.log(oTimer+"==1");
			if(oTimer){
				
				clearInterval(oTimer);
				oTimer = null;
			}
			aDiv[this.index].style.display = 'block';
		}
		aList[i].onmouseout = function(){
			var _this = this;
			oTimer = setTimeout(function(){
				aDiv[_this.index].style.display = 'none';
				oTimer = null;
			},1000);
			console.log(oTimer);	
		}
		
		aDiv[i].onmouseover = function(ev){
			var oEvent = ev||event;
			
			if(oTimer){
				clearInterval(oTimer);
				oTimer = null;
			}
			oEvent.cancelBubble = true;
				
		}
		aDiv[i].onmouseout = function(){
			var _this = this;
			oTimer = setTimeout(function(){				
				aDiv[_this.index].display = "none";
				oTimer = null;
			},1000);	
		}
	}	
	*/

	(function(){
		
		var aBannerList = document.getElementById("banner").getElementsByTagName("li");
		var i = 0;
		var oTimer = null;
		var iNow = 0;
		var oIndex = 2;
		setInterval(function(){
			
			if(iNow == aBannerList.length-1){
				iNow = 0;
			}else{
				iNow++;
			}
			aBannerList[iNow].style.opacity = 0;
			aBannerList[iNow].style.filter = "alpha(opacity:0)";
			aBannerList[iNow].style.zIndex = oIndex++;
			startMove(aBannerList[iNow],{opacity:100});
			
		},2000);
			
	})()
	
};
function getClass(target,className){
	
	var oTarget = document.getElementById(target).getElementsByTagName("*");
	var i=0;
	var arry = [];
	for(i=0;i<oTarget.length;i++){
		if(oTarget[i].className == className){
			arry.push(oTarget[i]);
		}
	}
	return arry;
	
	
}