using System;
using System.Collections.Generic;
using System.Text;

namespace POP_SF_63_2017.Model
{
    public enum TipKorisnika
    {
        Administrator,
        Prodavac
    }
    class Korisnik
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string KorisnickoIme { get; set; }
        public string Lozinka { get; set; }
        public TipKorisnika TipKorisnika { get; set; }
    }
}
