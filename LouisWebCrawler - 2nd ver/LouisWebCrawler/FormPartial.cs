using System;
using System.Linq;
using System.Threading;

namespace LouisWebCrawler
{
	public partial class MainForm
	{
		private const string LouisMainSite = "http://www.louis.de/index.php?topic=wgr&lang=en&grwgr=";

		private void GroupsEnabled(bool value)
		{
			ftpGroupBox.Enabled = value;
			dbGroupBox.Enabled = value;
		}

		private void FolderBtnEnabled(bool value)
		{
			directoryBtn.Enabled = value;
		}

		private void CheckGroups()
		{
			var isNotOk = false;
			var ftpGroupBoxStrings = FormHelpers.GetText(ftpGroupBox);
			var dbGroupBoxStrings = FormHelpers.GetText(dbGroupBox);

			if (ftpGroupBoxStrings.Count != 0)
			{
				foreach (var ftp in ftpGroupBoxStrings.Where(String.IsNullOrEmpty))
				{
					isNotOk = true;
				}
			}

			if (dbGroupBoxStrings.Count == 0) return;
			foreach (var db in dbGroupBoxStrings.Where(String.IsNullOrEmpty))
			{
				isNotOk = true;
			}

			if (isNotOk)
			{
				FormHelpers.ShowErrorMessage("Jedna z komórek jest niepoprawnie wypełniona!");
				GroupsEnabled(true);
				FolderBtnEnabled(true);
			}
			else
			{
				GroupsEnabled(false);
				FolderBtnEnabled(false);
			}
		}

		private void CheckConnections()
		{
			var isDbNotOk = false;
			var isFtpNotOk = false;

			var ftpD = ftpDestinationFolderTextBox.Text;
			var ftpP = ftpPasswordTextBox.Text;
			var ftpS = ftpServerNameTextBox.Text;
			var ftpU = ftpUsernameTextBox.Text;
			var dbD = dbDestinationDbTextBox.Text;
			var dbP = dbPasswordTextBox.Text;
			var dbS = dbServerNameTextBox.Text;
			var dbU = dbUsernameTextBox.Text;

			_webClass = new WebClass();
			if (_webClass.CheckDbConnection(dbS, dbU, dbP, dbD) == false)
			{
				isDbNotOk = true;
			}
			if (_webClass.CheckFtpConnection(ftpS, ftpU, ftpP, ftpD) == false)
			{
				isFtpNotOk = true;
			}

			if (isDbNotOk && isFtpNotOk)
			{
				FormHelpers.ShowErrorMessage("Nie można połączyć się do bazy danych i serwera FTP. Popraw dane.");
				GroupsEnabled(true);
				FolderBtnEnabled(true);
				_webClass = null;
			}
			else if (isDbNotOk)
			{
				FormHelpers.ShowErrorMessage("Nie można połączyć się do bazy danych. Popraw dane.");
				GroupsEnabled(true);
				FolderBtnEnabled(true);
				_webClass = null;
			}
			else if (isFtpNotOk)
			{
				FormHelpers.ShowErrorMessage("Nie można połączyć się do serwera FTP. Popraw dane.");
				GroupsEnabled(true);
				FolderBtnEnabled(true);
				_webClass = null;
			}
		}

		private void GetAllPhotosFromLouisMain()
		{
			var thread = new Thread(GetProductList);
			thread.Start();

			while (thread.IsAlive)
			{
				Thread.Sleep(100);
			}

			//TODO: after everything is made done make everything on form enabled
		}

		private void GetProductList()
		{
			var i = 0;

			for (; i <= AmountOfSites; i++)
			{
				var tempHtmlPage = _webClass.GetHtmlPageFromSite(LouisMainSite + i);

				if (String.IsNullOrEmpty(tempHtmlPage)) tempHtmlPage = _webClass.GetHtmlPageFromSite(LouisMainSite + i);
				if (String.IsNullOrEmpty(tempHtmlPage)) break;

				if (!String.IsNullOrEmpty(Helpers.ProductsExistance(tempHtmlPage)))
				{
					var louisProducts = String.Format("{0}{1}&page=", LouisMainSite, i);
				}

				ProgressBarPerformStep();
			}

			if (i != AmountOfSites)
			{
				FormHelpers.ShowErrorMessage("Nie udało się przetworzyć jednej ze stron: " + i);
			}
		}

		//delegaty
		private delegate void ProgressBarCallBack();
		private void ProgressBarPerformStep()
		{
			if (InvokeRequired)
			{
				ProgressBarCallBack upbc = (ProgressBarPerformStep);
				Invoke(upbc);
			}
			else
			{
				progressBar.PerformStep();
			}
		}
	}
}
