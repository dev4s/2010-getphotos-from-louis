using System;
using System.IO;
using NUnit.Framework;

namespace GetPhotosFromLouis.Tests
{
	[TestFixture]
	class ProductChecksTests
	{
		public static string Path(string value)
		{
			return String.Format(@"{0}\{1}\{2}", Environment.CurrentDirectory, @"..\..\TestFiles", value);
		}

		[Test]
		public void FirstChecksCheckIfStreamIsEmpty()
		{
			//Assert.That(ProductChecks.Start(null), Is.Null);
		}

		//TODO: All below tests

		[Test]
		public void FirstChecksShouldReturnString()
		{
			//var testStream = new StreamReader(Path("AllPassed.txt"));
			//var returnStream = new StreamReader(Path("AllPassed.txt"));

			//Assert.That(ProductChecks.Start(testStream), Is.EqualTo(returnStream.ReadToEnd()));
		}

		[Test]
		public void FirstChecksWhenCategoryDoesNotExistsShouldReturnNull()
		{
			//var testStream = new StreamReader(Path("WithBlockedText.txt"));

			//Assert.That(ProductChecks.Start(testStream), Is.Null);
		}

		[Test]
		public void FirstChecksCheckFiltering()
		{
			//var testStream = new StreamReader(Path("FilteredText.txt"));

			//Assert.That(ProductChecks.Start(testStream), Is.EqualTo("<body></body>"));
		}

		[Test]
		public void CheckGettingMainCategory()
		{
			//var testStream = new StreamReader(Path("MainCategory.txt"));
			//var testString = ProductChecks.Start(testStream);

			//Assert.That(ProductChecks.GetMainCategory(testString), Is.EqualTo("Clothing_&_Helmets"));

			//testString = "<a class=\"leftmenuboldred\">Products/Helmets/Base</a>";

			//Assert.That(ProductChecks.GetMainCategory(testString), Is.EqualTo("Products-Helmets-Base"));
		}

		[Test]
		public void CheckGettingSubCategory()
		{
			//var testStream = new StreamReader(Path("SubCategory.txt"));
			//var testString = ProductChecks.Start(testStream);

			//Assert.That(ProductChecks.GetSubCategory(testString), Is.EqualTo("Accessories"));

			//testStream = new StreamReader(Path("SubCategory2.txt"));
			//testString = ProductChecks.Start(testStream);

			//Assert.That(ProductChecks.GetSubCategory(testString), Is.EqualTo("Accessories"));

			//testString = "<a class=\"leftmenured\">Products/Helmets/Base</a>";

			//Assert.That(ProductChecks.GetSubCategory(testString), Is.EqualTo("Products-Helmets-Base"));
		}

		[Test]
		public void CheckGettingProductsUrl()
		{
			//var testStream = new StreamReader(Path("AllItems.txt"));
			//var testString = ProductChecks.Start(testStream);

			//Assert.That(ProductChecks.GetProductUrl(testString).Count, Is.GreaterThan(0));
			//Assert.That(ProductChecks.GetProductUrl(testString).Count, Is.EqualTo(9));
			//Assert.That(ProductChecks.GetProductUrl(testString)[0], Is.Not.StringContaining("<a"));
			//Assert.That(ProductChecks.GetProductUrl(testString)[0], Is.StringStarting("http"));
		}

		[Test]
		public void CheckGettingProductsName()
		{
			//var testStream = new StreamReader(Path("AllItems.txt"));
			//var testString = ProductChecks.Start(testStream);

			//Assert.That(ProductChecks.GetProductNames(testString).Count, Is.GreaterThan(0));
			//Assert.That(ProductChecks.GetProductNames(testString).Count, Is.EqualTo(9));
			//Assert.That(ProductChecks.GetProductNames(testString)[0], Is.Not.StringContaining("<a"));
			//Assert.That(ProductChecks.GetProductNames(testString)[0], Is.Not.StringContaining("&amp;"));
			//Assert.That(ProductChecks.GetProductNames(testString)[0], Is.Not.StringContaining("/"));
			//Assert.That(ProductChecks.GetProductNames(testString)[0], Is.Not.StringContaining("*"));
			//Assert.That(ProductChecks.GetProductNames(testString)[0], Is.Not.StringContaining("\""));
		}
		
		[Test]
		public void CheckUpdateProductsList()
		{
			//var testStream = new StreamReader(Path("AllItems.txt"));
			//var testString = ProductChecks.Start(testStream);

			//ProductChecks.UpdateProductsList(testString);

			//Assert.That(ProductChecks.Products.Count, Is.GreaterThan(0));
			//Assert.That(ProductChecks.Products.Count, Is.EqualTo(9));
			//Assert.That(ProductChecks.Products[0].Name, Is.Not.StringContaining("<a"));
			//Assert.That(ProductChecks.Products[0].MainCategory, Is.Not.StringContaining("<a"));
			//Assert.That(ProductChecks.Products[0].ProductUrl, Is.Not.StringContaining("<a"));
			//Assert.That(ProductChecks.Products[0].SubCategory, Is.Not.StringContaining("<a"));
			//Assert.That(ProductChecks.Products[0].ProductPhoto, Is.Empty);
		}

		[Test]
		public void CheckGettingProductBigImageUrl()
		{
			//var testStream = new StreamReader(Path("ProductDetails.txt"));
			//var testString = ProductChecks.Start(testStream);

			//Assert.That(ProductChecks.GetProductBigImageUrl(testString), Is.Not.StringContaining("<a"));
			//Assert.That(ProductChecks.GetProductBigImageUrl(testString), Is.StringStarting("http"));
			//Assert.That(ProductChecks.GetProductBigImageUrl(testString), Is.StringContaining("php"));
		}

		[Test]
		public void CheckGettingProductBigImageFromUrl()
		{
			//var testStream = new StreamReader(Path("ProductBigImage1.txt"));
			//var testString = ProductChecks.Start(testStream);

			//Assert.That(ProductChecks.GetProductBigImageFromUrl(testString), Is.Not.StringContaining("<a"));
			//Assert.That(ProductChecks.GetProductBigImageFromUrl(testString), Is.StringStarting("http"));
			//Assert.That(ProductChecks.GetProductBigImageFromUrl(testString), Is.StringEnding("JPG"));

			//testStream = new StreamReader(Path("ProductBigImage2.txt"));
			//testString = ProductChecks.Start(testStream);

			//Assert.That(ProductChecks.GetProductBigImageFromUrl(testString), Is.Not.StringContaining("<a"));
			//Assert.That(ProductChecks.GetProductBigImageFromUrl(testString), Is.StringStarting("http"));
			//Assert.That(ProductChecks.GetProductBigImageFromUrl(testString), Is.StringEnding("JPG"));

			//testStream = new StreamReader(Path("ProductBigImage3.txt"));
			//testString = ProductChecks.Start(testStream);

			//Assert.That(ProductChecks.GetProductBigImageFromUrl(testString), Is.Not.StringContaining("<a"));
			//Assert.That(ProductChecks.GetProductBigImageFromUrl(testString), Is.StringStarting("http"));
			//Assert.That(ProductChecks.GetProductBigImageFromUrl(testString), Is.StringEnding("JPG"));
		}

		[Test]
		public void CheckGettingProductNumbers()
		{
			//var testStream = new StreamReader(Path("ProductDetails.txt"));
			//var testString = ProductChecks.Start(testStream);

			//Assert.That(ProductChecks.GetProductNumbers(testString)[0], Is.Not.StringContaining("<td"));
			//Assert.That(ProductChecks.GetProductNumbers(testString)[0], Is.Not.StringEnding(">"));

			//testStream = new StreamReader(Path("ProductDetails2.txt"));
			//testString = ProductChecks.Start(testStream);

			//Assert.That(ProductChecks.GetProductNumbers(testString)[0], Is.Not.StringContaining("<td"));
			//Assert.That(ProductChecks.GetProductNumbers(testString)[0], Is.Not.StringEnding(">"));
		}
	}
}
