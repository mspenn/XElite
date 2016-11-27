using MicroSmadio.XElite.User.Controller;
using MicroSmadio.XElite.User.Model;
using MicroSmadio.XElite.Utilities.Screen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MicroSmadio.XElite.User
{
    /// <summary>
    /// Interaction logic for LoginControl.xaml
    /// </summary>
    public partial class LoginWinControl : UserControl
    {
        private delegate void UIEventLoginHandler();
        private UIEventLoginHandler uiEventLoginHandler;
        private ILoginController loginController;
        private BackgroundWorker backgroundWorker;
        public LoginViewModel ViewModel
        {
            get
            {
                return this.DataContext as LoginViewModel;
            }
            set
            {
                this.DataContext = value;
            }

        }
        public LoginWinControl()
        {
            InitializeComponent();
            ViewModel = new LoginViewModel();
            loginController = new LoginController();
            backgroundWorker = (BackgroundWorker)(this.FindResource("backgroundWorker"));
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1300:SpecifyMessageBoxOptions")]
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(string.Format(System.Globalization.CultureInfo.CurrentUICulture, "We are inside {0}.button1_Click()", this.ToString()),
                            "User Window");

        }
        private struct Input
        {
            public string UserEmail;
            public string Password;
            public bool? IsAutoLogin;
            public Input(string userEmail, string password, bool? isAutoLogin)
            {
                UserEmail = userEmail;
                Password = password;
                IsAutoLogin = isAutoLogin;
            }
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            uiEventLoginHandler = OnLoginStart;
            uiEventLoginHandler.Invoke();
            backgroundWorker.RunWorkerAsync(new Input(this.tbxAccount.Text,
                        this.pbxPassword.Password,
                        this.cbxAutoLogin.IsChecked));
        }
        private void pbxPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            FrameworkElement bdr = default(FrameworkElement);
            UIHelper.FindChildByName(pbxPassword, typeof(Border), ref bdr, "HintBorder");
            Border bdrHint = bdr as Border;
            //  pbxPassword.FindName("HintBorder") as Border;
            if (pbxPassword.Password != "" && pbxPassword.Password != null)
            {
                bdrHint.Visibility = Visibility.Hidden;
            }
            else
            {
                bdrHint.Visibility = Visibility.Visible;
            }
        }

        private void pbxPassword_Loaded(object sender, RoutedEventArgs e)
        {
            this.pbxPassword.Password = ViewModel.Password;
        }

        private void tbxAccount_Loaded(object sender, RoutedEventArgs e)
        {
            this.tbxAccount.Text = ViewModel.UserAccount;
        }

        private void OnLoginStart()
        {
            this.contentGrid.Visibility = Visibility.Hidden;
            this.waitingGrid.Visibility = Visibility.Visible;
        }

        private void OnLoginFail()
        { 
            MessageBox.Show("Login Failed!"); 
        }
        
        private void OnLoginSuccessful()
        { 
        }

        private void OnLoginEnd()
        {
            this.contentGrid.Visibility = Visibility.Visible;
            this.waitingGrid.Visibility = Visibility.Hidden;
        }

        private void DoWork(object sender, DoWorkEventArgs e)
        {
            Input input = (Input)e.Argument;
            try
            {
                LoginResult res = loginController.Login(
                         input.UserEmail,
                         input.Password,
                         input.IsAutoLogin);
                e.Result = res;
            }
            catch
            { e.Result = new LoginResult(); }

        }

        private void RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            LoginResult res = (LoginResult)(e.Result);
            if (res.IsSuccess)
                uiEventLoginHandler += OnLoginSuccessful;
            else
                uiEventLoginHandler += OnLoginFail;
            uiEventLoginHandler += OnLoginEnd;
            this.Dispatcher.BeginInvoke(uiEventLoginHandler);
        }
    }
}