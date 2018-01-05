using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace CORE
{
    /// <summary>
    /// Класс для подключения к базе данных приложения MessagingSystem
    /// </summary>
    public class App
    {
        /// <summary>
        /// SQL-соединение для базы данных приложения MessagingSystem
        /// </summary>
        internal SqlConnection Connection { get; set; }

        /// <summary>
        /// Инициализирует новый экземпляр класса App. Передает строку подключения к базе данных приложения ConnectionString.
        /// </summary>
        /// <param name="ConnectionString"></param>
        public App(String ConnectionString)
        {
            Connection = new SqlConnection();
            Connection.ConnectionString = ConnectionString; // @"Data Source=.\SQLEXPRESS;Initial Catalog=MessagingSystem; Integrated Security=True;";
            this.OpenConnection();
        }

        /// <summary>
        /// Закрывает соединение с базой данных приложения MessagingSystem
        /// </summary>
        public void CloseConnection()
        {
            if (Connection.State == System.Data.ConnectionState.Open)
            {
                Connection.Close();
            }
        }
        /// <summary>
        /// Открывает соединение с базой данных приложения MessagingSystem
        /// </summary>
        public void OpenConnection()
        {
            if (Connection.State == System.Data.ConnectionState.Open)
            {
                Connection.Close();
            }
                Connection.Open();
        }
    }
}
