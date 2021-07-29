using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class Musteri
    {
        [Key]
        public int MusteriNo { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Unvan { get; set; }
        public string TCKN { get; set; }
        public string Durum { get; set; }
        public string GercekTuzel { get; set; }
    }
}
