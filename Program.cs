using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CsvHelper;

namespace Aplokacja1
{
    internal class Program
    {
        class Linia
        {
            public string DATA_ODCZYTU { get; set; }
            public float ZUZYCIE_BIEZACE { get; set; }
            public string JEDNOSTKA { get; set; }
            public string DATA_POPRZEDNIEGO_ODCZYTU { get; set; }
            public string ODCZYT_BIEZACY { get; set; }
            public string ODCZYT_POPRZEDNI { get; set; }
            public string STREFA_EC { get; set; }
            public string ADRES_PPE { get; set; }
            public string TYP_ODCZYTU { get; set; }
            public int NUMER_LICZNIKA { get; set; }
            public string PUNKT_POBORU { get; set; }
            public string SKLADNIK { get; set; }
        }


        static void Main(string[] args)
        {
            //Console.WriteLine("Podaj nazwę pliku:");
            //string nazwa = Console.ReadLine();

            string[] dirs = Directory.GetFiles(@".", @"*.csv");//przeszukiwanie bieżącego katalogu dla plików *.csv


            int dirslp = 0;

            int liczbaplikow = 0;

            foreach (string fil in dirs)
            {
                string zmiana = "";
                Regex rgx = new Regex(@"\.\\");
                string wynik = rgx.Replace(fil, zmiana);
                //Console.WriteLine(wynik);
                dirs[dirslp] = wynik;
                dirslp++;
            }  //normalizacja nazw plików

            foreach (string fi in dirs)
            {
                Console.WriteLine(fi);
            }   // wypisanie plików w katalogu

            

            foreach (string nazwa in dirs)
            {
                liczbaplikow++;
                using (var reader = new StreamReader(nazwa))
                {
                    List<string> DATA_ODCZYTU = new List<string>();
                    List<string> ZUZYCIE_BIEZACE = new List<string>();
                    List<string> JEDNOSTKA = new List<string>();
                    List<string> DATA_POPRZEDNIEGO_ODCZYTU = new List<string>();
                    List<string> ODCZYT_BIEZACY = new List<string>();
                    List<string> ODCZYT_POPRZEDNI = new List<string>();
                    List<string> STREFA_EC = new List<string>();
                    List<string> ADRES_PPE = new List<string>();
                    List<string> TYP_ODCZYTU = new List<string>();
                    List<string> NUMER_LICZNIKA = new List<string>();
                    List<string> PUNKT_POBORU = new List<string>();
                    List<string> SKLADNIK = new List<string>();


                    int x = 0;


                    while (!reader.EndOfStream)
                    {

                        var line = reader.ReadLine();
                        var values = line.Split(';');
                        DATA_ODCZYTU.Add(values[0]);
                        ZUZYCIE_BIEZACE.Add(values[1]);
                        JEDNOSTKA.Add(values[2]);
                        DATA_POPRZEDNIEGO_ODCZYTU.Add(values[3]);
                        ODCZYT_BIEZACY.Add(values[4]);
                        ODCZYT_POPRZEDNI.Add(values[5]);
                        STREFA_EC.Add(values[6]);
                        ADRES_PPE.Add(values[7]);
                        TYP_ODCZYTU.Add(values[8]);
                        NUMER_LICZNIKA.Add(values[9]);
                        PUNKT_POBORU.Add(values[10]);
                        SKLADNIK.Add(values[11]);
                        x++;

                    }   //uzupełnienie list

                    string[,] dane = new string[12, x*liczbaplikow];
                    for (int wiersz = 0; wiersz <= x - 1; wiersz++)
                    {
                        dane[0, wiersz] = DATA_ODCZYTU[wiersz];
                        dane[1, wiersz] = ZUZYCIE_BIEZACE[wiersz];
                        dane[2, wiersz] = JEDNOSTKA[wiersz];
                        dane[3, wiersz] = DATA_POPRZEDNIEGO_ODCZYTU[wiersz];
                        dane[4, wiersz] = ODCZYT_BIEZACY[wiersz];
                        dane[5, wiersz] = ODCZYT_POPRZEDNI[wiersz];
                        dane[6, wiersz] = STREFA_EC[wiersz];
                        dane[7, wiersz] = ADRES_PPE[wiersz];
                        dane[8, wiersz] = TYP_ODCZYTU[wiersz];
                        dane[9, wiersz] = NUMER_LICZNIKA[wiersz];
                        dane[10, wiersz] = PUNKT_POBORU[wiersz];
                        dane[11, wiersz] = SKLADNIK[wiersz];
                   

                    }   //uzupełnienie tablicy
                    

                }


                /* using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                 {
                     var records = csv.GetRecords<Linia>();

                 }*/







            }
        }
    }
}

