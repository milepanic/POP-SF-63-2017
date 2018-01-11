using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace POP_SF_63_2017.Model
{
    public class Prodaja : INotifyPropertyChanged, ICloneable
    {
        private int id;
        private DateTime datumProdaje;
        private string brojRacuna;
        private string kupac;
        private decimal pdv = 20M;
        private double ukupnaCena;
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

        public DateTime DatumProdaje
        {
            get { return datumProdaje; }
            set
            {
                datumProdaje = value;
                OnPropertyChanged("DatumProdaje");
            }
        }

        public string BrojRacuna
        {
            get { return brojRacuna; }
            set
            {
                brojRacuna = value;
                OnPropertyChanged("BrojRacuna");
            }
        }

        public string Kupac
        {
            get { return kupac; }
            set
            {
                kupac = value;
                OnPropertyChanged("Kupac");
            }
        }

        public decimal PDV
        {
            get { return pdv; }
            set
            {
                pdv = 20M;
            }
        }


        public double UkupnaCena
        {
            get { return ukupnaCena; }
            set
            {
                ukupnaCena = value;
                OnPropertyChanged("UkupnaCena");
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

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public object Clone()
        {
            return new Prodaja()
            {
                id = Id,
                datumProdaje = DatumProdaje,
                brojRacuna = BrojRacuna,
                kupac = Kupac,
                ukupnaCena = UkupnaCena,
                obrisan = Obrisan
            };
        }
        #region Database
        public static ObservableCollection<Prodaja> GetAll()
        {
            var prodaje = new ObservableCollection<Prodaja>();

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM Prodaja WHERE Obrisan=0";

                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();

                da.SelectCommand = cmd;
                da.Fill(ds, "Prodaja");

                foreach (DataRow row in ds.Tables["Prodaja"].Rows)
                {
                    var p = new Prodaja();
                    p.Id = int.Parse(row["Id"].ToString());
                    p.DatumProdaje = DateTime.Parse(row["DatumProdaje"].ToString());
                    p.BrojRacuna = row["BrojRacuna"].ToString();
                    p.Kupac = row["Kupac"].ToString();
                    p.UkupnaCena = double.Parse(row["UkupnaCena"].ToString());
                    p.Obrisan = bool.Parse(row["Obrisan"].ToString());

                    prodaje.Add(p);
                }
            }

            return prodaje;
        }

        

        public static Prodaja Create(Prodaja p)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "INSERT INTO Prodaja ( BrojRacuna, Kupac, UkupnaCena) VALUES (@BrojRacuna, @Kupac, @UkupnaCena);";
                cmd.CommandText += "SELECT SCOPE_IDENTITY();";
                
                cmd.Parameters.AddWithValue("BrojRacuna", p.BrojRacuna);
                cmd.Parameters.AddWithValue("Kupac", p.Kupac);
                cmd.Parameters.AddWithValue("UkupnaCena", p.UkupnaCena);

                int newId = int.Parse(cmd.ExecuteScalar().ToString());
                p.Id = newId;
            }
            Projekat.Instance.Prodaje.Add(p);

            return p;
        }

        public static void Update(Prodaja p)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "UPDATE Prodaja SET BrojRacuna=@BrojRacuna, Kupac=@Kupac, UkupnaCena=@UkupnaCena WHERE Id=@Id";

                cmd.Parameters.AddWithValue("Id", p.Id);
                cmd.Parameters.AddWithValue("BrojRacuna", p.BrojRacuna);
                cmd.Parameters.AddWithValue("Kupac", p.Kupac);
                cmd.Parameters.AddWithValue("UkupnaCena", p.UkupnaCena);
                cmd.Parameters.AddWithValue("Obrisan", p.Obrisan);

                cmd.ExecuteNonQuery();
                
                foreach (var prodaja in Projekat.Instance.Prodaje)
                {
                    if (prodaja.Id == p.Id)
                    {
                        prodaja.BrojRacuna = p.BrojRacuna;
                        prodaja.Kupac = p.Kupac;
                        prodaja.UkupnaCena = p.UkupnaCena;
                        prodaja.Obrisan = p.Obrisan;
                        break;
                    }
                }
            }
        }

        public static void Delete(Prodaja p)
        {
            p.Obrisan = true;
            Update(p);
        }
        #endregion
    }
}

