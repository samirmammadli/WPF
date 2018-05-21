using System.Security;
using System.Windows.Controls;
using AdoNetTodoList.Services;
using AdoNetTodoList.Tools;


namespace AdoNetTodoList.View
{
    /// <summary>
    /// Interaction logic for LogInView.xaml
    /// </summary>
    public partial class LogInView : UserControl, IHavePassword
    {
        public LogInView()
        {
            InitializeComponent();
            ViewModelLoactor.Instance.LogInViewModel.Pb = this.PwdTb;
        }

        public SecureString Password => throw new System.NotImplementedException();
    }
}
