using System;
using System.Collections.Generic;
using System.Text;

namespace POP_SF_63_2017.Model
{
    public class Namjestaj
    {
        public bool Obrisan { get; set; }
        public int Id { get; set; }
        public string Sifra { get; set; }
        public string Naziv { get; set; }
        public double Cijena { get; set; }
        public int Kolicina { get; set; }
        public Akcija Akcija { get; set; }
        public TipNamjestaja TipNamjestaja { get; set; }

    }
}
