using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace ProjectShop
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {

        public ObservableCollection<Product> ProductChosenList { get; set; }
        private Control Control = new Control();
        private List<Product> Pro = new List<Product>();

        public Page1(ObservableCollection<Product> T)
        {
            InitializeComponent();
            this.DataContext = this;
            ProductChosenList = new ObservableCollection<Product>(T);
            this.ChooseCategoryComboBox.ItemsSource = Enum.GetValues(typeof(Category));
            this.ChooseCategoryComboBox.SelectedIndex = 2;
            this.ChooseItemComboBox.SelectedIndex = 0;
        }
 
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Exit_Window.Exit(1);
        }

        private void ChooseCategoryComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.ChooseItemComboBox.ItemsSource = Enum.GetValues(Type.GetType("ProjectShop." + this.ChooseCategoryComboBox.SelectedValue.ToString()));
        }

        private void ChooseItemComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                string a = this.ChooseItemComboBox.SelectedValue.ToString();
                if (Control.check(Pro, a) == 0)
                    Pro.Add((Product)Activator.CreateInstance(Type.GetType("ProjectShop." + a)));

                foreach (var Item in Pro)
                {
                    if (0 == (String.Compare(a, Item.Name)))
                    {
                        this.TextBlockMark.Text = Item.Name;
                        this.TextBlockPrice.Text = Item.Price.ToString();
                        this.TextBoxQuantity.Text = Item.Quantity.ToString();
                        this.TextBlockProducent.Text = Item.Producent;
                        if (0 ==(String.Compare("0",Item.Color)))
                        {
                            this.ColorComboBox.ItemsSource = Enum.GetValues(typeof(ColorBlack));
                            this.ColorComboBox.SelectedIndex = 0;
                        }
                        else
                        {
                            this.ColorComboBox.ItemsSource= Enum.GetValues(typeof(Color));
                            this.ColorComboBox.SelectedIndex = 1;
                        }
                    }
                }
            }
            catch (NullReferenceException)
            {
                this.ChooseItemComboBox.SelectedIndex = 0;
            }
        }

        private void AddItemButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string a = this.ChooseItemComboBox.SelectedValue.ToString();
                string c = this.ColorComboBox.SelectedValue.ToString();
                Product item = (Product)Activator.CreateInstance(Type.GetType("ProjectShop." + a));
                int b = Control.check(ProductChosenList, a,c);
                if (-1 == b )
                {
                    item.Quantity = int.Parse(this.TextBoxQuantity.Text);
                    item.Color = c;
                    ProductChosenList.Add(item);
                }
                else
                
                {
                    item.Quantity = int.Parse(this.TextBoxQuantity.Text) + ProductChosenList[b].Quantity;
                    item.Price = item.Count(item.Quantity,item.Price);
                    item.Color = ProductChosenList[b].Color;
                    ProductChosenList.RemoveAt(b);
                    ProductChosenList.Insert(b, item);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Select qauantity be can't ordered. Change the quantity", "Add item ");
            }
        }

        private void DeleteItemButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.ProductChosenList.RemoveAt(this.ListView1.SelectedIndex);
            }
            catch (Exception)
            {
                MessageBox.Show("Select item that you want to delete", "Delete item ");
            }
        }

        private void NextPageButton_Click(object sender, RoutedEventArgs e)
        {  
            try
            {
                if (0==ProductChosenList.Count)
                {
                    throw new Exception();
                }
                else
                {
                    this.NavigationService.Navigate(new Page2(ProductChosenList, new Person ()));
                }        
            }
            catch (Exception)
            {

                MessageBox.Show("You haven't chose anything.", "Empty basket. ");
            }   
        }
    }
}
