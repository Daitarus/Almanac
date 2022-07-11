using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Microsoft.Data.SqlClient;

namespace Almanac
{
    public class Database
    {

        private SqlConnection sqlConnection = null;
        private bool flagConection;

        public bool FlagConection { get { return flagConection; } }

        public Database() { }
        public Database(string ConnectionString)
        {
            sqlConnection = new SqlConnection(ConnectionString);
            if (!flagConection)
            {
                try
                {
                    sqlConnection.Open();
                    flagConection = true;
                }
                catch (SqlException ex)
                {
                    flagConection = false;
                    Console.WriteLine(ex.Message);
                }
            }
        }
        public void Connection()
        {
            if (!flagConection)
            {
                try
                {
                    sqlConnection.Open();
                    flagConection = true;
                }
                catch (SqlException ex)
                {
                    flagConection = false;
                    Console.WriteLine(ex.Message);
                }
            }
        }
        public void Close()
        {
            if (flagConection)
            {
                sqlConnection.Close();
                flagConection=false;
            }
        }
    }
}
