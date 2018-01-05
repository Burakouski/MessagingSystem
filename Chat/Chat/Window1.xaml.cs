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
using System.Windows.Shapes;

namespace Chat
{
    public partial class NativeWindow : Window
    {
        /// <summary>
        /// Страница "Профиль"
        /// </summary>
        Profile prof;

        /// <summary>
        /// Страница входа в приложение
        /// </summary>
        Pages.LoginPage LP;

        /// <summary>
        /// Связывает с базой данных приложения MessagingSystem
        /// </summary>
        public CORE.App mApp;

        /// <summary>
        /// Текущий пользователь
        /// </summary>
        private CORE.User PresentUser;

        /// <summary>
        /// Инициализирует новый экземпляр класса NativeWindow. Создает класс App для связи с базой данных
        /// </summary>
        public NativeWindow()
        {
            try
            {
                InitializeComponent();
                mApp = new CORE.App(@"Data Source=.\SQLEXPRESS;Initial Catalog=MessagingSystem; Integrated Security=True;");
                LP = new Pages.LoginPage(this);
                Main.Content = LP;
                ChatMenuPanel.IsEnabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Переход на страницу профиля
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnProfile_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Profile(mApp, PresentUser);
        }
        /// <summary>
        /// Переход на страницу Контакты
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnContacts_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Contacts(PresentUser, this);
        }

        /// <summary>
        /// переход на страницу Сообщения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnMessages_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Pages.Messages(PresentUser, this);
        }

        /// <summary>
        /// Перенаправляет на страницу Сообщения к переписке с выбранным пользователем со страницы Контакты
        /// </summary>
        /// <param name="Repicient"></param>
        public void GoToMessagePage(CORE.User Repicient)
        {
            Main.Content = new Pages.Messages(PresentUser, Repicient, this);
        }

        /// <summary>
        /// Вход в притложение. Определяет текущего пользователя и перенаправляет на страницу Профиль.
        /// </summary>
        /// <param name="sender"></param>
        public void LoginTrue(object sender)
        {
            PresentUser = new CORE.User(mApp, (int)sender);
            EnableMenu();

            Main.Content = new Profile(mApp, PresentUser);
            PresentUser.Read();
            PresentUser.MakeOnLine();
        }

        /// <summary>
        /// Выход из приложения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            LP = new Pages.LoginPage(this);
            Main.Content = LP;
            DisableMenu();
        }

        /// <summary>
        /// Деактивация меню
        /// </summary>
        private void DisableMenu()
        {
            ChatMenuPanel.IsEnabled = false;
        }

        /// <summary>
        /// Активация меню
        /// </summary>
        private void EnableMenu()
        {
            ChatMenuPanel.IsEnabled = true;
        }
    }
}
