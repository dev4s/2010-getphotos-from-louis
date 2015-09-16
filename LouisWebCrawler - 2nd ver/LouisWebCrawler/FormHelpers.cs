using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LouisWebCrawler
{
	public static class FormHelpers
	{
		public static List<string> GetText(GroupBox groupBox)
		{
			var result = new List<string>();

			foreach (var control in groupBox.Controls)
			{
				try
				{
					var tempBox = (TextBox)control;
					result.Add(tempBox.Text);
				}
				catch (Exception)
				{
					continue;
				}
			}

			return result;
		}

		public static void ShowErrorMessage(string errorMsg)
		{
			MessageBox.Show(errorMsg, "Wystąpił błąd!", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
	}
}
