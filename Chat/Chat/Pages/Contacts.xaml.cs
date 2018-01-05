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
        CORE.User PresentUser;
        NativeWindow MyWindow;

        /// <summary>
        /// 
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


        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            PresentUser.MakeOnLine();
            CORE.UserCollection UserList = new CORE.UserCollection(MyWindow.mApp);
            UserList.FillList(PresentUser);

            foreach (CORE.User u in UserList)
            {
                listContacts.Items.Add(u);
            }
        }

        private void btnWriteMessage_Click(object sender, RoutedEventArgs e)
        {
            PresentUser.MakeOnLine();
            CORE.User repicient = new CORE.User(MyWindow.mApp, Convert.ToInt32((sender as Button).Tag));
            repicient.Read();
            MyWindow.GoToMessagePage(repicient);
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            PresentUser.MakeOnLine();
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
