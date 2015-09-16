using System;
using System.Data.EntityClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;

namespace LouisWebCrawler
{
	public class WebClass
	{
		private string DbConnectionString { get; set; }

		private bool FtpUsePassive { get; set; }
		private string FtpUserName { get; set; }
		private string FtpServer { get; set; }
		private string FtpServerDirectory { get; set; }
		private string FtpConnectionString { get; set; }
		private const string FtpImagesDirectory = "components/com_virtuemart/shop_image/product";

		//public string ErrorMessage { get; private set; }
		//private HttpWebRequest Request { get; set; }
		//private HttpWebResponse Response { get; set; }
		//private WebClient WebClient { get; set; }

		public bool CheckFtpConnection(string server, string userName, string password, string serverDirectory)
		{
			var connectionString = String.Format("ftp://{0}/{1}", server, serverDirectory);
			var request = (FtpWebRequest) WebRequest.Create(connectionString);

			request.Method = WebRequestMethods.Ftp.ListDirectory;
			request.Credentials = new NetworkCredential(userName, password);
			request.UseBinary = true;
			request.KeepAlive = false;

			try
			{
				var response = request.GetResponse();
			}
			catch(Exception)
			{
				return false;
			}

			FtpServer = server;
			FtpUserName = userName;
			FtpServerDirectory = serverDirectory;
			FtpConnectionString = String.Format("{0}/{1}", connectionString, FtpImagesDirectory);

			return true;
		}

		public bool CheckDbConnection(string server, string userName, string password, string dbName)
		{
			var connectionString = String.Format("metadata=res://*/Virtuemart.csdl|res://*/Virtuemart.ssdl|res://*/Virtuemart.msl;provider=MySql.Data.MySqlClient;provider connection string=\"server={0};User Id={1};password={2};Persist Security Info=True;database={3}\"", server, userName, password, dbName);
			var virtuemart = new VirtuemartContainer(connectionString);

			try
			{
				var vmProducts = (from v in virtuemart.jos_vm_product select v).ToList();
			}
			catch (Exception)
			{
				return false;
			}

			DbConnectionString = connectionString;

			return true;
		}

		public string GetHtmlPageFromSite(string value)
		{
			StreamReader tempStream;

			try
			{
				tempStream = new StreamReader(Connection(value));
			}
			catch (WebException)
			{
				Thread.Sleep(new TimeSpan(0, 0, 5));
				tempStream = new StreamReader(Connection(value));
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
				stream.DiscardBufferedData();
				stream.BaseStream.Seek(0, SeekOrigin.Begin);
				inputString = stream.ReadToEnd();
			}
			stream.Close();

			return inputString;
		}

		private static Stream Connection(string value)
		{
			var request = (HttpWebRequest)WebRequest.Create(value);
			var response = (HttpWebResponse)request.GetResponse();
			return response.GetResponseStream();
		}

		//public bool DownloadFile(string fileDownload, string path, string fileName)
		//{
		//    try
		//    {
		//        if (String.IsNullOrEmpty(path) || String.IsNullOrEmpty(fileName) || String.IsNullOrEmpty(fileDownload))
		//            return false;

		//        WebClient = new WebClient();

		//        var tempPath = path.EndsWith("\\") ? path : path + "\\";

		//        WebClient.DownloadFile(new Uri(fileDownload), String.Format("{0}{1}", tempPath, fileName));
		//    }
		//    catch(Exception e)
		//    {
		//        ErrorMessage = e.Message;
		//        return false;
		//    }

		//    return true;
		//}

		//public static void FtpUploadFile(string server, string password, string username, string serverDirectory, string fileNameDirectory, string fileName)
		//{
		//    var ftpReturn = FtpConnection(server, username, password, serverDirectory, fileNameDirectory, fileName, true);
		//    var buffer = ftpReturn.Buffer;
		//    var request = ftpReturn.Request;

		//    try
		//    {
		//        var reqStream = request.GetRequestStream();
		//        reqStream.Write(buffer, 0, buffer.Length);
		//        reqStream.Close();
		//    }
		//    catch (Exception)
		//    {
		//        ftpReturn = FtpConnection(server, username, password, serverDirectory, fileNameDirectory, fileName, false);
		//        buffer = ftpReturn.Buffer;
		//        request = ftpReturn.Request;

		//        var reqStream = request.GetRequestStream();
		//        reqStream.Write(buffer, 0, buffer.Length);
		//        reqStream.Close();
		//    }
		//}

		//private static FtpReturn FtpConnection(string server, string username, string password, string serverDirectory, string fileNameDirectory, string fileName, bool usePassive)
		//{
		//    var ftpReturn = new FtpReturn();

		//    var request = (FtpWebRequest)WebRequest.Create(string.Format("ftp://{0}/{1}/{2}/{3}", server, serverDirectory, "components/com_virtuemart/shop_image/product", Path.GetFileName(fileName)));

		//    request.Method = WebRequestMethods.Ftp.UploadFile;
		//    request.Credentials = new NetworkCredential(username, password);
		//    request.UsePassive = usePassive;
		//    request.UseBinary = true;
		//    request.KeepAlive = false;

		//    var stream = File.OpenRead(String.Format("{0}/{1}", fileNameDirectory, fileName));
		//    var buffer = new byte[stream.Length];

		//    stream.Read(buffer, 0, buffer.Length);
		//    stream.Close();

		//    ftpReturn.Buffer = buffer;
		//    ftpReturn.Request = request;

		//    return ftpReturn;
		//}

		//private class FtpReturn
		//{
		//    public FtpWebRequest Request { get; set; }
		//    public Byte[] Buffer { get; set; }
		//}
	}
}
