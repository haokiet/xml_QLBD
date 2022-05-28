using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using XML.Models;
using XML.QLData;

namespace XML.Controllers
{
    public class QuocGiaController : Controller
    {
        // GET: QuocGia
        public ActionResult Index()
        {

            QLTong<QG> qLQG = new QLQG();
            qLQG.getdata();


            return View(qLQG.DS);
        }

        // GET: QuocGia/Details/5
        public ActionResult Details(String id)
        {
            QLTong<QG> t = new QLQG();
            if (!t.istimkiem(id))
            {
                return HttpNotFound();
            }

            return View(t.xemChiTiet(id));
        }

        // GET: QuocGia/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: QuocGia/Create
        [HttpPost]
        public ActionResult Create(QG qG)
        {

            try
            {
                QLTong<QG> t = new QLQG();
                t.them(qG);
                t.getdata();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: QuocGia/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            QLTong<QG> t = new QLQG();

            if (!t.istimkiem(id))
            {
                return HttpNotFound();
            }


            return View(t.xemChiTiet(id));
        }

        // POST: QuocGia/Edit/5
        [HttpPost]
        public ActionResult Edit(string id,QG qG)
        {
            QLTong<QG> t = new QLQG();
            t.sua(id, qG);
            t.getdata();
            return RedirectToAction("Index");
        }


        // POST: QuocGia/Delete/5
        [HttpGet]
        public ActionResult Delete(string id, QG qG)
        {
            QLTong<QG> t = new QLQG();
            t.xoa(id);
            t.getdata();
            return View("Index", t.DS);
        }
    }
}
