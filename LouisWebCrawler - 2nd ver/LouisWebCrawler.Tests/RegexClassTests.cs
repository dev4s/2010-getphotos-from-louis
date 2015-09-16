using NUnit.Framework;
using System.Collections.Generic;

namespace LouisWebCrawler.Tests
{
	[TestFixture]
	public class RegexClassTests
	{
		[Test]
		public void CheckIfEmptyValuesInMethodReturnFalse()
		{
			Assert.That(RegexClass.CheckRegexSuccess("", ""), Is.False);
		}

		[Test]
		public void CheckRegexSuccessCheckIfOneOfTheValueIsEmptyMethodShouldReturnFalse()
		{
			Assert.That(RegexClass.CheckRegexSuccess("", "asdfasd"), Is.False);
			Assert.That(RegexClass.CheckRegexSuccess("sdfasdf", ""), Is.False);
		}

		[Test]
		public void CheckRegexSuccessMethodShouldReturnTrueIfFindedText()
		{
			Assert.That(RegexClass.CheckRegexSuccess("a", "ssssaaa"), Is.True);
		}

		[Test]
		public void CheckRegexSuccessMethodShouldReturnFalseIfNotFindAText()
		{
			Assert.That(RegexClass.CheckRegexSuccess("a", "sssss"), Is.False);
		}

		[Test]
		public void CleanBegginigOfNodeCheckIfEmptyValueReturnNull()
		{
			Assert.That(RegexClass.CleanBegginigOfText("", ""), Is.Null);
		}

		[Test]
		public void CleanBegginigOfNodeCheckIfMethodReturnNullIfOneOfTheValuesIsEmpty()
		{
			Assert.That(RegexClass.CleanBegginigOfText("", "aaasss"), Is.Null);
			Assert.That(RegexClass.CleanBegginigOfText("sssaaa", ""), Is.Null);
		}

		[Test]
		public void CleanBegginigOfNodeMethodShouldCleanTheBeggining()
		{
			Assert.That(RegexClass.CleanBegginigOfText(@"\<a", "razdwatrzy<asss"), Is.EqualTo("<asss"));
		}

		[Test]
		public void GetTextFromStringCheckIfEmptyValueReturnNull()
		{
			Assert.That(RegexClass.GetTextFromString("", ""), Is.Null);
		}

		[Test]
		public void GetTextFromStringCheckIfMethodReturnNullIfOneOfTheValuesIsEmpty()
		{
			Assert.That(RegexClass.GetTextFromString("", "aass"), Is.Null);
			Assert.That(RegexClass.GetTextFromString("aass", ""), Is.Null);
		}

		[Test]
		public void GetTextFromStringShouldReturnSubString()
		{
			Assert.That(RegexClass.GetTextFromString(@"\d+(?<text>[a-z]+)\d+", "123abc123"), Is.EqualTo("abc"));
			Assert.That(RegexClass.GetTextFromString(@"\<.*\>(?<text>.*)\</a\>", "<a href=\"http://text\">bla bla</a>"), Is.EqualTo("bla bla"));
		}

		[Test]
		public void CleanTextCheckings()
		{
			Assert.That(RegexClass.CleanText("&amp;", "Clothing &amp; Helmets", "&"), Is.EqualTo("Clothing & Helmets"));
			Assert.That(RegexClass.CleanText("/", "Clothing/Helmets/Base", "-"), Is.EqualTo("Clothing-Helmets-Base"));
		}
		
		[Test]
		public void CleanTextCheckingsWithGroups()
		{
			var regexText = new List<string> {"&amp;", " ", ":", ";"};
			var replaceWith = new List<string> {"&", "_", "", ""};

			Assert.That(RegexClass.CleanText(regexText, "Clothing &amp; Helmets:;", replaceWith), Is.EqualTo("Clothing_&_Helmets"));
		}

		[Test]
		public void GetAllMatchesCheckings()
		{
			Assert.That(RegexClass.GetAllMatches("a", "abaa").Count, Is.EqualTo(3));
			Assert.That(RegexClass.GetAllMatches("\\<a.*class=\"produktbez\".*\\>(?<text>.*)\\</a\\>", "<a class=\"produktbez\" >raz, dwa, trzy</a>")[0], Is.EqualTo("raz, dwa, trzy"));
		}
	}
}
