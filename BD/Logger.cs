using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BD
{
    class Logger_CB

    {
        private string _serverIp;
        private string _database;
        /// <summary>
        /// DB User NOT app user
        /// </summary>
        private string _uid; 
        private string _paswd;

        private string app_user;
        private string passwd_user;


        public string ServerIp { get { return _serverIp; } set { _serverIp = value; } }
        public string Database { get { return _database; } set { _database = value; } }
        public string UID { get { return _uid; } set { _uid = value; } }
        public string PASSWD { get { return _paswd; } set { _paswd = value; } }
        public MySqlConnection context { get; set; }

        public Logger_CB(string server="127.0.0.1",string database="fabryka",string uid="root",string passwd="zxcvbnm")
        {
            ServerIp = server;
            Database = database;
            UID = uid;
            PASSWD = passwd;
        }

        private string ConnectionStringGet()
        {
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            builder.Server = ServerIp;
            builder.UserID = UID;
            builder.Port = 3306;
            builder.Password = PASSWD;
            builder.Database = Database;
            return builder.ToString();
        }

        public MySqlConnection ContextMake()
        {
            context= new MySqlConnection(ConnectionStringGet());
            return context;
        }

        public bool LogintoApp(string _array,string subname, string paswd)
        {

            String query = string.Format("SELECT ID FROM {0} WHERE Nazwisko='{1}' and Haslo='{2}'", _array,subname,paswd);

            MySqlCommand cmd = new MySqlCommand(query, context);

            context.Open();

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int id = (int)reader["ID"];
            }

            reader.Close();

            context.Close();



            return false;
        }







    }
}
