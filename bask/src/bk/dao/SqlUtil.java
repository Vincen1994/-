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
	// ��ȡ����
	public static Connection getConnection() {
		Connection conn = null;
	
			String driver = "com.mysql.jdbc.Driver";

			// URLָ��Ҫ���ʵ����ݿ���scutcs

			String url = "jdbc:mysql://localhost:3306/gxbasketball";

			// MySQL����ʱ���û���

			String user = "root";

			// Java����MySQL����ʱ������

			String password = "zhuyue";

			try {

			// ������������

			Class.forName(driver);

			// �������ݿ�

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
	// �ر�����
	public static void closeConnection(ResultSet rs, Statement stmt, Connection conn) {
		try {
			if (rs != null)
				rs.close();
			if (stmt != null)
				stmt.close();
			if (conn != null)
				conn.close(); // �ͷŻ����ӳ�
			
		} catch(SQLException e) {
			e.printStackTrace();
		}
	}
}
