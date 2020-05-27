using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BD
{
    public class Module: INotifyPropertyChanged
    {
        int _id;
        string _name;
        double _price;
        int _quantity;
        string _comment;

        public int ID { get { return _id; } set { _id = value; OnPropertyChanged(); } }
        public string Name { get { return _name; } set { _name = value; OnPropertyChanged(); } }
        public double Price { get { return _price; } set { _price = value; OnPropertyChanged(); } }
        public int Quantity { get { return _quantity; } set { _quantity = value; OnPropertyChanged(); } }
        public string Comment { get { return _comment; } set { _comment = value; OnPropertyChanged(); } }
        public ObservableCollection<Part> components = new ObservableCollection<Part>();


        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public static ObservableCollection<Module> Get_Collection(MySqlConnection dbConn)
        {
            String query = string.Format("SELECT * FROM {0}", "podzespol");
            Module module;
            MySqlCommand cmd = new MySqlCommand(query, dbConn);

            ObservableCollection<Module> list = new ObservableCollection<Module>();

            dbConn.Open();

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                module = new Module();
                module.ID = (int)reader["ID"];
                module.Name = reader["Nazwa"].ToString();
                module.Quantity = (int)reader["Ilosc"];
                module.Comment = reader["Komentarz"].ToString();

                list.Add(module);
            }

            reader.Close();

            dbConn.Close();


            return list;

        }

        public static bool sendNewModule(Module module, MySqlConnection dbConn)
        {
            bool status;
            String query = string.Format("INSERT INTO podzespol (Nazwa,Ilosc,Komentarz) VALUES ('{0}', '{1}', '{2}')", module.Name, module.Quantity,module.Comment);

            MySqlCommand cmd = new MySqlCommand(query, dbConn);

            dbConn.Open();

            if (0 != cmd.ExecuteNonQuery())
                status = true;
            else status = false;

            dbConn.Close();

            return status;
        }

        public static bool DeleteModule(int ID, MySqlConnection dbConn)
        {
            bool status;
            String query = string.Format("DELETE FROM podzespol WHERE ID='{0}'", ID);

            MySqlCommand cmd = new MySqlCommand(query, dbConn);

            dbConn.Open();

            if (0 != cmd.ExecuteNonQuery())
                status = true;
            else status = false;

            dbConn.Close();

            return status;
        }


    }
}
