using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokEkstresi
{
   public class StokEntity
    {
        public Nullable<long> SiraNo { get; set; }
        public string IslemTur { get; set; }
        public string EvrakNo { get; set; }
        public string Tarih { get; set; }
        public Nullable<int> GirisMiktar { get; set; }
        public Nullable<int> CikisMiktar { get; set; }

        public int stok { get; set; }
    }
}
