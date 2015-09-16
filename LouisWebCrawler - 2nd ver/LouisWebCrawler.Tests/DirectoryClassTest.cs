using System.IO;
using NUnit.Framework;

namespace LouisWebCrawler.Tests
{
	[TestFixture]
	class DirectoryClassTest
	{
		[Test]
		public void CheckCreatingDirectory()
		{
			var path = TestHelpers.Path("");

			DirectoryClass.CreateDirectory(path + "Accessories\\Test");
			var directory = new DirectoryInfo(path);

			Assert.That(directory.GetDirectories("Accessories")[0].Name, Is.EqualTo("Accessories"));
			Assert.That(directory.GetDirectories("Accessories\\Test")[0].Name, Is.EqualTo("Test"));

			directory.GetDirectories("Accessories")[0].Delete(true);
		}

		[Test]
		public void CheckCopyingFile()
		{
			var path = TestHelpers.Path("");
			var fileName = new FileInfo(path + "AllItems.txt");

			DirectoryClass.CopyFile(fileName.FullName, path + "AllItems2.txt");
			fileName = new FileInfo(path + "AllItems2.txt");

			Assert.That(fileName.Exists, Is.True);
			Assert.That(fileName.Length, Is.GreaterThan(0));

			fileName.Delete();
		}

		[Test]
		public void CheckDeletingFile()
		{
			var path = TestHelpers.Path("");
			var fileName = new FileInfo(path + "AllItems.txt");

			DirectoryClass.CopyFile(fileName.FullName, path + "AllItems2.txt");
			fileName = new FileInfo(path + "AllItems2.txt");

			DirectoryClass.Deletefile(fileName.FullName);

			Assert.That(fileName.Exists, Is.Not.True);
		}
	}
}
