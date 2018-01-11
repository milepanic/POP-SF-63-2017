using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace POP_SF_63_2017.Model
{
    public class Salon : INotifyPropertyChanged, ICloneable
    {
        private int id;
        private string naziv;
        private string adresa;
        private string telefon;
        private string email;
        private string websajt;
        private int pib;
        private int maticniBroj;
        private string brojZiroRacuna;
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
        public string Naziv
        {
            get { return naziv; }
            set
            {
                naziv = value;
                OnPropertyChanged("Naziv");
            }
        }
        public string Adresa
        {
            get { return adresa; }
            set
            {
                adresa = value;
                OnPropertyChanged("Adresa");
            }
        }
        public string Telefon
        {
            get { return telefon; }
            set
            {
                telefon = value;
                OnPropertyChanged("Telefon");
            }
        }
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                OnPropertyChanged("Email");
            }
        }
        public string Websajt
        {
            get { return websajt; }
            set
            {
                websajt = value;
                OnPropertyChanged("Websajt");
            }
        }
        public int PIB
        {
            get { return pib; }
            set
            {
                pib = value;
                OnPropertyChanged("PIB");
            }
        }
        public int MaticniBroj
        {
            get { return maticniBroj; }
            set
            {
                maticniBroj = value;
                OnPropertyChanged("MaticniBroj");
            }
        }
        public string BrojZiroRacuna
        {
            get { return brojZiroRacuna; }
            set
            {
                brojZiroRacuna = value;
                OnPropertyChanged("BrojZiroRacuna");
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
            return new Salon()
            {
                id = Id,
                naziv = Naziv,
                adresa = Adresa,
                telefon = Telefon,
                email = Email,
                websajt = Websajt,
                pib = PIB,
                maticniBroj = MaticniBroj,
                brojZiroRacuna = BrojZiroRacuna,
                obrisan = Obrisan
            };
        }

        public override string ToString()
        {
            return $"Salon namestaja {Naziv}\nAdresa: {Adresa}\nTelefon: {Telefon}\nEmail: {Email}\nWebsajt: {Websajt}\nPIB: {PIB}\nMaticni broj: {MaticniBroj}\nBroj ziro racuna: {BrojZiroRacuna}";
        }

        #region Database
        public static ObservableCollection<Salon> GetAll()
        {
            var saloni = new ObservableCollection<Salon>();

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM Salon WHERE Obrisan=0";

                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();

                da.SelectCommand = cmd;
                da.Fill(ds, "Salon");

                foreach (DataRow row in ds.Tables["Salon"].Rows)
                {
                    var s = new Salon();
                    s.Id = int.Parse(row["Id"].ToString());
                    s.Naziv = row["Naziv"].ToString();
                    s.Adresa = row["Adresa"].ToString();
                    s.Telefon = row["Telefon"].ToString();
                    s.Email = row["Email"].ToString();
                    s.Websajt = row["Websajt"].ToString();
                    s.PIB = int.Parse(row["PIB"].ToString());
                    s.MaticniBroj = int.Parse(row["MaticniBroj"].ToString());
                    s.BrojZiroRacuna = row["BrojZiroRacuna"].ToString();
                    s.Obrisan = bool.Parse(row["Obrisan"].ToString());

                    saloni.Add(s);
                }
            }
            return saloni;
        }

        public static Salon Create(Salon s)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "INSERT INTO Salon (Naziv, Adresa, Telefon, Email, Websajt, PIB, MaticniBroj, BrojZiroRacuna) VALUES (@Naziv, @Adresa, @Telefon, @Email, @Websajt, @PIB, @MaticniBroj, @BrojZiroRacuna);";
                cmd.CommandText += "SELECT SCOPE_IDENTITY();";

                cmd.Parameters.AddWithValue("Naziv", s.Naziv);
                cmd.Parameters.AddWithValue("Adresa", s.Adresa);
                cmd.Parameters.AddWithValue("Telefon", s.Telefon);
                cmd.Parameters.AddWithValue("Email", s.Email);
                cmd.Parameters.AddWithValue("Websajt", s.Websajt);
                cmd.Parameters.AddWithValue("PIB", s.PIB);
                cmd.Parameters.AddWithValue("MaticniBroj", s.MaticniBroj);
                cmd.Parameters.AddWithValue("BrojZiroRacuna", s.BrojZiroRacuna);

                int newId = int.Parse(cmd.ExecuteScalar().ToString()); // ExecuteScalar izvrsava query
                s.Id = newId;
            }
            Projekat.Instance.Saloni.Add(s); // azurira model

            return s;
        }

        public static void Update(Salon s)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "UPDATE Salon SET Naziv=@Naziv,Adresa=@Adresa,Telefon=@Telefon,Email=@Email,Websajt=@Websajt,PIB=@PIB,MaticniBroj=@MaticniBroj,BrojZiroRacuna=@BrojZiroRacuna,Obrisan=@Obrisan WHERE Id=@Id";

                cmd.Parameters.AddWithValue("Id", s.Id);
                cmd.Parameters.AddWithValue("Naziv", s.Naziv);
                cmd.Parameters.AddWithValue("Adresa", s.Adresa);
                cmd.Parameters.AddWithValue("Telefon", s.Telefon);
                cmd.Parameters.AddWithValue("Email", s.Email);
                cmd.Parameters.AddWithValue("Websajt", s.Websajt);
                cmd.Parameters.AddWithValue("PIB", s.PIB);
                cmd.Parameters.AddWithValue("MaticniBroj", s.MaticniBroj);
                cmd.Parameters.AddWithValue("BrojZiroRacuna", s.BrojZiroRacuna);
                cmd.Parameters.AddWithValue("Obrisan", s.Obrisan);

                cmd.ExecuteNonQuery();

                foreach (var salon in Projekat.Instance.Saloni)
                {
                    if (salon.Id == s.Id)
                    {
                        salon.Naziv = s.Naziv;
                        salon.Adresa = s.Adresa;
                        salon.Telefon = s.Telefon;
                        salon.Email = s.Email;
                        salon.Websajt = s.Websajt;
                        salon.PIB = s.PIB;
                        salon.MaticniBroj = s.MaticniBroj;
                        salon.BrojZiroRacuna = s.BrojZiroRacuna;
                        salon.Obrisan = s.Obrisan;
                        break;
                    }
                }
            }
        }

        public static void Delete(Salon s)
        {
            s.Obrisan = true;
            Update(s);
        }
        #endregion
    }
}

