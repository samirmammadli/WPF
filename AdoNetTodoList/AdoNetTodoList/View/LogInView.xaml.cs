using System.Windows.Controls;
using AdoNetTodoList.Tools;


namespace AdoNetTodoList.View
{
    /// <summary>
    /// Interaction logic for LogInView.xaml
    /// </summary>
    public partial class LogInView : UserControl
    {
        public LogInView()
        {
            InitializeComponent();
            ViewModelLoactor.Instance.LogInViewModel.Pb = this.PwdTb;
        }
    }
}
