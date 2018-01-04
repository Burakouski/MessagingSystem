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
using System.Collections.Specialized;
using System.Threading;
using System.Diagnostics;

namespace CoreTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CORE.App mApp = new CORE.App(@"Data Source=.\SQLEXPRESS;Initial Catalog=MessagingSystem; Integrated Security=True;");

        public MainWindow()
        {
            InitializeComponent();


            CORE.User u = new CORE.User(mApp, 1);
            u.CheckLogin("Ivanov", "123");


            //CORE.App pApp = new CORE.App();
            //CORE.Message mes = new CORE.Message(pApp, 2);
            //mes.Send(1, 3, "privet");
            //MyThread = Thread.CurrentThread;

            //CurApp = Application.Current;
            //CurApp.Exit += CurApp_Exit;
            //dom = AppDomain.CurrentDomain;
            //dom.ProcessExit += CurrentDomain_ProcessExit;

            //MyPro = Process.GetCurrentProcess();
            //MyPro.Disposed += MyPro_Disposed;
            //MyPro.Exited += MyPro_Exited;


            //CORE.MessageCollection mesco = new CORE.MessageCollection(pApp);
            //mesco.Fill(1, 2, 30);
        }



        private void button1_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                CORE.App pApp = mApp;
                CORE.UserCollection usc = new CORE.UserCollection(mApp);
           //     usc.FillList();
                //if (pApp.Connection.State == System.Data.ConnectionState.Open)
                //{
                //    MessageBox.Show("ujndjj");
                //    textBox1.Text = pApp.Connection.State.ToString();
                    
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }

        private void Window_Closed(object sender, EventArgs e)
        {

        }
    }
}
