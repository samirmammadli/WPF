using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AdoNetTodoList.Tools
{
    [Serializable]
    public class ObservableObject : INotifyPropertyChanged
    {
        [NonSerialized]
        private PropertyChangedEventHandler _PropertyChanged;

        public virtual event PropertyChangedEventHandler PropertyChanged
        {
            add { _PropertyChanged += value; }
            remove { _PropertyChanged -= value; }
        }

        protected void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            _PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
