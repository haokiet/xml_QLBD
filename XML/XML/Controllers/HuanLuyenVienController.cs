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
    public class HuanLuyenVienController : Controller
    {
        // GET: QuocGia
        public ActionResult Index()
        {

            QLTong<HLV> qLQG = new QLHLV();
            qLQG.getdata();


            return View(qLQG.DS);
        }

        // GET: QuocGia/Details/5
        public ActionResult Details(string id)
        {
            QLTong<HLV> t = new QLHLV();
            if (!t.istimkiem(id))
            {
                return HttpNotFound();
            }

            return View(t.xemChiTiet(id));
        }

        // GET: QuocGia/Create
        public ActionResult Create()
        {
            QLTong<HLV> t = new QLHLV();
            ViewBag.MAQG = t.getListSelect("QUOCGIA", "TENQG");
            return View();
        }

        // POST: QuocGia/Create
        [HttpPost]
        public ActionResult Create(HLV hLV)
        {

            try
            {
                QLTong<HLV> t = new QLHLV();
                t.them(hLV);
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

            QLTong<HLV> t = new QLHLV();

            if (!t.istimkiem(id))
            {
                return HttpNotFound();
            }

            ViewBag.MAQG = t.getListSelect("QUOCGIA", "TENQG");
            return View(t.xemChiTiet(id));
        }

        // POST: QuocGia/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, HLV hLV)
        {
            QLTong<HLV> t = new QLHLV();
            t.sua(id, hLV);
            t.getdata();
            return RedirectToAction("Index");
        }


        // POST: QuocGia/Delete/5
        [HttpGet]
        public ActionResult Delete(string id, HLV hLV)
        {
            QLTong<HLV> t = new QLHLV();
            t.xoa(id);
            t.getdata();
            return View("Index", t.DS);
        }
    }
}
