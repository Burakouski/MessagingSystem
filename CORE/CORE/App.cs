using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace CORE
{
    public class App
    {
        internal SqlConnection Connection { get; set; }

        public App(String ConnectionString)
        {
            Connection = new SqlConnection();
            Connection.ConnectionString = ConnectionString; // @"Data Source=.\SQLEXPRESS;Initial Catalog=MessagingSystem; Integrated Security=True;";
            this.OpenConnection();
        }

        public void CloseConnection()
        {
            if (Connection.State == System.Data.ConnectionState.Open)
            {
                Connection.Close();
            }
        }

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
