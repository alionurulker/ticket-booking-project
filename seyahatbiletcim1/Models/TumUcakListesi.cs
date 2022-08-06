using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace seyahatbiletcim1.Models
{
    [Table("TumUcakListesi")]
    public class TumUcakListesi
    {
        [Key]
        public int TumUcaklarID { get; set; }//otomatik primarykey ve birer birer artacak şekilde incremant yapmaktadır.

        public string Nereden { get; set; }

        public string Nereye { get; set; }
        [Display(Name = "Gidiş Tarih")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime GidisTarihi { get; set; }

        [Display(Name = "Dönüş Tarih")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DonusTarihi { get; set; }

        public string UcakFirmaAdi { get; set; }

        public string Sinif { get; set; }

        public int FiyatUcak { get; set; }

        public int YolcuKapasitesi { get; set; }
    }
}