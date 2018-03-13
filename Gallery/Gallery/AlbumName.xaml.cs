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
using System.Windows.Shapes;

namespace Gallery
{
    /// <summary>
    /// Interaction logic for AlbumName.xaml
    /// </summary>
    public partial class AlbumName : Window
    {
        public AlbumName()
        {
            InitializeComponent();
        }

        public string ShowAlbumNameDialog()
        {
            ShowDialog();
            return tbName.Text;
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            if (tbName.Text == string.Empty)
                MessageBox.Show("Album name can not be empty!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            else
                Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            tbName.Text = string.Empty;
            Close();
        }

        private void tbName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                btnOk_Click(sender, null);
        }
    }
}
