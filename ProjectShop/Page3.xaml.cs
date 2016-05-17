using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace ProjectShop
{
    /// <summary>
    /// Interaction logic for Page3.xaml
    /// </summary>
    public partial class Page3 : Page
    {
        public ObservableCollection<Product> ProductChosenList { get; set; }
        private Control Control;
        public Person Person;

        public Page3(ObservableCollection<Product> T, Person P)
        {
            InitializeComponent();
            ProductChosenList = new ObservableCollection<Product>(T);
            Control = new Control();
            Person = new Person(P);
            this.DataContext = this;
            this.NameLabel.Content = Person.Name;
            this.SurenameLabel.Content = Person.Surename;
            this.AddressLabel.Content = Person.Address;
            this.TelephoneLabel.Content = Person.Telephone;
            this.FinalPriceLabel.Content = Control.FinalPrice(ProductChosenList);
        }

        private void FinishShopping_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Control.PDF_Creator(ProductChosenList, Person);
            }
            catch (Exception)
            {
                MessageBox.Show("There is a problem with finishing order. Check if program is installed corectlly, then try to make order again.", "Order problem. ");
            }
            finally
            {
                Environment.Exit(0);
            }
        }

        private void BackButton1_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Page2(ProductChosenList, Person));
        }
    }
}
