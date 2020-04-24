using System.ComponentModel;

namespace vodovoz.Base
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        protected void RaisePropertyChanged(string p)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(p));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
