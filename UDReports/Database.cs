using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace UDReports
{
    public class Database
    {
        string ConnectionString =$@"Data Source = C:\Users\{Environment.UserName}\{Environment.SpecialFolder.Desktop}\FinalTest.db; Version=3;datetimeformat=CurrentCulture;";
        SQLiteConnection connection;

        public void OpenConnection()
        {
            connection = new SQLiteConnection(ConnectionString);
            connection.Open();
        }

        public void CloseConnection()
        {
            connection.Close();
        }

        public SQLiteDataReader DataReader(string Sql)
        {
            OpenConnection();
            SQLiteCommand command = new SQLiteCommand(Sql, connection);
            SQLiteDataReader dataReader = command.ExecuteReader();
            return dataReader;
        }
    }
}
