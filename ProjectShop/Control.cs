using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ProjectShop
{
    public class Control
    {
        public int check(List<Product> T, string a)
        {
            foreach (var Products in T)
            {
                if ((0 == (String.Compare(a, Products.Name))))
                    return 1;
            }
            return 0;
        }

        public int check(ObservableCollection<Product> T, string a, string b, string c)
        {
            foreach (var Products in T)
            {
                if ((0 == (String.Compare(a, Products.Name))) & (0 == (String.Compare(b, Products.Color))) & 0 == (String.Compare(c, Products.SizeItem)))
                    return (T.IndexOf(Products));
            }
            return -1;
        }
        public string FinalPrice(ObservableCollection<Product> T)
        {
            double Price = 0;
            foreach (var item in T)
            {
                Price += item.Price;
            }
            return Price.ToString();
        }
    }
        
    
}    



