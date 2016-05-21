using System;
using System.Collections.ObjectModel;
using System.Windows;


namespace ProjectShop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
    
        public MainWindow() 
        {
            InitializeComponent();
            Frame1.NavigationService.Navigate(new Page1(new ObservableCollection<Product>()));
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = Exit_Window.Exit();
        }
    }
}

