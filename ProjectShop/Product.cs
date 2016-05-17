using System;

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

    /// <summary>
    /// też do policzenia ogolnej liości i ceny
    /// </summary>
   
    public abstract class Product : ICount
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }

        public Product()
        {
            this.Quantity = 1;
        }
        public double Count(int quantity, double price)
        {

            return (quantity * price);
        }
    }
    public class Boot : Product
    {
        public Boot()
        {
            this.Name = "Boot";
            this.Price = 100;
        }
    }

    public class Shoes : Product
    {
        public Shoes()
        {
            this.Name = "Shoes";
            this.Price = 30;
           
        }


    }
    public class Dress: Product
    {
        public Dress()
        {
            this.Name = "Dress";
            this.Price = 1000;
        }
    }

    public class Micro : Product
    {
        public Micro()
        {
            this.Name = "Micro";
            this.Price = 20;
        }


       /* override public double Count(int quantity, double price)
        {
            return price;
        }*/
    }



}
