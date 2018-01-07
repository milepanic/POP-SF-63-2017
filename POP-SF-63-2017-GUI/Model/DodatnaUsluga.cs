using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace POP_SF_63_2017.Model
{
    public class DodatnaUsluga : INotifyPropertyChanged, ICloneable
	{
        private int id;
        private string naziv;
        private double cena;
        private bool obrisan;

        public event PropertyChangedEventHandler PropertyChanged;

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
        public double Cena
        {
            get { return cena; }
            set
            {
                cena = value;
                OnPropertyChanged("Cena");
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

        public static DodatnaUsluga GetById(int id)
        {
            foreach (DodatnaUsluga dodatnaUsluga in Projekat.Instance.DodatneUsluge)
            {
                if (dodatnaUsluga.Id == id)
                {
                    return dodatnaUsluga;
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
            return new DodatnaUsluga()
            {
                id = Id,
                naziv = Naziv,
                cena = Cena,
                obrisan = Obrisan
            };
        }
        #region Database
        public static ObservableCollection<DodatnaUsluga> GetAll()
        {
            var dodatneUsluge = new ObservableCollection<DodatnaUsluga>();

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM DodatnaUsluga WHERE Obrisan=0";

                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();

                da.SelectCommand = cmd;
                da.Fill(ds, "DodatnaUsluga");

                foreach (DataRow row in ds.Tables["DodatnaUsluga"].Rows)
                {
                    var du = new DodatnaUsluga();
                    du.Id = int.Parse(row["Id"].ToString());
                    du.Naziv = row["Naziv"].ToString();
                    du.Cena = double.Parse(row["Cena"].ToString());
                    du.Obrisan = bool.Parse(row["Obrisan"].ToString());

                    dodatneUsluge.Add(du);
                }
            }
            return dodatneUsluge;
        }

        public static DodatnaUsluga Create(DodatnaUsluga du)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "INSERT INTO DodatnaUsluga (Naziv, Cena) VALUES (@Naziv, @Cena);";
                cmd.CommandText += "SELECT SCOPE_IDENTITY();";

                cmd.Parameters.AddWithValue("Naziv", du.Naziv);
                cmd.Parameters.AddWithValue("Cena", du.Cena);

                int newId = int.Parse(cmd.ExecuteScalar().ToString());
                du.Id = newId;
            }
            Projekat.Instance.DodatneUsluge.Add(du);

            return du;
        }

        public static void Update(DodatnaUsluga du)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "UPDATE DodatnaUsluga SET Naziv=@Naziv,Cena=@Cena,Obrisan=@Obrisan WHERE Id=@Id";

                cmd.Parameters.AddWithValue("Id", du.Id);
                cmd.Parameters.AddWithValue("Naziv", du.Naziv);
                cmd.Parameters.AddWithValue("Cena", du.Cena);
                cmd.Parameters.AddWithValue("Obrisan", du.Obrisan);

                cmd.ExecuteNonQuery();
                
                foreach (var dodatnaUsluga in Projekat.Instance.DodatneUsluge)
                {
                    if (dodatnaUsluga.Id == du.Id)
                    {
                        dodatnaUsluga.Naziv = du.Naziv;
                        dodatnaUsluga.Cena = du.Cena;
                        dodatnaUsluga.Obrisan = du.Obrisan;
                        break;
                    }
                }
            }
        }

        public static void Delete(DodatnaUsluga du)
        {
            du.Obrisan = true;
            Update(du);
        }
        #endregion
    }
}

