using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hw9
{
   
    class Utilita
    {//Делегат може описуватись зовні
        public delegate void Handler(string message);
       //Чому тільки одна подія і з такою сигнатурою делегату. Це не відповідає умові. 
        public event Handler Notify;
        string Mes;
       // Чому в Storage немає подій.
        static Storage storage = new Storage();
        readonly string path = @"C:\\Users\\admin\\source\\repos\\Hw9\\Hw9\\Storage.txt";
        Product nProduct = null;
        public Utilita()
        {

        }


        public string W()
        {
            return storage.Write();
        }

        public void Termi ()
        {
            Console.WriteLine(storage.Write());
            Notify += Mess;
            Terminated();
            Console.WriteLine(storage.Write());

        }

        public void AddElem()
        {
            Console.WriteLine("Let`s add an element\nEnter Type (Product or Dairy)");
            string type = null;
            type = ValidateType(type);
            Mes = storage + Initialize(type);

            Notify?.Invoke(Mes);
            Console.WriteLine(storage.Write());

        }

        public void DeleteI()
        {
            Console.WriteLine(storage.Write());
            Console.WriteLine("Let`s delete element by index");
            int index = Convert.ToInt32(Console.ReadLine());
            Mes = storage - (index - 1);
            Notify?.Invoke(Mes);
            Console.WriteLine(storage.Write());
        }

        public void DeleteN ()
        {
            Console.WriteLine("Let`s delete element by name");
            string product = Console.ReadLine();
            Mes = storage - product;
            Notify?.Invoke(Mes);
            Console.WriteLine(storage.Write());
        }

        public void SearchP()
        {
            Console.WriteLine("Search by prcie");
            double price = 0;
            try
            {
                price = Convert.ToDouble(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Please Enter Double like this <1,2>");
                price = Convert.ToDouble(Console.ReadLine());
            }
            Mes = storage.Search(price);
            Console.WriteLine(Mes);
        }







        private void Terminated ()
        {
            Dairy dairy = new Dairy();
            for (int i=0; i< storage.Products.Count; i++)
            {
                storage.Terminated();
            }
            Notify?.Invoke("Dairy products, Terminated are in file ");
        }

        public Product Initialize(string type)
        {
            int itype = storage.TypeProduct(type);
            int day = 0;
            string name = null;
            double price = 0;
            Notify?.Invoke("Enter name then price(double)");
            name = Console.ReadLine();
            price = ValidatePrice(price);
            switch (itype)
            {
                case 1:
                    {
                        nProduct = new Product(name, price);
                        Write(type, name, price);
                        break;
                    }
                case 2:
                    {
                        day = ValidateDay(day);
                         nProduct = new Dairy(name, price, day);
                        Write(type, name, price, day);
                        break;
                    }
                default:
                    {
                        break;
                        //return nProduct;
                    }
           }
            return nProduct;

        }


        public void Write(string type, string name, double price)
        {
            string np ="\n"+ type + " " + name + " " + price;
            File.AppendAllText(path, np);
        }
        public void Write(string type, string name, double price, int day)
        {
            string np = "\n" + type + " " + name + " " + price + " " + day;
            File.AppendAllText(path, np);
        }

        public double ValidatePrice(double price)
        {
            try
            {
                price = Convert.ToDouble(Console.ReadLine());
            }
            catch (FormatException)
            {
                Notify?.Invoke("Please enter Double");
                ValidatePrice(price);
            }
            return price;
        }


        public int ValidateDay(int day)
        {
            try
            {
                day = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException)
            {
                Notify?.Invoke("Please enter Int");
                ValidatePrice(day);
                
            }
            if(day<0)
            {
                Notify?.Invoke("Days of Termination Cannot be -1");
                ValidatePrice(day);
            }
            return day;
        }

        public string ValidateType(string type)
        {
            type = Console.ReadLine();
            int i = storage.TypeProduct(type);
            if(i<=0)
            {
                Notify?.Invoke("There is no such type");
                ValidateType(type);
            }
            return type;
        }

        private static void Mess(string a)
        {
            Console.WriteLine(a);
        }
        
    }
}
