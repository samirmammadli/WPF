using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace Gallery
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Albums> albums;
        public MainWindow()
        {
            InitializeComponent();
            try
            {
                BtnOpenImage.Background = MyMainWindow.Background;
                albums = new List<Albums>();
                lbAlboms.ItemsSource = albums;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }


        private bool CheckAlbumExisting(string path)
        {
            foreach (var item in albums)
            {
                if (item.Path == path) return true;
            }
            return false;
        }
       

        private void AddNewAlbom(string albumName, string albumPath, ImageSource image)
        {
            albums.Add(new Albums(albumName, albumPath, image));
        }

        private void AddPicturesToAlbum(int index, Image image)
        {
            albums[index].AlbumImages.Add(new Button() { Content = image, Margin = new Thickness(3, 3, 3, 3) });
            lbAlboms.Items.Refresh();
        }
        
        private bool CheckIsAlbumSelected(Albums albom)
        {
            int index = lbAlboms.SelectedIndex;
            if (index < 0) return false;
            if (ImagesPanel.Children[index] == albom.AlbumImages[0]) return true;
            return false;
        }

        private void DeleteAlbum(Albums album)
        {
            if (CheckIsAlbumSelected(album))
                ImagesPanel.Children.Clear();
            albums.Remove(album);
            lbAlboms.Items.Refresh();
            
        }

        private void LoadAlbumImagestoViewer(int index)
        {
            ImagesPanel.Children.Clear();
            foreach (var image in albums[index].AlbumImages)
            {
                ImagesPanel.Children.Add(image);
            }
        }

        private void AddAlbum_OnClick(object sender, RoutedEventArgs e)
        {
            var window = new AlbumName { Owner = this };
            var name = window.ShowAlbumNameDialog();
            if (name == string.Empty) return;
            var dialog = new CommonOpenFileDialog { IsFolderPicker = true };
            try
            {
                if (dialog.ShowDialog() != CommonFileDialogResult.Ok) return;

                var loader = new ImageCollectionLoader(dialog.FileName, new ImageFilesFilter());
                var images = loader.ImageCollectionDownload();
                var fileInfo = images[0].Tag as FileInfo;

                AddNewAlbom(name, fileInfo.DirectoryName, images[0].Source);
                int index = albums.Count - 1;
                foreach (var image in images)
                {
                    AddPicturesToAlbum(index, image);
                }
                //LoadAlbumImagestoViewer(index);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void ImagesPanel_OnClick(object sender, RoutedEventArgs e)
        {
            var button = e.Source as Button;
            if (button == null || !(button.Content is Image)) return;
            var imageInfo = (button.Content as Image).Tag as FileInfo;
            var fileName = ((button.Content as Image).Source as BitmapImage).UriSource;
            ImageViewer.Source = SingleImageLoader.DownloadImage(fileName, new ImageFilesFilter());

            if (ImageViewer.Source == null) return;
            GridImageInfo.Visibility = Visibility.Visible;
            lbNameInfo.Text = imageInfo.Name;
            lbSizeInfo.Text = SizeCalculating.Calculate(imageInfo.Length);
            lbPathInfo.Text = imageInfo.Directory.FullName;
            lbCreationDateInfo.Text = imageInfo.CreationTime.ToString();

        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var result = MessageBox.Show("Are your sure you want to delete album?", "Delete album", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.No) return;
                DeleteAlbum((e.Source as Button).DataContext as Albums);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void lbAlboms_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lbAlboms.SelectedIndex < 0 || lbAlboms.SelectedIndex > albums.Count) return;
            LoadAlbumImagestoViewer(lbAlboms.SelectedIndex);
        }


        private void ImageViewer_SourceUpdated(object sender, DataTransferEventArgs e)
        {
            MessageBox.Show(sender.GetType().ToString());
        }

        private void btnNex_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnRotateRight_Click(object sender, RoutedEventArgs e)
        {
            //ImageViewer.Source = ImageRotation.RotateToRight(ImageViewer.Source.ToString());
            //MessageBox.Show(ImageViewer.Source.ToString());
            var img = (ImageViewer.Source as BitmapImage);
            MessageBox.Show(img.ToString());
            img.BeginInit();
            //img.Rotation = Rotation.Rotate180;
            img.EndInit();
        }

        private void btnRotateLeft_Click(object sender, RoutedEventArgs e)
        {
            ImageViewer.Source = ImageRotation.RotateToLeft(ImageViewer.Source.ToString());
        }
    }
}
