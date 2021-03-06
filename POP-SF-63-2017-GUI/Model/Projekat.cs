﻿using System.Collections.ObjectModel;

namespace POP_SF_63_2017.Model
{
    public class Projekat
    {
        public static Projekat Instance { get; private set; } = new Projekat();
        
        public ObservableCollection<TipNamestaja> TipoviNamestaja { get; set; }
        public ObservableCollection<Namestaj> Namestaji { get; set; }
        public ObservableCollection<Korisnik> Korisnici { get; set; }
        public ObservableCollection<Salon> Saloni { get; set; }
        public ObservableCollection<DodatnaUsluga> DodatneUsluge { get; set; }
        public ObservableCollection<Akcija> Akcije { get; set; }
        public ObservableCollection<Prodaja> Prodaje { get; set; }
        public ObservableCollection<Korpa> Korpe { get; set; }
        public ObservableCollection<IzabranaUsluga> Usluge { get; set; }

        private Projekat()
        {
            TipoviNamestaja = TipNamestaja.GetAll();
            Namestaji = Namestaj.GetAll();
            Akcije = Akcija.GetAll();
            Korisnici = Korisnik.GetAll();
            Saloni = Salon.GetAll();
            DodatneUsluge = DodatnaUsluga.GetAll();
            Prodaje = Prodaja.GetAll();

            Korpe = Korpa.GetAll();
            Usluge = IzabranaUsluga.GetAll();
        }

    }
}
