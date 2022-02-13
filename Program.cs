using EFSQLLABB3.Models;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;


namespace EFSQLLABB3
{
    class Program
    {
        

        static void Main(string[] args)
        {
            using KungsbackaSkolanDbContext Context = new KungsbackaSkolanDbContext();
            SqlConnection sqlCon = new SqlConnection(@"Data Source = DESKTOP-HMA3C5T\TESTSERVER; Initial Catalog = KungsbackaSkolan;Integrated Security = True");
            while (true)
            {
                Console.Clear();
                Console.WriteLine("" +
                    "1.Hur många lärare jobbar på de olika avdelningarna?(EF VS)\n" +
                    "2.Visa information om alla elever (EF VS)\n" +
                    "3.Visa en lista på alla aktiva kurser (EF VS)\n");
                string menuOption = Console.ReadLine();
                switch (menuOption)
                {
                    case "1": //"1. Hur många lärare jobbar på de olika avdelningarna?(EF VS)
                        {
                            Console.Clear();
                            var AllPersonal = Context.Personal;
                            int RektorNumber = 0;
                            int LarareNumber = 0;
                            int VaktmastareNumber = 0;
                            int LokalvardareNumber= 0;
                            foreach (var item in AllPersonal)
                            {
                                if(item.FBefattningId == 1) { RektorNumber++; }
                                if (item.FBefattningId == 2) { LarareNumber++; }
                                if (item.FBefattningId == 3) { VaktmastareNumber++; }
                                if (item.FBefattningId == 4) { LokalvardareNumber++; }
                            }
                            Console.WriteLine("Antal Rektorer: {0}", RektorNumber);
                            Console.WriteLine("Antal Lärarer: {0}", LarareNumber);
                            Console.WriteLine("Antal Vaktmästare: {0}", VaktmastareNumber);
                            Console.WriteLine("Antal Lokalvårdare: {0}", LokalvardareNumber);
                            Console.ReadKey();
                            break;
                        }
                    case "2": //2.Visa information om alla elever (EF VS)
                        {               
                            var AllStudents = Context.Elev;
                            string PrintOutHeadline;
                            PrintOutHeadline = String.Format("{0,15}|{1,15}|{2,15}|{3,3}|{4,3}|", "FÖRNAMN", "EFTERNAMN", "PERSON-NUMMER", "PID", "KID");
                            Console.WriteLine(PrintOutHeadline);
                            foreach (var item in AllStudents)
                            {
                                string PrintOut;
                                PrintOut = String.Format("{0,15}|{1,15}|{2,15}|{3,3}|{4,3}|", item.Fnamn, item.Enamn, item.Pnummer, item.FPronomenId, item.FKlassId);
                                Console.WriteLine(PrintOut);                                                            
                            }
                            Console.ReadKey();
                            break;
                        }
                    case "3": //3.Visa en lista på alla aktiva kurser (EF VS)
                        {
                            var KursList = Context.Kurs;
                            foreach (var item in KursList)
                            {   
                                Console.Write("{0}", item.KursNamn);                                
                                Console.WriteLine();
                            }                           
                            Console.ReadKey();
                            break;
                        }

                    default:
                        {
                            Console.Clear();
                            Console.WriteLine("Ogiltigt val.\nSkriv en siffra i menyn.\n\n");
                            Console.ReadKey();
                            break;
                        }
                }
            }
        }
    }
    }

