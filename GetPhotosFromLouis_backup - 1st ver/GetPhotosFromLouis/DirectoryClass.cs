using System.IO;

namespace GetPhotosFromLouis
{
	public static class DirectoryClass
	{
		public static void CreateDirectory(string value)
		{
			var newDirectory = new DirectoryInfo(value);
			newDirectory.Create();
		}

		public static void CopyFile(string source, string destination)
		{
			var file = new FileInfo(source);
			file.CopyTo(destination, true);
		}

		public static void Deletefile(string filename)
		{
			var file = new FileInfo(filename);
			file.Delete();
		}
	}
}
