namespace POP_SF_63_2017.Model
{
    public class TipNamestaja
	{
		public int Id { get; set; }
		public string Naziv { get; set; }
		public bool Obrisan { get; set; }

        public override string ToString()
        {
            return Naziv;
        }
        public static TipNamestaja GetById (int id)
        {
            foreach (TipNamestaja tipNamestaja in Projekat.Instance.TipoviNamestaja)
            {
                if(tipNamestaja.Id == id)
                {
                    return tipNamestaja;
                }
            }
            return null;
        }
	}
}

