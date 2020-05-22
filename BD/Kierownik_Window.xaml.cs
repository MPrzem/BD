using MySql.Data.MySqlClient;
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
    /// Logika interakcji dla klasy Kierownik_Window.xaml
    /// </summary>
    public partial class Kierownik_Window : Window, INotifyPropertyChanged
    {
        string _user;
        int _quantity;
        string _comment;
        private ObservableCollection<Part> partList;
        public ObservableCollection<Part> Parts { get { return partList; } set { partList = value; OnPropertyChanged(); } }
        MySqlConnection context;
        public string User { get { return "Zalogowany jako: " +_user; } set { _user = value; OnPropertyChanged(); } }
        public string Quantity { get { return "Wpisz ilość: " +_quantity.ToString(); } set {
                try { _quantity = Int32.Parse(value); }
                catch { MessageBox.Show("Podano zły format"); }
                OnPropertyChanged(); }
        }
        public string Comment { get { return "Wprowadz komentarz: " + _comment; } set { _comment = value; OnPropertyChanged(); } }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        

        public Kierownik_Window(string Login)
        {
            this.DataContext = this;
            User = Login;
            InitializeComponent();

            context = (new Logger_CB()).ContextMake();
            Parts = Part.Get_Collection(context) ;

        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (DataGrid.SelectedItem != null)
            {
                context = (new Logger_CB()).ContextMake();
                Part.UpdateQuantity(((Part)DataGrid.SelectedItem).ID, _quantity, context);
                Parts = Part.Get_Collection(context);

            }
        }

        private void TextBlock_GotFocus(object sender, RoutedEventArgs e)
        {
            (sender as TextBox).Text = String.Empty;

        }
    }
}
