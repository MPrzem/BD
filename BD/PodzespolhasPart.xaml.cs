﻿using System;
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
    /// Logika interakcji dla klasy PodzespolhasPart.xaml
    /// </summary>
    public partial class PodzespolhasPart : Window, INotifyPropertyChanged
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
            ObservableCollection<Part> components;
        ObservableCollection<Part> avalibleParts;
        public ObservableCollection<Part> Components { get { return components; } set { components = value; OnPropertyChanged(); } }
        public ObservableCollection<Part> AvalibleParts { get { return avalibleParts; } set { avalibleParts = value; OnPropertyChanged(); } }
        Module module;

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public PodzespolhasPart(Module module)
        {
            this.module = module;

            var context = new Logger_CB().ContextMake();
            avalibleParts = module.GiveAvalibleParts(context);
            components = module.GiveParts(context);
            InitializeComponent();
            DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (partsDataGrid.SelectedItem != null)
            {
                var context = new Logger_CB().ContextMake();
                (partsDataGrid.SelectedItem as Part).DeleteFromModule(module.ID, context);  //Raczej powinno byc Module.DeletePart
                    AvalibleParts = module.GiveAvalibleParts(context);
                Components = module.GiveParts(context);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            if (AvalibleDataGrid.SelectedItem != null)
            {
                var context = new Logger_CB().ContextMake();
                module.AddPart((AvalibleDataGrid.SelectedItem as Part).ID, quantity, context);
                AvalibleParts = module.GiveAvalibleParts(context);
                Components = module.GiveParts(context);
            }


        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            (sender as TextBox).Text = String.Empty;

        }


    }
}
