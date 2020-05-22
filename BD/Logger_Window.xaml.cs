using System;
using System.Collections.Generic;
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
    /// Logika interakcji dla klasy Logger_Window.xaml
    /// </summary>
    public partial class Logger_Window : Window,INotifyPropertyChanged 
    {
        Logger_CB logger;
        private string _login;
        private string _passwd;
        
        public event PropertyChangedEventHandler PropertyChanged;

        public string Login { get { return _login; } set { _login = value; OnPropertyChanged(); }}
        public string Passwd { get { return _passwd; } set{ _passwd = value; OnPropertyChanged(); } }
        public Logger_Window()
        {
            Login = "Login";
            Passwd = "Haslo";
            InitializeComponent();
            logger = new Logger_CB();
            this.DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            logger.ContextMake();
            if (logger.LogintoApp("kierownik_produkcji", Login, Passwd))
            {
                MessageBox.Show("Logowanie udane!");
                new Kierownik_Window(Login).Show();
            }
            else MessageBox.Show("Logowanie nie udane");

        }
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            (sender as TextBox).Text = String.Empty;

        }
    }

}
