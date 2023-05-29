using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace cerzAnimsaRefreshCozumleri
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cerez = new HttpCookie("bilgi");
            if (Session["veri"] == null)
            {
                if (Request.Cookies["bilgi"] != null)
                {
                    cerez = Request.Cookies["bilgi"];
                    int zisay = Convert.ToInt32(cerez["zis"]);
                    zisay++;
                    cerez["zis"] = zisay.ToString();
                    cerez.Expires = DateTime.Now.AddYears(1);
                    Response.Cookies.Add(cerez);
                    Response.Write("bu sayfamızı" + zisay + ".ziyretinizdir");
                    Session["veri"] = "dolu";//sayfada oturum açıldığının session nın veri değişenin içini doldurarak gösteriyoruz.

                }//çerez kontrol
                else
                {//burda refrehe karşı oturumu doldurmamıza gerek yok
                 //zaten çerez boşsa ilk defa gelmiştir ve ilk defa geliyorsa hemen çerez
                 //atılmıştır artık refresh yaptığında çerez dolu olduğu için if li kısma girere ordada doldurduk zaten
                    cerez["zis"] = "1";
                    cerez.Expires = DateTime.Now.AddYears(1);
                    Response.Cookies.Add(cerez);
                    Response.Write("bu sayfamızı ilk ziyaretinizdir.");
                }//çerez kontrol
            }//oturum kontol
            else
            {//doluysa oturumun kabı yeni çerez atmasın,gelen çerezin zis ini göstersin
                cerez = Request.Cookies["bilgi"];
                int zisay = Convert.ToInt32(cerez["zis"]);
                Response.Write("bu sayfamızı" + zisay + ".ziyretinizdir");
            }//otueum kontrol
        }
    }
}