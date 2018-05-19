using Autofac;
using Autofac.Configuration;
using Microsoft.Extensions.Configuration;
using System;
using AdoNetTodoList.Navigation;
using AdoNetTodoList.ViewModel;

namespace AdoNetTodoList.Tools
{
    class ViewModelLoactor
    {
        INavigationService navigationService = new NavigationService();

        //TODO: Add VMs 
        public AppViewModel AppViewModel { get; }
        public LogInViewModel LogInViewModel { get; }
        static public ViewModelLoactor Instance { get; private set; } = new ViewModelLoactor();

        private ViewModelLoactor()
        {
            try
            {
                var config = new ConfigurationBuilder();
                config.AddJsonFile("autofac.json");
                var module = new ConfigurationModule(config.Build());
                var builder = new ContainerBuilder();
                builder.RegisterModule(module);
                builder.RegisterInstance(navigationService).As<INavigationService>().SingleInstance();
                var container = builder.Build();

                using (var scope = container.BeginLifetimeScope())
                {
                    //TODO: Resolve all VMs
                    AppViewModel = scope.Resolve<AppViewModel>();
                    LogInViewModel = scope.Resolve<LogInViewModel>();

                }

                //TODO: Add VMs to navigation
                navigationService.AddPage(LogInViewModel, VM.Login);

                //TODO: Set default VM
                navigationService.NavigateTo(VM.Login);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
