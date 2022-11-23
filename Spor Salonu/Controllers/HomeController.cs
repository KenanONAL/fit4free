using Spor_Salonu.Models;
using Spor_Salonu.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Spor_Salonu.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        veritabaniEntities db = new veritabaniEntities();
        public ActionResult Index()
        {
            var duyuruListe = db.Duyurulars.OrderByDescending(c => c.tarih).ToList().Take(3);
            return View(duyuruListe);
        }

        public ActionResult Duyurular()
        {
            var duyuruListe = db.Duyurulars.OrderByDescending(c => c.tarih).ToList().Take(3);
            return View(duyuruListe);
        }

        public ActionResult Hakkimizda()
        {
            var duyuruListe = db.Duyurulars.OrderByDescending(c => c.tarih).ToList().Take(3);
            return View(duyuruListe);
        }

        public ActionResult Iletisim()
        {
            var duyuruListe = db.Duyurulars.OrderByDescending(c => c.tarih).ToList().Take(3);
            return View(duyuruListe);
        }

        [HttpPost]
        public ActionResult Iletisim(iletisimModel model)
        {
            var duyuruListe = db.Duyurulars.OrderByDescending(c => c.tarih).ToList().Take(3);
            try
            {
                Mesajs alinan_mesaj = new Mesajs();
                alinan_mesaj.ad = model.ad;
                alinan_mesaj.soyad = model.soyad;
                alinan_mesaj.mail = model.mail;
                alinan_mesaj.konu = model.konu;
                alinan_mesaj.mesaj1 = model.mesaj;
                alinan_mesaj.tarih = DateTime. Now;
                db.Mesajs.Add(alinan_mesaj);
                db.SaveChanges();
                TempData["sonuc"] = "Kayıt Başarılı Şekilde Yapıldı";
            }
            catch
            {
                TempData["sonuc"] = "Bir Hata Oluştu";
            }
            return View(duyuruListe);
        }

        public ActionResult OnKayit()
        {
            var duyuruListe = db.Duyurulars.OrderByDescending(c => c.tarih).ToList().Take(3);
            return View(duyuruListe);
        }

        [HttpPost]
        public ActionResult OnKayit(kayitModel model)
        {
            var duyuruListe = db.Duyurulars.OrderByDescending(c => c.tarih).ToList().Take(3);
            Kayits on_kayit = new Kayits();
            on_kayit.adsoyad = model.adsoyad;
            on_kayit.mail = model.mail;
            on_kayit.telefon = model.telefon;
            on_kayit.uyelik_suresi = model.uyelik_suresi;
            on_kayit.tarih = DateTime.Now;
            db.Kayits.Add(on_kayit);
            db.SaveChanges();

            TempData["sonuc"] = "Ön Kaydınız Başarılı Şekilde Kaydedildi";
            return View(duyuruListe);
        }

        public ActionResult AdminGiris()
        {  
            if(Session["admin"]!=null)
            {
                return new RedirectResult(Url.Action("Index", "Admin"));
            }
            else
            {
                return View();
            }
                
        }

        [HttpPost]
        public ActionResult AdminGiris(adminModel model)
        {
            try
            {               
                var admin=db.Admins.Where(s => s.kullanici_adi == model.kullanici_adi && s.sifre == model.sifre).Single();
                Session.Add("admin",admin.kullanici_adi);
                return new RedirectResult(@"~\Home\AdminGiris");           
            }
            catch
            {
                TempData["mesaj"] = "Hatalı Kullanıcı Adı veya Şifre";
                return new RedirectResult(@"~\Home\AdminGiris");
            }
        }
    }
}