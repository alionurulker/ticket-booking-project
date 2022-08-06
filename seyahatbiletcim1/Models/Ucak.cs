using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace seyahatbiletcim1.Models
{
    public class Ucak
    {
        public int UcakID { get; set; }//otomatik primarykey ve birer birer artacak şekilde incremant yapmaktadır.

        public string Nereden { get; set; }

        public string Nereye { get; set; }

        [Display(Name = "Gidiş Tarihi")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime Gtarih { get; set; }

        [Display(Name = "Dönüş Tarihi")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime Dtarih { get; set; }

        public string UcakFirmaAdi { get; set; }

        public int UFiyat { get; set; }

        public bool TekYon { get; set; }

        public int YolcuSayisi { get; set; }

        public string Sinif { get; set; }
    }
}