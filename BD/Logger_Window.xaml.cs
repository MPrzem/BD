using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace BD
{
    /// <summary>
    /// Logika interakcji dla klasy Logger_Window.xaml
    /// </summary>
    public partial class Logger_Window : Window, INotifyPropertyChanged
    {
        Logger_CB logger;
        private string _login;
        private string _passwd;
        private string _table;
        public event PropertyChangedEventHandler PropertyChanged;
        Action<string> show;

        public string Login { get { return _login; } set { _login = value; OnPropertyChanged(); } }
        public string Passwd { get { return _passwd; } set { _passwd = value; OnPropertyChanged(); } }
        public Logger_Window(string table, Action<string> show)
        {
            this.show = show;
            _table = table;
            Login = "Login";
            Passwd = "Haslo";
            InitializeComponent();
            logger = new Logger_CB();
            this.DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            logger.ContextMake();
            if (logger.LogintoApp(_table, Login, Passwd))
            {
                MessageBox.Show("Logowanie udane!");
                show(Login);
                this.Close();
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
