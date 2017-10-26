using System;
using POP_SF_63_2017.Model;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF_63_2017
{
    class Program
    {
        private static List<Namjestaj> Namjestaj = new List<Namjestaj>();
        private static List<Namjestaj> TipoviNamjestaja = new List<TipNamjestaja>();
        static void Main(string[] args)
        {
            Salon s1 = new Salon()
            {
                Id = 1,
                Adresa = "Trg Dositeja Obradovica 6",
                BrojZiroRacuna = "840-000171666-45",
                Email = "dekan@ftn.uns.ac.rs",
                MaticniBroj = 31415616,
                Naziv = "Forma FTNale",
                PIB = 123415,
                Telefon = "021/454-3434",
                Websajt = "http://ftn.uns.ac.rs"
            };

            var tp1 = new TipNamjestaja()
            {
                Id = 1,
                Naziv = "Krevet"
            };

            var tp2 = new TipNamjestaja()
            {
                Id = 2,
                Naziv = "Sofa"
            };

            var n1 = new Namjestaj()
            {
                Id = 1,
                Cijena = 516,
                TipNamjestaja = tp1,
                Naziv = "Ekstra Krevet socijalni",
                KolicinaUMagacinu = 100,
                Sifra = "KR3993434SC"
            };

            Namjestaj.Add(n1);
            TipoviNamjestaja.Add(tp1);
            TipoviNamjestaja.Add(tp2);

            Console.WriteLine($"=== Dobrodosli u salon namjestaja { s1.Naziv } ===");

            IspisiGlavniMeni();
        }

        public static void IspisiGlavniMeni()
        {
            int izbor = 0;

            do
            {
                do
                {
                    Console.WriteLine("=== GLAVNI MENI ===");
                    Console.WriteLine("1. Rad sa namjestajem");
                    Console.WriteLine("2. Rad sa tipom namjestaja");
                    //...dovrsiti kod kuce
                    Console.WriteLine("0. Izlaz iz aplikacije");

                    izbor = int.Parse(Console.ReadLine());
                } while (izbor < 0 || izbor > 2);

                switch (izbor)
                {
                    case 1:
                        NamjestajMeni();
                        break;
                    default:
                        break;
                }

            } while (izbor != 0);
        }

        private static void NamjestajMeni()
        {
            int izbor = 0;
            do
            {
                do
                {
                    Console.WriteLine("=== RAD SA NAMJESTAJEM ===");
                    IspisiCRUDMeni();

                    izbor = int.Parse(Console.ReadLine());

                } while (izbor < 0 || izbor > 4);

                switch (izbor)
                {
                    case 1:
                        PrikaziNamjestaj();
                        break;
                    case 2:
                        DodajNamjestaj();
                        break;
                    case 3:
                        IzmijeniNamjestaj();
                        break;
                    default:
                        break;
                }
            } while (izbor != 0);
        }

        private static void PrikaziNamjestaj()
        {
            Console.WriteLine("=== LISTING NAMJESTAJA ===");

            for (int i = 0; i < Namjestaj.Count; i++)
            {
                Console.WriteLine($"{i + 1}. naziv: { Namjestaj[i].Naziv }, cijena: { Namjestaj[i].Cijena }, tip namjestaja: { Namjestaj[i].TipNamjestaja.Naziv }");
            }
        }

        private static void DodajNamjestaj()
        {
            Console.WriteLine("=== DODAJ NOVI NAMJESTAJ ===");

            Console.WriteLine("Unesite naziv: ");
            string naziv = Console.ReadLine();

            Console.WriteLine("Unesite cijenu: ");
            double cijena = double.Parse(Console.ReadLine());

            Console.WriteLine("Unesite ID tipa namjestaja:"); //NAPOMENA: u praksi se veze preko ID-a
            int idTipaNamjestaja = int.Parse(Console.ReadLine());

            TipNamjestaja trazeniTipNamjestaja = null;

            foreach (var tipNamjestaja in TipoviNamjestaja)
            {
                if(tipNamjestaja.Id == idTipaNamjestaja) // PRAKSA tipNamjestaja.Id == trazeniId !
                {
                    trazeniTipNamjestaja = tipNamjestaja;
                }
            }

            var noviNamjestaj = new Namjestaj()
            {
                Id = Namjestaj.Count + 1,
                Naziv = naziv,
                Cijena = cijena,
                TipNamjestaja = trazeniTipNamjestaja
            };

            Namjestaj.Add(noviNamjestaj);
        }

        private static void IzmijeniNamjestaj()
        {
            Console.WriteLine("=== IZMJENA NAMJESTAJA ===");

            Console.WriteLine("Unesite ID tipa namjestaja");
            int idTipaNamjestaja = int.Parse(Console.ReadLine());

        }

        private static void IspisiCRUDMeni()
        {
            Console.WriteLine("1. Prikazi listing");
            Console.WriteLine("2. Dodaj novi");
            Console.WriteLine("3. Izmijeni postojeci");
            Console.WriteLine("4. Obrisi postojeci");
            Console.WriteLine("0. Povratak u glavni meni");
        }
    }
}
