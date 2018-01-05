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
using System.Data;

namespace Chat
{
    /// <summary>
    /// Страница контактов
    /// </summary>
    public partial class Contacts : Page
    {
        /// <summary>
        /// Текущий пользователь
        /// </summary>
        CORE.User PresentUser;

        /// <summary>
        /// Окно в котором загружается Contacts
        /// </summary>
        NativeWindow MyWindow;

        /// <summary>
        /// Инициализирует новый экземпляр класса Contacts
        /// </summary>
        /// <param name="I_am"></param>
        /// <param name="win"></param>
        public Contacts(CORE.User I_am, NativeWindow win)
        {
            PresentUser = I_am;
            PresentUser.MakeOnLine();

            MyWindow = win;
            InitializeComponent();
        }

        /// <summary>
        /// Загрузка страницы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            // Обновляем онлайн-статус пользователя.
            PresentUser.MakeOnLine();

            // Загружаем контакты
            CORE.UserCollection UserList = new CORE.UserCollection(MyWindow.mApp);
            UserList.FillList(PresentUser);

            // Отображаем контакты
            foreach (CORE.User u in UserList)
            {
                listContacts.Items.Add(u);
            }
        }
        /// <summary>
        /// Переходим к переписке с выбранным пользователем
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnWriteMessage_Click(object sender, RoutedEventArgs e)
        {
            // Обновляем онлайн-статус пользователя.
            PresentUser.MakeOnLine();

            CORE.User repicient = new CORE.User(MyWindow.mApp, Convert.ToInt32((sender as Button).Tag));
            repicient.Read();

            MyWindow.GoToMessagePage(repicient);
        }

        /// <summary>
        /// Выполняем поиск контактов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            // Обновляем онлайн-статус пользователя.
            PresentUser.MakeOnLine();

            // Перезагружаем отображаемых пользователей.
            listContacts.Items.Clear();
            CORE.UserCollection UserList = new CORE.UserCollection(MyWindow.mApp);
            UserList.FillList(PresentUser, txtSearch.Text);

            foreach (CORE.User u in UserList)
            {
                listContacts.Items.Add(u);
            }
        }
    }
}
