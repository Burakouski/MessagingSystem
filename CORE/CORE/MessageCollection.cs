using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Collections;
namespace CORE
{
    /// <summary>
    /// Коллекция сообщений, получаемая из базы данных
    /// </summary>
    public class MessageCollection : IEnumerable, IEnumerator
    {
        /// <summary>
        /// Связывает класс и базу данных приложения MessagingSystem
        /// </summary>
        App mApp;
        ArrayList ArrayMessage;
        int position = -1;

        /// <summary>
        /// Возвращает текущий элемент коллекции
        /// </summary>
        public object Current { get { return ArrayMessage[position]; } private set { } }

        /// <summary>
        /// Инициализирует новый экземпляр класса MessageCollection
        /// </summary>
        /// <param name="papp"></param>
        public MessageCollection(App papp)
        {
            mApp = papp;
            ArrayMessage = new ArrayList();
        }
        /// <summary>
        /// Определяет переписку между пользователем c идентификатором IdUserSender 
        /// и пользователем с идентификатором IdUserRecipient, где NumberMessages - количество последних сообщений в переписке
        /// </summary>
        /// <param name="IdUserSender"></param>
        /// <param name="IdUserRecipient"></param>
        /// <param name="NumberMessages"></param>
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
        /// <summary>
        /// для foreach
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// для foreach
        /// </summary>
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
