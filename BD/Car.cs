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
    public class Car : INotifyPropertyChanged
    {
        int _id;
        string _name;
        int _demand;
        double _price;
        string _comment;

        public int ID { get { return _id; } set { _id = value; OnPropertyChanged(); } }
        public string Name { get { return _name; } set { _name = value; OnPropertyChanged(); } }
        public double Price { get { return _price; } set { _price = value; OnPropertyChanged(); } }
        public int Demand { get { return _demand; } set { _demand = value; OnPropertyChanged(); } }
        public string Comment { get { return _comment; } set { _comment = value; OnPropertyChanged(); } }
        public ObservableCollection<Module> components = new ObservableCollection<Module>();


        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public static ObservableCollection<Car> Get_Collection(MySqlConnection dbConn)
        {
            String query = string.Format("SELECT * FROM {0}", "samochod");
            Car car;
            MySqlCommand cmd = new MySqlCommand(query, dbConn);

            ObservableCollection<Car> list = new ObservableCollection<Car>();

            dbConn.Open();

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                car = new Car();
                car.ID = (int)reader["ID"];
                car.Name = reader["Nazwa_Modelu"].ToString();
                car.Demand = (int)reader["Zapotrzebowanie"];
                car.Price = (double)reader["Cena"];
                car.Comment = reader["Komentarz"].ToString();
                list.Add(car);
            }

            reader.Close();

            dbConn.Close();


            return list;

        }

        public static bool sendNewCar(Car car, MySqlConnection dbConn)
        {
            bool status;
            String query = string.Format("INSERT INTO samochod (Nazwa_Modelu,Zapotrzebowanie,Cena,Komentarz) VALUES ('{0}', '{1}', '{2}', '{3}')", car.Name, car.Demand, car.Price,car.Comment);

            MySqlCommand cmd = new MySqlCommand(query, dbConn);

            dbConn.Open();

            if (0 != cmd.ExecuteNonQuery())
                status = true;
            else status = false;

            dbConn.Close();

            return status;
        }

        public static bool DeleteCar(int ID,MySqlConnection dbConn)
        {
            bool status;
            String query = string.Format("DELETE FROM samochod WHERE ID='{0}'",ID);

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