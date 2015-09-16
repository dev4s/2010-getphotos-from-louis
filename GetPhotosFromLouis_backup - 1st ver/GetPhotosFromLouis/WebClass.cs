using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace GetPhotosFromLouis
{
	public class WebClass
	{
		public string ErrorMessage { get; private set; }
		private HttpWebRequest Request { get; set; }
		private HttpWebResponse Response { get; set; }
		private WebClient WebClient { get; set; }

		public string ConnectingToSite(string value)
		{
			StreamReader tempStream;

			try
			{
				tempStream = new StreamReader(Connection(value));
			}
			catch (Exception)
			{
				Threads.SleepTime(1000);
				tempStream =  new StreamReader(Connection(value));
			}

			return GetStringFromStream(tempStream);
		}

		private static string GetStringFromStream(StreamReader stream)
		{
			string inputString;

			try
			{
				inputString = stream.ReadToEnd();
			}
			catch (Exception)
			{
				stream.BaseStream.Seek(0, SeekOrigin.Begin);
				stream.DiscardBufferedData();
				inputString = stream.ReadToEnd();
			}
			stream.Close();

			return inputString;
		}

		private Stream Connection(string value)
		{
			Request = (HttpWebRequest)WebRequest.Create(value);
			Response = (HttpWebResponse)Request.GetResponse();
			return Response.GetResponseStream();
		}

		public bool DownloadFile(string fileDownload, string path, string fileName)
		{
			try
			{
				if (String.IsNullOrEmpty(path) || String.IsNullOrEmpty(fileName) || String.IsNullOrEmpty(fileDownload))
					return false;

				WebClient = new WebClient();

				var tempPath = path.EndsWith("\\") ? path : path + "\\";

				WebClient.DownloadFile(new Uri(fileDownload), String.Format("{0}{1}", tempPath, fileName));
			}
			catch(Exception e)
			{
				ErrorMessage = e.Message;
				return false;
			}

			return true;
		}

		public static void FtpUploadFile(string server, string password, string username, string serverDirectory, string fileNameDirectory, string fileName)
		{
			var ftpReturn = FtpConnection(server, username, password, serverDirectory, fileNameDirectory, fileName, true);
			var buffer = ftpReturn.Buffer;
			var request = ftpReturn.Request;

			try
			{
				var reqStream = request.GetRequestStream();
				reqStream.Write(buffer, 0, buffer.Length);
				reqStream.Close();
			}
			catch (Exception)
			{
				ftpReturn = FtpConnection(server, username, password, serverDirectory, fileNameDirectory, fileName, false);
				buffer = ftpReturn.Buffer;
				request = ftpReturn.Request;

				var reqStream = request.GetRequestStream();
				reqStream.Write(buffer, 0, buffer.Length);
				reqStream.Close();
			}
		}

		private static FtpReturn FtpConnection(string server, string username, string password, string serverDirectory, string fileNameDirectory, string fileName, bool usePassive)
		{
			var ftpReturn = new FtpReturn();

			var request = (FtpWebRequest)WebRequest.Create(string.Format("ftp://{0}/{1}/{2}/{3}", server, serverDirectory, "components/com_virtuemart/shop_image/product", Path.GetFileName(fileName)));

			request.Method = WebRequestMethods.Ftp.UploadFile;
			request.Credentials = new NetworkCredential(username, password);
			request.UsePassive = usePassive;
			request.UseBinary = true;
			request.KeepAlive = false;

			var stream = File.OpenRead(String.Format("{0}/{1}", fileNameDirectory, fileName));
			var buffer = new byte[stream.Length];

			stream.Read(buffer, 0, buffer.Length);
			stream.Close();

			ftpReturn.Buffer = buffer;
			ftpReturn.Request = request;

			return ftpReturn;
		}

		private class FtpReturn
		{
			public FtpWebRequest Request { get; set; }
			public Byte[] Buffer { get; set; }
		}
	}
}
