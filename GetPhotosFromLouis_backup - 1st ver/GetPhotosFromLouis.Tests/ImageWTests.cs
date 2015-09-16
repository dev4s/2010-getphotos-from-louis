using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace GetPhotosFromLouis.Tests
{
	[TestFixture]
	class ImageWTests
	{
		[Test]
		public void ShouldReturnOnlyFilename()
		{
			const string testString = "C:\\test\\test\\test\\nazwa.txt";

			Assert.That(ImageW.ReturnOnlyFilename(testString), Is.EqualTo("nazwa.txt"));
		}
	}
}
