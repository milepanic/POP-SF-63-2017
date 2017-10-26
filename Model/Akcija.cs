using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace POP_SF_63_2017.Model
{
    public class Akcija
    {
    public int Id { get; set; }

    public bool Obrisan { get; set; }

    public DateTime DatumPocetka { get; set; }
    public DateTime DatumZavrsetka { get; set; }
    public decimal Popust { get; set; }

}
}
