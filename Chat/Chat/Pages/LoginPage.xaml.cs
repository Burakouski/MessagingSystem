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
        /// <summary>
        /// Флаг, отмечающий произошел вход в систему или нет
        /// </summary>
        public bool IsLogin = false;

        /// <summary>
        /// Окно в котором загружается LoginPage
        /// </summary>
        NativeWindow MainWin;

        /// <summary>
        /// Инициализирует новый экземпляр класса LoginPage
        /// </summary>
        /// <param name="win"></param>
        public LoginPage(NativeWindow win)
        {
            InitializeComponent();
            MainWin = win;
        }

        private void IsLogin_Changed(object sender, EventArgs args)
        {

        }

        /// <summary>
        /// Смена подсказок для поля txtLogin (Логин), при потере фокуса
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtLogin_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtLogin.Text.Length == 0)
            {
                txtLogin.Text = "Логин";
                LblLogin.Content = String.Empty;
            }
        }
        /// <summary>
        /// Смена подсказок для поля txtLogin (Логин), при получении фокуса
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtLogin_GotFocus(object sender, RoutedEventArgs e)
        {
            LblLogin.Content = "Логин";
            if (txtLogin.Text == "Логин")
            {
                txtLogin.Text = String.Empty;
            }
        }
        /// <summary>
        ///  Смена подсказок для поля lblPassword (Пароль), при получении фокуса
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void passwordBoxEdit1_GotFocus(object sender, RoutedEventArgs e)
        {
            lblPassword.Content = "Пароль";
            if (passwordBoxEdit1.Text == "Пароль")
            {
                passwordBoxEdit1.Text = String.Empty;
            }
        }
        /// <summary>
        /// Смена подсказок для поля lblPassword (Пароль), при потере фокуса
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void passwordBoxEdit1_LostFocus(object sender, RoutedEventArgs e)
        {
            if (passwordBoxEdit1.Text.Length == 0)
            {
                lblPassword.Content = String.Empty;
            }
        }
        /// <summary>
        /// Проверяем Логин и Пароль
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Переход на страницу регистрации
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRegistration_Click(object sender, RoutedEventArgs e)
        {
            MainWin.Main.Content = new Pages.Registration(MainWin);
        }
    }
}
