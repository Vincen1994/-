package bk.dao;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;

import javax.naming.Context;
import javax.naming.InitialContext;
import javax.sql.DataSource;

public class SqlUtil {
	// 获取连接
	public static Connection getConnection() {
		Connection conn = null;
	
			String driver = "com.mysql.jdbc.Driver";

			// URL指向要访问的数据库名scutcs

			String url = "jdbc:mysql://localhost:3306/gxbasketball";

			// MySQL配置时的用户名

			String user = "root";

			// Java连接MySQL配置时的密码

			String password = "zhuyue";

			try {

			// 加载驱动程序

			Class.forName(driver);

			// 连续数据库

			conn = DriverManager.getConnection(url, user, password);
		
		}catch(Exception e){
			e.printStackTrace();	
		}
		
		return conn;
	}
	
/*	public static Connection getConnection() {
		String url = "jdbc:oracle:thin:@10.25.84.70:1521:oracle";
		String user = "scott";
		String password = "tiger";
		Connection conn = null;
		
		try {
			Class.forName("oracle.jdbc.OracleDriver");
			conn = DriverManager.getConnection(url, user, password);
		} catch (ClassNotFoundException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		} catch (SQLException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		return conn;
	}
*/	
	// 关闭连接
	public static void closeConnection(ResultSet rs, Statement stmt, Connection conn) {
		try {
			if (rs != null)
				rs.close();
			if (stmt != null)
				stmt.close();
			if (conn != null)
				conn.close(); // 释放回连接池
			
		} catch(SQLException e) {
			e.printStackTrace();
		}
	}
}
