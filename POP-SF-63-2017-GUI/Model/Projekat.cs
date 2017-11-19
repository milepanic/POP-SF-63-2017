using POP_SF_63_2017.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF_63_2017.Model
{
    public class Projekat
    {
        public static Projekat Instance { get; private set; } = new Projekat();

        private List<TipNamestaja> tipoviNamestaja;
        private List<Namestaj> Namestaj;
        private List<Salon> Salon;
        private List<Korisnik> Korisnik;
        
        public  List<TipNamestaja> TipoviNamestaja
        {
            get
            {
                tipoviNamestaja = GenericSerializer.Deserialize<TipNamestaja>("tipovi_namestaja.xml");
                return tipoviNamestaja;
            }
            set
            {
                tipoviNamestaja = value;
                GenericSerializer.Serialize<TipNamestaja>("tipovi_namestaja.xml", tipoviNamestaja);
            }
        }

        public List<Namestaj> Namestaji
        {
            get
            {
                Namestaj = GenericSerializer.Deserialize<Namestaj>("namestaj.xml");
                return Namestaj;
            }
            set
            {
                Namestaj = value;
                GenericSerializer.Serialize<Namestaj>("namestaj.xml", Namestaj);
            }
        }

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
        }

    }
}
