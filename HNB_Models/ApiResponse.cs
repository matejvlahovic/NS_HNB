using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HNB_Models
{
    public class HnbApiResponse
    {
        public int broj_tecajnice { get; set; }
        public DateTime datum_primjene { get; set; }
        public string drzava { get; set; }
        public string drzava_iso { get; set; }
        public string sifra_valute { get; set; }
        public string valuta { get; set; }
        public int jedinica { get; set; }
        public decimal kupovni_tecaj { get; set; }
        public decimal srednji_tecaj { get; set; }
        public decimal prodajni_tecaj { get; set; }
    }
}
