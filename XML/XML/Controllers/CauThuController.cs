using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using XML.Models;
using XML.QLData;

namespace XML.Controllers
{
    public class CauThuController : Controller
    {

        // GET: CauThu
        public ActionResult Index()
        {

            QLTong<CAUTHU> t = new QLCauThu();
            t.getdata();

            return View(t.DS);
        }

        // GET: CauThu/Details/5
        public ActionResult Details(string id)
        {

            QLTong<CAUTHU> t = new QLCauThu();

            if (!t.istimkiem(id))
            {
                return HttpNotFound();
            }

            return View(t.xemChiTiet(id));
        }
        // GET: CauThu/Create
        public ActionResult Create()
        {
            QLTong<CAUTHU> t = new QLCauThu();

            ViewBag.MACLB = t.getListSelect("CAULACBO", "TENCLB");

            ViewBag.MAQG = t.getListSelect("QUOCGIA", "TENQG");
            return View();
        }

        // POST: CauThu/Create
        [HttpPost]
        public ActionResult Create(CAUTHU cauthu)
        {

            try
            {
                QLTong<CAUTHU> t = new QLCauThu();
                t.them(cauthu);
                t.getdata();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CauThu/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            QLTong<CAUTHU> t = new QLCauThu();

            if (!t.istimkiem(id))
            {
                return HttpNotFound();
            }

            ViewBag.MACLB = t.getListSelect("CAULACBO", "TENCLB");
            ViewBag.MAQG = t.getListSelect("QUOCGIA", "TENQG");


            return View(t.xemChiTiet(id));
        }

        // POST: CauThu/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, CAUTHU cauthu)
        {
            QLTong<CAUTHU> t = new QLCauThu();
            t.sua(id, cauthu);
            t.getdata();
            return RedirectToAction("Index");
        }

        // POST: CauThu/Delete/5
        [HttpGet]
        public ActionResult Delete(string id)
        {
            QLTong<CAUTHU> t = new QLCauThu();
            t.xoa(id);
            t.getdata();
            return View("Index", t.DS);
            /* return RedirectToAction("Index");*/
        }
    }
}
