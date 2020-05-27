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
    /// Logika interakcji dla klasy CarhasComponent.xaml
    /// </summary>
    public partial class CarhasComponent : Window, INotifyPropertyChanged
    {
        int quantity;
        public string Quantity
        {
            get { return "Ilosc potrzebnych do podzespolu: " + quantity.ToString(); }
            set
            {
                try
                {
                    quantity = Int32.Parse(value);
                    OnPropertyChanged();
                }
                catch
                {
                    MessageBox.Show("Podano zły format");
                }


            }
        }
        ObservableCollection<Module> components;
        ObservableCollection<Module> avalibleComponents;
        public ObservableCollection<Module> Components { get { return components; } set { components = value; OnPropertyChanged(); } }
        public ObservableCollection<Module> AvalibleComponents { get { return avalibleComponents; } set { avalibleComponents = value; OnPropertyChanged(); } }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        Car car;
        public CarhasComponent(Car car)
        {
            var context = new Logger_CB().ContextMake();

            this.car = car;
            Components = car.GetModules(context);
            AvalibleComponents = car.GetAvalibleModules(context);
            InitializeComponent();
            DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ///Usuwanie
            if (modulesDataGrid.SelectedItem != null)
            {
                var context = new Logger_CB().ContextMake();
                car.DeleteModule((modulesDataGrid.SelectedItem as Module).ID, context);
                Components = car.GetModules(context);
                AvalibleComponents = car.GetAvalibleModules(context);
            }


        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (modulesAvalibleDataGrid.SelectedItem != null)
            {
                var context = new Logger_CB().ContextMake();
                car.AddPart((modulesAvalibleDataGrid.SelectedItem as Module).ID, quantity, context);
                Components = car.GetModules(context);
                AvalibleComponents = car.GetAvalibleModules(context);
            }

        }
        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            (sender as TextBox).Text = String.Empty;

        }
    }
}
