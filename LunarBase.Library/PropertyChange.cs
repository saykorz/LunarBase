using System.ComponentModel;

namespace LunarBase.Library
{
    public class PropertyChange : INotifyPropertyChanged
    {
        public void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
