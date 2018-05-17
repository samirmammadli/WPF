using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AdoNetTodoList.ViewModel
{
    class LogInViewModel : ViewModelBase
    {
        private string username;

        public string Username
        {
            get { return username; }
            set { Set(ref username, value); }
        }

        private RelayCommand login;
        public RelayCommand Login
        {
            get
            {
                return login ?? (login = new RelayCommand(
                    param => MessageBox.Show(Username)));
            }
        }
    }
}
