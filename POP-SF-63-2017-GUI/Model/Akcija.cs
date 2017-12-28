using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace POP_SF_63_2017.Model
{
    public class Akcija : INotifyPropertyChanged, ICloneable
    {
        private int id;
        private DateTime datumPocetka;
        private decimal popust;
        private DateTime datumZavrsetka;
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
        public DateTime DatumPocetka
        {
            get { return datumPocetka; }
            set
            {
                datumPocetka = value;
                OnPropertyChanged("DatumPocetka");
            }
        }
        public decimal Popust
        {
            get { return popust; }
            set
            {
                popust = value;
                OnPropertyChanged("Popust");
            }
        }
        public DateTime DatumZavrsetka
        {
            get { return datumZavrsetka; }
            set
            {
                datumZavrsetka = value;
                OnPropertyChanged("DatumZavrsetka");
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

        public override string ToString()
        {
            return $"Popust: {Popust.ToString()}%, do {DatumZavrsetka.ToString()}";
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
            return new Akcija()
            {
                id = Id,
                datumPocetka = DatumPocetka,
                popust = Popust,
                datumZavrsetka = DatumZavrsetka,
                obrisan = Obrisan
            };
        }
        public static Akcija GetById(int id)
        {
            foreach (Akcija akcija in Projekat.Instance.Akcije)
            {
                if (akcija.Id == id)
                {
                    return akcija;
                }
            }
            return null;
        }
        #region Database
        public static ObservableCollection<Akcija> GetAll()
        {
            var akcije = new ObservableCollection<Akcija>();

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM Akcija WHERE Obrisan=0";

                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();

                da.SelectCommand = cmd;
                da.Fill(ds, "Akcija");

                foreach (DataRow row in ds.Tables["Akcija"].Rows)
                {
                    var a = new Akcija();
                    a.Id = int.Parse(row["Id"].ToString());
                    a.DatumPocetka = DateTime.Parse(row["DatumPocetka"].ToString());
                    a.Popust = decimal.Parse(row["Popust"].ToString());
                    a.DatumZavrsetka = DateTime.Parse(row["DatumZavrsetka"].ToString());
                    a.Obrisan = bool.Parse(row["Obrisan"].ToString());

                    akcije.Add(a);
                }
            }

            return akcije;
        }

        public static Akcija Create(Akcija a)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "INSERT INTO Akcija (DatumPocetka, Popust, DatumZavrsetka) VALUES (@DatumPocetka, @Popust, @DatumZavrsetka);";
                cmd.CommandText += "SELECT SCOPE_IDENTITY();";

                cmd.Parameters.AddWithValue("DatumPocetka", a.DatumPocetka);
                cmd.Parameters.AddWithValue("Popust", a.Popust);
                cmd.Parameters.AddWithValue("DatumZavrsetka", a.DatumZavrsetka);

                int newId = int.Parse(cmd.ExecuteScalar().ToString()); // ExecuteScalar izvrsava query
                a.Id = newId;
            }
            Projekat.Instance.Akcije.Add(a);

            return a;
        }

        public static void Update(Akcija a)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "UPDATE Akcija SET DatumPocetka=@DatumPocetka,Popust=@Popust,DatumZavrsetka=@DatumZavrsetka,Obrisan=@Obrisan WHERE Id=@Id";

                cmd.Parameters.AddWithValue("Id", a.Id);
                cmd.Parameters.AddWithValue("DatumPocetka", a.DatumPocetka);
                cmd.Parameters.AddWithValue("Popust", a.Popust);
                cmd.Parameters.AddWithValue("DatumZavrsetka", a.DatumZavrsetka);
                cmd.Parameters.AddWithValue("Obrisan", a.Obrisan);

                cmd.ExecuteNonQuery();

                // azurira se stanje modela
                foreach (var akcija in Projekat.Instance.Akcije)
                {
                    if (akcija.Id == a.Id)
                    {
                        akcija.DatumPocetka = a.DatumPocetka;
                        akcija.Popust = a.Popust;
                        akcija.DatumZavrsetka = a.DatumZavrsetka;
                        akcija.Obrisan = a.Obrisan;
                        break;
                    }
                }
            }
        }

        public static void Delete(Akcija a)
        {
            a.Obrisan = true;
            Update(a);
        }
        #endregion
    }
}

