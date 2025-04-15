﻿using Microsoft.AspNetCore.Mvc;
using Sube2.HelloMvc.Models;
using Sube2.HelloMvc.Models.ViewModels;

namespace Sube2.HelloMvc.Controllers
{
    public class OgrenciController : Controller
    {
        public ViewResult Index()//Action
        {
            return View("AnaSayfa");
        }

        public ViewResult OgrenciDetay(int id)
        {
            Ogrenci ogrenci = null;
            Ogretmen ogrt = null;
            if (id == 1)
            {
                ogrenci = new Ogrenci { Ad = "Ali", Soyad = "Veli", Ogrenciid = 1 };
                ogrt = new Ogretmen { Ad = "Hakan", Soyad = "Demir", Ogretmenid = 1 };
            }
            else if (id == 2)
            {
                ogrenci = new Ogrenci { Ad = "Ahmet", Soyad = "Mehmet", Ogrenciid = 2 };
                ogrt = new Ogretmen { Ad = "Osman", Soyad = "Yılmaz", Ogretmenid = 2 };
            }
            ViewData["ogr"] = ogrenci;
            ViewBag.Student = ogrenci;
            ViewBag.Teacher = ogrt;

            var dto = new OgrenciDetayDTO { Ogrenci = ogrenci, Ogretmen = ogrt };

            return View(dto);
        }

        public ViewResult OgrenciListe()
        {
            var lst = new List<Ogrenci>
            {
                 new Ogrenci { Ad = "Ahmet", Soyad = "Mehmet", Ogrenciid = 2 },
                 new Ogrenci { Ad = "Ali", Soyad = "Veli", Ogrenciid = 1 }
            };

            return View(lst);
        }

        [HttpGet]
        public ViewResult OgrenciEkle()
        {
            return View();
        }

        [HttpPost]
        public ViewResult OgrenciEkle(Ogrenci ogr)
        {
            int sonuc = 0;
            if (ogr != null)
            {
                using (var ctx = new OkulDbContext())
                {
                    ctx.Ogrenciler.Add(ogr);
                    sonuc = ctx.SaveChanges();
                }
            }

            if (sonuc > 0)
            {
                TempData["sonuc"] = true;
            }
            else
            {
                TempData["sonuc"] = false;
            }
            return View();
        }
    }
}

//Controller'dan View'e veri taşıma
//1-ViewData: Key-Value Pair Collection. Key'ler mutlaka tekil olmalıdır.Key'ler string, Value'lar object'dir. Type-Safe değildir.
//2-ViewBag: Arka planda ViewData dictionary'sini kullanır. Bu durumda daha önce ViewData'larda kullanılan key'ler kullanılamaz.
//ViewBag'ler dynamic yapılardır ve içindeki türler Runtime sırasında tespit edilir.

//3-Model
//4-TempData**
