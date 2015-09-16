using System;
using System.IO;
using System.Net;
using NUnit.Framework;

namespace GetPhotosFromLouis.Tests
{
	[TestFixture]
	class WebClassTests
	{
		[Test]
		public void ConnectingToSiteEmptyValue()
		{
			var webclass = new WebClass();
			Assert.Throws<UriFormatException>(() => webclass.ConnectingToSite(""));
		}

		[Test]
        [Ignore]
		public void ConnectingToSiteSiteDoesNotExist()
		{
			var webclass = new WebClass();
			Assert.Throws<WebException>(() => webclass.ConnectingToSite("http://blablablabla.asdfasdf.com.pl"));
		}

		[Test]
		public void ConnectingToSiteThatDoesExists()
		{
			var webclass = new WebClass();
			Assert.That(webclass.ConnectingToSite("http://google.pl"), Is.Not.Null);
		}

		[Test]
		public void CheckDownloadingOfAFileWithoutAPathAndFilename()
		{
			var webclass = new WebClass();
			Assert.That(webclass.DownloadFile("", "", ""), Is.False);
		}

		[Test]
		public void CheckDownloadingOfAFile()
		{
			var webclass = new WebClass();

			var tempPath = ProductChecksTests.Path("");
			const string fileName = "20000152_290_FR01_11.JPG";
			const string url = "http://www.louis.de/shop/img450/20000152_290_FR01_11.JPG";

			webclass.DownloadFile(url, tempPath, fileName);

			var fileInfo = new FileInfo(tempPath + fileName);
			
			Assert.That(fileInfo.Exists, Is.True);
			Assert.That(fileInfo.Length, Is.GreaterThan(0));

			fileInfo.Delete();
		}

		[Test]
		public void FtpUploadShouldUploadAFile()
		{
			var webclass = new WebClass();
			var directory = ProductChecksTests.Path("");
			//webclass.FtpUploadFile("xaneak.mine.nu", "pawel123", "pawel", directory, "SubCategory.txt");
		}
	}
}
