using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Controls;

namespace CORE
{
    public class Message
    {
        private App mApp;
        private int IdMessage { get; set; }

        public User Sender { get; set; }
        public User Recipient { get; set; }
        //public string ReceivedMessage { get; set; }
        public String ReceivedText { get; set; }
        public String DateReceived { get; set; }

        public string SentText { get; set; }
        public String DateSent { get; set; }

        public string Text { get; set; }
        public DateTime Date { get; set; }
        public TypeMessage Type {get; set;}


        public Message(App papp, int idMessage)
        {
            mApp = papp;
            IdMessage = idMessage;
        }

        public Message(App papp)
        {
            mApp = papp;
        }


        public void Send(int IdSender, int IdRecipient, string Text)
        {
            try
            {
                SqlCommand SC = new SqlCommand("[dbo].[SendMessage]", mApp.Connection);
                SC.CommandType = CommandType.StoredProcedure;

                SC.Parameters.Add("@Message", SqlDbType.VarChar, int.MaxValue).Value = Text.Trim();
                SC.Parameters.Add("@IdUserSender", SqlDbType.Int).Value = IdSender;
                SC.Parameters.Add("@IdUserRecipient", SqlDbType.Int).Value = IdRecipient;

                mApp.OpenConnection();

                SC.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                mApp.CloseConnection();
            }
        }

        public void Read()
        {
            try
            {
                SqlCommand command = new SqlCommand("[dbo].[ReadMessage]", mApp.Connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@IdMessage", SqlDbType.Int, 50).Value = IdMessage;

                mApp.OpenConnection();

                SqlDataReader R = command.ExecuteReader();
                if (R.Read())
                {
                    int IdUserSender = R.GetInt32(R.GetOrdinal("IdUserSender"));
                    Sender = new User(mApp, IdUserSender);
                    

                    int IdUserRecipient = R.GetInt32(R.GetOrdinal("IdUserRecipient"));
                    Recipient = new User(mApp, IdUserRecipient);
                    

                    Text = R.GetString(R.GetOrdinal("Text"));
                    Date = R.GetDateTime(R.GetOrdinal("DateSend"));

                    Recipient.Read();
                    Sender.Read();
                }

                R.Dispose();
                command.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                mApp.CloseConnection();
            }
        }
 
    }

    public enum TypeMessage
    {
        Sent,
        Received
    }
}
