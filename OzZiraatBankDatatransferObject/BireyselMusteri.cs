using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzZiraatBankDatatransferObject
{
    public class BireyselMusteri : Musteri//Musteri sınıfından kalıtım aldık
    {
        //Musteri sınıfından alınan property'lere ek olarak:
        public string Soyad { get; set; }
        public string AnneSoyad { get; set; }
        public DateTime DogumTarihi { get; set; }
        public string KimlikNo { get; set; }

        //ToString metodunu Bireysel Müşteri'yi kontrollere AD SOYAD şeklinde atabilmek için ezdik
        public override string ToString()
        {
            return this.Ad.ToUpper() + " " + this.Soyad.ToUpper();
        }
       
    }
}
