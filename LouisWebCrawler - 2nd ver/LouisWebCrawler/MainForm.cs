using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace LouisWebCrawler
{
	public partial class MainForm : Form
	{
		private string _destinationFolder;
		private WebClass _webClass;
		private List<Product> _products = new List<Product>();

		private const int AmountOfSites = 1000;

		public MainForm()
		{
			InitializeComponent();
			progressBar.Minimum = 0;
			progressBar.Maximum = AmountOfSites;
			progressBar.Step = 1;
		}

		private void DirectoryBtnClick(object sender, EventArgs e)
		{
			if (folderBrowserDialog.ShowDialog() != DialogResult.OK) return;

			directoryLabel.Text = folderBrowserDialog.SelectedPath;
			_destinationFolder = folderBrowserDialog.SelectedPath;
		}

		private void DownloadBtnClick(object sender, EventArgs e)
		{
			CheckGroups();
			CheckConnections();

			if (_webClass == null) return;
			var newThread = new Thread(GetAllPhotosFromLouisMain);
			newThread.Start();
		}
	}
}
