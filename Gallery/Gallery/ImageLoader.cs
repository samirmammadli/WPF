using System;
using System.Collections.Generic;
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
                if (filename.EndsWith(ext)) return true;
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

    class ImageLoader
    {
        private readonly List<Image> _images;
        private readonly string _path;
        public FileExtensionFilter Filter { get; set; }

        public ImageLoader(string path, FileExtensionFilter filter)
        {
            _path = path;
            Filter = filter;
            _images = new List<Image>();
        }

        public List<Image> GetImages()
        {
            var folder = new DirectoryInfo(_path);
            var files = folder.GetFiles();
            foreach (var file in files)
            {
                if (Filter.CheckExtensionMath(file.FullName))
                {
                    _images.Add(new Image{Source = new BitmapImage(new Uri(file.FullName))});
                }
            }
            return _images;
        }
    }
}
