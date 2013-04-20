using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using LunarBase.Library;
using LunarBase.Library.GameService;

namespace LunarBase.SL.View
{
    public partial class Login : UserControl
    {
        public Login()
        {
            InitializeComponent();
            
        }

        public void BtnLogin_OnClick(object sender, RoutedEventArgs e)
        {
            txtEmailAddress.Text = "saykor@gmail.com";
            txtPassword.Password = "test1234";
            if (!string.IsNullOrEmpty(txtEmailAddress.Text) && !string.IsNullOrEmpty(txtPassword.Password))
            {
                var client = new GameServiceClient();
                client.LoginCompleted += client_LoginCompleted;
                client.LoginAsync(txtEmailAddress.Text, txtPassword.Password);
            }
        }

        void client_LoginCompleted(object sender, LoginCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                AppCache.ApplicationViewModel.UserProfile = e.Result;
            }
        }

        private void TxtPassword_OnKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                BtnLogin_OnClick(btnLogin, new RoutedEventArgs());
        }
    }
}
