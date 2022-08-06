using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace seyahatbiletcim1.Models
{
    public class Otel
    {
        public int OtelID { get; set; }//otomatik primarykey ve birer birer artacak şekilde incremant yapmaktadır.

        public string Nerede { get; set; }

        public string UrlAdresi { get; set; }

        public string Konuk { get; set; }

        public int YildizSayisi { get; set; }

        public string TesisTipi { get; set; }

        public string GecelikFiyatAraligi { get; set; }
    }
}