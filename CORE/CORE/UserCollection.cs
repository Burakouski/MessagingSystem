using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Collections;

namespace CORE
{
    public class UserCollection : IEnumerable, IEnumerator
    {
        App mApp;
     //   public List<User> UserList {get; set;}

        ArrayList ArrayUser;
        int position = -1;

        public object Current { get { return ArrayUser[position]; } private set { } }
        
        public UserCollection(App papp)
        {
            mApp = papp;
            ArrayUser = new ArrayList();
        }

        public void FillList(User curUser)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlCommand SC = new SqlCommand("dbo.ListUsers", mApp.Connection);
                SC.CommandType = CommandType.StoredProcedure;
                SC.Parameters.Add("@IdCurrentUser", SqlDbType.VarChar, 100).Value = curUser.IdUser;
                SC.Parameters.Add("@SearchStr", SqlDbType.VarChar, 100).Value = DBNull.Value;
                mApp.OpenConnection();
                SqlDataReader R = SC.ExecuteReader();
                while (R.Read())
                {
                    User u = new User(mApp);
                    u.IdUser = R.GetInt32(R.GetOrdinal("IdUser"));
                    u.NameF = R.GetString(R.GetOrdinal("NameF"));
                    u.NameI = R.GetString(R.GetOrdinal("NameI"));
                    u.NameO = R.GetString(R.GetOrdinal("NameO"));
                    u.Phone = R.GetString(R.GetOrdinal("Phone"));
                    u.Birthday = R.GetDateTime(R.GetOrdinal("Birthday"));
                    u.DateRegistration = R.GetDateTime(R.GetOrdinal("DateRegistration"));
                    u.Online = R.GetString(R.GetOrdinal("Online"));
                    u.Online2 = R.GetString(R.GetOrdinal("Online2"));
                    ArrayUser.Add(u);
                }

                R.Dispose();
                SC.Dispose();
                //SqlDataAdapter adapt = new SqlDataAdapter(SC);
                //adapt.Fill(dt);
                //return dt;

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

        public void FillList(User curUser, string SearchString)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlCommand SC = new SqlCommand("dbo.ListUsers", mApp.Connection);
                SC.CommandType = CommandType.StoredProcedure;
                SC.Parameters.Add("@IdCurrentUser", SqlDbType.VarChar, 100).Value = curUser.IdUser;
                SC.Parameters.Add("@SearchStr", SqlDbType.VarChar, 100).Value = SearchString.Trim();
                mApp.OpenConnection();
                SqlDataReader R = SC.ExecuteReader();
                while (R.Read())
                {
                    User u = new User(mApp);
                    u.IdUser = R.GetInt32(R.GetOrdinal("IdUser"));
                    u.NameF = R.GetString(R.GetOrdinal("NameF"));
                    u.NameI = R.GetString(R.GetOrdinal("NameI"));
                    u.NameO = R.GetString(R.GetOrdinal("NameO"));
                    u.Phone = R.GetString(R.GetOrdinal("Phone"));
                    u.Birthday = R.GetDateTime(R.GetOrdinal("Birthday"));
                    u.DateRegistration = R.GetDateTime(R.GetOrdinal("DateRegistration"));
                    u.Online = R.GetString(R.GetOrdinal("Online"));
                    u.Online2 = R.GetString(R.GetOrdinal("Online2"));
                    ArrayUser.Add(u);
                }

                R.Dispose();
                SC.Dispose();
                //SqlDataAdapter adapt = new SqlDataAdapter(SC);
                //adapt.Fill(dt);
                //return dt;

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
            if (position < ArrayUser.Count - 1)
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
