using AdoNetTodoList.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoNetTodoList.ViewModel
{
    class AppViewModel : ObservableObject
    {
        public LogInViewModel Login { get; set; }
        public AppViewModel()
        {
            Login = new LogInViewModel();
        }
    }
}
