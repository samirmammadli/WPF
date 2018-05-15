using AdoNetTodoList.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AdoNetTodoList.ViewModel
{
    class LogInViewModel : ObservableObject
    {
        private RelayCommand doubleCommand;
        public RelayCommand DoubleCommand
        {
            get
            {
                return doubleCommand ?? (doubleCommand = new RelayCommand(
                    param => MessageBox.Show(param.ToString())));
            }
        }
    }
}
