using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoNetTodoList.ViewModel
{
    class AppViewModel : ViewModelBase
    {
        public ViewModelBase CurrentVM { get; set; }
        private INavigationService navigationService;
        public AppViewModel(INavigationService service)
        {
            this.navigationService = service;

            Messenger.Default.Register<ViewModelBase>(this,
                param => CurrentVM = param
            );
        }
    }
}
