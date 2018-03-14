using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media;

namespace Gallery
{
    class Albums
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public ImageSource AlbumImage { get; set; }
        public List<Button> AlbumImages { get; set; }

        public Albums(string name, string path, ImageSource image)
        {
            AlbumImages = new List<Button>();
            Name = name;
            Path = path;
            AlbumImage = image;
        }
    }
}
