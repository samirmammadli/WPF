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
        private List<AlbumInfo> albums;
        public MainWindow()
        {
            InitializeComponent();
            try
            {
                BtnOpenImage.Background = MyMainWindow.Background;
                albums = new List<AlbumInfo>();
                lbAlboms.ItemsSource = albums;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void AddPicture_OnClick(object sender, RoutedEventArgs e)
        {
            var dialog = new CommonOpenFileDialog { IsFolderPicker = true };
            try
            {
                if (dialog.ShowDialog() != CommonFileDialogResult.Ok) return;

                ImagesPanel.Children.Clear();
                var loader = new ImageCollectionLoader(dialog.FileName, new ImageFilesFilter());
                var images = loader.ImageCollectionDownload();


                foreach (var image in images)
                {
                    ImagesPanel.Children.Add(new Button() { Content = image, Margin = new Thickness(3, 3, 3, 3) });
                }
                var fileInfo = images.First.Value.Tag as FileInfo;
                albums.Add(new AlbumInfo(fileInfo.Name, fileInfo.DirectoryName, images.First.Value.Source));
                lbAlboms.Items.Refresh();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void ImagesPanel_OnClick(object sender, RoutedEventArgs e)
        {
            
            var button = e.Source as Button;
            if (button == null || button.Content as Image == null) return;


            var fileName = ((button.Content as Image).Source as BitmapImage).UriSource;


            ImageViewer.Source = SingleImageLoader.DownloadImage(fileName, new ImageFilesFilter());
            //ImageViewer.Source = Nese(fileName);

        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(((e.Source as Button).DataContext as AlbumInfo).Name);
            try
            {

                MessageBox.Show(lbAlboms.Items.Contains((e.Source as Button).DataContext as AlbumInfo).ToString());
                lbAlboms.Items.Remove((e.Source as Button).DataContext);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
