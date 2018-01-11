using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace POP_SF_63_2017.Model
{
    public class Korpa : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private int id;
        private int racunId;
        private int namestajId;
        private int kolicina;
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

        public int RacunId
        {
            get { return racunId; }
            set
            {
                racunId = value;
                OnPropertyChanged("RacunId");
            }
        }

        public int NamestajId
        {
            get { return namestajId; }
            set
            {
                namestajId = value;
                OnPropertyChanged("NamestajId");
            }
        }

        public int Kolicina
        {
            get { return kolicina; }
            set
            {
                kolicina = value;
                OnPropertyChanged("Kolicina");
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

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #region Database
        public static ObservableCollection<Korpa> GetAll()
        {
            var korpa = new ObservableCollection<Korpa>();

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM Korpa WHERE Obrisan=0";

                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();

                da.SelectCommand = cmd;
                da.Fill(ds, "Korpa");

                foreach (DataRow row in ds.Tables["Korpa"].Rows)
                {
                    var n = new Korpa();
                    n.Id = int.Parse(row["Id"].ToString());
                    n.RacunId = int.Parse(row["RacunId"].ToString());
                    n.NamestajId = int.Parse(row["NamestajId"].ToString());
                    n.Kolicina = int.Parse(row["Kolicina"].ToString());
                    n.Obrisan = bool.Parse(row["Obrisan"].ToString());

                    korpa.Add(n);
                }
            }

            return korpa;
        }

        public static Korpa Create(Korpa n)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "INSERT INTO Korpa (RacunId, NamestajId, Kolicina) VALUES (@RacunId, @NamestajId, @Kolicina);";
                cmd.CommandText += "SELECT SCOPE_IDENTITY();";

                cmd.Parameters.AddWithValue("RacunId", n.RacunId);
                cmd.Parameters.AddWithValue("NamestajId", n.NamestajId);
                cmd.Parameters.AddWithValue("Kolicina", n.Kolicina);

                int newId = int.Parse(cmd.ExecuteScalar().ToString());
                n.Id = newId;
            }
            Projekat.Instance.Korpe.Add(n);

            return n;
        }

        public static void Update(Korpa n)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "UPDATE Korpa SET RacunId=@RacunId,NamestajId=@NamestajId,Kolicina=@Kolicina,Obrisan=@Obrisan WHERE Id=@Id";

                cmd.Parameters.AddWithValue("Id", n.Id);
                cmd.Parameters.AddWithValue("RacunId", n.RacunId);
                cmd.Parameters.AddWithValue("NamestajId", n.NamestajId);
                cmd.Parameters.AddWithValue("Kolicina", n.Kolicina);
                cmd.Parameters.AddWithValue("Obrisan", n.Obrisan);

                cmd.ExecuteNonQuery();

                foreach (var korpa in Projekat.Instance.Korpe)
                {
                    if (korpa.Id == n.Id)
                    {
                        korpa.RacunId = n.RacunId;
                        korpa.NamestajId = n.NamestajId;
                        korpa.Kolicina = n.Kolicina;
                        korpa.Obrisan = n.Obrisan;
                        break;
                    }
                }
            }
        }

        public static void Delete(Korpa n)
        {
            n.Obrisan = true;
            Update(n);
        }
        #endregion
    }
}