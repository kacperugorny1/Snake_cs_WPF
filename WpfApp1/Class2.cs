using System;
using System.Windows.Media;
using System.Windows.Media.Imaging;




namespace WpfApp1
{
    public enum ImageType
    {
        Empty,
        Face,
        Food,
        Body
    }
    public static class Images
    {
        public readonly static ImageSource Empty = LoadImage("Empty.png");
        public readonly static ImageSource Face = LoadImage("Face.png");
        public readonly static ImageSource Food = LoadImage("Food.png");
        public readonly static ImageSource Body = LoadImage("Body.png");

        private static ImageSource LoadImage(string fileName)
        {
            return new BitmapImage(new Uri($"assets/{fileName}", UriKind.Relative));
        }
    }
}
