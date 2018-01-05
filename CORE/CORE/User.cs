using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace CORE
{
    /// <summary>
    /// Пользователь
    /// </summary>
    public class User
    {
        App mApp;
        /// <summary>
        /// идентификатор пользователя
        /// </summary>
        public int? IdUser { get; set; }
        /// <summary>
        /// Фамилия
        /// </summary>
        public string NameF { get; set; }
        /// <summary>
        /// Имя
        /// </summary>
        public string NameI { get; set; }
        /// <summary>
        /// Отчество
        /// </summary>
        public string NameO { get; set; }
        /// <summary>
        /// Дата рождения
        /// </summary>
        public DateTime Birthday { get; set; }
        /// <summary>
        /// Телефон
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// Дата регистрации
        /// </summary>
        public DateTime DateRegistration { get; set; }
        /// <summary>
        /// Логин
        /// </summary>
        public string Login { get; set; }
        /// <summary>
        /// пароль
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Полное описание присутствия пользователя онлайн 
        /// </summary>
        public string Online { get; set; }
        /// <summary>
        /// Краткое описание присутствия пользователя онлайн
        /// </summary>
        public string Online2 { get; set; }

        /// <summary>
        /// Инициализирует новый экземпляр класса User, не существующий в базе данных приложения MessagingSystem
        /// </summary>
        /// <param name="pApp"></param>
        public User(App pApp)
        {
            mApp = pApp;

        }
        /// <summary>
        /// Инициализирует новый экземпляр класса User, существующий в базе данных приложения MessagingSystem
        /// </summary>
        /// <param name="pApp"></param>
        /// <param name="idUser"></param>
        public User(App pApp, int idUser)
        {
            mApp = pApp;
            IdUser = idUser;
        }
        /// <summary>
        /// Регистрация пользователя
        /// </summary>
        public void NewUser()
        {
            try
            {
                SqlCommand SC = new SqlCommand("[dbo].[Registration]", mApp.Connection);
                SC.CommandType = CommandType.StoredProcedure;

                SC.Parameters.AddWithValue("@NameF", NameF); //Add("@NameF", SqlDbType.VarChar, 100).Value = NameF;
                SC.Parameters.Add("@NameI", SqlDbType.VarChar, 100).Value = NameI;
                SC.Parameters.Add("@NameO", SqlDbType.VarChar, 100).Value = NameO;
                SC.Parameters.Add("@Password", SqlDbType.VarChar, 100).Value = Password;
                SC.Parameters.Add("@Login", SqlDbType.VarChar, 100).Value = Login;
                SC.Parameters.Add("@Phone", SqlDbType.VarChar, 50).Value = Phone;
                SC.Parameters.Add("@Birthday", SqlDbType.Date, 100).Value = Birthday;
                SC.Parameters.Add("@DateRegistration", SqlDbType.Date, 100).Value = DateRegistration;

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
        /// Считывает информацию о пользователе из базы данных приложения MessagingSystem
        /// </summary>
        public void Read()
        {
            try
            {
                SqlCommand command = new SqlCommand("dbo.UserRead", mApp.Connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@IdUser", SqlDbType.Int, 50).Value = IdUser;

                mApp.OpenConnection();

                SqlDataReader R = command.ExecuteReader();
                if (R.Read())
                {
                    NameF = R.GetString(R.GetOrdinal("NameF"));
                    NameI = R.GetString(R.GetOrdinal("NameI"));
                    NameO = R.GetString(R.GetOrdinal("NameO"));
                    Phone = R.GetString(R.GetOrdinal("Phone"));
                    Password = R.GetString(R.GetOrdinal("Password"));
                    Birthday = R.GetDateTime(R.GetOrdinal("Birthday"));
                    DateRegistration = R.GetDateTime(R.GetOrdinal("DateRegistration"));
                    Online = R.GetString(R.GetOrdinal("Online"));
                    Online2 = R.GetString(R.GetOrdinal("Online2"));
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
        /// <summary>
        /// Проверяет правильность введенных логина и пароля
        /// </summary>
        /// <param name="Login"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public int? CheckLogin( string Login, string Password)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlCommand SC = new SqlCommand("[dbo].[Check_Login]", mApp.Connection);
                SqlParameterCollection pp = SC.Parameters;
                pp.Add("@Login", SqlDbType.VarChar, 100).Value = Login;
                pp.Add("@Password", SqlDbType.VarChar, 100).Value = Password;
                SC.CommandType = CommandType.StoredProcedure;

                mApp.OpenConnection();
                SqlDataAdapter adapt = new SqlDataAdapter(SC);
                adapt.Fill(dt);

                if (dt.Rows.Count == 0)
                { return null; }
                else
                { return Convert.ToInt32(dt.Rows[0][0]); }

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
        /// Обновляет информацию в базе данных о присутствии пользователя онлайн
        /// </summary>
        public void MakeOnLine()
        {
            try
            {
                SqlCommand SC = new SqlCommand("dbo.UserOnLine", mApp.Connection);
                SC.CommandType = CommandType.StoredProcedure;

                SC.Parameters.AddWithValue("@IdUser", IdUser);

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
        /// Статусная строка о пользователе и его онлайн-статусе 
        /// </summary>
        /// <returns></returns>
        public string GetInformation()
        {
            return NameF + " " + NameI + " " + NameO + " " + Online;
        }
    }
}
