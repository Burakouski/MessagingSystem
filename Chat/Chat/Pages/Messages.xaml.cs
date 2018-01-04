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
    /// Interaction logic for Messages.xaml
    /// </summary>
    public partial class Messages : Page
    {
        private int NumberMessages = 50;
        CORE.User PresentUser;
        CORE.User RecipientUser;
        Window1 MainWin;

        public Messages(CORE.User I_am, Window1 win)
        {
            InitializeComponent();
            MainWin = win;
            PresentUser = I_am;

            LoadListBoxContacts();
            PresentUser.MakeOnLine();
            //LoadMessages((int)PresentUser.IdUser, (int)RecipientUser.IdUser);
        }

        public Messages(CORE.User I_am, CORE.User Recipient, Window1 win)
        {
            InitializeComponent();
            MainWin = win;

            PresentUser = I_am;
            RecipientUser = Recipient;
            SetInfoRecipient();

            LoadListBoxContacts();
            LoadMessages((int)PresentUser.IdUser, RecipientUser);
            PresentUser.MakeOnLine();

        }

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

        private void LoadMessages(int IdSender, CORE.User Recipient)
        {
            if (Recipient != null)
            {
                CORE.MessageCollection mesco = new CORE.MessageCollection(MainWin.mApp);
                mesco.Fill(IdSender, (int)Recipient.IdUser, NumberMessages);
                ListMessages.ItemsSource = mesco;
            }
        }

        private void ListContacts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            RecipientUser = new CORE.User(MainWin.mApp, (int)((ListContacts.SelectedItem as CORE.User).IdUser));
            SetInfoRecipient();
            LoadMessages((int)PresentUser.IdUser, RecipientUser);
        }

        private void SetInfoRecipient()
        {
            RecipientUser.Read();
            txtInfoRecipient.Text = RecipientUser.GetInformation();
        }

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            PresentUser.MakeOnLine();
            if (RecipientUser != null)
            {
                CORE.Message NewMessage = new CORE.Message(MainWin.mApp);
                string Text = txtMessage.Text;
                NewMessage.Send((int)PresentUser.IdUser, (int)RecipientUser.IdUser, Text);

                LoadMessages((int)PresentUser.IdUser, RecipientUser);
                txtMessage.Clear();
            }
        }

        private CORE.User SelectedUser()
        {
            return ListContacts.SelectedItem as CORE.User;
        }

        private void btnNumberMsges_Click(object sender, RoutedEventArgs e)
        {
            PresentUser.MakeOnLine();
            NumberMessages += 50;
            btnNumberMsges.Content = NumberMessages.ToString();
            if (RecipientUser != null)
            {
                LoadMessages((int)PresentUser.IdUser, RecipientUser);
            }
        }

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
