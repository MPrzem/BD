using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BD
{
    class Logger

    {
        private string _serverIp;
        private string _database;
        private string _uid;
        private string _paswd;


        public string ServerIp { get { return _serverIp; } set { _serverIp = value; } }
        public string Database { get { return _database; } set { _database = value; } }
        public string UID { get { return _uid; } set { _uid = value; } }
        public string PASSWD { get { return _paswd; } set { _paswd = value; } }

        public Logger(string server="127.0.0.1",string database="fabryka",string uid="root",string passwd="ukulele")
        {
            ServerIp = server;
            Database = database;
            UID = uid;
            PASSWD = passwd;
        }

        public string ConnectionStringGet()
        {
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            builder.Server = ServerIp;
            builder.UserID = UID;
            builder.Password = PASSWD;
            builder.Database = Database;
            String connString = builder.ToString();


        }

    }
}
