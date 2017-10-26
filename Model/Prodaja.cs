using System;
using System.Collections.Generic;
using System.Text;

namespace POP_SF_63_2017.Model
{
    public class Prodaja
    {
        public int Id { get; set; }
        public List<Namjestaj> NamjestajZaProdaju { get; set; }
        public string BrojRacuna { get; set; }
        public string Kupac { get; set; }
        public List<DodatneUsluge> DodatneUsluge {get; set; }

        public const double PDV = 0.02;
        public double UkupnaCijena { get; set; }
    }
}
