using OzZiraatBankDatatransferObject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OzZiraatBank.UserInterface
{
    public partial class frmBakiyeIslemleri : Form
    {
        public delegate void MyEventHandler(Musteri musteri);//musteri tipinde parametre alan-değer döndürmeyen bir TEMSİLCİ FONKSİYON TİPİ tanımladık
        public event MyEventHandler bakiyeYenile;//tanımlanan tipte, event(olay) döndüren fonksiyon deklarasyonu (tanımı form1'de)

        Musteri HESAPSAHIBI;//ilk formdan gelen gönderici nesnesi saklayacak referans(listbox'tan gelen)
        Musteri ALICI;//ilk formdan gelen alici nesnesi saklayacak referans(combobox'tan gelen)
        IslemTipi ISLEM;//ilk formdan gelen islem bilgisini saklayacak referans(hangi butondan geldiysek)

        public frmBakiyeIslemleri(Musteri secilen, IslemTipi islem)//constructor overloading/kurucu fonk. aşırı yükledik
        {
            InitializeComponent();
            HESAPSAHIBI = secilen;//tanımlanan referans ilk formdan gelen gönderici nesnesini göstersin 
            ISLEM = islem;//tanımlanan referans ilk formdan gelen islem bilgisini göstersin
        }

        public frmBakiyeIslemleri(Musteri secilen, Musteri alici)//constructor overloading/kurucu fonk. aşırı yükledik
                                                                 // kurucu fonksiyon Musteri tipinde 2 adet parametreye ihtiyaç duysun 
        {
            InitializeComponent();
            HESAPSAHIBI = secilen;//tanımlanan referans ilk formdan gelen gönderici nesnesini göstersin 
            //ISLEM = IslemTipi.HavaleYap;
            ISLEM = (IslemTipi)3;// tanımlanan referans ilk formdan gelen islem bilgisini göstersin
            ALICI = alici;//tanımlanan referans ilk formdan gelen alici nesnesini göstersin
        }

        private void frmBakiyeIslemleri_Load(object sender, EventArgs e)
        {
            switch (ISLEM)//seçili işlem bilgisine göre formdaki mesajı düzenledik!
            {
                case IslemTipi.PCek:
                    lblMesaj.Text = "Çekilecek tutarı giriniz:";
                    break;
                case IslemTipi.PYatir:
                    lblMesaj.Text = "Yatırılacak tutarı giriniz:";
                    break;
                case IslemTipi.HavaleYap:
                    lblMesaj.Text = "Havale tutarını giriniz:";
                    break;
            }
        }

        private void btnOnay_Click(object sender, EventArgs e)
        {
            double miktar = double.Parse(txtTutar.Text);//girilen tutarı değişkene atadık
            switch (ISLEM) // seçili işleme göre listbox'tan seçilen elemanın üzerinden ilgili fonk. çağırdık
            {
                case IslemTipi.PCek:
                    HESAPSAHIBI.ParaCek(miktar);
                    break;
                case IslemTipi.PYatir:
                    HESAPSAHIBI.ParaYatir(miktar);
                    break;
                case IslemTipi.HavaleYap:
                    HESAPSAHIBI.HavaleYap(miktar, ALICI);
                    break;
            }

            bakiyeYenile(HESAPSAHIBI);//bakiyeYenile olayını HESAPSAHIBI için çağırdık
            this.Close();//formu kapattık
        }
    }
}