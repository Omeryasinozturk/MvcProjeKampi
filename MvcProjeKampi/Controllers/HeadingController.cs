using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class HeadingController : Controller
    {
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        WriterManager wm = new WriterManager(new EfWriterDal());
        public ActionResult Index()
        {
            var headingvalues = hm.GetList();
            return View(headingvalues);
        }
        [HttpGet]
        public ActionResult AddHeading()
        {
            //Başlık ekleme ekranında dropdown ı category ile doldurup category yi direkt seçmek için yapıyoruz.
            List<SelectListItem> valueCategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      //verileri dropdown ile listeyeleceğimiz için 
                                                      //value member= Seçtiğimz değerin ID si
                                                      // display member = Seçmiş olduğum kısmın adı
                                                      // Controler tarafında text = displaymember Value= valuemember
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()

                                                  }).ToList();
            List<SelectListItem> valuewriter = (from x in wm.GetList()
                                                select new SelectListItem
                                                {
                                                    Text=x.WriterName+" "+x.WriterSurName,
                                                    Value=x.WriterID.ToString()

                                                }).ToList();
            ViewBag.vlc = valueCategory;
            ViewBag.vlw = valuewriter;
            return View();
        }
        
        public ActionResult AddHeading(Heading p)
        {
            p.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            hm.HeadingAdd(p);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditHeading(int id)
        {
            List<SelectListItem> valueCategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()

                                                  }).ToList();
            ViewBag.vlc = valueCategory;
            var HeadingValue=hm.GetByID(id);
            return View(HeadingValue);

        }
        [HttpPost]
        public ActionResult EditHeading(Heading p)
        {
            hm.HeadingUpdate(p);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteHeading(int id)
        {
            var headingvalue=hm.GetByID(id);
            if (headingvalue.HeadingStatus == true)
            {
                headingvalue.HeadingStatus = false;
            }
            else if (headingvalue.HeadingStatus == false)
            {
                headingvalue.HeadingStatus = true;
            }
            hm.HeadingDelete(headingvalue);
            return RedirectToAction("Index");
        }
    }
}