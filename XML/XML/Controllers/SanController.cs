using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using XML.Models;
using XML.QLData;
using System.Runtime;

namespace XML.Controllers
{
    public class SanController : Controller
    {

        public ActionResult Index()
        {

            QLTong<SAN> qLSan = new QLSan();
            qLSan.getdata();


            return View(qLSan.DS);
        }

        // GET: San/Details/5
        public ActionResult Details(string id)
        {
            QLTong<SAN> t = new QLSan();
            if (!t.istimkiem(id))
            {
                return HttpNotFound();
            }

            return View(t.xemChiTiet(id));
        }

        // GET: San/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: San/Create
        [HttpPost]
        public ActionResult Create(SAN sanMoi)
        {

            ViewBag.t = "thanh cong";
            QLTong<SAN> qLSan = new QLSan();
            qLSan.them(sanMoi);
            qLSan.getdata();

            return View("Index", qLSan.DS);


        }

        // GET: San/Edit/5
        public ActionResult Edit(string id)
        {
            QLTong<SAN> t = new QLSan();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (t.istimkiem(id))
            {
                return HttpNotFound();
            }

            return View(t.xemChiTiet(id));
        }

        // POST: San/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, SAN sanSua)
        {


            QLTong<SAN> t = new QLSan();
            t.sua(id, sanSua);
            t.getdata();
            return RedirectToAction("Index");
        }

        // GET: San/Delete/5

        [HttpGet]
        public ActionResult Delete(string id)
        {
            QLTong<SAN> qLSan = new QLSan();
            qLSan.xoa(id);
            qLSan.getdata();
            return View("Index", qLSan.DS);
        }

    }
}
