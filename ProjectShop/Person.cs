namespace ProjectShop
{
    public class Person
    {
        public string Name { get; set; }
        public string Surename{ get; set; }   
        public string Address { get; set; }
        public string Telephone { get; set; }

        public Person()
        {}
        public Person(Person P)
        {
            
            this.Name = P.Name;
            this.Surename = P.Surename;
            this.Address = P.Address;
            this.Telephone = P.Telephone;
        }

    }
}
