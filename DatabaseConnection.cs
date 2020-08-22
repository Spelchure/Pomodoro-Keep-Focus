using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Security.Cryptography;

namespace Pomodoro_Keep_Focus
{
    class DatabaseConnection
    {
        private SQLiteConnection connection;
        private SQLiteCommand command;

        public SQLiteConnection GetConnection
        {
            get
            {
                return connection;
            }
        }
        public SQLiteCommand GetCommand
        {
            get
            {
                return command;
            }
        }

        public DatabaseConnection(string fileName)
        {
            string connectionString = "URI=file:" + fileName;
            this.connection = new SQLiteConnection(connectionString);
            this.command = new SQLiteCommand(connection);
            this.connection.Open();
        }
        
        ~DatabaseConnection()
        {
            //this.connection.Close();
        }
      
    }
}
