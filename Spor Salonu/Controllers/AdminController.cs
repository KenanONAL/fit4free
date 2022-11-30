using OfficeOpenXml;
using Spor_Salonu.Models;
using Spor_Salonu.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using static System.Net.WebRequestMethods;

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
                List<Duyurulars> duyuruListe = db.Duyurulars.ToList();
                return View(duyuruListe);
            }
            return new RedirectResult(@"~\Home\AdminGiris");
        }

        public ActionResult DuyuruEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DuyuruEkle(Duyurulars model)
        {
            if (Session["admin"] != null)
            {
                try
                {
                    Duyurulars duyuru = new Duyurulars();
                    duyuru.duyuru_adi = model.duyuru_adi;
                    duyuru.duyuru_konu = model.duyuru_konu;
                    duyuru.tarih = DateTime.Now;
                    db.Duyurulars.Add(duyuru);
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
                var duyuru = db.Duyurulars.Where(s => s.Id == id).Single();
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
                    Duyurulars duyuru = new Duyurulars();
                    duyuru.Id = model.Id;
                    duyuru.duyuru_adi = model.duyuru_adi;
                    duyuru.duyuru_konu = model.duyuru_konu;
                    duyuru.tarih = DateTime.Now;
                    db.Duyurulars.AddOrUpdate(duyuru);
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
                db.Duyurulars.Remove(db.Duyurulars.Where(d => d.Id == id).First());
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
                List<Mesajs> mesajListesi = db.Mesajs.OrderByDescending(c => c.tarih).ToList();
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
                Mesajs mesaj = db.Mesajs.Where(c => c.Id == id).Single();
                mesaj.okundu_bilgisi = 1;
                db.Mesajs.AddOrUpdate(mesaj);
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
                db.Mesajs.Remove(db.Mesajs.Where(d => d.Id == id).First());
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
                List<Kayits> kayitListesi = db.Kayits.ToList();
                return View(kayitListesi);
            }
            else
            {
                return new RedirectResult(@"~\Home\adminGiris");
            }

        }

        public void KayitSil(int id)
        {
            if (Session["admin"] != null)
            {
                db.Kayits.Remove(db.Kayits.Where(d => d.Id == id).First());
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
            if (Session["admin"] != null)
            {
                List<Uyelers> uyeList = db.Uyelers.OrderBy(c => c.uyelik_bitis_tarihi).ToList();
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
        public ActionResult UyeEkle(Uyelers model)
        {
            if (Session["admin"] != null)
            {
                try
                {
                    Uyelers uyeler = new Uyelers();
                    uyeler.uye_adisoyadi = model.uye_adisoyadi;
                    uyeler.telefon = model.telefon;
                    uyeler.mail = model.mail;
                    uyeler.uyelik_baslangic_tarihi = model.uyelik_baslangic_tarihi;
                    uyeler.uyelik_bitis_tarihi = model.uyelik_bitis_tarihi;
                    uyeler.toplam_ucret = model.toplam_ucret;
                    uyeler.odenen_ucret = model.odenen_ucret;
                    uyeler.kalan_ucret = model.kalan_ucret;

                    db.Uyelers.Add(uyeler);
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
            if (Session["admin"] != null)
            {
                var uye = db.Uyelers.Where(k => k.Id == id).Single();
                return View(uye);
            }
            else
            {
                return new RedirectResult(@"~\Home\AdminGiris");
            }
        }

        [HttpPost]
        public ActionResult UyeDuzenle(Uyelers model)
        {
            if (Session["admin"] != null)
            {
                try
                {
                    Uyelers uye = new Uyelers();
                    uye.Id = model.Id;
                    uye.uye_adisoyadi = model.uye_adisoyadi;
                    uye.telefon = model.telefon;
                    uye.mail = model.mail;
                    uye.uyelik_baslangic_tarihi = model.uyelik_baslangic_tarihi;
                    uye.uyelik_bitis_tarihi = model.uyelik_bitis_tarihi;
                    uye.toplam_ucret = model.toplam_ucret;
                    uye.odenen_ucret = model.odenen_ucret;
                    uye.kalan_ucret = model.kalan_ucret;
                    db.Uyelers.AddOrUpdate(uye);
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
            if (Session["admin"] != null)
            {
                db.Uyelers.Remove(db.Uyelers.Where(k => k.Id == id).First());
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
                var uye_getir = db.Uyelers.Where(k => k.Id == uid).Single();
                Uyelers uye = db.Uyelers.SingleOrDefault(k => k.Id == uid);
                uye.kalan_ucret = uye_getir.kalan_ucret - Convert.ToInt32(collection.Get("ucret"));
                db.SaveChanges();
                TempData["sonuc"] = "Ödeme Başarıyla Gerçekleşti.";
                Response.Redirect(Url.Action("Uyeler", "Admin"));
            }
            catch
            {
                TempData["sonuc"] = "Ödeme Başarısız Oldu...";
                Response.Redirect(Url.Action("Uyeler", "Admin"));
            }
        }

        public void Cikis()
        {
            Session.Abandon();
            Response.Redirect(Url.Action("Index", "Home"));
        }

        public ActionResult Mesailer()
        {
            List<Mesailer> mesailer = db.Mesailer.Where(c=>c.Ay==DateTime.Now.Month).OrderByDescending(c => c.Ay).ToList();

            return View(mesailer);
            //if (Session["admin"] != null)
            //{
            //    List<Mesailer> uyeList = db.Mesailer.OrderBy(c => c.Gun).ToList();
            //    return View(uyeList);
            //}
            //else
            //{
            //    return new RedirectResult(@"~\Home\AdminGiris");
            //}
        }

        public ActionResult MesaiEkle()
        {
            return View();
            //if (Session["admin"] != null)
            //{
            //    return View();
            //}
            //else
            //{
            //    return new RedirectResult(@"~\Home\AdminGiris");
            //}
        }
        [HttpPost]
        public ActionResult MesaiEkle(Mesailer model)
        {

            //if (Session["admin"] != null)
            //{
            try
            {
                Mesailer mesailer = new Mesailer();
                mesailer.Ay = model.Ay;
                mesailer.Gun = model.Gun;
                mesailer.Saat = model.Saat;

                db.Mesailer.Add(mesailer);
                db.SaveChanges();
                TempData["sonuc"] = "Kayıt Başarılı Şekilde Yapıldı";
                return new RedirectResult(@"~\Admin\Mesailer");
            }
            catch
            {
                TempData["sonuc"] = "Bir Hata Oluştu";
            }
            return View();
            //}
            //else
            //{
            //    return new redirectresult(@"~\home\admingiris");
            //}

        }
        
        [HttpPost]
        public ActionResult Mesailer(int ay)
        {
            if (Session["admin"] != null)
            {
                var mesai = db.Mesailer.Where(k => k.Ay == ay);
                ViewBag.Ay = ay;
                if (Request.Form["listele"]!=null)
                {
                    return View(mesai);
                }
                else if (Request.Form["excel"]!=null)
                {
                    var mesailer = db.Mesailer.Where(c => c.Ay == ay).OrderByDescending(c => c.Ay).ToList(); ;
                    string strFileName = @"C:\Users\konal\Desktop\mesai.xlsx";
                    FileInfo fileInfo = new FileInfo(strFileName);

                    using (ExcelPackage excelPackage = new ExcelPackage(fileInfo))
                    {

                        ExcelPackage.LicenseContext = LicenseContext.Commercial;
                        ExcelWorksheet namedWorksheet = excelPackage.Workbook.Worksheets["mesai"];

                        for (int i = 3; i <= 33; i++)
                        {
                            namedWorksheet.Cells[6, Convert.ToInt32(i)].Value = "";
                        }

                        foreach (var item in mesailer)
                        {
                            namedWorksheet.Cells[6, Convert.ToInt32(item.Gun + 2)].Value = item.Saat;
                        }
                        excelPackage.SaveAs(fileInfo);
                        excelPackage.Dispose();
                    }
                    Process.Start(new ProcessStartInfo { FileName = strFileName, UseShellExecute = true });
                    Response.Redirect(Url.Action("Mesailer", "Admin"));
                    
                }
                return View(mesai);

            }
            else
            {
                return new RedirectResult(@"~\Home\AdminGiris");
            }
        }
        public void MesaiSil(int id)
        {
            if (Session["admin"] != null)
            {
                db.Mesailer.Remove(db.Mesailer.Where(k => k.Id == id).First());
                db.SaveChanges();
                TempData["sonuc"] = "Mesai Başarılı Şekilde Silindi";
                Response.Redirect(Url.Action("Mesailer", "Admin"));
            }
            else
            {
                new RedirectResult(@"~\Home\AdminGiris");
            }
        }

        public void VerileriSil()
        {
            if (Session["admin"] != null)
            {
                //Verileri Silme Kodları
                TempData["sonuc"] = "Veriler Başarılı Şekilde Silindi";
                Response.Redirect(Url.Action("Mesailer", "Admin"));
            }
            else
            {
                new RedirectResult(@"~\Home\AdminGiris");
            }
        }

        public void ExcelAktar()
        {


            //var mesailer = db.Mesailer.Where(c => c.Ay ==).OrderByDescending(c => c.Ay).ToList(); ;
            //string strFileName = @"C:\Users\konal\Desktop\mesai.xlsx";
            //FileInfo fileInfo = new FileInfo(strFileName);

            //using (ExcelPackage excelPackage = new ExcelPackage(fileInfo))
            //{

            //    ExcelPackage.LicenseContext = LicenseContext.Commercial;
            //    ExcelWorksheet namedWorksheet = excelPackage.Workbook.Worksheets["mesai"];

            //    for (int i = 3; i <= 33; i++)
            //    {
            //        namedWorksheet.Cells[6, Convert.ToInt32(i)].Value = "";
            //    }

            //    foreach (var item in mesailer)
            //    {
            //        namedWorksheet.Cells[6, Convert.ToInt32(item.Gun + 2)].Value = item.Saat;
            //    }
            //    excelPackage.SaveAs(fileInfo);
            //    excelPackage.Dispose();
            //}
            //Process.Start(new ProcessStartInfo { FileName = strFileName, UseShellExecute = true });
            //Response.Redirect(Url.Action("Mesailer", "Admin"));
        }


    }
}