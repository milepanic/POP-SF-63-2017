using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace POP_SF_63_2017.Model
{
    public enum TipKorisnika
	{
		Administrator,
		Prodavac
	}
    public class Korisnik : INotifyPropertyChanged, ICloneable
    {
        private int id;
        private string ime;
        private string prezime;
        private string korisnickoIme;
        private string lozinka;
        private int tipKorisnika;
        private bool obrisan;

        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }
        public string Ime
        {
            get { return ime; }
            set
            {
                ime = value;
                OnPropertyChanged("Ime");
            }
        }
        public string Prezime
        {
            get { return prezime; }
            set
            {
                prezime = value;
                OnPropertyChanged("Prezime");
            }
        }
        public string KorisnickoIme
        {
            get { return korisnickoIme; }
            set
            {
                korisnickoIme = value;
                OnPropertyChanged("KorisnickoIme");
            }
        }
        public string Lozinka
        {
            get { return lozinka; }
            set
            {
                lozinka = value;
                OnPropertyChanged("Lozinka");
            }
        }
        public int TipKorisnika
        {
            get { return tipKorisnika; }
            set
            {
                tipKorisnika = value;
                OnPropertyChanged("TipKorisnika");
            }
        }
        public bool Obrisan
        {
            get { return obrisan; }
            set
            {
                obrisan = value;
                OnPropertyChanged("Obrisan");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        // TODO: Tip korisnika
        public override string ToString()
        {
            return $"{ Ime }, { Prezime }, { KorisnickoIme }";
        }

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public object Clone()
        {
            return new Korisnik()
            {
                id = Id,
                ime = Ime,
                prezime = Prezime,
                korisnickoIme = KorisnickoIme,
                lozinka = Lozinka,
                tipKorisnika = TipKorisnika,
                obrisan = Obrisan
            };
        }

        #region Database
        public static ObservableCollection<Korisnik> GetAll()
        {
            var korisnici = new ObservableCollection<Korisnik>();

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM Korisnik WHERE Obrisan=0";

                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();

                da.SelectCommand = cmd;
                da.Fill(ds, "Korisnik");

                foreach (DataRow row in ds.Tables["Korisnik"].Rows)
                {
                    var k = new Korisnik();
                    k.Id = int.Parse(row["Id"].ToString());
                    k.Ime = row["Ime"].ToString();
                    k.Prezime = row["Prezime"].ToString();
                    k.KorisnickoIme = row["KorisnickoIme"].ToString();
                    k.Lozinka = row["Lozinka"].ToString();
                    k.TipKorisnika = int.Parse(row["TipKorisnika"].ToString());
                    k.Obrisan = bool.Parse(row["Obrisan"].ToString());

                    korisnici.Add(k);
                }
            }

            return korisnici;
        }

        public static Korisnik Create(Korisnik k)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "INSERT INTO Korisnik (Ime, Prezime, KorisnickoIme, Lozinka, TipKorisinka) VALUES (@Ime, @Prezime, @KorisnickoIme, @Lozinka, @TipKorisinka);";
                cmd.CommandText += "SELECT SCOPE_IDENTITY();";

                cmd.Parameters.AddWithValue("Ime", k.Ime);
                cmd.Parameters.AddWithValue("Prezime", k.Prezime);
                cmd.Parameters.AddWithValue("KorisnickoIme", k.KorisnickoIme);
                cmd.Parameters.AddWithValue("Lozinka", k.Lozinka);
                cmd.Parameters.AddWithValue("TipKorisnika", k.TipKorisnika);

                int newId = int.Parse(cmd.ExecuteScalar().ToString()); // ExecuteScalar izvrsava query
                k.Id = newId;
            }
            Projekat.Instance.Korisnici.Add(k);

            return k;
        }

        public static void Update(Korisnik k)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "UPDATE Korisnik SET Ime=@Ime,Prezime=@Prezime,KorisnickoIme=@KorisnickoIme,Lozinka=@Lozinka,TipKorisinka=@TipKorisinka,Obrisan=@Obrisan WHERE Id=@Id";

                cmd.Parameters.AddWithValue("Id", k.Id);
                cmd.Parameters.AddWithValue("Ime", k.Ime);
                cmd.Parameters.AddWithValue("Prezime", k.Prezime);
                cmd.Parameters.AddWithValue("KorisnickoIme", k.KorisnickoIme);
                cmd.Parameters.AddWithValue("Lozinka", k.Lozinka);
                cmd.Parameters.AddWithValue("TipKorisnika", k.TipKorisnika);
                cmd.Parameters.AddWithValue("Obrisan", k.Obrisan);

                cmd.ExecuteNonQuery();

                // azurira se stanje modela
                foreach (var korisnik in Projekat.Instance.Korisnici)
                {
                    if (korisnik.Id == k.Id)
                    {
                        korisnik.Ime = k.Ime;
                        korisnik.Prezime = k.Prezime;
                        korisnik.KorisnickoIme = k.KorisnickoIme;
                        korisnik.Lozinka = k.Lozinka;
                        korisnik.TipKorisnika = k.TipKorisnika;
                        korisnik.Obrisan = k.Obrisan;
                        break;
                    }
                }
            }
        }

        public static void Delete(Korisnik k)
        {
            k.Obrisan = true;
            Update(k);
        }
        #endregion
    }
}

