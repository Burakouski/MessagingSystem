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
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Page
    {
        /// <summary>
        /// Окно в котором загружается Registration
        /// </summary>
        NativeWindow MainWin;

        /// <summary>
        /// Инициализирует новый экземпляр класса Registration
        /// </summary>
        /// <param name="win"></param>
        public Registration(NativeWindow win)
        {
            MainWin = win;
            InitializeComponent();
        }
        /// <summary>
        /// Возвращение к странице входа LoginPage
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            MainWin.Main.Content = new Pages.LoginPage(MainWin);
        }

        /// <summary>
        /// Регистрация
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (CheckFields() && CheckPassword())
                {
                    CORE.User u = new CORE.User(MainWin.mApp);

                    u.NameF = txtNameF.Text;
                    u.NameI = txtNameI.Text;
                    u.NameO = txtNameO.Text;
                    u.Phone = txtPhone.Text;
                    u.Birthday = dtpBirthday.DisplayDate;
                    u.Password = passBox.Password;
                    u.Login = txtLogin.Text;
                    u.DateRegistration = DateTime.Now;

                    u.NewUser();
                    MainWin.Main.Content = new Pages.LoginPage(MainWin);
                }
            }
            catch (Exception ex)
            {
                ShowErrorMessage(ex.Message);
            }


        }

        /// <summary>
        /// Проверка совпадения вводимых значений в полях "Пароль" и "Еще раз пароль"
        /// </summary>
        /// <returns></returns>
        private bool CheckPassword()
        {
            if (passBox.Password == passwordBoxCheck.Password)
            {
                return true;
            }
            else
            {
                ShowErrorMessage("Пароли не совпадают.");
                return false;
            }
        }
        /// <summary>
        /// Проверка заполненности полей
        /// </summary>
        /// <returns></returns>
        private bool CheckFields()
        {
            bool Is = true;

            if (txtNameF.Text == String.Empty)
            {
                ShowErrorMessage("Введите фамилию");
                return false;
            }

            if (txtNameI.Text == String.Empty)
            {
                ShowErrorMessage("Введите имя");
                return false;
            }

            if (txtNameO.Text == String.Empty)
            {
                ShowErrorMessage("Введите отчество");
                return false;
            }

            if (txtPhone.Text == String.Empty)
            {
                ShowErrorMessage("Введите номер телефона");
                return false;
            }
            DateTime dtm;
            if (!DateTime.TryParse(dtpBirthday.Text, out dtm)) //dtpBirthday.DisplayDate.GetType() != typeof(DateTime) && dtpBirthday.Text == string.Empty)
            {
                ShowErrorMessage("Дата рождения внесена некорректно");
                return false;
            }

            if (txtLogin.Text == String.Empty)
            {
                ShowErrorMessage("Введите логин");
                return false;
            }

            if (passBox.Password == String.Empty)
            {

                ShowErrorMessage("Введите пароль");
                return false;
            }

            if (passwordBoxCheck.Password == String.Empty)
            {

                ShowErrorMessage("Повторите пароль");
                return false;
            }
            return Is;
        }

        /// <summary>
        /// Сообщение об ошибке с текстом "text"
        /// </summary>
        /// <param name="text"></param>
        private void ShowErrorMessage(string text)
        {
            MessageBox.Show(text, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
