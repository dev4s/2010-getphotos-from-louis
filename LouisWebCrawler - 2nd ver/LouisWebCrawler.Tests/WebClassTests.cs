using System;
using System.IO;
using System.Net;
using NUnit.Framework;

namespace LouisWebCrawler.Tests
{
	[TestFixture]
	class WebClassTests
	{
		[Test]
		public void CheckGetHtmlPageFromSiteWithEmptyValue()
		{
			var webclass = new WebClass();
			Assert.Throws<UriFormatException>(() => webclass.GetHtmlPageFromSite(""));
		}

		[Test]
		public void CheckGetHtmlPageFromSiteWhenSiteDoesNotExist()
		{
			var webclass = new WebClass();
			Assert.Throws<WebException>(() => webclass.GetHtmlPageFromSite("http://blablablabla.asdfasdf.com.pl"));
		}

		[Test]
		public void CheckGetHtmlPageFromSiteWhenSiteDoesExists()
		{
			var webclass = new WebClass();
			Assert.That(webclass.GetHtmlPageFromSite("http://google.pl"), Is.Not.Null);
		}

		//[Test]
		//public void CheckDownloadingOfAFileWithoutAPathAndFilename()
		//{
		//    var webclass = new WebClass();
		//    Assert.That(webclass.DownloadFile("", "", ""), Is.False);
		//}

		//[Test]
		//public void CheckDownloadingOfAFile()
		//{
		//    var webclass = new WebClass();

		//    var tempPath = TestHelpers.Path("");
		//    const string fileName = "20000152_290_FR01_11.JPG";
		//    const string url = "http://www.louis.de/shop/img450/" + fileName;

		//    webclass.DownloadFile(url, tempPath, fileName);

		//    var fileInfo = new FileInfo(tempPath + fileName);

		//    Assert.That(fileInfo.Exists, Is.True);
		//    Assert.That(fileInfo.Length, Is.GreaterThan(0));

		//    fileInfo.Delete();
		//}

		[Test]
		[Description("It depends on DB Connection")]
		public void CheckingCheckDbConnectionWithBadConnectionString()
		{
			var webclass = new WebClass();

			var result = webclass.CheckDbConnection("local", "local", "local", "local");

			Assert.That(result, Is.EqualTo(false));
		}
		
		[Test]
		[Description("It depends on DB Connection")]
		public void CheckingCheckDbConnectionWithGoodConnectionString()
		{
			var webclass = new WebClass();

			var result = webclass.CheckDbConnection("localhost", "root", "zaq12wsx", "tt_probny");

			Assert.That(result, Is.EqualTo(true));
		}

		[Test]
		[Description("It's depends on FTP connection")]
		public void CheckingCheckFtpConnectionWithGoodConnectionString()
		{
			var webclass = new WebClass();

			var result = webclass.CheckFtpConnection("localhost", "tomasz", "tomasz123", "");

			Assert.That(result, Is.EqualTo(true));
		}
		
		[Test]
		[Description("It's depends on FTP connection")]
		public void CheckingCheckFtpConnectionWithBadConnectionString()
		{
			var webclass = new WebClass();

			var result = webclass.CheckFtpConnection("test", "test", "test", "");

			Assert.That(result, Is.EqualTo(false));
		}

		//[Ignore("Needs an FTP Connection, I don't know how to test it without it")]
		//[Test]
		//public void FtpUploadShouldUploadAFile()
		//{
		//    var webclass = new WebClass();
		//    var directory = TestHelpers.Path("");
		//    //webclass.FtpUploadFile("xaneak.mine.nu", "pawel123", "pawel", directory, "SubCategory.txt");
		//}
	}
}
