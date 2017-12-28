using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace POP_SF_63_2017.Model
{
    public class Namestaj : INotifyPropertyChanged, ICloneable
	{
        private int id;
        private string naziv;
        private string sifra;
        private double cena;
        private int kolicinaUMagacinu;
        private int akcijaId;
        private int tipNamestajaId;
        private bool obrisan;
        private Akcija akcija;
        private TipNamestaja tipNamestaja;
        
        public TipNamestaja TipNamestaja
        {
            get
            {
                if (tipNamestaja == null)
                {
                    return TipNamestaja.GetById(tipNamestajaId);
                }
                return tipNamestaja;
            }
            set
            {
                tipNamestaja = value;
                TipNamestajaId = tipNamestaja.Id;
                OnPropertyChanged("TipNamestaja");
            }
        }
        
        public Akcija Akcija
        {
            get
            {
                if (akcija == null)
                {
                    return Akcija.GetById(akcijaId);
                }
                return akcija;
            }
            set
            {
                akcija = value;
                akcijaId = akcija.Id;
                OnPropertyChanged("Akcija");
            }
        }
        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }
        public string Naziv
        {
            get { return naziv; }
            set
            {
                naziv = value;
                OnPropertyChanged("Naziv");
            }
        }
        public string Sifra
        {
            get { return sifra; }
            set
            {
                sifra = value;
                OnPropertyChanged("Sifra");
            }
        }
        public double Cena
        {
            get { return cena; }
            set
            {
                cena = value;
                OnPropertyChanged("Cena");
            }
        }
        public int KolicinaUMagacinu
        {
            get { return kolicinaUMagacinu; }
            set
            {
                kolicinaUMagacinu = value;
                OnPropertyChanged("KolicinaUMagacinu");
            }
        }
        public int AkcijaId
        {
            get { return akcijaId; }
            set
            {
                akcijaId = value;
                OnPropertyChanged("AkcijaId");
            }
        }

        public int TipNamestajaId
        {
            get { return tipNamestajaId; }
            set
            {
                tipNamestajaId = value;
                OnPropertyChanged("TipNamestajaId");
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

        public override string ToString()
        {
            return $"{ Naziv }, { Cena }, { TipNamestaja.GetById(TipNamestajaId).Naziv } ";
        }

        public static Namestaj GetById(int id)
        {
            foreach (Namestaj namestaj in Projekat.Instance.Namestaji)
            {
                if (namestaj.Id == id)
                {
                    return namestaj;
                }
            }
            return null;
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
            return new Namestaj()
            {
                id = Id,
                naziv = Naziv,
                sifra = Sifra,
                tipNamestaja = TipNamestaja,
                tipNamestajaId = TipNamestajaId,
                akcija = Akcija,
                akcijaId = AkcijaId,
                kolicinaUMagacinu = KolicinaUMagacinu,
                cena = Cena,
                obrisan = Obrisan
            };
        }

        #region Database
        public static ObservableCollection<Namestaj> GetAll()
        {
            var namestaji = new ObservableCollection<Namestaj>();

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM Namestaj WHERE Obrisan=0";

                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();

                da.SelectCommand = cmd;
                da.Fill(ds, "Namestaj");

                foreach (DataRow row in ds.Tables["Namestaj"].Rows)
                {
                    var n = new Namestaj();
                    n.Id = int.Parse(row["Id"].ToString());
                    n.Sifra = row["Sifra"].ToString();
                    n.TipNamestajaId = int.Parse(row["TipNamestajaId"].ToString());
                    n.AkcijaId = int.Parse(row["AkcijaId"].ToString());
                    n.Naziv = row["Naziv"].ToString();
                    n.Cena = double.Parse(row["Cena"].ToString());
                    n.KolicinaUMagacinu = int.Parse(row["KolicinaUMagacinu"].ToString());
                    n.Obrisan = bool.Parse(row["Obrisan"].ToString());

                    namestaji.Add(n);
                }
            }

            return namestaji;
        }

        public static Namestaj Create(Namestaj n)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "INSERT INTO Namestaj (TipNamestajaId, AkcijaId, Sifra, Naziv, Cena, KolicinaUMagacinu) VALUES (@TipNamestajaId, @AkcijaId, @Sifra, @Naziv, @Cena, @KolicinaUMagacinu);";
                cmd.CommandText += "SELECT SCOPE_IDENTITY();";

                cmd.Parameters.AddWithValue("TipNamestajaId", n.TipNamestajaId);
                cmd.Parameters.AddWithValue("AkcijaId", n.AkcijaId);
                cmd.Parameters.AddWithValue("Sifra", n.Sifra);
                cmd.Parameters.AddWithValue("Naziv", n.Naziv);
                cmd.Parameters.AddWithValue("Cena", n.Cena);
                cmd.Parameters.AddWithValue("KolicinaUMagacinu", n.KolicinaUMagacinu);

                int newId = int.Parse(cmd.ExecuteScalar().ToString()); // ExecuteScalar izvrsava query
                n.Id = newId;
            }
            Projekat.Instance.Namestaji.Add(n);

            return n;
        }

        public static void Update(Namestaj n)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "UPDATE Namestaj SET TipNamestajaId=@TipNamestajaId,AkcijaId=@AkcijaId,Sifra=@Sifra,Naziv=@Naziv,Cena=@Cena,KolicinaUMagacinu=@KolicinaUMagacinu,Obrisan=@Obrisan WHERE Id=@Id";

                cmd.Parameters.AddWithValue("Id", n.Id);
                cmd.Parameters.AddWithValue("TipNamestajaId", n.TipNamestajaId);
                cmd.Parameters.AddWithValue("AkcijaId", n.AkcijaId);
                cmd.Parameters.AddWithValue("Sifra", n.Sifra);
                cmd.Parameters.AddWithValue("Naziv", n.Naziv);
                cmd.Parameters.AddWithValue("Cena", n.Cena);
                cmd.Parameters.AddWithValue("KolicinaUMagacinu", n.KolicinaUMagacinu);
                cmd.Parameters.AddWithValue("Obrisan", n.Obrisan);

                cmd.ExecuteNonQuery();

                // azurira se stanje modela
                foreach (var namestaj in Projekat.Instance.Namestaji)
                {
                    if (namestaj.Id == n.Id)
                    {
                        namestaj.TipNamestajaId = n.TipNamestajaId;
                        namestaj.AkcijaId = n.AkcijaId;
                        namestaj.Sifra = n.Sifra;
                        namestaj.Naziv = n.Naziv;
                        namestaj.Cena = n.Cena;
                        namestaj.KolicinaUMagacinu = n.KolicinaUMagacinu;
                        namestaj.Obrisan = n.Obrisan;
                        break;
                    }
                }
            }
        }

        public static void Delete(Namestaj n)
        {
            n.Obrisan = true;
            Update(n);
        }
        #endregion
    }
}

