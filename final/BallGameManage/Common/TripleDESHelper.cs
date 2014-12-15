using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Common
{
	/// <summary>
	/// TripleDESHelper ��ժҪ˵���� ������
	/// </summary>
	public static class TripleDESHelper
	{
        private const string DEFAULT_KEY = "{A090CB24-AF38-4544-92F8-A5B9F1A36ABD}";

		private static readonly TripleDESService m_TripleDES = null;

        static TripleDESHelper()
        {
            //GlobalSettings settings = GlobalSettings.Instance;
            //if (null == settings)
            //{
            m_TripleDES = new TripleDESService(DEFAULT_KEY);
            //}
            //else
            //{
            //    m_TripleDES = new TripleDESService(settings.EncryptKey);
            //}
        }

        /// <summary>
        /// ����.
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
		public static string Encrypt(string source)
		{
			return m_TripleDES.Encrypt(source);
		}

        /// <summary>
        /// ����.
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
		public static string Decrypt(string source)
		{
			return m_TripleDES.Decrypt(source);
		}

        /// <summary>
        /// ����.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string Encrypt(string key, string source)
        {
            return new TripleDESService(key).Encrypt(source);
        }

        /// <summary>
        /// ����.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string Decrypt(string key, string source)
        {
            return new TripleDESService(key).Decrypt(source);
        }
	}

	/// <summary>
	/// ����DES.
	/// </summary>
	public class TripleDESService : IDisposable
	{
		private TripleDES mydes;
        /// <summary>
        /// ��Կֵ.
        /// </summary>
		public string Key;
        /// <summary>
        /// ��ʼ����ֵ.
        /// </summary>
		public string IV;

		/// <summary>
		/// �ԳƼ�����Ĺ��캯��.
		/// </summary>
		public TripleDESService(string key)
		{
			mydes = new TripleDESCryptoServiceProvider(); 
			Key = key;
			IV = "#$^%&&*Yisifhsfjsljfslhgosdshf26382837sdfjskhf97(*&(*";
		}

		/// <summary>
		/// �ԳƼ�����Ĺ��캯��.
		/// </summary>
		public TripleDESService(string key, string iv)
		{
			mydes = new TripleDESCryptoServiceProvider(); 
			Key = key;
			IV = iv;
		}

		/// <summary>
		/// �����Կ.
		/// </summary>
		/// <returns>��Կ.</returns>
		private byte[] GetLegalKey()
		{
			string sTemp = Key;
			mydes.GenerateKey();
			byte[] bytTemp = mydes.Key;
			int KeyLength = bytTemp.Length;
			if (sTemp.Length > KeyLength)
				sTemp = sTemp.Substring(0, KeyLength);
			else if (sTemp.Length < KeyLength)
				sTemp = sTemp.PadRight(KeyLength, ' ');
			return ASCIIEncoding.ASCII.GetBytes(sTemp);
		}

		/// <summary>
		/// ��ó�ʼ���� IV.
		/// </summary>
		/// <returns>�������� IV.</returns>
		private byte[] GetLegalIV()
		{
			string sTemp = IV;
			mydes.GenerateIV();
			byte[] bytTemp = mydes.IV;
			int IVLength = bytTemp.Length;
			if (sTemp.Length > IVLength)
				sTemp = sTemp.Substring(0, IVLength);
			else if (sTemp.Length < IVLength)
				sTemp = sTemp.PadRight(IVLength, ' ');
			return ASCIIEncoding.ASCII.GetBytes(sTemp);
		}

		/// <summary>
		/// ���ܷ���.
		/// </summary>
		/// <param name="Source">�����ܵĴ�.</param>
		/// <returns>�������ܵĴ�.</returns>
		public string Encrypt(string Source)
		{
			try
			{
				byte[] bytIn = UTF8Encoding.UTF8.GetBytes(Source);
				MemoryStream ms = new MemoryStream();
				mydes.Key = GetLegalKey();
				mydes.IV = GetLegalIV();
				ICryptoTransform encrypto = mydes.CreateEncryptor();
				CryptoStream cs = new CryptoStream(ms, encrypto, CryptoStreamMode.Write);
				cs.Write(bytIn, 0, bytIn.Length);
				cs.FlushFinalBlock();
				ms.Close();
				byte[] bytOut = ms.ToArray();
				return Convert.ToBase64String(bytOut);
			}
			catch (Exception ex)
			{
				throw new Exception("���ļ����ܵ�ʱ����ִ��󣡴�����ʾ�� \n" + ex.Message);
			}
		}

		/// <summary>
		/// ���ܷ���.
		/// </summary>
		/// <param name="Source">�����ܵĴ�.</param>
		/// <returns>�������ܵĴ�.</returns>
		public string Decrypt(string Source)
		{
			try
			{
				byte[] bytIn = Convert.FromBase64String(Source);
				MemoryStream ms = new MemoryStream(bytIn, 0, bytIn.Length);
				mydes.Key = GetLegalKey();
				mydes.IV = GetLegalIV();
				ICryptoTransform encrypto = mydes.CreateDecryptor();
				CryptoStream cs = new CryptoStream(ms, encrypto, CryptoStreamMode.Read);
				StreamReader sr = new StreamReader(cs);
				return sr.ReadToEnd();
			}
			catch (Exception ex)
			{
				throw new Exception("���ļ����ܵ�ʱ����ִ��󣡴�����ʾ�� \n" + ex.Message);
			}
		}

		/// <summary>
		/// ���ܷ���byte[] to byte[].
		/// </summary>
		/// <param name="Source">�����ܵ�byte����.</param>
		/// <returns>�������ܵ�byte����.</returns>
		public byte[] Encrypt(byte[] Source)
		{
			try
			{
				byte[] bytIn = Source;
				MemoryStream ms = new MemoryStream();
				mydes.Key = GetLegalKey();
				mydes.IV = GetLegalIV();
				ICryptoTransform encrypto = mydes.CreateEncryptor();
				CryptoStream cs = new CryptoStream(ms, encrypto, CryptoStreamMode.Write);
				cs.Write(bytIn, 0, bytIn.Length);
				cs.FlushFinalBlock();
				ms.Close();
				byte[] bytOut = ms.ToArray();
				return bytOut;
			}
			catch (Exception ex)
			{
				throw new Exception("���ļ����ܵ�ʱ����ִ��󣡴�����ʾ�� \n" + ex.Message);
			}
		}

		/// <summary>
		/// ���ܷ���byte[] to byte[].
		/// </summary>
		/// <param name="Source">�����ܵ�byte����.</param>
		/// <returns>�������ܵ�byte����.</returns>
		public byte[] Decrypt(byte[] Source)
		{
			try
			{
				byte[] bytIn = Source;
				MemoryStream ms = new MemoryStream(bytIn, 0, bytIn.Length);
				mydes.Key = GetLegalKey();
				mydes.IV = GetLegalIV();
				ICryptoTransform encrypto = mydes.CreateDecryptor();
				CryptoStream cs = new CryptoStream(ms, encrypto, CryptoStreamMode.Read);
				StreamReader sr = new StreamReader(cs);
				return UTF8Encoding.UTF8.GetBytes(sr.ReadToEnd());
			}
			catch (Exception ex)
			{
				throw new Exception("���ļ����ܵ�ʱ����ִ��󣡴�����ʾ�� \n" + ex.Message);
			}
		}

		/// <summary>
		/// ���ܷ���File to File.
		/// </summary>
		/// <param name="inFileName">�������ļ���·��.</param>
		/// <param name="outFileName">�����ܺ��ļ������·��.</param>
       
		public void Encrypt(string inFileName, string outFileName)
		{
			try
			{

				FileStream fin = new FileStream(inFileName, FileMode.Open, FileAccess.Read);
				FileStream fout = new FileStream(outFileName, FileMode.OpenOrCreate, FileAccess.Write);
				fout.SetLength(0);

				mydes.Key = GetLegalKey();
				mydes.IV = GetLegalIV();

				byte[] bin = new byte[100]; 
				long rdlen = 0;              
				long totlen = fin.Length;   
				int len;                     

				ICryptoTransform encrypto = mydes.CreateEncryptor();
				CryptoStream cs = new CryptoStream(fout, encrypto, CryptoStreamMode.Write);
				while (rdlen < totlen)
				{
					len = fin.Read(bin, 0, 100);
					cs.Write(bin, 0, len);
					rdlen = rdlen + len;
				}
				cs.Close();
				fout.Close();
				fin.Close();    

			}
			catch (Exception ex)
			{
				throw new Exception("���ļ����ܵ�ʱ����ִ��󣡴�����ʾ�� \n" + ex.Message);
			}
		}

		/// <summary>
		/// ���ܷ���File to File.
		/// </summary>
		/// <param name="inFileName">�������ļ���·��.</param>
		/// <param name="outFileName">�����ܺ��ļ������·��.</param>
		public void Decrypt(string inFileName, string outFileName)
		{
			try
			{
				FileStream fin = new FileStream(inFileName, FileMode.Open, FileAccess.Read);
				FileStream fout = new FileStream(outFileName, FileMode.OpenOrCreate, FileAccess.Write);
				fout.SetLength(0);

				byte[] bin = new byte[100]; 
				long rdlen = 0;            
				long totlen = fin.Length;  
				int len;                  
				mydes.Key = GetLegalKey();
				mydes.IV = GetLegalIV();
				ICryptoTransform encrypto = mydes.CreateDecryptor();
				CryptoStream cs = new CryptoStream(fout, encrypto, CryptoStreamMode.Write);
				while (rdlen < totlen)
				{
					len = fin.Read(bin, 0, 100);
					cs.Write(bin, 0, len);
					rdlen = rdlen + len;
				}
				cs.Close();
				fout.Close();
				fin.Close();    

			}
			catch (Exception ex)
			{
				throw new Exception("���ļ����ܵ�ʱ����ִ��󣡴�����ʾ�� \n" + ex.Message);
			}
		}

        #region IDisposable Members

        /// <summary>
        /// ����.
        /// </summary>
        public void Dispose()
        {
            //;
        }

        #endregion
    }
}
