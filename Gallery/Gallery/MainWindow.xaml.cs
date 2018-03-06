using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
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
        public MainWindow()
        {
            InitializeComponent();
            BtnOpenImage.Background = MyMainWindow.Background;
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

                //////////////////////////////////
                try
                {
                    ProgressManager pm = new ProgressManager();
                    pm.BeginWaiting();
                    pm.SetProgressMaxValue(10);

                    for (int i = 0; i < 10; i++)
                    {
                        pm.ChangeStatus("Loading " + i.ToString() + " from 10");
                        pm.ChangeProgress(i);
                        Thread.Sleep(100);
                    }
                    pm.EndWaiting();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    
                }

                //int i = 0;


                //foreach (var image in images)
                //{
                //    ImagesPanel.Children.Add(new Button (){ Content = image, Margin = new Thickness(3,3,3,3)});
                //    pm.ChangeProgress(++i);
                //    pm.ChangeStatus("Loading " + i.ToString() + $" from {images.Count}");

                //}


                /////////////////////////////////
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

        
    }
}
