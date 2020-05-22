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
    public class Part : INotifyPropertyChanged
    {
        int _id;
        string _name;
        double _price;
        int _quantity;
        public int ID { get { return _id; } set { _id = value;OnPropertyChanged(); } }
        public string Name { get { return _name; } set { _name = value; OnPropertyChanged(); } }
        public double Price { get { return _price; } set { _price = value; OnPropertyChanged(); } }
        public int Quantity { get { return _quantity; } set { _quantity = value; OnPropertyChanged(); } }
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public static ObservableCollection<Part> Get_Collection(MySqlConnection dbConn)
        {
           String query = string.Format("SELECT * FROM {0}","czesc");
            Part tmpPart;
            MySqlCommand cmd = new MySqlCommand(query, dbConn);

            ObservableCollection<Part> list = new ObservableCollection<Part>();

            dbConn.Open();

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                tmpPart = new Part();
                tmpPart.ID = (int)reader["ID"];
                tmpPart.Name = reader["Nazwa"].ToString();
                tmpPart.Quantity =(int) reader["Ilosc"];
                tmpPart.Price = (double)reader["Cena"];
         
                list.Add(tmpPart);
            }

            reader.Close();

            dbConn.Close();

            
            return list;

        }

    }
}
