﻿using System;
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

namespace Chat
{
    /// <summary>
    /// Профиль
    /// </summary>
    public partial class Profile : Page
    {
        /// <summary>
        /// Связывает с базой данных приложения MessagingSystem
        /// </summary>
        private CORE.App mApp;
        /// <summary>
        /// Текущий пользователь
        /// </summary>
        private CORE.User ProfileUser;

        /// <summary>
        /// Инициализирует новый экземпляр класса Profile
        /// </summary>
        /// <param name="pApp"></param>
        /// <param name="user"></param>
        public Profile(CORE.App pApp, CORE.User user)
        {
            user.Read();
            user.MakeOnLine();
            mApp = pApp;
            ProfileUser = user;
            InitializeComponent();
        }

        /// <summary>
        /// Отображение информации о пользователе
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            txtNameF.Text = ProfileUser.NameF;
            txtNameI.Text = ProfileUser.NameI;
            txtNameO.Text = ProfileUser.NameO;
            txtBirthday.Text = ProfileUser.Birthday.ToLongDateString();
            txtPhone.Text = ProfileUser.Phone;
            
        }
    }
}
