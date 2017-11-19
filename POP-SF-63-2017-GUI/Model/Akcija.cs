using System;

namespace POP_SF_63_2017.Model
{
    public class Akcija
	{
		public int Id { get; set; }
		public DateTime DatumPocetka { get; set; }
		public decimal Popust { get; set; }
		public DateTime DatumZavrsetka { get; set; }
		public bool Obrisan { get; set; }
	}
}

