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
    /// Logika interakcji dla klasy Projektant.xaml
    /// </summary>
    public partial class Projektant : Window, INotifyPropertyChanged
    {
        string _user;
        string _moduleName;
        string _moduleComment;
        double _carPrice;
        string _carName;
        string _carComment;

        public string User { get { return _user; } set { _user = value; OnPropertyChanged(); } }
        public string ModuleName { get { return "Nazwa podzespołu: " +_moduleName; } set { _moduleName = value; OnPropertyChanged(); } }
        public string ModuleComment { get { return "Komentarz do podzespołu: " + _moduleComment; } set { _moduleComment = value; OnPropertyChanged(); } }
        public string CarName { get { return "Nazwa samochodu" + _carName; } set { _carName = value; OnPropertyChanged(); } }
        public string CarPrice { get { return "Cena :" + _carPrice.ToString(); } set {
                try
                {
                    _carPrice = Double.Parse( value);
                    OnPropertyChanged();
                }
                catch
                {
                    MessageBox.Show("Podano zły format");
                }
                
                
                }
        
        
        
        }
        public string CarComment { get { return "Komentarz do podzespołu: " + _carComment; } set { _carComment = value; OnPropertyChanged(); } }

        private ObservableCollection<Module> _modulelist;
        private ObservableCollection<Car> _cars;

        public ObservableCollection<Module> Modules { get { return _modulelist; } set { _modulelist = value; OnPropertyChanged(); } }
        public ObservableCollection<Car> Cars { get { return _cars; } set { _cars = value; OnPropertyChanged(); } }

        public Projektant(string Login)
        {
            var context = new Logger_CB().ContextMake();
            InitializeComponent();
            Modules = Module.Get_Collection(context);
            Cars = Car.Get_Collection(context);
            this.DataContext = this;
        }

        public event PropertyChangedEventHandler PropertyChanged;


        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            (sender as TextBox).Text = String.Empty;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Car tmp_car = new Car();
            var context = new Logger_CB().ContextMake();
            tmp_car.Comment = _carComment;
            tmp_car.Demand = 0;
            tmp_car.Name = _carName;

            tmp_car.Price = _carPrice;
            Car.sendNewCar(tmp_car, context);
            Cars = Car.Get_Collection(context);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        { Module tmp_module = new Module();
            var context = new Logger_CB().ContextMake();
            tmp_module.Comment = _moduleComment;
            tmp_module.Name = _moduleName;
            Module.sendNewModule(tmp_module,context);
            Modules=Module.Get_Collection(context);
        }

        private void ModelName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (CarDataGrid.SelectedItem != null)
            {
                var context = new Logger_CB().ContextMake();
                Car.DeleteCar((CarDataGrid.SelectedItem as Car).ID, context);
               Cars = Car.Get_Collection(context);
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if (ModuleDataGrid.SelectedItem != null)
            {
                var context = new Logger_CB().ContextMake();
                Module.DeleteModule((ModuleDataGrid.SelectedItem as Module).ID, context);
                Modules = Module.Get_Collection(context);
            }
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            if (CarDataGrid.SelectedItem != null)
                (new CarhasComponent(CarDataGrid.SelectedItem as Car)).Show();
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            if (ModuleDataGrid.SelectedItem != null)
            {

                (new PodzespolhasPart(ModuleDataGrid.SelectedItem as Module)).Show();

            }

        }
    }
}
