using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hw9
{
    class Storage
    {
        readonly string path = @"C:\\Users\\admin\\source\\repos\\Hw9\\Hw9\\Storage.txt";
        readonly string deleted = @"C:\\Users\\admin\\source\\repos\\Hw9\\Hw9\\Deleted.txt";
        readonly string terminated = @"C:\Users\admin\source\repos\Hw9\Hw9\Terminated.txt";
        List<Product> products = new List<Product>();
        int index = 0;
        public List<Product> Products => products;
        DateTime today = DateTime.Today;
        public Storage()
        {
           string[] readallText=null;
            try
            {
                 readallText = File.ReadAllLines(path);
            }
            catch (IOException)
            {
                Console.WriteLine("There is a problem with a path");
                Console.ReadKey();
            }
            Initilization(readallText);
        }


        public void Initilization(string [] readAllText)
        {
            Product product;
            string[] sub;
            for(int i=0; i<readAllText.Length; i++)
            {
                sub = readAllText[i].Split(' ');
                if(TypeProduct(sub[0])==1)
                {
                    product = new Product(sub[1], Convert.ToDouble(sub[2]));
                    products.Add(product);
                }
                else if(TypeProduct(sub[0]) == 2)
                {
                    product = new Dairy(sub[1], Convert.ToDouble(sub[2]), Convert.ToInt32(sub[3]));
                    products.Add(product);
                }
            }
        }

        public int TypeProduct(string sub) // For initilization, to define the type
        {
            if (sub == "Product")
            {
                return 1;
            }
            else if (sub == "Dairy") return 2;
            else return 0;
        }


        public static string operator+(Storage storage, Product product)//Add products to storage
        {
           
            string Mes = "Added sucsefuly";
            storage.products.Add(product);
            return Mes;
        }



        public static string operator -(Storage storage, string product)//Remove
        {
            string Mes = "Removed sucsefuly";
            File.AppendAllText(storage.deleted, storage.products[WhatToRemov(storage, product)].ToString());
            storage.products.RemoveAt(WhatToRemov(storage, product));
            return Mes;
        }



        public static string operator -(Storage storage, int i)//Remove by index
        {
            string Mes = "Removed sucsefuly";
            File.AppendAllText(storage.deleted, storage.products[i].ToString());
            storage.DeleteFile(i);
            storage.products.RemoveAt(i);
            return Mes;
        }



        public string Search(double price)//Search by price
        {
            string Mes = null;
            for(int i=0; i<products.Count; i++)
            {
                if (products[i].Price == price) 
                {
                    Mes += products[i].ToString();
                }
            }
            return Mes;
        }




        public static int WhatToRemov(Storage storage, string product)//if i don`t` know the index of removing element
        {
            int index = 0;
            for (int i = 0; i < storage.products.Count; i++)
            {
                if (product == storage.products[i].Name)
                {
                    index = i;
                }
            }
            storage.DeleteFile(index);
            return index;
        }

        public string Write()
        {
            string list = null;
            for (int i=0; i<products.Count; i++)
            {
                list += products[i].ToString();
            }
            return list;
        }


        public  void Terminated()
        {
            Dairy dairy = new Dairy();
            for (int i = 0; i < products.Count; i++)
            {
                if (Object.ReferenceEquals(products[i].GetType(), dairy.GetType()))
                {
                    if (string.Equals(products[i].Expi(), today.ToString()))
                    {
                        File.AppendAllText(terminated, products[i].ToString());
                        DeleteFile(i);
                        products.RemoveAt(i);
                    }
                }
            }

        }

        public void DeleteFile(int index)
        {
            string[] readallText = null;
            try
            {
                readallText = File.ReadAllLines(path);
            }
            catch (IOException)
            {
                Console.WriteLine("There is a problem with a path");
                Console.ReadKey();
            }
            File.WriteAllText(path, String.Empty);
            for (int i =0 ; i < readallText.Length; i++)
            {
                if(i!=index)
                {
                    File.AppendAllText(path, readallText[i]+"\n");
                }
            }
        }
  


    }
}
