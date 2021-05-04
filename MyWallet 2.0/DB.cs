using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWallet_2._0
{
    class DB
    {
        SQLiteConnection connection = new SQLiteConnection("Data Source=.\\MyWallet.db");


        public void openConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
                connection.Open();
        }

        public void closeConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
                connection.Close();
        }

        public SQLiteConnection getConnection()
        {
            return connection;
        }
    }
}
