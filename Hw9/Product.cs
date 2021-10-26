using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hw9
{
    class Product
    {
        protected string name = null;
        protected double price = 0;
        public double Price => price;
        public string Name => name;
        public Product(string name, double price)
        {
            this.name = name;
            this.price = price;
        }
        public Product()
        {
            this.name = "Nothing";
            this.price = 0.0;
        }

        public virtual string Expi()
        {
            return "beb";
        }

        public override string ToString()
        {
            return "Name " + name + " Price " + price + "\n";
        }

        public string SetterName
        {
            set
            { 
                name = value; 
            }
        }
        public double SetterPrice
        {
            set
            {
                price = value;
            }
        }


       

    }
}
