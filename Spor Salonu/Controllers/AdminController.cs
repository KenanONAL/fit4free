using Spor_Salonu.Models;
using Spor_Salonu.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Spor_Salonu.Controllers
{
    public class AdminController : Controller
    {
        veritabaniEntities db = new veritabaniEntities();
        // GET: Admin
        public ActionResult Index()
        {
            if (Session["admin"] != null)
            {
                return View();
            }
            else
            {
                return new RedirectResult(@"~\Home\AdminGiris");
            }

        }

        public ActionResult Duyurular()
        {
            if (Session["admin"] != null)
            {
                List<Duyurular> duyuruListe = db.Duyurular.ToList();
                return View(duyuruListe);
            }
            return new RedirectResult(@"~\Home\AdminGiris");
        }

        public ActionResult DuyuruEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DuyuruEkle(duyurularModel model)
        {
            if (Session["admin"] != null)
            {
                try
                {
                    Duyurular duyuru = new Duyurular();
                    duyuru.duyuru_adi = model.duyuru_adi;
                    duyuru.duyuru_konu = model.duyuru_konu;
                    duyuru.tarih = DateTime.Now;
                    db.Duyurular.Add(duyuru);
                    db.SaveChanges();
                    TempData["sonuc"] = "Kayıt Başarılı Şekilde Yapıldı.";
                    return new RedirectResult(@"~\Admin\Duyurular");
                }
                catch
                {
                    TempData["sonuc"] = "Bir Hata Oluştu";
                }
                return View();
            }
            else
            {
                return new RedirectResult(@"~\Home\AdminGiris");
            }
        }

        public ActionResult DuyuruDuzenle(int id)
        {
            if (Session["admin"] != null)
            {
                var duyuru = db.Duyurular.Where(s => s.Id == id).Single();
                TempData["duyuru_adi"] = duyuru.duyuru_adi.Trim();
                TempData["duyuru_konu"] = duyuru.duyuru_konu.Trim();
                return View();
            }
            else
            {
                return new RedirectResult(@"~\Home\AdminGiris");
            }
        }

        [HttpPost]
        public ActionResult DuyuruDuzenle(duyurularModel model)
        {
            if (Session["admin"] != null)
            {
                try
                {
                    Duyurular duyuru = new Duyurular();
                    duyuru.Id = model.Id;
                    duyuru.duyuru_adi = model.duyuru_adi;
                    duyuru.duyuru_konu = model.duyuru_konu;
                    duyuru.tarih = DateTime.Now;
                    db.Duyurular.AddOrUpdate(duyuru);
                    db.SaveChanges();
                    TempData["sonuc"] = "Kayıt Başarılı Şekilde Güncellendi";
                    return new RedirectResult(@"~\Admin\Duyurular");
                }
                catch
                {
                    TempData["sonuc"] = "Bir Hata Oluştu";
                }
                return View();
            }
            else
            {
                return new RedirectResult(@"~\Home\AdminGiris");
            }
        }

        public void DuyuruSil(int id)
        {
            if (Session["admin"] != null)
            {
                db.Duyurular.Remove(db.Duyurular.Where(d => d.Id == id).First());
                db.SaveChanges();
                TempData["sonuc"] = "Duyuru Başarıyla Silindi";
                Response.Redirect(Url.Action("Duyurular", "Admin"));
            }
            else
            {
                new RedirectResult(@"~\Home\AdminGiris");
            }
        }

        public ActionResult Mesajlar()
        {
            if (Session["admin"] != null)
            {
                List<Mesaj> mesajListesi = db.Mesaj.OrderByDescending(c => c.tarih).ToList();
                return View(mesajListesi);
            }
            else
            {
                return new RedirectResult(@"~\Home\AdminGiris");
            }
        }

        public ActionResult MesajOku(int id)
        {
            if (Session["admin"] != null)
            {
                Mesaj mesaj = db.Mesaj.Where(c => c.Id == id).Single();
                mesaj.okundu_bilgisi = 1;
                db.Mesaj.AddOrUpdate(mesaj);
                db.SaveChanges();
                return View(mesaj);
            }
            else
            {
                return new RedirectResult(@"~\Home\AdminGiris");
            }
        }

        public void MesajSil(int id)
        {
            if (Session["admin"] != null)
            {
                db.Mesaj.Remove(db.Mesaj.Where(d => d.Id == id).First());
                db.SaveChanges();
                TempData["sonuc"] = "Mesaj Başarıyla Silindi";
                Response.Redirect(Url.Action("Mesajlar", "Admin"));
            }
            else
            {
                new RedirectResult(@"~\Home\AdminGiris");
            }
        }

        public ActionResult Kayitlar()
        {
            if (Session["admin"] != null)
            {
                List<Kayit> kayitListesi = db.Kayit.ToList();
                return View(kayitListesi);
            }
            else
            {
                return new RedirectResult(@"~\Home\adminGiris");
            }

        }

        public void KayitSil(int id)
        {
            if (Session["admin"]!=null)
            {
                db.Kayit.Remove(db.Kayit.Where(d => d.Id == id).First());
                db.SaveChanges();
                TempData["sonuc"] = "Kayıt Başarılı Şekilde Silindi";
                Response.Redirect(Url.Action("Kayitlar", "Admin")); 
            }
            else
            {
                new RedirectResult(@"~\Home\AdminGiris");
            }
        }

        public ActionResult Uyeler()
        {
            if (Session["admin"]!=null)
            {
                List<Uyeler> uyeList = db.Uyeler.ToList();
                return View(uyeList); 
            }
            else
            {
                return new RedirectResult(@"~\Home\AdminGiris");
            }
        }

        public ActionResult UyeEkle()
        {

            if (Session["admin"] != null)
            {
                return View(); 
            }
            else
            {
                return new RedirectResult(@"~\Home\AdminGiris");
            }
        }

        [HttpPost]
        public ActionResult UyeEkle(Uyeler model)
        {
            if (Session["admin"] != null)
            {
                try
                {
                    Uyeler uyeler = new Uyeler();
                    uyeler.uye_adisoyadi = model.uye_adisoyadi;
                    uyeler.telefon = model.telefon;
                    uyeler.mail = model.mail;
                    uyeler.uyelik_baslangic_tarihi = model.uyelik_baslangic_tarihi;
                    uyeler.uyelik_bitis_tarihi = model.uyelik_bitis_tarihi;
                    uyeler.toplam_ucret = model.toplam_ucret;
                    uyeler.odenen_ucret = model.odenen_ucret;
                    uyeler.kalan_ucret = model.kalan_ucret;
                    
                    db.Uyeler.Add(uyeler);
                    db.SaveChanges();
                    TempData["sonuc"] = "Kayıt Başarılı Şekilde Yapıldı";
                    return new RedirectResult(@"~\Admin\Uyeler");
                }
                catch
                {
                    TempData["sonuc"] = "Bir Hata Oluştu";
                }
                return View();
            }
            else
            {
                return new RedirectResult(@"~\Home\AdminGiris");
            }
        }

        public ActionResult UyeDuzenle(int id)
        {
            if (Session["admin"]!=null)
            {
                var uye = db.Uyeler.Where(k => k.Id == id).Single();
                return View(uye); 
            }
            else
            {
                return new RedirectResult(@"~\Home\AdminGiris");
            }
        }

        [HttpPost]
        public ActionResult UyeDuzenle(Uyeler model)
        {
            if (Session["admin"]!=null)
            {
                try
                {
                    Uyeler uye = new Uyeler();
                    uye.Id = model.Id;
                    uye.uye_adisoyadi = model.uye_adisoyadi;
                    uye.telefon = model.telefon;
                    uye.mail = model.mail;
                    uye.uyelik_baslangic_tarihi = model.uyelik_baslangic_tarihi;
                    uye.uyelik_bitis_tarihi = model.uyelik_bitis_tarihi;
                    uye.toplam_ucret = model.toplam_ucret;
                    uye.odenen_ucret = model.odenen_ucret;
                    uye.kalan_ucret = model.kalan_ucret;
                    db.Uyeler.AddOrUpdate(uye);
                    db.SaveChanges();
                    TempData["sonuc"] = "Üye Başarılı Şekilde Güncellendi";
                    return new RedirectResult(@"~\Admin\Uyeler");
                }
                catch
                {
                    TempData["sonuc"] = "Bir Hata Oluştu";
                }
                return View(); 
            }
            else
            {
                return new RedirectResult(@"~\Home\AdminGiris");
            }
        }

        public void UyeSil(int id)
        {
            if (Session["admin"]!=null)
            {
                db.Uyeler.Remove(db.Uyeler.Where(k => k.Id == id).First());
                db.SaveChanges();
                TempData["sonuc"] = "Üye Başarılı Şekilde Silindi";
                Response.Redirect(Url.Action("Uyeler", "Admin")); 
            }
            else
            {
                new RedirectResult(@"~\Home\AdminGiris");
            }
        }
        [HttpPost]
        public void UyeOdemeYap(FormCollection collection)
        {
            try
            {
                int uid = Convert.ToInt32(collection.Get("uid"));
                var uye_getir = db.Uyeler.Where(k => k.Id == uid).Single();
                Uyeler uye = db.Uyeler.SingleOrDefault(k=>k.Id==uid);
                uye.kalan_ucret = uye_getir.kalan_ucret - Convert.ToInt32(collection.Get("ucret"));
                db.SaveChanges();
                TempData["sonuc"]="Ödeme Başarıyla Gerçekleşti.";
                Response.Redirect(Url.Action("Uyeler", "Admin"));
            }
            catch
            {
                TempData["sonuc"] = "Ödeme Başarısız Oldu..";
                Response.Redirect(Url.Action("Uyeler", "Admin"));
            }
        }

        public void Cikis()
        {
            Session.Abandon();
            Response.Redirect(Url.Action("Index", "Home"));
        }
    }
}