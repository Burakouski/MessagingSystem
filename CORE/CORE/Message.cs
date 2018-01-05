using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Controls;

namespace CORE
{
    /// <summary>
    /// Сообщение
    /// </summary>
    public class Message
    {
        /// <summary>
        /// Связывает класс и базу данных приложения MessagingSystem
        /// </summary>
        private App mApp;
        /// <summary>
        /// Идентификатор сообщения
        /// </summary>
        private int IdMessage { get; set; }

        /// <summary>
        /// Пользователь, отправляющий сообщение
        /// </summary>
        public User Sender { get; set; }

        /// <summary>
        /// Пользователь, получающий сообщение
        /// </summary>
        public User Recipient { get; set; }
        
        /// <summary>
        /// Текст полученного сообщения
        /// </summary>
        public String ReceivedText { get; set; }
        /// <summary>
        /// Дата полученного сообщения
        /// </summary>
        public String DateReceived { get; set; }

        /// <summary>
        /// Текст отправленного сообщения
        /// </summary>
        public string SentText { get; set; }
        /// <summary>
        /// Дата отправленного сообщения
        /// </summary>
        public String DateSent { get; set; }

        /// <summary>
        /// Текст сообщения
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// Дата сообщения
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Тип сообщения
        /// </summary>
        public TypeMessage Type {get; set;}

        /// <summary>
        /// Инициализирует новый экземпляр класса Message, существующий в базе данных приложения MessagingSystem
        /// </summary>
        /// <param name="papp"></param>
        /// <param name="idMessage">Идентификатор сообщения</param>
        public Message(App papp, int idMessage)
        {
            mApp = papp;
            IdMessage = idMessage;
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса Message, не существующий в базе данных приложения MessagingSystem
        /// </summary>
        /// <param name="papp"></param>
        public Message(App papp)
        {
            mApp = papp;
        }

        /// <summary>
        /// Отправляет сообщение c текстом <paramref name="text"/> от пользователя с идентификатором IdSender(Отправляющий) пользователю с идентификатором IdRecipient (Получающий)
        /// </summary>
        /// <param name="IdSender">Кто отправляет</param>
        /// <param name="IdRecipient">Кому отправляет</param>
        /// <param name="text">Текст сообщения</param>
        public void Send(int IdSender, int IdRecipient, string text)
        {
            try
            {
                SqlCommand SC = new SqlCommand("[dbo].[SendMessage]", mApp.Connection);
                SC.CommandType = CommandType.StoredProcedure;

                SC.Parameters.Add("@Message", SqlDbType.VarChar, int.MaxValue).Value = text.Trim();
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
        /// <summary>
        /// Считывает информацию о сообщении из базы данных приложения MessagingSystem
        /// </summary>
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
    /// <summary>
    /// Определяет тип сообщения
    /// </summary>
    public enum TypeMessage
    {
        /// <summary>
        /// Отправлено
        /// </summary>
        Sent,
        /// <summary>
        /// Получено
        /// </summary>
        Received
    }
}
