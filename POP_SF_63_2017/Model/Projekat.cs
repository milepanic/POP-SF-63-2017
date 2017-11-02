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

    }
}
