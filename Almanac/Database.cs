using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;

namespace Almanac
{
    public class Database
    {

        private SqlConnection sqlConnection = null;

        public bool FlagConection 
        { 
            get { return sqlConnection.State == ConnectionState.Open; } 
        }

        public Database() { }
        public Database(string ConnectionString)
        {
            sqlConnection = new SqlConnection(ConnectionString);
            if (!FlagConection)
            {
                try
                {
                    sqlConnection.Open();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        public bool Connection(string ConnectionString)
        {
            sqlConnection = new SqlConnection(ConnectionString);
            if (!FlagConection)
            {
                try
                {
                    sqlConnection.Open();
                    return true;
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                    return false;
                }
            }
            return false;
        }
        public void Close()
        {
            if (FlagConection)
            {
                sqlConnection.Close();
            }
        }
        public bool InsertUser(User user)
        {
            bool flag = false;
            try
            {
                SqlCommand insertUser = new SqlCommand($"INSERT INTO Users (_Login, _Password) VALUES (N'{user.login}', '{user.password}')", sqlConnection);
                insertUser.ExecuteNonQuery();
                flag = true;
            }
            catch (SqlException ex)
            {
                flag = false;
            }
            return flag;
        }
        public List<int> GetAllId()
        {
            List<int> id = new List<int>();
            SqlDataReader dataReader = null;
            try
            {
                SqlCommand readId = new SqlCommand($"SELECT Id From Users", sqlConnection);
                dataReader = readId.ExecuteReader();
                while (dataReader.Read())
                {
                    id.Add(Convert.ToInt32(dataReader["Id"]));
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if ((dataReader != null) && (!dataReader.IsClosed))
                {
                    dataReader.Close();
                }
            }
            return id;
        }
        public List<User> GetAllUsers()
        {
            List<User> users = new List<User>();
            User user = new User();
            SqlDataReader dataReader = null;
            try
            {
                SqlCommand readUsers = new SqlCommand($"SELECT * From Users", sqlConnection);
                dataReader = readUsers.ExecuteReader();
                while (dataReader.Read())
                {
                    user.id = Convert.ToInt32(dataReader["Id"]);
                    user.login = Convert.ToString(dataReader["_Login"]);
                    user.password = Convert.ToString(dataReader["_Password"]);
                    //user.id_record = Convert.ToInt32(dataReader["Id_record"]);
                    users.Add(user);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if ((dataReader != null) && (!dataReader.IsClosed))
                {
                    dataReader.Close();
                }
            }
            return users;
        }
        public User GetUserByLogin(string login)
        {
            User user = new User();
            SqlDataReader dataReader = null;
            try
            {
                SqlCommand readUsers = new SqlCommand($"SELECT * From Users WHERE _Login = '{login}'", sqlConnection);
                dataReader = readUsers.ExecuteReader();
                while (dataReader.Read())
                {
                    user.id = Convert.ToInt32(dataReader["Id"]);
                    user.login = Convert.ToString(dataReader["_Login"]);
                    user.password = Convert.ToString(dataReader["_Password"]);
                    //user.id_record = Convert.ToInt32(dataReader["Id_record"]);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if ((dataReader != null) && (!dataReader.IsClosed))
                {
                    dataReader.Close();
                }
            }
            return user;
        }
        
    }
}
