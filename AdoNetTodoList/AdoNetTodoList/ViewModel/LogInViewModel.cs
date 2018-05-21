using AdoNetTodoList.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        private RelayCommand<string> loginCmd;
        public RelayCommand<string> LoginCmd
        {
            get
            {
                return loginCmd ?? (loginCmd = new RelayCommand<string>(
                    param => MessageBox.Show(Pb.Password)));
            }
        }

        private void Login(object parameter)
        {
            var passwordContainer = parameter as IHavePassword;
            if (passwordContainer != null)
            {
                var secureString = passwordContainer.Password;
                PasswordInVM = ConvertToUnsecureString(secureString);
            }
        }
    }
}
