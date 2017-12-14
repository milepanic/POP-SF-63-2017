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
        public ObservableCollection<DodatnaUsluga> DodatneUsluge { get; set; }
        public ObservableCollection<Akcija> Akcije { get; set; }
        public ObservableCollection<Prodaja> Prodaje { get; set; }

        private Projekat()
        {
            TipoviNamestaja = TipNamestaja.GetAll();
            Namestaji = GenericSerializer.Deserialize<Namestaj>("namestaj.xml");
            Korisnici = GenericSerializer.Deserialize<Korisnik>("korisnik.xml");
            Saloni = GenericSerializer.Deserialize<Salon>("salon.xml");
            DodatneUsluge = GenericSerializer.Deserialize<DodatnaUsluga>("dodatna_usluga.xml");
            Akcije = GenericSerializer.Deserialize<Akcija>("akcije.xml");
            Prodaje = GenericSerializer.Deserialize<Prodaja>("prodaja.xml");
        }

    }
}
