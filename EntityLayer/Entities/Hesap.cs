using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace EntityLayer.Entities
{
    public class Hesap
    {
      
        public int Id { get; set; }
        public int SubeKodu { get; set; }
        public int MusteriNo { get; set; }
        public int EkNo { get; set; }
        public string DovizCinsi { get; set; }
        public int BakiyeTutar { get; set; }
        public string Durum { get; set; }
        public DateTime HesapKapanisTarihi { get; set; }
    }
    
}
