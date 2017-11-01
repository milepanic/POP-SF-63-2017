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
		private static List<Namestaj> Namestaj = new List<Namestaj>();
		private static List<TipNamestaja> TipoviNamestaja = new List<TipNamestaja>();

		public static void Main (string[] args)
		{
			Salon s1 = new Salon () {
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

			var tp1 = new TipNamestaja () {
				Id = 1,
				Naziv = "Krevet"
			};

			var tp2 = new TipNamestaja () {
				Id = 2,
				Naziv = "Sofa"
			};

			var n1 = new Namestaj () {
				Id = 1,
				Cena = 516,
				TipNamestaja = tp1,
				Naziv = "Ekstra Krevet socijalni",
				KolicinaUMagacinu = 100,
				Sifra = "KR3993434SC"	
			};

			Namestaj.Add (n1);
			TipoviNamestaja.Add (tp1);
			TipoviNamestaja.Add (tp2);

			Console.WriteLine($"=== Dobrodosli u salon namestaja { s1.Naziv } ===");

			IspisiGlavniMeni ();
		}

		public static void IspisiGlavniMeni()
		{
			int izbor = 0;

			do {
				do {
					Console.WriteLine("=== GLAVNI MENI ===");
					Console.WriteLine("1. Rad sa namestajem");
					Console.WriteLine("2. Rad sa tipom namestaja");
					//uraditi
					Console.WriteLine("0. Izlaz");

					izbor = int.Parse(Console.ReadLine());
				} while (izbor < 0 || izbor > 2);

				switch (izbor) {
					case 1:
						NamestajMeni();
						break;
					default:
						break;
				}

			} while (izbor != 0);
		}

		public static void NamestajMeni()
		{
			int izbor = 0;

			do {
				do {
					Console.WriteLine("=== RAD SA NAMJESTAJEM ===");
					IspisiCRUDMeni();

					izbor = int.Parse(Console.ReadLine());
				} while (izbor < 0 || izbor > 4);

				switch (izbor)
				{
				case 1:
					PrikaziNamestaj();
					break;
				case 2:
					DodajNamestaj();
					break;
				case 3:
					IzmeniNamestaj();
					break;
				case 4:
					ObrisiNamestaj();
					break;
				default:
					break;
				}

			} while (izbor != 0);
		}

		private static void PrikaziNamestaj()
		{
			Console.WriteLine("=== LISTING NAMJESTAJA ===");

			for (int i = 0; i < Namestaj.Count; i++) {
				Console.WriteLine ($"===== {i + 1}. ===== \nID: { Namestaj[i].Id }\nNaziv: { Namestaj[i].Naziv }\nCena: { Namestaj[i].Cena }\nTip namestaja: { Namestaj[i].TipNamestaja.Naziv }\n");
			}
		}

		private static void DodajNamestaj()
		{
			Console.WriteLine("=== DODAVANJE NAMESTAJA ===");

			Console.WriteLine ("Unesite naziv: ");
			string naziv = Console.ReadLine ();

			Console.WriteLine ("Unesite cenu: ");
			double cena = double.Parse(Console.ReadLine ());

			Console.WriteLine("Unesite ID tipa namestaja:"); //NAPOMENA: u praksi se veze preko ID-a
			int idTipaNamestaja = int.Parse(Console.ReadLine());

			TipNamestaja trazeniTipNamestaja = null;

			foreach (var tipNamestaja in TipoviNamestaja) {
				if(tipNamestaja.Id == idTipaNamestaja) { // PRAKSA tipNamestaja.Id == trazeniId !
					trazeniTipNamestaja = tipNamestaja;
				}
			}

			var noviNamestaj = new Namestaj () {
				Id = Namestaj.Count + 1,
				Naziv = naziv,
				Cena = cena,
				TipNamestaja = trazeniTipNamestaja
			};

			Namestaj.Add (noviNamestaj);
		}

		private static void IzmeniNamestaj()
		{
			Console.WriteLine ("=== IZMENA NAMESTAJA ===");

			Console.WriteLine ("Unesite redni broj namestaja");
			int idNamestaja = int.Parse (Console.ReadLine ());

			Console.WriteLine($"Izmenjujete namestaj \nID: { Namestaj[idNamestaja-1].Id }\nnaziv: {Namestaj[idNamestaja-1].Naziv}\ncena: {Namestaj[idNamestaja-1].Cena}\ntip: {Namestaj[idNamestaja-1].TipNamestaja.Naziv}");

			Console.WriteLine ("Unesite nove vrednosti");

			Console.WriteLine ("Naziv: ");
			string naziv = Console.ReadLine ();

			Console.WriteLine ("Cena: ");
			double cena = double.Parse (Console.ReadLine ());

			Console.WriteLine ("ID tipa namestaja: ");
			int idTipaNamestaja = int.Parse (Console.ReadLine ());

			TipNamestaja trazeniTipNamestaja = null;

			foreach (var tipNamestaja in TipoviNamestaja) {
				if(tipNamestaja.Id == idTipaNamestaja) { // PRAKSA tipNamestaja.Id == trazeniId !
					trazeniTipNamestaja = tipNamestaja;
				}
			}

			Namestaj [idNamestaja-1].Naziv = naziv;
			Namestaj [idNamestaja-1].Cena = cena;
			Namestaj [idNamestaja-1].TipNamestaja = trazeniTipNamestaja;
		}

		private static void ObrisiNamestaj()
		{
			Console.WriteLine ("=== BRISANJE NAMESTAJA ===");

			Console.WriteLine ("Unesite redni broj namestaja");
			int idNamestaja = int.Parse (Console.ReadLine ());

			Console.WriteLine($"Da li zelite da obrisete namestaj \nID: { Namestaj[idNamestaja-1].Id }\nnaziv: {Namestaj[idNamestaja-1].Naziv}\ncena: {Namestaj[idNamestaja-1].Cena}\ntip: {Namestaj[idNamestaja-1].TipNamestaja.Naziv}\nZa brisanje unesite 1");

			int odgovor = int.Parse (Console.ReadLine ());

			if (odgovor == 1) {
				Namestaj.RemoveAll (i => i.Id == idNamestaja);
			}
		}

		private static void IspisiCRUDMeni()
		{
			Console.WriteLine("1. Prikazi listing");
			Console.WriteLine("2. Dodaj novi");
			Console.WriteLine("3. Izmeni postojeci");
			Console.WriteLine("4. Obrisi postojeci");
			Console.WriteLine("0. Povratak u glavni meni");
		}

	}
}
