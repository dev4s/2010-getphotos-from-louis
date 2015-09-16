using System.IO;
using NUnit.Framework;

namespace LouisWebCrawler.Tests
{
	[TestFixture]
	class HelpersTests
	{
		[Test]
		public void CheckIfTextBeforeBodyIsDeleted()
		{
			var testString = TestHelpers.ReturnStringFromFile("FilteredText.txt");

			var result = Helpers.RemoveTextBeforeBodyTag(testString);

			Assert.That(result, Is.EqualTo("<body></body>"));
		}

		[Test]
		public void CheckIfProductsExistanceReturnTextWhenIsOk()
		{
			var testString = TestHelpers.ReturnStringFromFile("SubCategory.txt");

			var result = Helpers.ProductsExistance(testString);

			Assert.That(result, Is.Not.Null);
		}
		
		[Test]
		public void CheckIfProductsExistanceReturnTextWhenTextIsMatched()
		{
			var testString = TestHelpers.ReturnStringFromFile("WithBlockedText.txt");

			var result = Helpers.ProductsExistance(testString);

			Assert.That(result, Is.Null);
		}

		[Test]
		public void CheckGettingMainCategory()
		{
			var testString = TestHelpers.ReturnStringFromFile("MainCategory.txt");
			Assert.That(Helpers.GetMainCategory(testString), Is.EqualTo("Clothing_&_Helmets"));

			testString = "<a class=\"leftmenuboldred\">Products/Helmets/Base</a>";
			Assert.That(Helpers.GetMainCategory(testString), Is.EqualTo("Products-Helmets-Base"));
		}

		[Test]
		public void CheckGettingSubCategory()
		{
			var testString = TestHelpers.ReturnStringFromFile("SubCategory.txt");
			Assert.That(Helpers.GetSubCategory(testString), Is.EqualTo("Accessories"));

			testString = TestHelpers.ReturnStringFromFile("SubCategory2.txt");
			Assert.That(Helpers.GetSubCategory(testString), Is.EqualTo("Accessories"));

			testString = "<a class=\"leftmenured\">Products/Helmets/Base</a>";
			Assert.That(Helpers.GetSubCategory(testString), Is.EqualTo("Products-Helmets-Base"));
		}

		[Test]
		public void CheckGettingProductsName()
		{
			var testString = TestHelpers.ReturnStringFromFile("AllItems.txt");

			var result = Helpers.GetProductNames(testString);

			Assert.That(result.Count, Is.GreaterThan(0));
			Assert.That(result.Count, Is.EqualTo(9));

			foreach (var r in result)
			{
				Assert.That(r, Is.Not.StringContaining("<a"));
				Assert.That(r, Is.Not.StringContaining("&amp;"));
				Assert.That(r, Is.Not.StringContaining("/"));
				Assert.That(r, Is.Not.StringContaining("*"));
				Assert.That(r, Is.Not.StringContaining("\""));
				Assert.That(r, Is.Not.StringContaining(" "));
				Assert.That(r, Is.Not.StringContaining(":"));	
			}
		}

		[Test]
		public void CheckGettingProductsUrl()
		{
			var testString = TestHelpers.ReturnStringFromFile("AllItems.txt");

			var result = Helpers.GetProductUrl(testString);

			Assert.That(result.Count, Is.GreaterThan(0));
			Assert.That(result.Count, Is.EqualTo(9));

			foreach (var r in result)
			{
				Assert.That(r, Is.Not.StringContaining("<a"));
				Assert.That(r, Is.StringStarting("http"));
			}
		}

		[Test]
		public void CheckGettingProductBigImageUrl()
		{
			var testString = TestHelpers.ReturnStringFromFile("ProductDetails.txt");

			var result = Helpers.GetProductBigImageUrl(testString);

			Assert.That(result, Is.Not.StringContaining("<a"));
			Assert.That(result, Is.StringStarting("http"));
			Assert.That(result, Is.StringContaining("php"));
		}

		[Test]
		public void CheckGettingProductBigImageFromUrl()
		{
			var testString = TestHelpers.ReturnStringFromFile("ProductBigImage1.txt");
			var result = Helpers.GetProductBigImageFromUrl(testString);

			Assert.That(result, Is.Not.StringContaining("<a"));
			Assert.That(result, Is.StringStarting("http"));
			Assert.That(result, Is.StringEnding("JPG"));

			testString = TestHelpers.ReturnStringFromFile("ProductBigImage2.txt");
			result = Helpers.GetProductBigImageFromUrl(testString);

			Assert.That(result, Is.Not.StringContaining("<a"));
			Assert.That(result, Is.StringStarting("http"));
			Assert.That(result, Is.StringEnding("JPG"));

			testString = TestHelpers.ReturnStringFromFile("ProductBigImage3.txt");
			result = Helpers.GetProductBigImageFromUrl(testString);

			Assert.That(result, Is.Not.StringContaining("<a"));
			Assert.That(result, Is.StringStarting("http"));
			Assert.That(result, Is.StringEnding("JPG"));
		}


		[Test]
		public void CheckGettingProductNumbers()
		{
			var testString = TestHelpers.ReturnStringFromFile("ProductDetails.txt");
			var result = Helpers.GetProductNumbers(testString);

			foreach (var r in result)
			{
				Assert.That(r, Is.Not.StringContaining("<td"));
				Assert.That(r, Is.Not.StringEnding(">"));
			}

			testString = TestHelpers.ReturnStringFromFile("ProductDetails2.txt");
			result = Helpers.GetProductNumbers(testString);

			foreach (var r in result)
			{
				Assert.That(r, Is.Not.StringContaining("<td"));
				Assert.That(r, Is.Not.StringEnding(">"));
			}
		}

		//[Test]
		//public void CheckUpdateProductsList()
		//{
		//    var testStream = new StreamReader(Path("AllItems.txt"));
		//    var testString = ProductChecks.Start(testStream);

		//    ProductChecks.UpdateProductsList(testString);

		//    Assert.That(ProductChecks.Products.Count, Is.GreaterThan(0));
		//    Assert.That(ProductChecks.Products.Count, Is.EqualTo(9));
		//    Assert.That(ProductChecks.Products[0].Name, Is.Not.StringContaining("<a"));
		//    Assert.That(ProductChecks.Products[0].MainCategory, Is.Not.StringContaining("<a"));
		//    Assert.That(ProductChecks.Products[0].ProductUrl, Is.Not.StringContaining("<a"));
		//    Assert.That(ProductChecks.Products[0].SubCategory, Is.Not.StringContaining("<a"));
		//    Assert.That(ProductChecks.Products[0].ProductPhoto, Is.Empty);
		//}
	}
}
