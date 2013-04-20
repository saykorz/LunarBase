using System.Windows.Media;

namespace LunarBase.Library.Models
{
    public class MessageBoxDataContext : PropertyChange
    {
        private string status;
        public string Status
        {
            get { return this.status; }
            set { status = value; RaisePropertyChanged("Status"); }
        }

        private bool isError;
        public bool IsError
        {
            get { return this.isError; }
            set
            {
                if (value)
                    Status = "/Images/Icons/Error.png";
                else
                    Status = "/Images/Icons/Gtk-ok.png";
                isError = value; RaisePropertyChanged("IsError");
            }
        }

        private string message;
        public string Message
        {
            get { return this.message; }
            set { message = value; RaisePropertyChanged("Message"); }
        }

        private Color foreground;
        public Color Foreground
        {
            get { return this.foreground; }
            set
            {
                if (value == Colors.Green)
                    Status = "/Images/Icons/Gtk-ok.png";
                else
                    Status = "/Images/Icons/Error.png";
                foreground = value; RaisePropertyChanged("Foreground");
            }
        }
    }
}
