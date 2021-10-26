using System;

namespace Hw9
{
    class Program
    {

        static void Main(string[] args)
        {
            Utilita utilita = new Utilita();
            string comand = "ok";
            comand = (Console.ReadLine()).ToUpper();
            while(comand!="END")
            {
                switch (comand)
                    {
                        case "S":
                        {
                            utilita.SearchP();
                            break;
                        }
                        case "DI":
                        {
                            utilita.DeleteI();
                            break;
                        }
                        case "DN":
                        {
                            utilita.DeleteN();
                            break;
                        }
                        case "A":
                        {
                            utilita.AddElem();
                            break;
                        }
                        case "W":
                        {
                            Console.WriteLine(utilita.W());
                            break;
                        }
                    case "T":
                        {
                            utilita.Termi();
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("There is no such comand");
                            break;
                        }


                }
                comand = (Console.ReadLine()).ToUpper();
            }
        }
    }
}
