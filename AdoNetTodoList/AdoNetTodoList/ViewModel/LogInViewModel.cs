using AdoNetTodoList.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdoNetTodoList.ExtensionMethods;
using System.Windows;

namespace AdoNetTodoList.ViewModel
{
    

    public class LogInViewModel : ViewModelBase
    {
        public Xceed.Wpf.Toolkit.WatermarkPasswordBox Pb { get; set; }

        private string username;
        public string Username
        {
            get => username;
            set => Set(ref username, value);
        }

        private RelayCommand<object> loginCmd;
        public RelayCommand<object> LoginCmd => loginCmd ?? (loginCmd = new RelayCommand<object>(Login));

        private void Login(object parameter)
        {
            if (parameter is IHavePassword passwordContainer)
            {
                var secureString = passwordContainer.Password;
                MessageBox.Show(secureString.ConvertToUnsecureString());
            }
        }
    }
}
