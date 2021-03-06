﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Gallery
{

    abstract class FileExtensionFilter
    {
        protected string[] FileEtensions { get;  set; }

        public string CheckExtensionMath(string filename)
        {
            foreach (var ext in FileEtensions)
            {
                if (filename.EndsWith(ext, true, CultureInfo.CurrentCulture)) return ext;
            }
            return "";
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
                ".png" };
        } 
    }

    static class SingleImageLoader
    {
        static public BitmapImage DownloadImage(Uri filename, FileExtensionFilter filter)
        {
            if (filter.CheckExtensionMath(filename.ToString()) != "")
            {
                var image = new BitmapImage();

                image.BeginInit();
                image.UriSource = filename;
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.EndInit();
                return image;
            }
            throw new ArgumentException("Image not found!");
        }
    }

    static class ImageRotation
    {
        static public BitmapImage RotateToRight(string path)
        {
            var image = new BitmapImage();
            image.BeginInit();
            image.Rotation = Rotation.Rotate90;
            image.UriSource = new Uri(path);
            image.CacheOption = BitmapCacheOption.OnLoad;
            image.EndInit();
            return image;
        }

        static public BitmapImage RotateToLeft(string path)
        {
            var image = new BitmapImage();
            image.BeginInit();

            image.Rotation = Rotation.Rotate270;
            image.UriSource = new Uri(path);
            image.CacheOption = BitmapCacheOption.OnLoad;
            image.EndInit();

            return image;
        }
    }

    class ImageCollectionLoader
    {
        private readonly List<Image> _images;
        private readonly string _path;
        public FileExtensionFilter Filter { get; set; }

        public ImageCollectionLoader(string path, FileExtensionFilter filter)
        {
            _path = path;
            Filter = filter;
            _images = new List<Image>();
        }

        private BitmapImage ImagePreview(Uri uri)
        {
            var image = new BitmapImage();

            image.BeginInit();
            image.UriSource = uri;
            image.CacheOption = BitmapCacheOption.OnLoad;
            image.DecodePixelWidth = 100;
            image.EndInit();
            return image;
        }

        public List<Image> ImageCollectionDownload()
        {
            var folder = new DirectoryInfo(_path);
            var files = folder.GetFiles();
            foreach (var file in files)
            {
                if (Filter.CheckExtensionMath(file.FullName) != "")
                {
                    _images.Add(new Image {Source = ImagePreview(new Uri(file.FullName)), Tag = file } );
                }
            }
            return _images;
        }
    }
}
