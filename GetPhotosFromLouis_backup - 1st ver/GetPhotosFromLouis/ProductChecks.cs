using System.Collections.Generic;

namespace GetPhotosFromLouis
{
	public static class ProductChecks
	{
		private const string StartOfBody = @"\<body.*\>";
		private const string ProductsInCategoryDoesNotExist = "No matching products were found.";

		private const string MainCategory = "\\<a.*class=\"?leftmenuboldred\"?.*\\>(?<text>.*)\\</a\\>";
		private const string SubCategory = "\\<a.*class=\"?leftmenured\"?.*\\>(?<text>.*)\\</a\\>";
		private const string ProductName = "\\<a.*class=\"?produktbez\"?.*\\>(?<text>.*)\\</a\\>";
		private const string ProductUrl = "\\<a.*href=\"(?<text>.*)\".*class=\"?produktbez\"?.*\\>.*\\</a\\>";
		private const string ProductBigImageUrl = "\\<a.*class=\"contentlink\".*onclick=\".*\\('(?<text>.*)','p";
		private const string ProductBigImageFromUrl = "\\('\\<img.*src=\"(?<text>.*)\" w.*";
		private const string ProductNumbers = "\\<td class=\"?tdwhite\"? valign=\"top\"\\>(?<text>\\d*)\\</td\\>";

		public static string RemoveBodyStart(string inputString)
		{ 
			return RegexClass.CleanBegginigOfNode(StartOfBody, inputString);
		}

		public static string DoesNotExist(string inputString)
		{
			return RegexClass.CheckRegexSuccess(ProductsInCategoryDoesNotExist, inputString) ? null : inputString;
		}

		public static string GetMainCategory(string value)
		{
			var temp = RegexClass.GetTextFromString(MainCategory, value);
			temp = RegexClass.CleanText("/", temp, "-");
			temp = RegexClass.CleanText("\\*", temp, "");
			temp = RegexClass.CleanText("\"", temp, "");
			temp = RegexClass.CleanText(" ", temp, "_");
			return RegexClass.CleanText("&amp;", temp, "&");
		}

		public static string GetSubCategory(string value)
		{
			var temp = RegexClass.GetTextFromString(SubCategory, value);
			temp = RegexClass.CleanText("/", temp, "-");
			temp = RegexClass.CleanText("\\*", temp, "");
			temp = RegexClass.CleanText("\"", temp, "");
			temp = RegexClass.CleanText(" ", temp, "_");
			return RegexClass.CleanText("&amp;", temp, "&");
		}

		public static IList<string> GetProductNames(string value)
		{
			var listOfNames = RegexClass.GetAllMatches(ProductName, value);
			for (var i = 0; i < listOfNames.Count; i++)
			{
				listOfNames[i] = RegexClass.CleanText("/", listOfNames[i], "-");
				listOfNames[i] = RegexClass.CleanText("&amp;", listOfNames[i], "&");
				listOfNames[i] = RegexClass.CleanText("\\*", listOfNames[i], "");
				listOfNames[i] = RegexClass.CleanText("\"", listOfNames[i], "");
				listOfNames[i] = RegexClass.CleanText(":", listOfNames[i], "");
				listOfNames[i] = RegexClass.CleanText(" ", listOfNames[i], "_");
			}

			return listOfNames;
		}

		public static IList<string> GetProductUrl(string value)
		{
			return RegexClass.GetAllMatches(ProductUrl, value);
		}

		public static string GetProductBigImageUrl(string value)
		{
			return RegexClass.GetTextFromString(ProductBigImageUrl, value);
		}

		public static string GetProductBigImageFromUrl(string value)
		{
			return RegexClass.GetTextFromString(ProductBigImageFromUrl, value);
		}

		public static IList<string> GetProductNumbers(string value)
		{
			return RegexClass.GetAllMatches(ProductNumbers, value);
		}
	}
}
