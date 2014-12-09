package bk.dao;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;
import java.sql.Date;
import java.util.List;

import bk.dao.SqlUtil;


public class BkDao {
	public List<Bk> select(String username) throws SQLException {
		// TODO Auto-generated method stub
		Connection con = SqlUtil.getConnection();
		PreparedStatement ps = null;
		PreparedStatement ps2 = null;
		ResultSet rs = null;
		ResultSet rs2 = null;
		List<Bk> list = new ArrayList<Bk>();
		String team = null;
		String sql2 = "select userteam from user where username="+"'"+username+"'";
		
		// 如果查询条件不空，则增加此条件
		List<String> params = new ArrayList<String>();
	
		
		try {
			ps2 = con.prepareStatement(sql2);
			rs2 = ps2.executeQuery();
			while (rs2.next()){
				team = rs2.getString(1);
			}
			String sql = "select * from player where playerteam="+"'"+team+"'";
			
			ps = con.prepareStatement(sql);
			rs = ps.executeQuery();
		
			while (rs.next()) {
				Bk bk = new Bk();
				bk.setPlayerid(rs.getString(1));
				bk.setPlayername(rs.getString(2));
				bk.setPlayersex(rs.getString(3));
				bk.setPlayerlab(rs.getString(4));
				bk.setPlayerteam(rs.getString(5));
				bk.setPlayernum(rs.getString(6));
		
		
				list.add(bk);
			}
		} finally {
			SqlUtil.closeConnection(null, ps, con);
		}
		
		return list;
	}
	
	public void insert(String username,String usercode,String userverify,String userdep) throws SQLException {
	
	
		
			String sql2 = "select userteam from gxbasketball.user order by userteam desc" ;
			String sql = "INSERT INTO gxbasketball.user (username,usercode, userverify, userdep, userteam)"
					+ " VALUES(?,?,?,?,?)";
		
			PreparedStatement st = null;
			ResultSet rs = null;
			Connection con = null;
		
			int id1 =0;
			int row = 0;
			try {
				
				con = SqlUtil.getConnection();
				st = con.prepareStatement(sql2);
				//求 id1
				rs = st.executeQuery();
				if (rs.next()) {
					int i=Integer.parseInt(rs.getString(1));
					id1=i+1;
				}
				// insert
				con = SqlUtil.getConnection();
				st = con.prepareStatement(sql);
				
				st.setString(1, username);
				st.setString(2, usercode);
				st.setString(3, userverify);
				st.setString(4, userdep);
				st.setString(5, id1+"");
				
			
				row = st.executeUpdate();
			

			} finally {
				SqlUtil.closeConnection(rs, st, con);
			
			}
		}
	public String add(String playerid,String playername,String playersex,String playerlab,String playernum,String playerteam) throws SQLException {
		String username=null;
		String sql = "INSERT INTO gxbasketball.player (playerid,playername,playersex,playerlab,playernum,playerteam)"
				+ " VALUES(?,?,?,?,?,?)";
		String sql2 = "select username from gxbasketball.user where userteam="+"'"+playerteam+"'" ;
		PreparedStatement st = null;
		PreparedStatement st2 = null;
		ResultSet rs = null;
		ResultSet rs2 = null;
		Connection con = null;
	
	
		int row = 0;
		try {
			
			con = SqlUtil.getConnection();
			st = con.prepareStatement(sql);
			
			st.setString(1, playerid);
			st.setString(2, playername);
			st.setString(3, playersex);
			st.setString(4, playerlab);
			st.setString(5, playernum);
			st.setString(6, playerteam);
			
			
			row = st.executeUpdate();
			

		} finally {
			SqlUtil.closeConnection(rs, st, con);
		
		}	
		//huoqu username
		
		try {
			
			con = SqlUtil.getConnection();
			st2 = con.prepareStatement(sql2);
			rs2 = st2.executeQuery();
			if (rs2.next()) {
				username = rs2.getString(1);
			}
		
		
		

		} finally {
			SqlUtil.closeConnection(rs2, st2, con);
		
		}
		return username;
	}
		
	public String logon(String username,String usercode) throws SQLException {
		
		String yesorno= null;
		
		String sql = "select usercode from gxbasketball.user where username="+"'"+username +"'";

		PreparedStatement st = null;
		ResultSet rs = null;
		Connection con = null;
	
		int id1 =0;
		int row = 0;
		try {
			
			con = SqlUtil.getConnection();
			st = con.prepareStatement(sql);
			//求 id1
			rs = st.executeQuery();
			if (rs.next()) {
			
			System.out.println(usercode);
				if(rs.getString(1).equals(usercode))
				{
					yesorno ="yes";
				}
				else
					yesorno ="no";
			}
		
			else
				yesorno ="noid";
		} finally {
			SqlUtil.closeConnection(rs, st, con);
		
		}
		return yesorno;
	}
		
		
		
		
	
}

