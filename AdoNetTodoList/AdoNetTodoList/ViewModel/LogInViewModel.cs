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

        private string _username;
        public string Username
        {
            get => _username;
            set => Set(ref _username, value);
        }

        private RelayCommand<IHavePassword> _loginCmd;
        public RelayCommand<IHavePassword> LoginCmd => _loginCmd ?? (_loginCmd = new RelayCommand<IHavePassword>(Login));

        private void Login(IHavePassword passwordContainer)
        {
            var secureString = passwordContainer.Password;
            MessageBox.Show(secureString.ConvertToUnsecureString());
        }
    }
}
