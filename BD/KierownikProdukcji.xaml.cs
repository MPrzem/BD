using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BD
{
    /// <summary>
    /// Logika interakcji dla klasy KierownikProdukcji.xaml
    /// </summary>
    public partial class Zarzadca : Window, INotifyPropertyChanged
    {
        int partQuantity;
        int componentQuantity;
        int carQuantity;
        string login;
        public string PartQuantity
        {
            get { return "Ilosc potrzebnych do podzespolu: " + partQuantity.ToString(); }
            set
            {
                try
                {
                    partQuantity = Int32.Parse(value);
                    OnPropertyChanged();
                }
                catch
                {
                    MessageBox.Show("Podano zły format");
                }


            }
        }
        public string CarQuantity
        {
            get { return "Ilosc potrzebnych do podzespolu: " + carQuantity.ToString(); }
            set
            {
                try
                {
                    carQuantity = Int32.Parse(value);
                    OnPropertyChanged();
                }
                catch
                {
                    MessageBox.Show("Podano zły format");
                }


            }
        }
        public string ComponentQuantity
        {
            get { return "Ilosc potrzebnych do podzespolu: " + componentQuantity.ToString(); }
            set
            {
                try
                {
                    componentQuantity = Int32.Parse(value);
                    OnPropertyChanged();
                }
                catch
                {
                    MessageBox.Show("Podano zły format");
                }


            }
        }

        public string Login { get { return login; } set { login = value; OnPropertyChanged(); } }




        ObservableCollection<Module> components;
        ObservableCollection<Part> parts;
        ObservableCollection<Car> cars;
        public ObservableCollection<Module> Components { get { return components; } set { components = value; OnPropertyChanged(); } }
        public ObservableCollection<Part> Parts { get { return parts; } set { parts = value; OnPropertyChanged(); } }
        public ObservableCollection<Car> Cars { get { return cars; } set { cars = value; OnPropertyChanged(); } }


        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public Zarzadca(string _login)
        {
            var context = new Logger_CB().ContextMake();
            Login = _login;
            InitializeComponent();
            Parts= Part.Get_Collection(context);
            Components = Module.Get_Collection(context);
            Cars = Car.Get_Collection(context);
            this.DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {// ilość czesci
            if (PartsDataGrid.SelectedItem != null)
            {
                var tmpPart = PartsDataGrid.SelectedItem as Part;
                var context = new Logger_CB().ContextMake();
                Part.UpdateQuantity(tmpPart.ID, partQuantity,context );
                Parts = Part.Get_Collection(context); 
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (ComponentsDataGrid.SelectedItem != null)
            {
                var module = ComponentsDataGrid.SelectedItem as Module;
                var context = new Logger_CB().ContextMake();
                Module.UpdateQuantity(module.ID, componentQuantity, context);
                Components = Module.Get_Collection(context); 
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (CarsDataGrid.SelectedItem != null)
            {
                var car = CarsDataGrid.SelectedItem as Car;
                var context = new Logger_CB().ContextMake();
                Car.UpdateQuantity(car.ID, carQuantity, context);
                Cars = Car.Get_Collection(context);
            }

        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            (sender as TextBox).Text = String.Empty;

        }
    }
}
