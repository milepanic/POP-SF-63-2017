using POP_SF_63_2017.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF_63_2017.Model
{
    public class Projekat
    {
        public static Projekat Instance { get; private set; } = new Projekat();
        
        // TODO: obrisati
        /*
        private List<Salon> Salon;
        private List<Korisnik> Korisnik; */
        
        public  ObservableCollection<TipNamestaja> TipoviNamestaja { get; set; }

        public ObservableCollection<Namestaj> Namestaji { get; set; }

        // TODO: promijeniti
        /*
        public List<Salon> Saloni
        {
            get
            {
                Salon = GenericSerializer.Deserialize<Salon>("salon.xml");
                return Salon;
            }
            set
            {
                Salon = value;
                GenericSerializer.Serialize<Salon>("salon.xml", Salon);
            }
        }

        public List<Korisnik> Korisnici
        {
            get
            {
                Korisnik = GenericSerializer.Deserialize<Korisnik>("korisnik.xml");
                return Korisnik;
            }
            set
            {
                Korisnik = value;
                GenericSerializer.Serialize<Korisnik>("korisnik.xml", Korisnik);
            }
        } */

        private Projekat()
        {
            TipoviNamestaja = GenericSerializer.Deserialize<TipNamestaja>("tipovi_namestaja.xml");
            Namestaji = GenericSerializer.Deserialize<Namestaj>("namestaj.xml");
        }

    }
}
