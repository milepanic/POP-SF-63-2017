using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF_63_2017.Model
{
	public class Namestaj
	{
		public int Id { get; set; }
		public string Naziv { get; set; }
		public string Sifra { get; set; }
		public double Cena { get; set; }
		public int KolicinaUMagacinu { get; set; }
		public Akcija Akcija { get; set; }
		public int TipNamestajaId { get; set; }
		public bool Obrisan { get; set; }

        public override string ToString()
        {
            return $"{ Naziv }, { Cena }, { TipNamestaja.GetById(TipNamestajaId).Naziv } ";
        }

        public static Namestaj GetById(int id)
        {
            foreach (Namestaj namestaj in Projekat.Instance.Namestaji)
            {
                if (namestaj.Id == id)
                {
                    return namestaj;
                }
            }
            return null;
        }
    }
}

