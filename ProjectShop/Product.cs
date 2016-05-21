using System;
using System.Collections.Generic;

namespace ProjectShop
{

    public enum Category { Culture, Electronics, Fasion , Home, Motorization, Music, Sport }
    public enum Culture { Theater, Cat, Something }
    public enum Electronics { Micro, Nano, Piko }
    public enum Fasion { Boot, Shoes, Dress }
    public enum Home { Table, Cap, Door }
    public enum Music { CD, AMP, Guitar }
    public enum Sport { Ball,Tenis_Rocket , Net }
    public enum Motorization { Car, Bus, Bike }
    public enum Color { Black, Pink, Yellow, Blue, White }
    public enum ColorBlack {Black}



    /// <summary>
    /// też do policzenia ogolnej liości i ceny
    /// </summary>

    public abstract class Product : ICount
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string Color { get; set; }
        public string Producent { get; set; }
        public List<int> Size;
        //każdy produk ma liste swoich rozmairów podpinaną do boxa
        public Product()
        {
            this.Quantity = 1;
            this.Color = "1";
        }
        public double Count(int quantity, double price, bool? checkbox)
        {
            if (checkbox == true)            
                return ((quantity * price) + quantity*10);   
            else 
            return (quantity * price);
        }
    }
    public class Boot : Product
    {
        public Boot()
        {
            this.Name = "Boot";
            this.Price = 100;
            this.Producent = "Hugo Boss";
        }
    }

    public class Shoes : Product
    {
        public Shoes()
        {
            this.Name = "Shoes";
            this.Price = 30;
            this.Producent = "Hugo Boss";
        }

    }
    public class Dress: Product
    {
        public Dress()
        {
            this.Name = "Dress";
            this.Price = 1000;
            this.Producent = "Olivia";
        }
    }

    public class Micro : Product
    {
        public Micro()
        {
            this.Name = "Micro";
            this.Price = 20;
            this.Color = "0";
            this.Producent = "Flexic";
        }

    }



}
