using System.Windows.Forms;
using NUnit.Framework;

namespace LouisWebCrawler.Tests
{
	[TestFixture]
	class FormHelpersTests
	{
		[Test]
		public void CheckGetTextFromEmptyGroupBox()
		{
			var groupBox = new GroupBox();

			var result = FormHelpers.GetText(groupBox);

			Assert.That(result.Count, Is.EqualTo(0));
		}

		[Test]
		public void CheckGetTextFromGroupBoxWithDifferentElements()
		{
			const string testString = "Testing";
			var groupBox = new GroupBox();
			var textBox1 = new TextBox();
			var textBox2 = new TextBox();
			var textBox3 = new TextBox();
			var label1 = new Label();
			var label2 = new Label();

			textBox1.Text = textBox2.Text = textBox3.Text = testString;

			groupBox.Controls.Add(textBox1);
			groupBox.Controls.Add(textBox2);
			groupBox.Controls.Add(textBox3);
			groupBox.Controls.Add(label1);
			groupBox.Controls.Add(label2);

			var result = FormHelpers.GetText(groupBox);

			Assert.That(result.Count, Is.EqualTo(3));
			foreach (var r in result)
			{
				Assert.That(r, Is.EqualTo(testString));
			}
		}
	}
}
