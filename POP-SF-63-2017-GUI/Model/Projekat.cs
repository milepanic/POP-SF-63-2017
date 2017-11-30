using POP_SF_63_2017.Utils;
using System.Collections.ObjectModel;

namespace POP_SF_63_2017.Model
{
    public class Projekat
    {
        public static Projekat Instance { get; private set; } = new Projekat();
        
        public ObservableCollection<TipNamestaja> TipoviNamestaja { get; set; }
        public ObservableCollection<Namestaj> Namestaji { get; set; }
        public ObservableCollection<Korisnik> Korisnici { get; set; }
        public ObservableCollection<Salon> Saloni { get; set; }

        private Projekat()
        {
            TipoviNamestaja = GenericSerializer.Deserialize<TipNamestaja>("tipovi_namestaja.xml");
            Namestaji = GenericSerializer.Deserialize<Namestaj>("namestaj.xml");
            Korisnici = GenericSerializer.Deserialize<Korisnik>("korisnik.xml");
            Saloni = GenericSerializer.Deserialize<Salon>("salon.xml");
        }

    }
}
