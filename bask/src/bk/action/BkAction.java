package bk.action;
import java.sql.Date;
import java.util.List;
import java.util.Map;

import javax.servlet.http.HttpServletRequest;

import org.apache.struts2.ServletActionContext;
import org.apache.struts2.interceptor.RequestAware;


import bk.dao.Bk;
import bk.dao.BkDao;


import com.opensymphony.xwork2.ActionSupport;
public class BkAction extends ActionSupport implements RequestAware{
	private Map<String, Object> request = null;
	private Map<String, Object> request1 = null;
	private Bk bk;
	private String username;
	private String usercode;
	private String userverify;
	private String userdep;
	private String playerid;
	private String playername;
	private String playersex;
	private String playerlab;
	private String playerteam;
	private String playernum;
	private String form1;
	
	@Override
	public void setRequest(Map<String, Object> request) {
		// TODO Auto-generated method stub
		this.request =request;
	}
	
	
	public String insert() throws Exception {
		String str = "insert";
		BkDao dao = new BkDao();

		dao.insert(username,usercode,userverify,userdep);

		return str;
	}
	public String logon() throws Exception {
		String str = null;
		BkDao dao = new BkDao();

		str = dao.logon(username,usercode);
		if(str.equals("yes")){
			
			List<Bk> list = dao.select(username);
			
			request.put("list", list);
		}
		return str;
	}
	public String add() throws Exception {
		String str = null;
		String str2 = "add";
		BkDao dao = new BkDao();

		str = dao.add(playerid,playername,playersex,playerlab,playernum,playerteam);
		List<Bk> list = dao.select(str);
		
		request.put("list", list);
		return str2;
	}
	public String form1() throws Exception {
		String str = "form1";
		System.out.println(form1);
		//String freetime = request.getPrameter("jsPrama");
		return str;
	}

	public String getUsername() {
		return username;
	}


	public void setUsername(String username) {
		this.username = username;
	}


	public String getUsercode() {
		return usercode;
	}


	public void setUsercode(String usercode) {
		this.usercode = usercode;
	}


	public String getUserverify() {
		return userverify;
	}


	public void setUserverify(String userverify) {
		this.userverify = userverify;
	}


	public String getUserdep() {
		return userdep;
	}


	public void setUserdep(String userdep) {
		this.userdep = userdep;
	}


	public Map<String, Object> getRequest() {
		return request;
	}


	public Bk getBk() {
		return bk;
	}


	public void setBk(Bk bk) {
		this.bk = bk;
	}


	public Map<String, Object> getRequest1() {
		return request1;
	}


	public void setRequest1(Map<String, Object> request1) {
		this.request1 = request1;
	}


	public String getPlayerid() {
		return playerid;
	}


	public void setPlayerid(String playerid) {
		this.playerid = playerid;
	}


	public String getPlayername() {
		return playername;
	}


	public void setPlayername(String playername) {
		this.playername = playername;
	}


	public String getPlayersex() {
		return playersex;
	}


	public void setPlayersex(String playersex) {
		this.playersex = playersex;
	}


	public String getPlayerlab() {
		return playerlab;
	}


	public void setPlayerlab(String playerlab) {
		this.playerlab = playerlab;
	}


	public String getPlayerteam() {
		return playerteam;
	}


	public void setPlayerteam(String playerteam) {
		this.playerteam = playerteam;
	}


	public String getPlayernum() {
		return playernum;
	}


	public void setPlayernum(String playernum) {
		this.playernum = playernum;
	}


	public String getForm1() {
		return form1;
	}


	public void setForm1(String form1) {
		this.form1 = form1;
	}
	
	
}
