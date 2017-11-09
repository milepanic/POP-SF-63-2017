using System;
using POP_SF_63_2017.Model;

namespace POP_SF_63_2017
{
    class Program
	{
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

            /*var tp1 = new TipNamestaja () {
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
            
            var admin = new Korisnik()
            {
                Id = 1,
                Ime = "admin",
                Prezime = "admin",
                KorisnickoIme = "admin",
                Lozinka = "admin",
                TipKorisnika = 2
            };
            var listaKorisnika = new List<Korisnik>();
            listaKorisnika.Add(admin);
            
			Namestaj.Add (n1);
			TipoviNamestaja.Add (tp1);
			TipoviNamestaja.Add (tp2);
			Salon.Add (s1);
            Korisnici.Add(admin);

            var listaNamestaja = new List<Namestaj>();
            listaNamestaja.Add(n1);

            GenericSerializer.Serialize<TipNamestaja>("tipovi_namestaja.xml", TipoviNamestaja);
            Console.WriteLine("Finished serialization...");

            var listaTipovaNamestaja = GenericSerializer.Deserialize<TipNamestaja>("tipovi_namestaja.xml");

            Projekat.Instance.TipoviNamestaja = listaTipovaNamestaja;*/
            /* Napraviti main u Projekat.cs */

            //GenericSerializer.Serialize<Korisnik>("korisnik.xml", listaKorisnika);
            

            Console.WriteLine($"=== Dobrodosli u salon namestaja { s1.Naziv } ===");

            Login();
		}

        public static void Login()
        {
            int pokusaj = 3;
            var SviKorisnici = Projekat.Instance.Korisnici;

            do
            {
                Console.WriteLine($"broj pokusaja: {pokusaj}");

                Console.WriteLine("Unesite korisnicko ime");
                string ime = Console.ReadLine();

                Console.WriteLine("Unesite sifru");
                string sifra = Console.ReadLine();

                foreach (Korisnik Korisnik in SviKorisnici)
                {
                    if (Korisnik.Ime != ime || Korisnik.Lozinka != sifra)
                    {
                        Console.WriteLine("Greska, pokusajte ponovo");
                        --pokusaj;
                    }
                    else
                    {
                        IspisiGlavniMeni();
                    }
                }
            } while (pokusaj != 0);

          Environment.Exit(1);
        }
        
		public static void IspisiGlavniMeni()
		{
			int izbor = 0;

			do {
				do {
					Console.WriteLine("=== GLAVNI MENI ===");
					Console.WriteLine("1. Rad sa namestajem");
					Console.WriteLine("2. Rad sa tipom namestaja");
					Console.WriteLine("3. Rad sa salonima namestaja");
					Console.WriteLine("4. Rad sa korisnicima");
					//uraditi
					Console.WriteLine("0. Izlaz");

					izbor = int.Parse(Console.ReadLine());
				} while (izbor < 0 || izbor > 4);

				switch (izbor) {
				case 1:
					NamestajMeni();
					break;
				case 2:
					//TipNamestajaMeni();
					break;
				case 3:
					//SalonMeni();
					break;
				case 4:
					//KorisnikMeni();
					break;
				default:
					break;
				}

			} while (izbor != 0);

            Environment.Exit(1);
        }

		// RAD SA NAMJESTAJEM
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

            var UcitanNamestaj = Projekat.Instance.Namestaji;

			for (int i = 0; i < UcitanNamestaj.Count; i++)
            {
				if (UcitanNamestaj[i].Obrisan == false)
                {
                    Console.WriteLine($"===== {i + 1}. ===== \nID: { UcitanNamestaj[i].Id }\nNaziv: { UcitanNamestaj[i].Naziv }\nCena: { UcitanNamestaj[i].Cena }\nTip namestaja: { UcitanNamestaj[i].TipNamestajaId }\n");
                }
			}
		}
        
		private static void DodajNamestaj()
		{
			Console.WriteLine("=== DODAVANJE NAMESTAJA ===");

            var UcitanNamestaj = Projekat.Instance.Namestaji;

			Console.WriteLine ("Unesite naziv: ");
			string naziv = Console.ReadLine ();

			Console.WriteLine ("Unesite cenu: ");
			double cena = double.Parse(Console.ReadLine ());

			Console.WriteLine("Unesite ID tipa namestaja:");
			int idTipaNamestaja = int.Parse(Console.ReadLine());

			var noviNamestaj = new Namestaj () {
				Id = UcitanNamestaj.Count + 1,
				Naziv = naziv,
				Cena = cena,
				TipNamestajaId = idTipaNamestaja
			};

			UcitanNamestaj.Add(noviNamestaj);
            Projekat.Instance.Namestaji = UcitanNamestaj;

		}
        
		private static void IzmeniNamestaj()
		{
			Console.WriteLine ("=== IZMENA NAMESTAJA ===");

            var UcitanNamestaj = Projekat.Instance.Namestaji;

			Console.WriteLine ("Unesite redni broj namestaja");
			int idNamestaja = int.Parse (Console.ReadLine ());

			Console.WriteLine($"Izmenjujete namestaj \nID: { UcitanNamestaj[idNamestaja-1].Id }\nnaziv: {UcitanNamestaj[idNamestaja-1].Naziv}\ncena: {UcitanNamestaj[idNamestaja-1].Cena}\ntip: {UcitanNamestaj[idNamestaja-1].TipNamestajaId}");

			Console.WriteLine ("Unesite nove vrednosti");

			Console.WriteLine ("Naziv: ");
			string naziv = Console.ReadLine ();

			Console.WriteLine ("Cena: ");
			double cena = double.Parse (Console.ReadLine ());

			Console.WriteLine ("ID tipa namestaja: ");
			int idTipaNamestaja = int.Parse (Console.ReadLine ());

			UcitanNamestaj [idNamestaja-1].Naziv = naziv;
			UcitanNamestaj [idNamestaja-1].Cena = cena;
			UcitanNamestaj [idNamestaja-1].TipNamestajaId = idTipaNamestaja;

            Projekat.Instance.Namestaji = UcitanNamestaj;
		}
        
		private static void ObrisiNamestaj()
		{
			Console.WriteLine ("=== BRISANJE NAMESTAJA ===");

            var UcitanNamestaj = Projekat.Instance.Namestaji;

			Console.WriteLine ("Unesite redni broj namestaja");
			int idNamestaja = int.Parse (Console.ReadLine ());

			Console.WriteLine($"Da li zelite da obrisete namestaj \nID: { UcitanNamestaj[idNamestaja-1].Id }\nnaziv: {UcitanNamestaj[idNamestaja-1].Naziv}\ncena: {UcitanNamestaj[idNamestaja-1].Cena}\ntip: {UcitanNamestaj[idNamestaja-1].TipNamestajaId}\nZa brisanje unesite 1");

			int odgovor = int.Parse (Console.ReadLine ());

			if (odgovor == 1) {
                UcitanNamestaj[idNamestaja-1].Obrisan = true;
                Projekat.Instance.Namestaji = UcitanNamestaj;
			}
		}
        /*
		// RAD SA TIPOVIMA NAMJESTAJA
		private static void TipNamestajaMeni()
		{
			int izbor = 0;

			do {
				do {
					Console.WriteLine ("=== RAD SA TIPOM NAMESTAJA ===");
					IspisiCRUDMeni ();

					izbor = int.Parse (Console.ReadLine ());
				} while (izbor < 0 || izbor > 4);

				switch (izbor) 
				{
				case 1:
					PrikaziTipNamestaja();
					break;
				case 2:
					DodajTipNamestaja();
					break;
				case 3:
					IzmeniTipNamestaja();
					break;
				case 4:
					ObrisiTipNamestaja();
					break;
				default:
					break;
				}

			} while (izbor != 0);
		}

		private static void PrikaziTipNamestaja()
		{
			Console.WriteLine("=== LISTING TIPOVA NAMESTAJA ===");

			for (int i = 0; i < TipoviNamestaja.Count; i++) {
				Console.WriteLine ($"===== {i + 1}. ===== \nID: { TipoviNamestaja[i].Id }\nNaziv: { TipoviNamestaja[i].Naziv }\n");
			}
		}

		private static void DodajTipNamestaja()
		{
			Console.WriteLine ("=== DODAVANJE TIPA NAMESTAJA ===");

			Console.WriteLine ("Unesite naziv: ");
			string naziv = Console.ReadLine ();

			var noviTipNamestaja = new TipNamestaja {
				Id = TipoviNamestaja.Count + 1,
				Naziv = naziv
			};

			TipoviNamestaja.Add (noviTipNamestaja);
		}

		private static void IzmeniTipNamestaja()
		{
			Console.WriteLine ("=== IZMENA TIPA NAMESTAJA ===");

			Console.WriteLine ("Unesite ID tipa namestaja koji hocete da izmenite: ");
			int id = int.Parse(Console.ReadLine ());

			Console.WriteLine ("Unesite novi naziv: ");
			string naziv = Console.ReadLine ();

			TipoviNamestaja [id - 1].Naziv = naziv;
		}

		private static void ObrisiTipNamestaja()
		{
			Console.WriteLine ("=== BRISANJE TIPA NAMESTAJA ===");

			Console.WriteLine ("Unesite ID tipa namestaja koji hocete da obriste: ");
			int idTipaNamestaja = int.Parse(Console.ReadLine ());

			Console.WriteLine($"Da li zelite da obrisete namestaj \nID: { TipoviNamestaja[idTipaNamestaja-1].Id }\nnaziv: { TipoviNamestaja[idTipaNamestaja-1].Naziv}\nZa brisanje unesite 1");

			if (int.Parse(Console.ReadLine()) == 1) {
				TipoviNamestaja.RemoveAll (i => i.Id == idTipaNamestaja);
			}
		}

		// RAD SA SALONIMA
		private static void SalonMeni()
		{
			int izbor = 0;

			do {
				do {
					Console.WriteLine ("=== RAD SA SALONIMA NAMESTAJA ===");
					IspisiCRUDMeni ();

					izbor = int.Parse (Console.ReadLine ());
				} while (izbor < 0 || izbor > 4);

				switch (izbor) 
				{
				case 1:
					PrikaziSalon();
					break;
				case 2:
					DodajSalon();
					break;
				case 3:
					IzmeniSalon();
					break;
				case 4:
					ObrisiSalon();
					break;
				default:
					break;
				}

			} while (izbor != 0);
		}

		private static void PrikaziSalon()
		{
			Console.WriteLine("=== LISTING SALONA NAMESTAJA ===");

			for (int i = 0; i < Salon.Count; i++) {
				Console.WriteLine ($"===== {i + 1}. ===== \nID: { Salon[i].Id }\nNaziv: { Salon[i].Naziv }\nAdresa: { Salon[i].Adresa }\nTelefon: { Salon[i].Telefon }\nEmail: { Salon[i].Email }\nWebsajt: { Salon[i].Websajt }\nPIB: { Salon[i].PIB }\nMaticniBroj: { Salon[i].MaticniBroj }\nBrojZiroRacuna: { Salon[i].BrojZiroRacuna }\n");
			}
		}

		private static void DodajSalon()
		{
			Console.WriteLine("=== DODAVANJE SALONA ===");

			Console.WriteLine ("Unesite naziv: ");
			string naziv = Console.ReadLine ();

			Console.WriteLine ("Unesite adresu: ");
			string adresa = Console.ReadLine ();

			Console.WriteLine ("Unesite telefon: ");
			string telefon = Console.ReadLine ();

			Console.WriteLine ("Unesite email: ");
			string email = Console.ReadLine ();

			Console.WriteLine ("Unesite websajt: ");
			string websajt = Console.ReadLine ();

			Console.WriteLine ("Unesite PIB: ");
			int pib = int.Parse(Console.ReadLine ());

			Console.WriteLine ("Unesite maticni broj: ");
			int maticniBroj = int.Parse(Console.ReadLine ());

			Console.WriteLine ("Unesite broj ziro racuna: ");
			string ziroRacun = Console.ReadLine ();


			var noviSalon = new Salon () {
				Id = Salon.Count + 1,
				Naziv = naziv,
				Adresa = adresa,
				Telefon = telefon,
				Email = email,
				Websajt = websajt,
				PIB = pib,
				MaticniBroj = maticniBroj,
				BrojZiroRacuna = ziroRacun
			};

			Salon.Add (noviSalon);
		}

		private static void IzmeniSalon()
		{
			Console.WriteLine ("=== IZMENA SALONA ===");

			Console.WriteLine ("Unesite ID salona koji hocete da izmenite: ");
			int id = int.Parse(Console.ReadLine ());

			Console.WriteLine ("Unesite novi naziv: ");
			string naziv = Console.ReadLine ();

			Console.WriteLine ("Unesite adresu: ");
			string adresa = Console.ReadLine ();

			Console.WriteLine ("Unesite telefon: ");
			string telefon = Console.ReadLine ();

			Console.WriteLine ("Unesite email: ");
			string email = Console.ReadLine ();

			Console.WriteLine ("Unesite websajt: ");
			string websajt = Console.ReadLine ();

			Console.WriteLine ("Unesite PIB: ");
			int pib = int.Parse(Console.ReadLine ());

			Console.WriteLine ("Unesite maticni broj: ");
			int maticniBroj = int.Parse(Console.ReadLine ());

			Console.WriteLine ("Unesite broj ziro racuna: ");
			string ziroRacun = Console.ReadLine ();

			Salon [id - 1].Naziv = naziv;
			Salon [id - 1].Adresa = adresa;
			Salon [id - 1].Telefon = telefon;
			Salon [id - 1].Email = email;
			Salon [id - 1].Websajt = websajt;
			Salon [id - 1].PIB = pib;
			Salon [id - 1].MaticniBroj = maticniBroj;
			Salon [id - 1].BrojZiroRacuna = ziroRacun;

		}

		private static void ObrisiSalon()
		{
			Console.WriteLine ("=== BRISANJE TIPA NAMESTAJA ===");

			Console.WriteLine ("Unesite ID salona koji hocete da obriste: ");
			int idSalona = int.Parse(Console.ReadLine ());

			//Console.WriteLine($"Da li zelite da obrisete namestaj \nID: { TipoviNamestaja[idTipaNamestaja-1].Id }\nnaziv: { TipoviNamestaja[idTipaNamestaja-1].Naziv}\nZa brisanje unesite 1");

			//if (int.Parse(Console.ReadLine()) == 1) {
				Salon.RemoveAll (i => i.Id == idSalona);
			//}
		}

		// RAD SA KORISNICIMA
		private static void KorisnikMeni()
		{
			int izbor = 0;

			do {
				do {
					Console.WriteLine ("=== RAD SA KORISNICIMA ===");
					IspisiCRUDMeni ();

					izbor = int.Parse (Console.ReadLine ());
				} while (izbor < 0 || izbor > 4);

				switch (izbor) 
				{
				case 1:
					PrikaziKorisnike();
					break;
				case 2:
					DodajKorisnika();
					break;
				case 3:
					IzmeniKorisnika();
					break;
				case 4:
					ObrisiKorisnika();
					break;
				default:
					break;
				}

			} while (izbor != 0);
		}

		public static void PrikaziKorisnike()
		{
			Console.WriteLine("=== LISTING KORISNIKA ===");

			for (int i = 0; i < Korisnici.Count; i++) {
				Console.WriteLine ($"===== {i + 1}. ===== \nID: { Korisnici[i].Id }\nIme: { Korisnici[i].Ime }\nPrezime: { Korisnici[i].Prezime }\nKorisnicko ime: { Korisnici[i].KorisnickoIme }\nLozinka: { Korisnici[i].Lozinka }\n");
			}
		}

		private static void DodajKorisnika()
		{
			Console.WriteLine("=== DODAVANJE KORISNIKA ===");

			Console.WriteLine ("Unesite ime: ");
			string ime = Console.ReadLine ();

			Console.WriteLine ("Unesite prezime: ");
			string prezime = Console.ReadLine ();

			Console.WriteLine ("Unesite korisnicko ime: ");
			string korisnickoIme = Console.ReadLine ();

			Console.WriteLine ("Unesite lozinku: ");
			string lozinka = Console.ReadLine ();

			var noviKorisnik = new Korisnik () {
				Id = Korisnici.Count + 1,
				Ime = ime,
				Prezime = prezime,
				KorisnickoIme = korisnickoIme,
				Lozinka = lozinka,
			};

			Korisnici.Add (noviKorisnik);
		}

		private static void IzmeniKorisnika()
		{
			Console.WriteLine ("=== IZMENA KORISNIKA ===");

			Console.WriteLine ("Unesite ID korisnika koji hocete da izmenite: ");
			int id = int.Parse(Console.ReadLine ());

			Console.WriteLine ("Unesite novo ime: ");
			string ime = Console.ReadLine ();

			Console.WriteLine ("Unesite prezime: ");
			string prezime = Console.ReadLine ();

			Console.WriteLine ("Unesite korisnicko ime: ");
			string korisnickoIme = Console.ReadLine ();

			Console.WriteLine ("Unesite lozinku: ");
			string lozinka = Console.ReadLine ();

			Korisnici [id - 1].Ime = ime;
			Korisnici [id - 1].Prezime = prezime;
			Korisnici [id - 1].KorisnickoIme = korisnickoIme;
			Korisnici [id - 1].Lozinka = lozinka;
		}

		public static void ObrisiKorisnika()
		{
			Console.WriteLine ("=== BRISANJE KORISNIKA ===");

			Console.WriteLine ("Unesite ID korisnika koji hocete da obriste: ");
			int idKorisnika = int.Parse(Console.ReadLine ());

			//Console.WriteLine($"Da li zelite da obrisete namestaj \nID: { TipoviNamestaja[idTipaNamestaja-1].Id }\nnaziv: { TipoviNamestaja[idTipaNamestaja-1].Naziv}\nZa brisanje unesite 1");

			//if (int.Parse(Console.ReadLine()) == 1) {
			Korisnici.RemoveAll (i => i.Id == idKorisnika);
			//}
		}
        */
			
		// CreateReadUpdateDelete Meni
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
