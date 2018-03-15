using System.IO;
using System.Windows.Media.Imaging;

namespace Gallery
{
    static class ImageSaver
    {
        static private BitmapEncoder GetEncoder(string file, FileExtensionFilter filter)
        {
            var encoderType = filter.CheckExtensionMath(file);
            if (encoderType == ".gif")
                return new GifBitmapEncoder();
            else if(encoderType == ".bmp")
                return new BmpBitmapEncoder();
            else if (encoderType == ".png")
                return new PngBitmapEncoder();
            else
                return new JpegBitmapEncoder();
        }
        
        public static void Save(this BitmapImage image, string filePath)
        {
            var encoder = GetEncoder(filePath, new ImageFilesFilter());
            encoder.Frames.Add(BitmapFrame.Create(image));

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                encoder.Save(fileStream);
            }
        }
    }
    
}
