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
        private Part _forAdd = new Part();
        public Part Add { get { return _forAdd; } set { _forAdd = value; OnPropertyChanged(); } }
        private ObservableCollection<Part> partList;
        public ObservableCollection<Part> Parts { get { return partList; } set { partList = value; OnPropertyChanged(); } }
        MySqlConnection context;
        public string User { get { return "Zalogowany jako: " +_user; } set { _user = value; OnPropertyChanged(); } }
        public int Quantity { get { try { return Int32.Parse(DataMaintanceInstance.Text1.Text); }
                catch { MessageBox.Show("Podano zły format"); return 0; }
            } set {
                 DataMaintanceInstance.Text1.Text = value.ToString(); 
                OnPropertyChanged(); }
        }
        public string Comment
        {
            get { return DataMaintanceInstance.Text2.Text; }
            set
            {
                if (DataMaintanceInstance.Text2.Text.Length > 512)
                {
                    DataMaintanceInstance.Text2.Text = value;
                    OnPropertyChanged();
                }
                else
                    MessageBox.Show("Podano za długi komentarz, max 512 znakow");
            }
        } 
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
            Binding quantitybidnd = new Binding("Quantity");
            DataMaintanceInstance.Text1.SetBinding(TextBox.TextProperty, "Quantity");
            DataMaintanceInstance.Text1.Text = "Wprowadz ilosc";
            DataMaintanceInstance.Text2.Text = "Wprowadz komentarz";
            DataMaintanceInstance.Text3.Text = "Wproawdz nazwe";
            DataMaintanceInstance.Text4.Text = "Wprowadz cenę";
            DataMaintanceInstance.Text5.Text = "Wprowadz ilosc";


        }

        private void DataMaintance_Button1Clicked()
        {
            if (DataGrid.SelectedItem != null)
            {
                context = (new Logger_CB()).ContextMake();
                Part.UpdateQuantity(((Part)DataGrid.SelectedItem).ID, Quantity, context);
                Parts = Part.Get_Collection(context);///Moznaby edytowac lokalna kolekcje ale dla pewnosci tak, probnie

            }
        }

        private void DataMaintanceInstance_Button2Clicked()
        {
            if (DataGrid.SelectedItem != null)
            {
                context = (new Logger_CB()).ContextMake();
                Part.UpdateComment(((Part)DataGrid.SelectedItem).ID, Comment, context);
                Parts = Part.Get_Collection(context);///Moznaby edytowac lokalna kolekcje ale dla pewnosci tak, probnie

            }
           

        }

        private void DataMaintanceInstance_Button3Clicked()
        {

                Part part = new Part();
                part.Comment = "";
                part.Name = DataMaintanceInstance.Text3.Text;
                part.Price = Double.Parse(DataMaintanceInstance.Text4.Text);
                part.Quantity = Int32.Parse(DataMaintanceInstance.Text5.Text);
                context = (new Logger_CB()).ContextMake();
                Part.sendNewPart(part, context);
            Parts = Part.Get_Collection(context);///Moznaby edytowac lokalna kolekcje ale dla pewnosci tak, probnie




        }
    }
}
