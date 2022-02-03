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
                    "1.Hämta ut personal (SQL)\n" +
                    "2.Hämta ut alla elever (Entity)\n" +
                    "3.Hämta ut alla elever i en viss klass (Entity)\n" +
                    "4.Hämta ut alla betyg som sats senaste månaden (SQL)\n" +
                    "5.Hämta ut en lista med alla kurser och det snittbetyg som eleverna fått på den kursen samt det högsta och lägsta betyget som någon fått i kursen (SQL)\n" +
                    "6.Lägga till nya elever (SQL)\n" +
                    "7.Lägga till ny personal (Entity)\n");
                string menuOption = Console.ReadLine();
                switch (menuOption)
                {
                    case "1": //"1.Hämta ut personal (SQL)
                        {
                            Console.Clear();
                            SqlDataAdapter sqlPersonal = new SqlDataAdapter("Select PFNamn, PENamn, BefattningTyp from Personal join Befattning on Personal.fBefattningID = Befattning.BefattningID", sqlCon);
                            DataTable Personaltbl = new DataTable();
                            sqlPersonal.Fill(Personaltbl);
                            foreach (DataRow r in Personaltbl.Rows)
                            {
                                Console.Write(r["PFNamn"] + " ");
                                Console.Write(r["PENamn"]);
                                Console.Write(" - " + r["BefattningTyp"]);
                                Console.WriteLine();
                            }
                            Console.ReadKey();
                            break;
                        }
                    case "2": //2.Hämta ut alla elever (Entity)
                        {
                            var AllStudents = from FNamn in Context.Elev select FNamn;
                            foreach (var item in AllStudents)
                            {
                                Console.Write(item.Fnamn);
                                Console.Write(" {0}",item.Enamn);
                                Console.WriteLine();
                            }
                            Console.ReadKey();
                            break;
                        }
                    case "3": //3.Hämta ut alla elever i en viss klass (Entity)
                        {
                            var KlassList = from Klasskod in Context.Klass select Klasskod;
                            foreach (var item in KlassList)
                            {
                                Console.Write(item.KlassId);
                                Console.Write(" {0}", item.KlassKod);
                                Console.WriteLine();
                            }
                            Console.WriteLine("Vilken klass? Skriv ID");
                            int klasskodid = Convert.ToInt32(Console.ReadLine());
                            var elevKlass = from Fnamn in Context.Elev select Fnamn;
                            foreach (var item in elevKlass)
                            {
                                if(item.FKlassId == klasskodid)
                                {
                                    Console.Write(item.Fnamn);
                                    Console.Write(" {0}", item.Enamn);
                                    Console.WriteLine();
                                }
                            }


                            Console.ReadKey();
                            break;
                        }
                    case "4": //4.Hämta ut alla betyg som sats senaste månaden (SQL)
                        {
                            Console.Clear();
                            SqlDataAdapter sqlBetygSenasteMånad = new SqlDataAdapter("Select FNamn, ENamn, KursNamn, BetygTyp, PFNamn, PENamn, Datum from Betyg join Elev on Betyg.fElevID = Elev.ElevID join Kurs on Betyg.fKursID = Kurs.KursID join Personal on Betyg.fPersonalID = Personal.PersonalID join BetygKod on Betyg.fBetygKodID = BetygKod.BetygKodID where Datum between(select dateadd(month, -1, getdate())) and getdate()", sqlCon);
                            DataTable Betygtbl = new DataTable();
                            sqlBetygSenasteMånad.Fill(Betygtbl);
                            foreach (DataRow r in Betygtbl.Rows)
                            {
                                Console.Write(r["FNamn"] + "\t");
                                Console.Write(r["ENamn"] + "\t");
                                Console.Write(r["KursNamn"] + "\t");
                                Console.Write(r["BetygTyp"] + "\t");
                                Console.Write(r["Datum"] + "\t");
                                Console.WriteLine();
                            }

                            Console.ReadKey();
                            break;
                        }
                    case "5": //Hämta ut en lista med alla kurser och det snittbetyg som eleverna fått på den kursen samt det högsta och lägsta betyget som någon fått i kursen (SQL)
                        {
                            Console.Clear();
                            SqlDataAdapter sqlKurser = new SqlDataAdapter("Select KursNamn, AVG(DISTINCT fBetygKodID) as Average, MAX(DISTINCT fBetygKodID) as Max, MIN(DISTINCT fBetygKodID) as Min from Betyg join Kurs on Betyg.fKursID = Kurs.KursID Group By KursNamn", sqlCon);
                            DataTable SnittBetyg = new DataTable();
                            sqlKurser.Fill(SnittBetyg);
                            Console.Write("KursNamn" + "\t");
                            Console.Write("AVR" + "\t");
                            Console.Write("Max" + "\t");
                            Console.Write("Min");
                            Console.WriteLine();
                            foreach (DataRow r in SnittBetyg.Rows)
                            {
                                Console.Write(r["KursNamn"] + "\t");
                                Console.Write(r["Average"] + "\t");
                                Console.Write(r["Max"] + "\t");
                                Console.Write(r["Min"]);

                                Console.WriteLine();
                            }
                            Console.ReadKey();
                            break;
                        }
                    case "6": //"6.Lägga till nya elever (SQL)
                        {
                            string insertfPronomenID = "PH";
                            string insertfKlassID;
                            Console.WriteLine("Förnamn: ");
                            string insertFNamn = Console.ReadLine();
                            Console.WriteLine("Efternamn: ");
                            string insertENamn = Console.ReadLine();
                            Console.WriteLine("Personnummer: ");
                            string insertPNummer = Console.ReadLine();
                            bool pronomenBool = false;
                            while (pronomenBool == false)
                            {
                                Console.WriteLine("Pronomen: (Hon, Han, Hen, Övrigt");
                                string approve = Console.ReadLine().ToUpper();
                                if (approve == "HON")
                                {
                                    pronomenBool = true;
                                    insertfPronomenID = "1";
                                }
                                if (approve == "HAN")
                                {
                                    pronomenBool = true;
                                    insertfPronomenID = "2";
                                }
                                if (approve == "HEN")
                                {
                                    pronomenBool = true;
                                    insertfPronomenID = "3";
                                }
                                if (approve == "ÖVRIGT")
                                {
                                    pronomenBool = true;
                                    insertfPronomenID = "4";
                                }
                            }

                            SqlDataAdapter sqlKlasser = new SqlDataAdapter("Select KlassID, KlassKod from Klass", sqlCon);
                            DataTable Klassertbl = new DataTable();
                            sqlKlasser.Fill(Klassertbl);
                            foreach (DataRow r in Klassertbl.Rows)
                            {
                                Console.Write(r["KlassID"] + " ");
                                Console.Write(r["Klasskod"]);
                                Console.WriteLine();
                            }
                            Console.WriteLine("KlassID: ");
                            insertfKlassID = Console.ReadLine();
                            string nyElev = "INSERT INTO Elev(FNamn, ENamn, PNummer, fPronomenID, fKlassID) VALUES('" + insertFNamn + "', '" + insertENamn + "','" + insertPNummer + "','" + insertfPronomenID + "','" + insertfKlassID + "')";

                            SqlCommand addnyElev = sqlCon.CreateCommand();
                            addnyElev.CommandText = nyElev;
                            sqlCon.Open();
                            addnyElev.ExecuteNonQuery();
                            sqlCon.Close();


                            Console.ReadKey();
                            break;
                        }
                    case "7": //"7.Lägga till ny personal (Entity)"
                        {
                            int insertfPPronomenID = 1; //PH VALUE

                            Console.WriteLine("Förnamn: ");
                            string insertFNamn = Console.ReadLine();
                            Console.WriteLine("Efternamn: ");
                            string insertENamn = Console.ReadLine();
                            var BefattningList = from BefattningTyp in Context.Befattning select BefattningTyp;
                            foreach (var item in BefattningList)
                            {
                                Console.Write(item.BefattningId);
                                Console.Write(" {0}", item.BefattningTyp);
                                Console.WriteLine();
                            }
                            Console.WriteLine("BefattningsID: ");
                            int insertfBefattningsID = Convert.ToInt32(Console.ReadLine());
                            bool pronomenBool = false;
                            while (pronomenBool == false)
                            {
                                Console.WriteLine("Pronomen: (Hon, Han, Hen, Övrigt");
                                string approve = Console.ReadLine().ToUpper();
                                if (approve == "HON")
                                {
                                    pronomenBool = true;
                                    insertfPPronomenID = 1;
                                }
                                if (approve == "HAN")
                                {
                                    pronomenBool = true;
                                    insertfPPronomenID = 2;
                                }
                                if (approve == "HEN")
                                {
                                    pronomenBool = true;
                                    insertfPPronomenID = 3;
                                }
                                if (approve == "ÖVRIGT")
                                {
                                    pronomenBool = true;
                                    insertfPPronomenID = 4;
                                }
                            }
                            Personal AddPersonal = new Personal()
                            {
                                Pfnamn = insertFNamn,
                                Penamn = insertENamn,
                                FBefattningId = insertfBefattningsID,
                                FPpronomenId = insertfPPronomenID,
                            };
                            Context.Personal.Add(AddPersonal);
                            Context.SaveChanges();
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

