using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
                var loader = new ImageLoader(dialog.FileName, new ImageFilesFilter());
                foreach (var image in loader.GetImages())
                {
                    ImagesPanel.Children.Add(new Button (){ Content = image, Margin = new Thickness(3,3,3,3)});
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void ImagesPanel_OnClick(object sender, RoutedEventArgs e)
        {
            var button = e.Source as Button;
            if ((button?.Content as Image)?.Source != null)
                SelectedImage.Source = (button.Content as Image).Source;
        }
    }
}
