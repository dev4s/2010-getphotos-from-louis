using System.Collections.Generic;

namespace LouisWebCrawler
{
	public static class Helpers
	{
		private static readonly List<string> RegexList = new List<string> { "/", "\\*", "\"", " ", "&amp;", ":" };
		private static readonly List<string> ReplaceList = new List<string> { "-", "", "", "_", "&", "" };

		private const string StartOfBody = @"\<body.*\>";
		private const string ProductsInCategoryDoesNotExist = "No matching products were found.";

		private const string MainCategory = "\\<a.*class=\"?leftmenuboldred\"?.*\\>(?<text>.*)\\</a\\>";
		private const string SubCategory = "\\<a.*class=\"?leftmenured\"?.*\\>(?<text>.*)\\</a\\>";
		private const string ProductName = "\\<a.*class=\"?produktbez\"?.*\\>(?<text>.*)\\</a\\>";
		private const string ProductUrl = "\\<a.*href=\"(?<text>.*)\".*class=\"?produktbez\"?.*\\>.*\\</a\\>";
		private const string ProductBigImageUrl = "\\<a.*class=\"contentlink\".*onclick=\".*\\('(?<text>.*)','p";
		private const string ProductBigImageFromUrl = "\\('\\<img.*src=\"(?<text>.*)\" w.*";
		private const string ProductNumbers = "\\<td class=\"?tdwhite\"? valign=\"top\"\\>(?<text>\\d*)\\</td\\>";

		public static string RemoveTextBeforeBodyTag(string inputString)
		{
			return RegexClass.CleanBegginigOfText(StartOfBody, inputString);
		}

		public static string ProductsExistance(string inputString)
		{
			return RegexClass.CheckRegexSuccess(ProductsInCategoryDoesNotExist, inputString) ? null : inputString;
		}

		public static string GetMainCategory(string value)
		{
			var temp = RegexClass.GetTextFromString(MainCategory, value);
			return RegexClass.CleanText(RegexList, temp, ReplaceList);
		}

		public static string GetSubCategory(string value)
		{
			var temp = RegexClass.GetTextFromString(SubCategory, value);
			return RegexClass.CleanText(RegexList, temp, ReplaceList);
		}

		public static List<string> GetProductNames(string value)
		{
			var listOfNames = RegexClass.GetAllMatches(ProductName, value);
			var count = listOfNames.Count;

			for (var i = 0; i < count; i++)
			{
				listOfNames[i] = RegexClass.CleanText(RegexList, listOfNames[i], ReplaceList);
			}

			return listOfNames;
		}

		public static List<string> GetProductUrl(string value)
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

		public static List<string> GetProductNumbers(string value)
		{
			return RegexClass.GetAllMatches(ProductNumbers, value);
		}
	}
}
