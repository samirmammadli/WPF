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

        private RelayCommand<string> login;
        public RelayCommand<string> Login
        {
            get
            {
                return login ?? (login = new RelayCommand<string>(
                    param => MessageBox.Show(Pb.Password)));
            }
        }
    }
}
