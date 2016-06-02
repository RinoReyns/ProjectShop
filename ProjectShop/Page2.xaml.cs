using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ProjectShop
{
    /// <summary>
    /// Interaction logic for Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {
        public ObservableCollection<Product> ProductChosenList { get; set; }
        public Person Person ;

        public Page2(ObservableCollection<Product> T, Person P)
        {
            InitializeComponent();
            ProductChosenList = new ObservableCollection<Product>(T);
            Person = new Person(P);
            this.NameTextBox.Text = Person.Name;
            this.SurenameTextBox.Text = Person.Surename;
            this.AddressTextBox.Text = Person.Address;
            this.TelephoneTextBox.Text = Person.Telephone;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Page1(ProductChosenList));
        }

        private void OrderButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(NameTextBox.Text) | String.IsNullOrEmpty(SurenameTextBox.Text) | String.IsNullOrEmpty(AddressTextBox.Text) 
                    | String.IsNullOrEmpty(TelephoneTextBox.Text))
                {
                    throw new InvalidOperationException();
                }
                else
                {                   
                    Person.Name = NameTextBox.Text;
                    Person.Surename = SurenameTextBox.Text;
                    Person.Address = AddressTextBox.Text;
                    Person.Telephone = TelephoneTextBox.Text;
                    this.NavigationService.Navigate(new Page3(ProductChosenList, Person));
                }
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("One or more of fields is empty", "Empty field ");
            }   
        }
    }
}
