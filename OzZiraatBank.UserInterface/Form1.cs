using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OzZiraatBankDatatransferObject;

// PROJE İÇERİĞİNE ERİŞEBİLMEK İÇİN ÖNCE REFERANSLARA EKLEDİK, SONRA PROJEYE DAHİL ETTİK (PROJEYE SAĞ TIK ADD REFERENCE)
//BU PROJE'DE BULUNAN FORM1.CS VE PROGRAM.CS DOSYALARINI SİLEREK PROJEYİ CLASS LIBRARY OLARAK AYARLADIK (PROJEYE SAĞ TIK PROPERTIES) 

namespace OzZiraatBank.UserInterface
{
    //KULLANICININ GÖRECEĞİ PROJE!

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pnlKurumsal.Location = pnlBireysel.Location;//2 paneli üst üste konumlandırdık, rbtn'dan yapılan seçime göre gösteriyoruz 
            MusteriYukle();//başlagıçta bir kurumsal bir de bireysel müşteri oluşturup yükledik
        }

        private void MusteriYukle()//müşteri ekleyen fonksiyon
        {
            BireyselMusteri bm = new BireyselMusteri()//object initalize / tanımlama sırasında değerleri verdik
            {
                Ad = "Ali",
                Soyad = "Veli",
                Adres = "Karşıyaka",
                AnneSoyad = "Yılmaz",
                KimlikNo = "12312312312",
                Mail = "ali@veli.com",
                MusteriNo = "125",
                Telefon = "532 532 32 32",
                Bakiye = 20000,
                DogumTarihi = DateTime.Parse("1.1.1990")
            };
            lbxMusteri.Items.Add(bm);//listbox'a ekledik
            cmbAlici.Items.Add(bm);//combobox'a ekledik

            KurumsalMusteri km = new KurumsalMusteri()
            {
                Ad = "Emre Tekstil",
                Adres = "Karşıyaka",
                Mail = "info@emretekstil.com",
                MusteriNo = "326",
                Telefon = "555 55 55",
                Bakiye = 600000,
                VergiDairesi = "Bornova",
                VergiNo = "3445645",
                Yetkili = "Emre Koç"
            };
            lbxMusteri.Items.Add(km);
            cmbAlici.Items.Add(km);
        }

        private void rbtnBireysel_CheckedChanged(object sender, EventArgs e)
        {
            //rbtn'dan yapılan seçime göre panelleri gösterdik/gizledik
            pnlBireysel.Visible = rbtnBireysel.Checked;
            pnlKurumsal.Visible = rbtnKurumsal.Checked;
        }

        private void btnHavaleYap_Click(object sender, EventArgs e)
        {
            pnlHavale.Visible = !pnlHavale.Visible;//butona tıkladıkça paneli göster/gizle
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();// kontrolleri temizlemek için kullanılacak fonksiyon
        }

        private void Temizle()
        {
            foreach (Control item in this.Controls)//formdaki textbox'ları temizle
            {
                if (item is TextBox)
                {
                    item.Text = string.Empty;
                }
            }

            foreach (Control item in pnlBireysel.Controls)//pnlBireysel'deki textbox'ları temizle
            {
                if (item is TextBox)
                {
                    item.Text = string.Empty;
                }
            }
            foreach (Control item in pnlKurumsal.Controls)//pnlKurumsal'daki textbox'ları temizle
            {
                if (item is TextBox)
                {
                    item.Text = string.Empty;
                }
            }
            //reset'lenecek diğer kontroller
            rbtnBireysel.Checked = true;//rbtnBireysel seçili/pnlBireysel ekranda
            dtDogum.Value = DateTime.Now;//datetimepicker'ı bugüne getir
            lbxMusteri.SelectedItem = null;//listbox'da eleman seçili olmasın
            cmbAlici.SelectedItem = null;//combo'da eleman seçili olmasın
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            MusteriKaydet();//müşteri kaydı yapan fonksiyon
            Temizle();
        }

        private void MusteriKaydet()
        {
            Musteri yeni;//Musteri tipinde bir referans tanımladık
            if (rbtnBireysel.Checked)//rbtnBireysel seçili ise
            {
                yeni = new BireyselMusteri()//tanımlanan referans için BireyselMusteri tipinde yer ayırdık
                { //object initalize / tanımlama sırasında ortak olmayan alanlara atama yaptık
                    AnneSoyad = txtAnneSoyad.Text,
                    DogumTarihi = dtDogum.Value,
                    KimlikNo = txtKimlikNo.Text,
                    Soyad = txtSoyad.Text
                };
            }
            else
            {
                yeni = new KurumsalMusteri()//tanımlanan referans için KurumsalMusteri tipinde yer ayırdık
                {//object initalize / tanımlama sırasında ortak olmayan alanlara atama yaptık
                    VergiDairesi = txtVergiDairesi.Text,
                    VergiNo = txtVergiNo.Text,
                    Yetkili = txtYetkili.Text
                };
            }
            //ortak alanlara atama yaptık
            yeni.Ad = txtAd.Text;
            yeni.Adres = txtAdres.Text;
            yeni.MusteriNo = txtMusteriNo.Text;
            yeni.Telefon = txtTelefon.Text;
            yeni.Mail = txtMail.Text;
            yeni.Bakiye = double.Parse(txtBakiye.Text);

            lbxMusteri.Items.Add(yeni);//listbox'a ekledik
            cmbAlici.Items.Add(yeni);//combobox'a ekledik
        }

        private void lbxMusteri_SelectedIndexChanged(object sender, EventArgs e)
        {
            Musteri secilen = lbxMusteri.SelectedItem as Musteri;//listbox'tan seçilen elemanı Musteri olarak gör, tanımlanan referans'a ata
            if (secilen == null) return;   //listbox'tan eleman seçilmemişse geri dön

            MusteriGoster(secilen);//seçili musteri bilgilerini görüntüleyen fonk. çağırdık!
        }

        private void MusteriGoster(Musteri secilen)//parametre olarak gelen müşteri bilgilerini göster
        {
            if (secilen is BireyselMusteri)//referansın gösterdiği eleman BireyselMusteri ise
            {
                BireyselMusteri bm = secilen as BireyselMusteri;
                //bireysel özellikler
                txtAnneSoyad.Text = bm.AnneSoyad;
                txtKimlikNo.Text = bm.KimlikNo;
                txtSoyad.Text = bm.Soyad;
                dtDogum.Value = bm.DogumTarihi;
                rbtnBireysel.Checked = true;
            }
            else
            {
                KurumsalMusteri km = secilen as KurumsalMusteri;//Musteri tipindeki referansı KurumsalMusteri olarak gör
                //kurumsal özellikler
                txtVergiDairesi.Text = km.VergiDairesi;
                txtVergiNo.Text = km.VergiNo;
                txtYetkili.Text = km.Yetkili;
                rbtnKurumsal.Checked = true;
            }

            //ortak özellikler
            txtAd.Text = secilen.Ad;
            txtAdres.Text = secilen.Adres;
            txtTelefon.Text = secilen.Telefon;
            txtMail.Text = secilen.Mail;
            txtMusteriNo.Text = secilen.MusteriNo;
            txtBakiye.Text = secilen.Bakiye.ToString();
        }

        private void btnParaCek_Click(object sender, EventArgs e)
        {
            Musteri secilen = lbxMusteri.SelectedItem as Musteri;//listbox'tan seçilen elemanı Musteri olarak gör, tanımlanan referans'a ata
            if (secilen == null)//listbox'tan eleman seçilmemişse geri dön
            {
                MessageBox.Show("Müşteri seçmediniz!");
                return;
            }

            frmBakiyeIslemleri frm = new frmBakiyeIslemleri(secilen, IslemTipi.PCek);//frmBakiyeIslemleri tipinde nesne tanımla, nesne'nin(formun) kurucu fonksiyonu Musteri ve IslemTipi tiplerinde 2 adet parametreye ihtiyaç duysun 
            frm.bakiyeYenile += Frm_bakiyeYenile;//bakiyeYenile alt yordamını nesneye bağla!
            frm.ShowDialog();//formu görüntüle
        }

        private void Frm_bakiyeYenile(Musteri musteri)//frm nesnesinin tetiklenecek olan eventi!
        {
            MusteriGoster(musteri);//değişiklikleri görmek için parametre olarak gelen müşteri GÜNCEL bilgilerini göster
        }

        private void btnParaYatir_Click(object sender, EventArgs e)
        {
            Musteri secilen = lbxMusteri.SelectedItem as Musteri;
            if (secilen == null)
            {
                MessageBox.Show("Müşteri seçmediniz!");
                return;
            }

            frmBakiyeIslemleri frm = new frmBakiyeIslemleri(secilen, IslemTipi.PYatir);
            frm.bakiyeYenile += Frm_bakiyeYenile;
            frm.ShowDialog();
        }

        private void btnMusteriSec_Click(object sender, EventArgs e)
        {
            Musteri secilen = lbxMusteri.SelectedItem as Musteri;//listbox'tan seçilen elemanı Musteri olarak gör, tanımlanan referans'a ata
            Musteri alici = cmbAlici.SelectedItem as Musteri;//combobox'tan seçilen elemanı Musteri olarak gör, tanımlanan referans'a ata

            if (secilen == null)//gönderici seçilmemişse geri dön
            {
                MessageBox.Show("Gönderici hesap seçilmedi");
                return;
            }
            if (alici == null)//alıcı seçilmemişse geri dön
            {
                MessageBox.Show("Alıcı hesap seçilmedi");
                return;
            }
            if (secilen == alici)//göderici ve alıcı aynı ise geri dön
            {
                MessageBox.Show("Gönderici-Alıcı aynı olamaz");
                return;
            }

            frmBakiyeIslemleri frm = new frmBakiyeIslemleri(secilen, alici);//frmBakiyeIslemleri tipinde nesne tanımla, nesne'nin(formun) kurucu fonksiyonu Musteri tipinde 2 adet parametreye ihtiyaç duysun
            frm.bakiyeYenile += Frm_bakiyeYenile;// Frm_bakiyeYenile alt yordamını nesneye bağla!
            frm.ShowDialog();//formu görüntüle
        }
    }
}
