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
using System.Windows.Threading;
using Microsoft.Win32;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace Gallery
{
    public partial class MainWindow : Window
    {
        private List<Albums> albums;
        private int currentIndex = -1;
        private DispatcherTimer timer;
        public MainWindow()
        {
            InitializeComponent();
            try
            {
                BtnOpenImage.Background = MyMainWindow.Background;
                albums = new List<Albums>();
                lbAlboms.ItemsSource = albums;
                timer = new DispatcherTimer();
                timer.Tick += Timer_Tick;
                timer.Interval = TimeSpan.FromSeconds(1);
                timer.Start();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            //MessageBox.Show("Salam");
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
            int albomindex = albums.IndexOf(albom);
            if (index < 0) return false;
            if (index == albomindex) return true;
            return false;
        }

        private void DeleteAlbum(Albums album)
        {
            if (CheckIsAlbumSelected(album))
            {
                ImagesPanel.Children.Clear();
                currentIndex = -1;
            }
            albums.Remove(album);
            lbAlboms.Items.Refresh();
            
        }

        private void LoadAlbumImagestoImagesList(int index)
        {
            ImagesPanel.Children.Clear();
            foreach (var image in albums[index].AlbumImages)
            {
                ImagesPanel.Children.Add(image);
            }
        }

        private void AddAlbum_OnClick(object sender, RoutedEventArgs e)
        {
            
            var dialog = new CommonOpenFileDialog { IsFolderPicker = true };
            try
            {
                if (dialog.ShowDialog() != CommonFileDialogResult.Ok) return;

                var loader = new ImageCollectionLoader(dialog.FileName, new ImageFilesFilter());
                var images = loader.ImageCollectionDownload();
                var fileInfo = images[0].Tag as FileInfo;

                var window = new AlbumName { Owner = this };
                var name = window.ShowAlbumNameDialog();
                if (name == string.Empty) return;

                AddNewAlbom(name, fileInfo.DirectoryName, images[0].Source);
                int index = albums.Count - 1;
                foreach (var image in images)
                {
                    AddPicturesToAlbum(index, image);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void ImagesPanel_OnClick(object sender, RoutedEventArgs e)
        {
            var image = GetSelectedImage(e);
            var imageInfo = image.Tag as FileInfo;
            var fileName = (image.Source as BitmapImage).UriSource;
            LoadViewerImage(fileName, imageInfo);
            

        }

        private Image GetSelectedImage(RoutedEventArgs e)
        {
            var button = e.Source as Button;
            currentIndex = ImagesPanel.Children.IndexOf(button);
            if (button == null || !(button.Content is Image)) throw new ArgumentException("Not found!");
            var image = (button.Content as Image);
            return image;
        }

        private void LoadViewerImage(Uri path, FileInfo imageInfo)
        {
            ImageViewer.Source = SingleImageLoader.DownloadImage(path, new ImageFilesFilter());
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
            LoadAlbumImagestoImagesList(lbAlboms.SelectedIndex);
        }


        private void ImageViewer_SourceUpdated(object sender, DataTransferEventArgs e)
        {
            MessageBox.Show(sender.GetType().ToString());
        }

        private void btnNex_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ImagesPanel.Children == null) return;
                if (currentIndex + 1 >= ImagesPanel.Children.Count || currentIndex == -1) return;
                var image = (ImagesPanel.Children[++currentIndex] as Button).Content as Image;
                var source = (image.Source as BitmapImage).UriSource;
                var info = image.Tag as FileInfo;
                LoadViewerImage(source, info);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnRotateRight_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ImageViewer.Source = ImageRotation.RotateToRight(ImageViewer.Source.ToString());
                var img = ImageViewer.Source as BitmapImage;
                img.Save(img.UriSource.LocalPath);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnRotateLeft_Click(object sender, RoutedEventArgs e)
        {
            ImageViewer.Source = ImageRotation.RotateToLeft(ImageViewer.Source.ToString());
            var img = ImageViewer.Source as BitmapImage;
            img.Save(img.UriSource.LocalPath);
        }

        private void btnPrevious_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ImagesPanel.Children == null) return;
                if (currentIndex - 1 < 0) return;
                var image = (ImagesPanel.Children[--currentIndex] as Button).Content as Image;
                var source = (image.Source as BitmapImage).UriSource;
                var info = image.Tag as FileInfo;
                LoadViewerImage(source, info);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {


        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new SetSlideShowTimerWindow();
            dialog.ShowDialog();
        }
    }    
}
