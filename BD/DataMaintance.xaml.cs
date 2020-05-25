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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BD
{
    /// <summary>
    /// Logika interakcji dla klasy DataMaintance.xaml
    /// </summary>
    public partial class DataMaintance : UserControl, INotifyPropertyChanged
    {
        string _button1;
        string _button2;
        string _button3;

        public string Button1 { get { return _button1; } set { _button1 = value; OnPropertyChanged(); } }
        public string Button2 { get { return _button2; } set { _button2 = value; OnPropertyChanged(); } }
        public string Button3 { get { return _button3; } set { _button3 = value; OnPropertyChanged(); } }

        public event Action Button1Clicked;
        public event Action Button2Clicked;
        public event Action Button3Clicked;

        public DataMaintance()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Button1Clicked?.Invoke();

        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Button2Clicked?.Invoke();

        }
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Button3Clicked?.Invoke();

        }
        private void TextBlock_GotFocus(object sender, RoutedEventArgs e)
        {
            (sender as TextBox).Text = String.Empty;

        }
    }
}
