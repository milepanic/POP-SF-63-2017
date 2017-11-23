using System.ComponentModel;
using System.Xml.Serialization;

namespace POP_SF_63_2017.Model
{
    public class Namestaj : INotifyPropertyChanged
	{
        // propfull
        private int id;
        private string naziv;
        private string sifra;
        private double cena;
        private int kolicinaUMagacinu;
        private int tipNamestajaId;
        private bool obrisan;
        private TipNamestaja tipNamestaja;

        [XmlIgnore]
        public TipNamestaja TipNamestaja
        {
            get
            {
                if (TipNamestaja == null)
                    return TipNamestaja.GetById(tipNamestajaId);

                return tipNamestaja;
            }
            set
            {
                tipNamestaja = value;
                TipNamestajaId = tipNamestaja.Id;
                OnPropertyChanged("TipNamestaja");
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
        
        // TODO: Akcija
		public Akcija Akcija { get; set; }
        

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
    }
}

