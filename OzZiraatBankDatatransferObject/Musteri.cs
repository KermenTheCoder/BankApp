using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzZiraatBankDatatransferObject
{
    public class Musteri
    {
        //properties
        public string MusteriNo { get; set; }
        public string Ad { get; set; }
        public string Adres { get; set; }
        public string Telefon { get; set; }
        public string Mail { get; set; }
        public double Bakiye { get; set; }

        //functions
        public void ParaCek(double miktar)
        {
            if (miktar > this.Bakiye)//çekilecek tutar bakiyeden büyükse
            {
                System.Windows.Forms.MessageBox.Show("HATA\nÇekilebilecek max tutar:" + this.Bakiye);
            }
            else
            {
                this.Bakiye -= miktar;//çekilen tutarı bakiyeden düştük
                System.Windows.Forms.MessageBox.Show("İşlem Tamam\nYeni Bakiye:" + this.Bakiye);
            }
        }

        public void ParaYatir(double miktar)
        {
            this.Bakiye += miktar;//yatırılan tutarı bakiyeye ekledik
            System.Windows.Forms.MessageBox.Show("İşlem Tamam\nYeni Bakiye:" + this.Bakiye);
        }
        public virtual void HavaleYap(double miktar, Musteri alici)//müşteri kurumsal ise masraf olmayacak, ezebilmek için virtual yaptık
        {
            double masraf = 20;
            if (miktar + masraf > this.Bakiye)//çekilecek tutar + masraf, bakiyeden büyük ise
            {
                System.Windows.Forms.MessageBox.Show("HATA\nÇekilebilecek max tutar:" + (this.Bakiye - masraf).ToString());
            }
            else
            {
                this.Bakiye -= (masraf + miktar);//tutar + masraf gönderici'den düşülsün
                alici.Bakiye += miktar;//tutar Alıcı'nın bakiyesine eklensin
                System.Windows.Forms.MessageBox.Show("İşlem Tamam\nYeni Bakiye:" + this.Bakiye);
            }

        }

    }
}
