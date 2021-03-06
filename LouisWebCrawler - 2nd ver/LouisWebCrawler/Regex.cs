﻿using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace LouisWebCrawler
{
	public static class RegexClass
	{
		static public bool CheckRegexSuccess(string regexText, string textForCheck)
		{
			if (string.IsNullOrEmpty(regexText) || string.IsNullOrEmpty(textForCheck))
				return false;

			return new Regex(regexText).Match(textForCheck).Success;
		}

		public static string CleanBegginigOfText(string regexText, string textForCheck)
		{
			if (string.IsNullOrEmpty(regexText) || string.IsNullOrEmpty(textForCheck))
				return null;

			var regex = new Regex(regexText).Match(textForCheck).Index;

			return textForCheck.Remove(0, regex);
		}

		public static string GetTextFromString(string regexText, string textForCheck)
		{
			if (string.IsNullOrEmpty(regexText) || string.IsNullOrEmpty(textForCheck))
				return null;

			return new Regex(regexText).Match(textForCheck).Groups["text"].Value;
		}

		public static string CleanText(string regexText, string textForCheck, string replaceWith)
		{
			return new Regex(regexText).Replace(textForCheck, replaceWith);
		}

		public static string CleanText(List<string> regextText, string textForCheck, List<string> replaceWith)
		{
			for (var i = 0; i < regextText.Count; i++)
			{
				textForCheck = new Regex(regextText[i]).Replace(textForCheck, replaceWith[i]);
			}

			return textForCheck;
		}

		public static List<string> GetAllMatches(string regexText, string textForCheck)
		{
			var matches = new Regex(regexText).Matches(textForCheck);

			return (from Match match in matches select match.Groups["text"].Value).ToList();
		}
	}
}
