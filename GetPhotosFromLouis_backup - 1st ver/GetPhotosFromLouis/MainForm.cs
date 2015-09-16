using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GetPhotosFromLouis
{
	public partial class MainForm : Form
	{
		#region Metody i Atrybuty
		private const string FolderName = "Katalog";
		private static string _downloadFolder;

		private Threads CheckingThread { get; set; }
		private Threads UpdateProductListThreads { get; set; }
		private Threads GetPhotoUrlThreads { get; set; }
		private Threads DownloadAndCopyPhotosThreads { get; set; }
		private Threads FtpUploadThreads { get; set; }

		private int _counter = 1;
		private static readonly object LockProducts = new object();

		private bool Checking()
		{
			Threads.SleepTime(2500);

			while(UpdateProductListThreads.IsRunning())
			{
				Threads.SleepTime(750);
			}

			_counter = 1;
			//InformationBoxAdd(String.Format("Zakończono wstępne pobieranie: {0}", DateTime.Now));
			//InformationBoxScrollToEnd();

			//InformationBoxAdd("----------------------------------------------------------------------------------------------------------------------------------");
			//InformationBoxScrollToEnd();

			//InformationBoxAdd(String.Format("Rozpoczynam pobieranie URL dla Grafik: {0}", DateTime.Now));
			//InformationBoxScrollToEnd();

			//GetPhotoUrlThreads = new Threads(ProductChecks.Products.Count, GetPhotoUrl);
			//GetPhotoUrlThreads.Start();

			//Threads.SleepTime(2500);

			//while (GetPhotoUrlThreads.IsRunning())
			//{
			//    Threads.SleepTime(750);
			//}

			//_counter = 1;
			//InformationBoxAdd(String.Format("Zakończono pobieranie URL dla Grafik: {0}", DateTime.Now));
			//InformationBoxScrollToEnd();

			//InformationBoxAdd("----------------------------------------------------------------------------------------------------------------------------------");
			//InformationBoxScrollToEnd();

			//InformationBoxAdd(String.Format("Rozpoczynam pobieranie obrazów: {0}", DateTime.Now));
			//InformationBoxScrollToEnd();

			//foreach (var product in from product in ProductChecks.Products
			//                        from product2 in ProductChecks.Products
			//                        where product.Name == product2.Name
			//                        select product)
			//{
			//    product.Name += "-2";
			//}

			//DownloadAndCopyPhotosThreads = new Threads(ProductChecks.Products.Count, DownloadAndCopyPhotos);
			//DownloadAndCopyPhotosThreads.Start();

			//Threads.SleepTime(2500);

			//while (DownloadAndCopyPhotosThreads.IsRunning())
			//{
			//    Threads.SleepTime(750);
			//}

			//InformationBoxAdd(String.Format("Zakończono pobieranie obrazów: {0}", DateTime.Now));
			//InformationBoxScrollToEnd();

			//InformationBoxAdd("----------------------------------------------------------------------------------------------------------------------------------");
			//InformationBoxScrollToEnd();

			//var withoutPhoto = ProductChecks.Products.Where(product => product.ProductUrl == "");

			//InformationBoxAdd(String.Format("Produkty bez obrazów: {0}", withoutPhoto.Count()));
			//InformationBoxScrollToEnd();

			//foreach (var product in withoutPhoto)
			//{
			//    InformationBoxAdd(String.Format("Nazwa: {0}, kategoria: {1}/{2}", product.Name, product.MainCategory, product.SubCategory));
			//    InformationBoxScrollToEnd();
			//}

			//InformationBoxAdd("----------------------------------------------------------------------------------------------------------------------------------");
			//InformationBoxScrollToEnd();

			//InformationBoxAdd("Wysyłam obrazy na serwer");
			//InformationBoxScrollToEnd();

			//FtpUploadThreads = new Threads(FtpUpload);
			//FtpUploadThreads.Start();

			//Threads.SleepTime(2500);

			//while (FtpUploadThreads.IsRunning())
			//{
			//    Threads.SleepTime(750);
			//}

			//InformationBoxAdd("Zakończono wysyłanie obrazów na serwer");
			//InformationBoxScrollToEnd();

			//InformationBoxAdd("----------------------------------------------------------------------------------------------------------------------------------");
			//InformationBoxScrollToEnd();

			//InformationBoxAdd("Wysyłam obrazy na serwer");
			//InformationBoxScrollToEnd();

			//FtpUploadThreads = new Threads(FtpUpload);
			//FtpUploadThreads.Start();

			//Threads.SleepTime(2500);

			//while (FtpUploadThreads.IsRunning())
			//{
			//    Threads.SleepTime(750);
			//}

			//InformationBoxAdd("Zakończono wysyłanie obrazów na serwer");
			//InformationBoxScrollToEnd();

			//InformationBoxAdd("----------------------------------------------------------------------------------------------------------------------------------");
			//InformationBoxScrollToEnd();

			////TODO: Database Alert'ing

			//Threads.SleepTime(2500);

			//EnableAllElements();

			return true;
		}

		private bool UpdateProductList()
		{
			
			return true;
		}

		//private bool GetPhotoUrl(int min, int max)
		//{
		//    for (; min < max; min++)
		//    {
		//        var webclass = new WebClass();

		//        InformationBoxAdd(String.Format("Pobieram URL obrazu dla: {0}, nr {1}/{2}", ProductChecks.Products[min].Name,
		//                                            _counter++, ProductChecks.Products.Count));
		//        InformationBoxScrollToEnd();
					

		//        var stream = webclass.ConnectingToSite(ProductChecks.Products[min].ProductUrl);
		//        var tempString = ProductChecks.Start(stream);

		//        lock (LockProducts)
		//        {
		//            ProductChecks.Products[min].Numbers = new List<string>();
		//            ProductChecks.Products[min].Numbers.AddRange(ProductChecks.GetProductNumbers(tempString));
		//        }

		//        if (ProductChecks.GetProductBigImageUrl(tempString) == "") continue;

		//        stream = webclass.ConnectingToSite(ProductChecks.GetProductBigImageUrl(tempString));
		//        tempString = ProductChecks.Start(stream);

		//        lock (LockProducts)
		//        {
		//            ProductChecks.Products[min].ProductPhoto = ProductChecks.GetProductBigImageFromUrl(tempString);
		//        }
		//    }
		//    return true;
		//}

		private bool DownloadAndCopyPhotos(int min, int max)
		{
			//for (; min < max; min++)
			//{
			//    var webclass = new WebClass();

			//    InformationBoxAdd(String.Format("Pobieram obraz: {0}, nr {1}/{2}", ProductChecks.Products[min].Name,
			//                                        _counter++, ProductChecks.Products.Count));
			//    InformationBoxScrollToEnd();

			//    var directory = String.Format("{0}\\{1}\\{2}", _downloadFolder, ProductChecks.Products[min].MainCategory,
			//                                    ProductChecks.Products[min].SubCategory);

			//    DirectoryClass.CreateDirectory(directory);

			//    if (ProductChecks.Products[min].ProductPhoto == "") continue;

			//    var filename = String.Format("{0}.jpg", ProductChecks.Products[min].Name);
			//    if (!webclass.DownloadFile(ProductChecks.Products[min].ProductPhoto, directory, filename))
			//    {
			//        InformationBoxAdd(String.Format("Wystąpił problem z: {0}, Treść błędu: {1}", ProductChecks.Products[min].Name, webclass.ErrorMessage));
			//    }
			//    else
			//    {
			//        ProductChecks.Products[min].FileName = filename;
			//        ProductChecks.Products[min].Directory = directory;
			//    }

                //NOTE: Tymczasowo niepotrzebne
                //var sourceFile = String.Format("{0}\\{1}", directory, filename);

                //foreach (var number in ProductChecks.Products[min].Numbers)
                //{
                //    var destinationFile = String.Format("{0}\\{1}-{2}", directory, number, filename);
                //    lock (LockProducts)
                //    {
                //        DirectoryClass.CopyFile(sourceFile, destinationFile);
                //    }
                //}

                //DirectoryClass.Deletefile(sourceFile);
			//}

			return true;
		}

		private void CloseAllThreads()
		{
			if (CheckingThread != null)
			{
				if (CheckingThread.IsRunning())
				{
					CheckingThread.Close();
				}
			}
			if (UpdateProductListThreads != null)
			{
				if (UpdateProductListThreads.IsRunning())
				{
					UpdateProductListThreads.Close();
				}
			}
			if (GetPhotoUrlThreads != null)
			{
				if (GetPhotoUrlThreads.IsRunning())
				{
					GetPhotoUrlThreads.Close();
				}
			}
			if (DownloadAndCopyPhotosThreads == null) return;
			if (DownloadAndCopyPhotosThreads.IsRunning())
			{
				DownloadAndCopyPhotosThreads.Close();
			}
		}

		private bool FtpUpload()
		{
			//foreach (var product in ProductChecks.Products)
			//{
			//    var web = new WebClass();
			//    if (!String.IsNullOrEmpty(product.Directory) || !String.IsNullOrEmpty(product.FileName))
			//    {
			//        var tempImage = ImageW.Resize90(product.Directory + "\\" + product.FileName);
			//        product.ThumbFileName = tempImage;

			//        WebClass.FtpUploadFile(ftpServerName.Text, ftpPassword.Text, ftpUsername.Text, ftpDirectory.Text, product.Directory, product.ThumbFileName);
					
			//        WebClass.FtpUploadFile(ftpServerName.Text, ftpPassword.Text, ftpUsername.Text, ftpDirectory.Text, product.Directory, product.FileName);

			//        InformationBoxAdd(String.Format("Załadowano na serwer: {0}", product.Name));
			//        InformationBoxScrollToEnd();
			//    }
			//    else
			//    {
			//        InformationBoxAdd(String.Format("Produkt bez ścieżki dla obrazu: {0}", product.Name));
			//        InformationBoxScrollToEnd();
			//    }
			//}

			return true;
		}

		#endregion

		#region Delegaty
		private delegate void InformationBoxAddCallback(string value);
		public void InformationBoxAdd(string value)
		{
			if (InvokeRequired)
			{
				InformationBoxAddCallback upbc = (InformationBoxAdd);
				Invoke(upbc, new object[] {value});
			}
			else
			{
				informationBox.Items.Add(value);
			}
		}

		private delegate void InformationBoxScrollToEndCallback();
		public void InformationBoxScrollToEnd()
		{
			if (InvokeRequired)
			{
				InformationBoxScrollToEndCallback ibstec = (InformationBoxScrollToEnd);
				Invoke(ibstec);
			}
			else
			{
				informationBox.SelectedIndex = informationBox.Items.Count - 1;
				informationBox.SelectedIndex = -1;
			}
		}

		private delegate void EnableAllElementsCallback();
		private void EnableAllElements()
		{
			if (InvokeRequired)
			{
				EnableAllElementsCallback eaec = (EnableAllElements);
				Invoke(eaec);
			}
			else
			{
				downloadButton.Enabled = true;
				destinationCatalogTextBox.Enabled = true;
				destinationCatalogButton.Enabled = true;
			}
		}
		#endregion

		public MainForm()
		{
			InitializeComponent();
		}

		private void MainFormLoad(object sender, EventArgs e)
		{
			destinationCatalogTextBox.Text = FolderName;
		}

		private void DestinationCatalogTextBoxEnter(object sender, EventArgs e)
		{
			if (destinationCatalogTextBox.Text == FolderName)
			{
				destinationCatalogTextBox.Text = "";
			}
		}

		private void DestinationCatalogTextBoxLeave(object sender, EventArgs e)
		{
			if (destinationCatalogTextBox.Text == "")
			{
				destinationCatalogTextBox.Text = FolderName;
			}
		}

		private void DestinationCatalogButtonClick(object sender, EventArgs e)
		{
			if (folderBrowserDialog.ShowDialog() != DialogResult.OK) return;

			destinationCatalogTextBox.Text = folderBrowserDialog.SelectedPath;
			_downloadFolder = destinationCatalogTextBox.Text;
		}

		private void DownloadButtonClick(object sender, EventArgs e)
		{
			if (destinationCatalogTextBox.Text == FolderName)
			{
				MessageBox.Show(@"Wybierz katalog", @"Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			informationBox.Items.Add(String.Format("Rozpoczęto wstępne pobieranie: {0}", DateTime.Now));

			Task.Factory.StartNew(() => Product.GetList(this));

			//UpdateProductListThreads = new Threads(AmountOfSites, UpdateProductList);
			//UpdateProductListThreads.Start();

			//downloadButton.Enabled = false;
			//destinationCatalogButton.Enabled = false;
			//destinationCatalogTextBox.Enabled = false;

			//CheckingThread = new Threads(Checking);
			//CheckingThread.Start();
		}

		private void MainFormFormClosed(object sender, FormClosedEventArgs e)
		{
			CloseAllThreads();

			var process = Process.GetCurrentProcess();
			process.Kill();
		}
	}
}