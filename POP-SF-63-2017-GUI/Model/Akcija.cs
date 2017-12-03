using System;
using System.ComponentModel;

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
    }
}

