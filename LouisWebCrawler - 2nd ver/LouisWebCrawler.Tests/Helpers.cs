using System;
using System.IO;

namespace LouisWebCrawler.Tests
{
	static class TestHelpers
	{
		public static string Path(string value)
		{
			return String.Format(@"{0}\{1}\{2}", Environment.CurrentDirectory, @"..\..\TestFiles", value);
		}

		public static string ReturnStringFromFile(string fileName)
		{
			var path = Path("");
			var fileStream = new StreamReader(path + fileName);
			return fileStream.ReadToEnd();
		}
	}
}
