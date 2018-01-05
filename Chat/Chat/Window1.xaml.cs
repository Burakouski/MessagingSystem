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
        Profile prof;
        Pages.LoginPage LP;
        public CORE.App mApp;


        private CORE.User PresentUser;
        
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


        private void BtnProfile_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Profile(mApp, PresentUser);
        }

        private void BtnContacts_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Contacts(PresentUser, this);
        }

        private void BtnMessages_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Pages.Messages(PresentUser, this);
        }

        public void GoToMessagePage(CORE.User Repicient)
        {
            Main.Content = new Pages.Messages(PresentUser, Repicient, this);
        }

        public void LoginTrue(object sender)
        {
            PresentUser = new CORE.User(mApp, (int)sender);
            EnableMenu();

            Main.Content = new Profile(mApp, PresentUser);
            PresentUser.Read();
            PresentUser.MakeOnLine();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            LP = new Pages.LoginPage(this);
            Main.Content = LP;
            DisableMenu();
        }


        private void DisableMenu()
        {
            ChatMenuPanel.IsEnabled = false;
        }

        private void EnableMenu()
        {
            ChatMenuPanel.IsEnabled = true;
        }
    }
}
