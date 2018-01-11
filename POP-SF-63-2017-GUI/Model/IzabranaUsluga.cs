using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace POP_SF_63_2017.Model
{
    public class IzabranaUsluga : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private int id;
        private int racunId;
        private int uslugaId;
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

        public int UslugaId
        {
            get { return uslugaId; }
            set
            {
                uslugaId = value;
                OnPropertyChanged("UslugaId");
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
        public static ObservableCollection<IzabranaUsluga> GetAll()
        {
            var usluga = new ObservableCollection<IzabranaUsluga>();

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM IzabranaUsluga WHERE Obrisan=0";

                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();

                da.SelectCommand = cmd;
                da.Fill(ds, "IzabranaUsluga");

                foreach (DataRow row in ds.Tables["IzabranaUsluga"].Rows)
                {
                    var n = new IzabranaUsluga();
                    n.Id = int.Parse(row["Id"].ToString());
                    n.RacunId = int.Parse(row["RacunId"].ToString());
                    n.UslugaId = int.Parse(row["UslugaId"].ToString());
                    n.Obrisan = bool.Parse(row["Obrisan"].ToString());

                    usluga.Add(n);
                }
            }

            return usluga;
        }

        public static IzabranaUsluga Create(IzabranaUsluga n)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "INSERT INTO IzabranaUsluga (RacunId, UslugaId) VALUES (@RacunId, @UslugaId);";
                cmd.CommandText += "SELECT SCOPE_IDENTITY();";

                cmd.Parameters.AddWithValue("RacunId", n.RacunId);
                cmd.Parameters.AddWithValue("UslugaId", n.UslugaId);

                int newId = int.Parse(cmd.ExecuteScalar().ToString());
                n.Id = newId;
            }
            Projekat.Instance.Usluge.Add(n);

            return n;
        }

        public static void Update(IzabranaUsluga n)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "UPDATE IzabranaUsluga SET RacunId=@RacunId,UslugaId=@UslugaId,Obrisan=@Obrisan WHERE Id=@Id";

                cmd.Parameters.AddWithValue("Id", n.Id);
                cmd.Parameters.AddWithValue("RacunId", n.RacunId);
                cmd.Parameters.AddWithValue("UslugaId", n.UslugaId);
                cmd.Parameters.AddWithValue("Obrisan", n.Obrisan);

                cmd.ExecuteNonQuery();

                foreach (var usluga in Projekat.Instance.Usluge)
                {
                    if (usluga.Id == n.Id)
                    {
                        usluga.RacunId = n.RacunId;
                        usluga.UslugaId = n.UslugaId;
                        usluga.Obrisan = n.Obrisan;
                        break;
                    }
                }
            }
        }

        public static void Delete(IzabranaUsluga n)
        {
            n.Obrisan = true;
            Update(n);
        }
        #endregion
    }
}
