using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace ProjectShop
{
    
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
            this.ChooseCategoryComboBox.SelectedIndex = 0;
            this.ChooseItemComboBox.SelectedIndex = 0;
        }
 
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
           ExitWindow.Exit(1);
        }

        private void ChooseCategoryComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.ChooseItemComboBox.ItemsSource = Enum.GetValues(Type.GetType("ProjectShop." + this.ChooseCategoryComboBox.SelectedValue.ToString()));
        }

        private void ChooseItemComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                string valueFromChooseItemComboBox = this.ChooseItemComboBox.SelectedValue.ToString();
                if (Control.check(Pro, valueFromChooseItemComboBox) == 0)
                    Pro.Add((Product)Activator.CreateInstance(Type.GetType("ProjectShop." + valueFromChooseItemComboBox)));

                foreach (var Item in Pro)
                {
                    if (0 == (String.Compare(valueFromChooseItemComboBox, Item.Name)))
                    {
                        this.TextBlockMark.Text = Item.Name;
                        this.TextBlockPrice.Text = Item.Price.ToString();
                        this.TextBoxQuantity.Text = Item.Quantity.ToString();
                        this.TextBlockProducent.Text = Item.Producent;
                        this.SizeComboBox.ItemsSource = Item.Size;
                        this.SizeComboBox.SelectedIndex = 0;
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
                const int noExist = -1;
                string valueFromChooseItemComboBox = this.ChooseItemComboBox.SelectedValue.ToString();
                string valueFromColorComboBox = this.ColorComboBox.SelectedValue.ToString();
                bool? check = this.CheckBoxButton.IsChecked;
                Product item = (Product)Activator.CreateInstance(Type.GetType("ProjectShop." + valueFromChooseItemComboBox));
                item.SizeItem = this.SizeComboBox.SelectedValue.ToString();
                int existingOfElement = Control.check(ProductChosenList, valueFromChooseItemComboBox,valueFromColorComboBox, item.SizeItem);
            

                if (noExist == existingOfElement )
                {    //// if added element doesn't excist 
                    if (check==true)
                        item.WithWarrentyElementsCounter= int.Parse(this.TextBoxQuantity.Text);
                    item.Quantity = int.Parse(this.TextBoxQuantity.Text);
                    item.Color = valueFromColorComboBox;
                    item.Price = item.Count(item.Quantity, item.Price,check);
                    ProductChosenList.Add(item);
                }
                else
                
                {   // if excists
                    if (check == true)
                        item.WithWarrentyElementsCounter = int.Parse(this.TextBoxQuantity.Text) + ProductChosenList[existingOfElement].WithWarrentyElementsCounter;
                    else
                        item.WithWarrentyElementsCounter =  ProductChosenList[existingOfElement].WithWarrentyElementsCounter;

                    item.Price = item.Count(int.Parse(this.TextBoxQuantity.Text), item.Price, check )+ ProductChosenList[existingOfElement].Price;
                    item.Quantity = int.Parse(this.TextBoxQuantity.Text) + ProductChosenList[existingOfElement].Quantity;
                    item.Color = ProductChosenList[existingOfElement].Color;
                    ProductChosenList.RemoveAt(existingOfElement);
                    ProductChosenList.Insert(existingOfElement, item);
                }
            }
            catch (FormatException)
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
            catch (ArgumentOutOfRangeException )
            {
                MessageBox.Show("Select item that you want to delete", "Delete item ");
            }
        }

    
        private void NextPageButton_Click(object sender, RoutedEventArgs e)
        {  
            try
            {
                if (0==ProductChosenList.Count)
                    throw new InvalidOperationException();
                else
                    this.NavigationService.Navigate(new Page2(ProductChosenList, new Person ()));
                      
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("You haven't chose anything.", "Empty basket. ");
            }   
        }
 
    }
}
