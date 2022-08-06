using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace seyahatbiletcim1.Models
{

    public class Otobus
    {
        public int OtobusID { get; set; }//otomatik primarykey ve birer birer artacak şekilde incremant yapmaktadır.

        public string Nereden { get; set; }

        public string Nereye { get; set; }
        [Display(Name = "Tarih")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString ="{0:MM/dd/yyyy}")]
        public DateTime Tarih { get; set; }

        public int KoltukNo { get; set; }

        public int FiyatOto { get; set; }

        public string FirmaAdi { get; set; }

        public int YolcuSayisiOto { get; set; }

    }
}