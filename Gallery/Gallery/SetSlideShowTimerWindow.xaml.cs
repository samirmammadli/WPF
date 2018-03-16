using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for SetSlideShowTimerWindow.xaml
    /// </summary>
    public partial class SetSlideShowTimerWindow : Window
    {
        public int Value { get; private set; } = 0;

        public SetSlideShowTimerWindow()
        {
            InitializeComponent();
            tbValue.Focus();
        }


        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            int.TryParse(tbValue.Text, out int value);
            Value = value;
            if (Value <= 0 || Value > 10)
                MessageBox.Show("Incorrect value! (from 1 to 10)", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            else
                Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (Value <= 0 || Value > 10)
                DialogResult = false;
            else
                DialogResult = true;
        }

        private void tbValue_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                btnOk_Click(sender, e);
            }
        }
    }
}
