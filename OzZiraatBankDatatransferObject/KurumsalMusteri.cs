using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzZiraatBankDatatransferObject
{
    public class KurumsalMusteri : Musteri      //Musteri sınıfından kalıtım aldık
    {
        //Musteri sınıfından alınan property'lere ek olarak:
        public string VergiNo { get; set; }
        public string VergiDairesi { get; set; }
        public string Yetkili { get; set; }

        //ToString metodunu Kurumsal Müşteri'yi kontrollere AD şeklinde atabilmek için ezdik
        public override string ToString()
        {
            return this.Ad.ToUpper();
        }

        //HavaleYap metodunu Kurumsal Müşteri'den masraf alınmayacağı için ezdik
        public override void HavaleYap(double miktar, Musteri alici)
        {
            if (miktar > this.Bakiye)//çekilecek tutar + masraf, bakiyeden büyük ise
            {
                System.Windows.Forms.MessageBox.Show("HATA\nÇekilebilecek max tutar:" + this.Bakiye);
            }
            else
            {
                this.Bakiye -= miktar;//tutar + masraf gönderici'den düşülsün
                alici.Bakiye += miktar;//tutar Alıcı'nın bakiyesine eklensin
                System.Windows.Forms.MessageBox.Show("İşlem Tamam\nYeni Bakiye:" + this.Bakiye);
            }
        }

    }
}
