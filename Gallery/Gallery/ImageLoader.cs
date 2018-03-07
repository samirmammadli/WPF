using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Gallery
{
    abstract class FileExtensionFilter
    {
        protected string[] FileEtensions { get;  set; }

        public bool CheckExtensionMath(string filename)
        {
            foreach (var ext in FileEtensions)
            {
                if (filename.EndsWith(ext, true, CultureInfo.CurrentCulture)) return true;
            }
            return false;
        }
    }

    class ImageFilesFilter : FileExtensionFilter
    {
        public ImageFilesFilter()
        {
            FileEtensions =  new string[] { 
                ".jpg",
                ".jpeg",
                ".bmp",
                ".gif" };
        } 
    }

    static class SingleImageLoader
    {
        static public BitmapImage DownloadImage(Uri filename, FileExtensionFilter filter)
        {
            if (filter.CheckExtensionMath(filename.ToString()))
            {
                return  new BitmapImage (filename);
            }
            throw new ArgumentException("Image not found!");
        }
    }

    static class ImageRotation
    {
        static public BitmapImage RotateToRight(Uri uri)
        {
            var image = new BitmapImage();
            image.BeginInit();

            image.Rotation = Rotation.Rotate90;
            image.UriSource = uri;

            image.EndInit();

            return image;
        }
        static public BitmapImage RotateToLeft(Uri uri)
        {
            var image = new BitmapImage();
            image.BeginInit();

            image.Rotation = Rotation.Rotate270;
            image.UriSource = uri;

            image.EndInit();

            return image;
        }
    }

    class ImageCollectionLoader
    {
        private readonly LinkedList<Image> _images;
        private readonly string _path;
        public FileExtensionFilter Filter { get; set; }

        public ImageCollectionLoader(string path, FileExtensionFilter filter)
        {
            _path = path;
            Filter = filter;
            _images = new LinkedList<Image>();
        }

        private BitmapImage ImagePreview(Uri uri)
        {
            var image = new BitmapImage();

            image.BeginInit();
            image.UriSource = uri;
            image.CacheOption = BitmapCacheOption.OnLoad;
            image.DecodePixelWidth = 200;
            image.EndInit();

            return image;
        }

        public LinkedList<Image> ImageCollectionDownload()
        {
            var folder = new DirectoryInfo(_path);
            var files = folder.GetFiles();
            foreach (var file in files)
            {
                if (Filter.CheckExtensionMath(file.FullName))
                {
                    _images.AddLast(new Image {Source = ImagePreview(new Uri(file.FullName)), Tag = file } );
                }
            }
            return _images;
        }
    }
}
