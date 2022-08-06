using seyahatbiletcim1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace seyahatbiletcim1.DAL
{
    public class BiletBaslangic:System.Data.Entity.DropCreateDatabaseIfModelChanges<BiletContext>//model değişirse bu sınıf devreye girer 
    {
        protected override void Seed(BiletContext context)
        {
            var Ucaklar1 = new List<Ucak>
            {
                new Ucak{Nereden="İstanbul",Nereye="Çek Cumhuriyeti",Gtarih=DateTime.Parse("13-01-2018"),Dtarih=DateTime.Parse("13-07-2019"),UFiyat=455,TekYon=true,UcakFirmaAdi="OnurAir"},
                new Ucak{Nereden="İstanbul",Nereye="Polonya",Gtarih=DateTime.Parse("13-01-2018"),Dtarih=DateTime.Parse("13-07-2018")},
                new Ucak{Nereden="İstanbul",Nereye="Almanya",Gtarih=DateTime.Parse("13-01-2018"),Dtarih=DateTime.Parse("13-07-2018")},
            new Ucak { Nereden = "İstanbul", Nereye = "Romanya", Gtarih = DateTime.Parse("13-01-2018"), Dtarih = DateTime.Parse("13-07-2018")}
            };
            Ucaklar1.ForEach(s => context.Ucaklar1.Add(s));
            context.SaveChanges();

                    
            var Otobuslar1 = new List<Otobus>
            {
                new Otobus{OtobusID=1,Nereden="İstanbul",Nereye="Ankara",Tarih=DateTime.Parse("13-11-2017"),KoltukNo=1,YolcuSayisiOto=2,FirmaAdi="VİB",FiyatOto=100},
                new Otobus{OtobusID=12,Nereden="Sakarya",Nereye="İstanbul",Tarih=DateTime.Parse("13-2-2017"),KoltukNo=5,YolcuSayisiOto=1,FirmaAdi="SEV",FiyatOto=50},
                new Otobus{OtobusID=13,Nereden="Sakarya",Nereye="Ankara",Tarih=DateTime.Parse("13-3-2017"),KoltukNo=2,YolcuSayisiOto=4,FirmaAdi="SEV",FiyatOto=50},
            };
            Otobuslar1.ForEach(s => context.Otobuslar1.Add(s));
            context.SaveChanges();

            var Oteller = new List<Otel>
            {
                new Otel{Nerede="İstanbul", UrlAdresi="https://tr.hotels.com", Konuk="1 yetişkin",TesisTipi="Otel",YildizSayisi=5,GecelikFiyatAraligi="100-120"}

            };

            Otobuslar1.ForEach(s => context.Otobuslar1.Add(s));
            context.SaveChanges();

            var TumOtobusListesi = new List<TumOtobusListesi>
            {
                new TumOtobusListesi{Nereden="İstanbul",Nereye="Ankara",Tarih=DateTime.Parse("13-11-2017"),OtobusFirmaAdi="SEV",YolcuKapasitesi=24,FiyatOto=100},
                new TumOtobusListesi{Nereden="İstanbul",Nereye="Mersin",Tarih=DateTime.Parse("13-11-2017"),OtobusFirmaAdi="SEV",YolcuKapasitesi=24,FiyatOto=100},
                new TumOtobusListesi{Nereden="İstanbul",Nereye="Bodrum",Tarih=DateTime.Parse("13-11-2017"),OtobusFirmaAdi="SEV",YolcuKapasitesi=24,FiyatOto=100},
                new TumOtobusListesi{Nereden="İstanbul",Nereye="Kütahya",Tarih=DateTime.Parse("13-11-2017"),OtobusFirmaAdi="SEV",YolcuKapasitesi=24,FiyatOto=50},
                new TumOtobusListesi{Nereden="İstanbul",Nereye="Eskişehir",Tarih=DateTime.Parse("13-11-2017"),OtobusFirmaAdi="SEV",YolcuKapasitesi=24,FiyatOto=50},
                new TumOtobusListesi{Nereden="Sakarya",Nereye="İstanbul",Tarih=DateTime.Parse("13-2-2017"),OtobusFirmaAdi="Metro",YolcuKapasitesi=22,FiyatOto=50},
                new TumOtobusListesi{Nereden="Sakarya",Nereye="Mersin",Tarih=DateTime.Parse("13-2-2017"),OtobusFirmaAdi="Metro",YolcuKapasitesi=22,FiyatOto=100},
                new TumOtobusListesi{Nereden="Sakarya",Nereye="Ankara",Tarih=DateTime.Parse("13-2-2017"),OtobusFirmaAdi="Metro",YolcuKapasitesi=22,FiyatOto=50},
                new TumOtobusListesi{Nereden="Sakarya",Nereye="Yozgat",Tarih=DateTime.Parse("13-2-2017"),OtobusFirmaAdi="Metro",YolcuKapasitesi=22,FiyatOto=50},
                new TumOtobusListesi{Nereden="Sakarya",Nereye="Trabzon",Tarih=DateTime.Parse("13-2-2017"),OtobusFirmaAdi="Metro",YolcuKapasitesi=22,FiyatOto=50},
                new TumOtobusListesi{Nereden="Sakarya",Nereye="Zonguldak",Tarih=DateTime.Parse("13-2-2017"),OtobusFirmaAdi="Metro",YolcuKapasitesi=22,FiyatOto=50},
                new TumOtobusListesi{Nereden="Sakarya",Nereye="Ankara",Tarih=DateTime.Parse("13-3-2017"),OtobusFirmaAdi="VİB",YolcuKapasitesi=22,FiyatOto=50},
                new TumOtobusListesi{Nereden="Sakarya",Nereye="İzmir",Tarih=DateTime.Parse("13-3-2017"),OtobusFirmaAdi="VİB",YolcuKapasitesi=22,FiyatOto=50},
                new TumOtobusListesi{Nereden="Sakarya",Nereye="Düzce",Tarih=DateTime.Parse("13-3-2017"),OtobusFirmaAdi="VİB",YolcuKapasitesi=22,FiyatOto=50},
                new TumOtobusListesi{Nereden="Sakarya",Nereye="Bursa",Tarih=DateTime.Parse("13-3-2017"),OtobusFirmaAdi="VİB",YolcuKapasitesi=22,FiyatOto=50},
                new TumOtobusListesi{Nereden="Sakarya",Nereye="Aydın",Tarih=DateTime.Parse("13-3-2017"),OtobusFirmaAdi="VİB",YolcuKapasitesi=22,FiyatOto=50},
            };
            TumOtobusListesi.ForEach(s => context.TumOtobusListesi.Add(s));
            context.SaveChanges();

            var TumUcakListesi = new List<TumUcakListesi>
            {
                new TumUcakListesi{Nereden="İstanbul",Nereye="Czech Public",GidisTarihi=DateTime.Parse("13-11-2017"),DonusTarihi=DateTime.Parse("13-11-2017"),UcakFirmaAdi="Onur Air",YolcuKapasitesi=120,FiyatUcak=400},
                new TumUcakListesi{Nereden="İstanbul",Nereye="Polland",GidisTarihi=DateTime.Parse("13-11-2017"),DonusTarihi=DateTime.Parse("13-11-2017"),UcakFirmaAdi="Turkish Airline",YolcuKapasitesi=120,FiyatUcak=500},
                new TumUcakListesi{Nereden="İstanbul",Nereye="Bodrum",GidisTarihi=DateTime.Parse("13-11-2017"),DonusTarihi=DateTime.Parse("13-11-2017"),UcakFirmaAdi="Turkish Airline",YolcuKapasitesi=120,FiyatUcak=400},
            };
            TumUcakListesi.ForEach(s => context.TumUcakListesi.Add(s));
            context.SaveChanges();

        }
    }
}