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
    /// Страница сообщений
    /// </summary>
    public partial class Messages : Page
    {
        /// <summary>
        ///Количество отображаемых сообщений
        /// </summary>
        private int NumberMessages = 50;
        /// <summary>
        /// Текущий пользователь
        /// </summary>
        CORE.User PresentUser;
        /// <summary>
        /// Пользователь с кем ведется переписка
        /// </summary>
        CORE.User RecipientUser;
        /// <summary>
        /// Окно в котором загружается Messages (Страница сообщений)
        /// </summary>
        NativeWindow MainWin;

        /// <summary>
        /// Инициализирует новый экземпляр класса Messages
        /// </summary>
        /// <param name="I_am"></param>
        /// <param name="win"></param>
        public Messages(CORE.User I_am, NativeWindow win)
        {
            InitializeComponent();
            MainWin = win;
            PresentUser = I_am;

            LoadListBoxContacts();
            PresentUser.MakeOnLine();
        }
        /// <summary>
        /// Инициализирует новый экземпляр класса Messages (Для перехода со страницы контактов). 
        /// С учётом пользовтеля, с которым ведется переписка
        /// </summary>
        /// <param name="I_am"></param>
        /// <param name="Recipient"></param>
        /// <param name="win"></param>
        public Messages(CORE.User I_am, CORE.User Recipient, NativeWindow win)
        {
            InitializeComponent();
            MainWin = win;

            PresentUser = I_am;
            RecipientUser = Recipient;
            SetInfoRecipient();

            LoadListBoxContacts();
            LoadMessages(PresentUser, RecipientUser);
            PresentUser.MakeOnLine();

        }

        /// <summary>
        /// Отображаем контакты
        /// </summary>
        private void LoadListBoxContacts()
        {
            ListContacts.Items.Clear();
            CORE.UserCollection UserList = new CORE.UserCollection(MainWin.mApp);
            UserList.FillList(PresentUser);

            foreach (CORE.User u in UserList)
            {
                ListContacts.Items.Add(u);
            }

            ListContacts.SelectedItem = RecipientUser;
        }

        private void ListContacts_MouseDown(object sender, MouseButtonEventArgs e)
        {
            
        }
        /// <summary>
        /// отображаем переписку между пользователями Sender (текущий пользователь) и Recipient
        /// </summary>
        /// <param name="Sender"></param>
        /// <param name="Recipient"></param>
        private void LoadMessages(CORE.User Sender, CORE.User Recipient)
        {
            if (Recipient != null)
            {
                CORE.MessageCollection mesco = new CORE.MessageCollection(MainWin.mApp);
                mesco.Fill((int)Sender.IdUser, (int)Recipient.IdUser, NumberMessages);
                ListMessages.ItemsSource = mesco;
            }
        }

        /// <summary>
        /// Переопределение пользователя с которым ведется переписка, при изменении выбора пользователя
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListContacts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Обновляем онлайн-статус пользователя. 
            PresentUser.MakeOnLine();

            RecipientUser = new CORE.User(MainWin.mApp, (int)((ListContacts.SelectedItem as CORE.User).IdUser));
            SetInfoRecipient();
            LoadMessages(PresentUser, RecipientUser);
        }

        /// <summary>
        /// Отображение информации о пользователе с которым ведется переписка и его статусе онлайн
        /// </summary>
        private void SetInfoRecipient()
        {
            RecipientUser.Read();
            txtInfoRecipient.Text = RecipientUser.GetInformation();
        }

        /// <summary>
        /// Отправляем сообщение
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            // Обновляем онлайн-статус пользователя. 
            PresentUser.MakeOnLine();

            if (RecipientUser != null)
            {
                CORE.Message NewMessage = new CORE.Message(MainWin.mApp);
                string Text = txtMessage.Text;
                NewMessage.Send((int)PresentUser.IdUser, (int)RecipientUser.IdUser, Text);

                LoadMessages(PresentUser, RecipientUser);
                txtMessage.Clear();
            }
        }

        /// <summary>
        ///  Возвращаем выбранного пользователя (пользователя с кем ведется переписка)
        /// </summary>
        /// <returns></returns>
        private CORE.User SelectedUser()
        {
            return ListContacts.SelectedItem as CORE.User;
        }

        /// <summary>
        /// Увеличиваем количество отображаемых сообщений
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNumberMsges_Click(object sender, RoutedEventArgs e)
        {
            PresentUser.MakeOnLine();
            NumberMessages += 50;
            btnNumberMsges.Content = NumberMessages.ToString();
            if (RecipientUser != null)
            {
                LoadMessages(PresentUser, RecipientUser);
            }
        }

        /// <summary>
        /// Ищем контакты
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            PresentUser.MakeOnLine();
            ListContacts.Items.Clear();
            CORE.UserCollection UserList = new CORE.UserCollection(MainWin.mApp);
            UserList.FillList(PresentUser, txtSearch.Text);

            foreach (CORE.User u in UserList)
            {
                ListContacts.Items.Add(u);
            }
        }
    }
}
