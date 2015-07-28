using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace jsair.Util
{
	public class AESCryptoService
	{
	
		private byte[] soh;

		private byte[] stx;

		public AESCryptoService(string pubToken, string priToken)
		{
			this.SOH(pubToken, priToken);
		}

		public AESCryptoService(string token)
		{
			this.SOH(token);
		}

		private void SOH(string STX, string ETS)
		{
			string expr_00 = "125B999464194769AC72CCC42E4DB8FA";
			string text;
			if (!false)
			{
				text = expr_00;
			}
			string text2 = string.Format("{0}+{1}+{2}", STX.Trim().ToUpper(), text, ETS.Trim().ToUpper());
			this.SOH(text2);
		}

		private void SOH(string STX)
		{
			SHA256Managed expr_64 = new SHA256Managed();
			SHA256Managed sHA256Managed;
			if (!false)
			{
				sHA256Managed = expr_64;
			}
			try
			{
				byte[] array = sHA256Managed.ComputeHash(Encoding.UTF8.GetBytes(STX));
				this.soh = new byte[32];
				this.stx = new byte[16];
				Array.Copy(array, 0, this.soh, 0, 32);
				Array.Copy(array, 16, this.stx, 0, 16);
			}
			finally
			{
				if (sHA256Managed != null)
				{
                    sHA256Managed.Dispose();
				}
			}
		}

		public byte[] EncryptData(byte[] source)
		{
			byte[] result;
			using (AesManaged aesManaged = new AesManaged())
			{
				ICryptoTransform cryptoTransform = aesManaged.CreateEncryptor(this.soh, this.stx);
				using (MemoryStream memoryStream = new MemoryStream())
				{
					using (CryptoStream cryptoStream = new CryptoStream(memoryStream, cryptoTransform, CryptoStreamMode.Write))
					{
						cryptoStream.Write(source, 0, source.Length);
						cryptoStream.FlushFinalBlock();
						result = memoryStream.ToArray();
					}
				}
			}
			return result;
		}

		public byte[] EncryptData(string source)
		{
			byte[] bytes = Encoding.UTF8.GetBytes(source);
			return this.EncryptData(bytes);
		}

		public string EncryptString(string source)
		{
			byte[] bytes = Encoding.UTF8.GetBytes(source);
			return Convert.ToBase64String(this.EncryptData(bytes));
		}

		public string EncryptString(byte[] source)
		{
			return Convert.ToBase64String(this.EncryptData(source));
		}

		public byte[] DecryptData(byte[] source)
		{
			byte[] result;
			using (AesManaged aesManaged = new AesManaged())
			{
				ICryptoTransform cryptoTransform = aesManaged.CreateDecryptor(this.soh, this.stx);
				using (MemoryStream memoryStream = new MemoryStream())
				{
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, cryptoTransform, CryptoStreamMode.Write))
					{
						cryptoStream.Write(source, 0, source.Length);
						cryptoStream.FlushFinalBlock();
						result = memoryStream.ToArray();
					}
				}
			}
			return result;
		}

		public string DecryptString(string source)
		{
			byte[] array = Convert.FromBase64String(source);
			array = this.DecryptData(array);
			return Encoding.UTF8.GetString(array, 0, array.Length);
		}

		public static string CreateToken()
		{
			byte[] array = Guid.NewGuid().ToByteArray();
			StringBuilder stringBuilder = new StringBuilder();
			byte[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				byte b = array2[i];
				stringBuilder.AppendFormat("{0:x2}", new object[]
				{
					b
				});
			}
			return stringBuilder.ToString();
		}
	}
}
