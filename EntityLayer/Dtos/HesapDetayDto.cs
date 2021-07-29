using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Dtos
{
    public class HesapDetayDto
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string DovizCinsi { get; set; }
        public int SubeNo { get; set; }
        public int Bakiye { get; set; }
        public int EkNo { get; set; }
        public DateTime HesapKapanisTarihi { get; set; }
    }
}
