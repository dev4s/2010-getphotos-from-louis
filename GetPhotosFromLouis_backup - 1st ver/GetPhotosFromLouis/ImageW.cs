using System.Drawing;
using System.Drawing.Drawing2D;

namespace GetPhotosFromLouis
{
	public static class ImageW
	{
		public static string Resize90(string imageFilename)
		{
			var image = (Image) new Bitmap(imageFilename);

			const int size = 90;

			var newBitmap = new Bitmap(size, size);
			var newImage = Graphics.FromImage(newBitmap);
			newImage.InterpolationMode = InterpolationMode.HighQualityBicubic;
			newImage.DrawImage(image, 0, 0, size, size);

			image.Save(AddTextToFilename(imageFilename));

			return ReturnOnlyFilename(imageFilename);
		}

		private static string AddTextToFilename(string imageFilename)
		{
			var tempFilename = imageFilename.Split('.');
			var tempL = tempFilename.Length;
			tempFilename[tempL - 2] += "_90x90";

			return tempFilename[tempL - 2] + "." + tempFilename[tempL - 1];
		}

		public static string ReturnOnlyFilename(string text)
		{
			var tempFilename = text.Split('\\');
			var tempL = tempFilename.Length;

			return tempFilename[tempL - 1];
		}
	}
}
