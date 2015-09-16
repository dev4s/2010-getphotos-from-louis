using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GetPhotosFromLouis
{
	public class Product
	{
		private const int AmountOfSites = 115; //maksymalnie 1000
		private const string MainCategories = "http://www.louis.de/index.php?topic=wgr&lang=en&grwgr=";

		public static readonly List<Product> List = new List<Product>();

		public string Name { get; set; }
		public string ProductUrl { get; set; }
		public string ProductPhoto { get; set; }
		public string MainCategory { get; set; }
		public string SubCategory { get; set; }
		public List<string> Numbers { get; set; }

		public string FileName { get; set; }
		public string Directory { get; set; }
		public string ThumbFileName { get; set; }

		private static void UpdateList(string value)
		{
			var productNames = ProductChecks.GetProductNames(value);
			var productUrls = ProductChecks.GetProductUrl(value);
			var subCategory = ProductChecks.GetSubCategory(value);
			var mainCategory = ProductChecks.GetMainCategory(value);

			for (var i = 0; i < productNames.Count; i++)
			{
				List.Add(new Product
				{
					MainCategory = mainCategory,
					Name = productNames[i],
					ProductPhoto = "",
					ProductUrl = productUrls[i],
					SubCategory = subCategory
				});
			}
		}

		public static void GetList(MainForm mainForm)
		{
			Parallel.For(0, AmountOfSites, i =>
			                               	{
			                               		var webClass = new WebClass();
			                               		var tempString = webClass.ConnectingToSite(MainCategories + i);

												if (mainForm != null)
												{
													mainForm.InformationBoxAdd(String.Format("Strona nr. {0}", i));
													mainForm.InformationBoxScrollToEnd();
												}

												if (String.IsNullOrEmpty(ProductChecks.DoesNotExist(tempString)))
													return;

			                               		var mainProducts = String.Format("{0}{1}&page=", MainCategories, i);
												
			                               		//pobieranie produktów z poszczególnych podstron

			                               		for (var j = 0; j < 100; j++)
			                               		{
			                               			Threads.SleepTime(100);
			                               			tempString = ProductChecks.DoesNotExist(webClass.ConnectingToSite(mainProducts + j));

													if (String.IsNullOrEmpty(tempString)) break;

			                               			tempString = ProductChecks.RemoveBodyStart(tempString);

													if (mainForm != null)
													{
														foreach (var name in ProductChecks.GetProductNames(tempString))
														{
															var mainCategory = ProductChecks.GetMainCategory(tempString);
															var subCategory = ProductChecks.GetSubCategory(tempString);
															mainForm.InformationBoxAdd(String.Format("Znaleziono produkt: {0}, kategoria: {1}\\{2}", name, mainCategory, subCategory));
															mainForm.InformationBoxScrollToEnd();
														}	
													}

													UpdateList(tempString);
			                               		}
			                               	});
		}
	}
}
