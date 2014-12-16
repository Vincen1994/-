
function selectDate() {
	 WdatePicker();
	 window.focus();
}
function selectDatetime() {
	WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'});
	window.focus();
}
function selectTime() {
	WdatePicker({dateFmt:'H:mm:ss'});
	window.focus();
}
function selectDateYYYYMM() {
	WdatePicker({dateFmt:'yyyyMM'});
	window.focus();
}

function selectDateYYYYMMDD() {
	WdatePicker({dateFmt:'yyyyMMdd'})
	window.focus();
}

function selectDateYYYY() {
	WdatePicker({dateFmt:'yyyy'})
	window.focus();
}
function selectddy() {
	WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'});
	window.focus();
}

function selectdddy() {
    WdatePicker({ dateFmt: 'yyyyMMddHHmmss' });
    window.focus();
}


/** 
 * 时间对象的格式化; 
 * eg:format="yyyy-MM-dd hh:mm:ss
 */  
Date.prototype.format = function(format) {  
    var o = {  
        "M+" : this.getMonth() + 1, // month  
        "d+" : this.getDate(), // day  
        "h+" : this.getHours(), // hour  
        "m+" : this.getMinutes(), // minute  
        "s+" : this.getSeconds(), // second  
        "q+" : Math.floor((this.getMonth() + 3) / 3), // quarter  
        "S" : this.getMilliseconds()  
        // millisecond  
    }  
  
    if (/(y+)/.test(format)) {  
        format = format.replace(RegExp.$1, (this.getFullYear() + "").substr(4  
                        - RegExp.$1.length));  
    }  
  
    for (var k in o) {  
        if (new RegExp("(" + k + ")").test(format)) {  
            format = format.replace(RegExp.$1, RegExp.$1.length == 1  
                            ? o[k]  
                            : ("00" + o[k]).substr(("" + o[k]).length));  
        }  
    }  
    return format;  
}
function str2date(date) {
	if (!date) return null;
	var args = date.split(/-| |:/);
	date = new Date(args[0],args[1]-1,args[2],args[3],args[4],args[5]);
	return date;
}
function checkDateRange(startdate, enddate, field, amount) {
	startdate["set" + field](startdate["get" + field]() + amount);
	return enddate > startdate;
}