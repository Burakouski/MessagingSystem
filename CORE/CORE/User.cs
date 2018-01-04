using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace CORE
{
    public class User
    {
        App mApp;

        public int? IdUser { get; set; }
        public string NameF { get; set; }
        public string NameI { get; set; }
        public string NameO { get; set; }

        public DateTime Birthday { get; set; }
        public string Phone { get; set; }
        public DateTime DateRegistration { get; set; }

        public string Login { get; set; }
        public string Password { get; set; }

        public string Online { get; set; }
        public string Online2 { get; set; }

        public User(App pApp)
        {
            mApp = pApp;

        }

        public User(App pApp, int idUser)
        {
            mApp = pApp;
            IdUser = idUser;
        }

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

        public void MakeOffLine()
        {
            try
            {
                SqlCommand SC = new SqlCommand("dbo.UserOffLine", mApp.Connection);
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

        public string GetInformation()
        {
            return NameF + " " + NameI + " " + NameO + " " + Online;
        }
    }
}
