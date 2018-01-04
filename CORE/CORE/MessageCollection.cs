using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Collections;
namespace CORE
{
    public class MessageCollection : IEnumerable, IEnumerator
    {
        App mApp;
        ArrayList ArrayMessage;
        int position = -1;

        public object Current { get { return ArrayMessage[position]; } private set { } }

        public MessageCollection(App papp)
        {
            mApp = papp;
            ArrayMessage = new ArrayList();
        }

        public void Fill(int IdUserSender, int IdUserRecipient, int NumberMessages)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlCommand SC = new SqlCommand("[dbo].[ListMessages]", mApp.Connection);
                SC.CommandType = CommandType.StoredProcedure;

                SC.Parameters.Add("@IdUserSender", SqlDbType.Int).Value = IdUserSender;
                SC.Parameters.Add("@IdUserRecipient", SqlDbType.Int).Value = IdUserRecipient;
                SC.Parameters.Add("@NumberMessages", SqlDbType.Int).Value = NumberMessages;

                mApp.OpenConnection();
                SqlDataReader Reader = SC.ExecuteReader();
                while (Reader.Read())
                {
                    Message m = new Message(mApp);

                    int IdSender = Reader.GetInt32(Reader.GetOrdinal("IdUserSender"));
                    m.Sender = new User(mApp, IdUserSender);
                    
                    int IdRecipient = Reader.GetInt32(Reader.GetOrdinal("IdUserRecipient"));
                    m.Recipient = new User(mApp, IdRecipient);
                    m.Text = Reader.GetString(Reader.GetOrdinal("Text"));
                    m.Date = Reader.GetDateTime(Reader.GetOrdinal("DateSend")).ToLocalTime();


                    if (Reader.GetBoolean(Reader.GetOrdinal("TypeMessage")))
                    {
                        m.Type = TypeMessage.Sent;
                        m.SentText = Reader.GetString(Reader.GetOrdinal("Text"));
                        m.DateSent = Reader.GetDateTime(Reader.GetOrdinal("DateSend")).ToString();
                    }
                    else
                    {
                        m.Type = TypeMessage.Received;
                        m.ReceivedText = Reader.GetString(Reader.GetOrdinal("Text"));
                        m.DateReceived = Reader.GetDateTime(Reader.GetOrdinal("DateSend")).ToString();
                    }

                    ArrayMessage.Add(m);
                }

                Reader.Dispose();
                SC.Dispose();

                foreach (Message m in ArrayMessage)
                {
                    m.Sender.Read();
                    m.Recipient.Read();
                }
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

        public bool MoveNext()
        {
            if (position < ArrayMessage.Count - 1)
            {
                position++;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Reset()
        {
            position = -1;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this as IEnumerator;
        }
    }
}
