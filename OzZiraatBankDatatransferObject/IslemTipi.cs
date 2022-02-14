using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzZiraatBankDatatransferObject
{
    public enum IslemTipi//enum:kullanıcı tanımlı tip tanımlamak için kullanılır
    { 
        //tanımlı tipin alabileceği değerler!
        PCek = 1,//cast edip sayısal olarak da kullanılabilir
        PYatir = 2,
        HavaleYap = 3
    }
}
