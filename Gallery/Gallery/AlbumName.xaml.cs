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
        private bool Cancel = true;

        public AlbumName()
        {
            InitializeComponent();
            tbName.Focus();
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
            { Cancel = false; Close(); }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void tbName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                btnOk_Click(sender, null);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (Cancel) tbName.Text = string.Empty;
        }
    }
}
