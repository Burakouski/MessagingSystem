using System;
using System.Collections.Generic;
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

namespace Chat.Pages
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public bool IsLogin = false;
        public event EventHandler IsLoginChanged;
        NativeWindow MainWin;

        public LoginPage(NativeWindow win)
        {
            InitializeComponent();
            MainWin = win;


            this.IsLoginChanged += new EventHandler(IsLogin_Changed);
        }

        private void IsLogin_Changed(object sender, EventArgs args)
        {

        }

        private void txtLogin_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtLogin.Text.Length == 0)
            {
                txtLogin.Text = "Логин";
                LblLogin.Content = String.Empty;
            }
        }

        private void txtLogin_GotFocus(object sender, RoutedEventArgs e)
        {
            LblLogin.Content = "Логин";
            if (txtLogin.Text == "Логин")
            {
                txtLogin.Text = String.Empty;
            }
        }

        private void passwordBoxEdit1_GotFocus(object sender, RoutedEventArgs e)
        {
            lblPassword.Content = "Пароль";
            if (passwordBoxEdit1.Text == "Пароль")
            {
                passwordBoxEdit1.Text = String.Empty;
            }
        }

        private void passwordBoxEdit1_LostFocus(object sender, RoutedEventArgs e)
        {
            if (passwordBoxEdit1.Text.Length == 0)
            {
                lblPassword.Content = String.Empty;
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            CORE.User us = new CORE.User(MainWin.mApp);
            
            int? IdUser = us.CheckLogin(txtLogin.Text, passwordBoxEdit1.Password);
            if (IdUser == null)
            {
                MessageBox.Show("Неправильный логин и/или пароль", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                IsLogin = true;
                MainWin.LoginTrue(IdUser);
            }
        }

        private void LoginIn()
        { 
        }

        private void btnRegistration_Click(object sender, RoutedEventArgs e)
        {
            MainWin.Main.Content = new Pages.Registration(MainWin);
        }
    }
}
