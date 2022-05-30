using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using XML.Models;
using XML.QLData;

namespace XML.Controllers
{
    public class TranDauController : Controller
    {
        // GET: TranDau
        public ActionResult Index()
        {

            QLTong<TRANDAU> qLtran = new QLTran();
            qLtran.getdata();


            return View(qLtran.DS);
        }
        public ActionResult Details(string id)
        {
            QLTong<TRANDAU> t = new QLTran();
            if (!t.istimkiem(id))
            {
                return HttpNotFound();
            }

            return View(t.xemChiTiet(id));
        }
        public ActionResult Create()
        {
            QLTong<TRANDAU> t = new QLTran();
            ViewBag.MACLB1 = t.getListSelect("CAULACBO", "TENCLB");
            ViewBag.MACLB2 = t.getListSelect("CAULACBO", "TENCLB");
            ViewBag.MASAN = t.getListSelect("SANVD", "TENSAN");
            return View();
        }
        [HttpPost]
        public ActionResult Create(TRANDAU tRANDAU)
        {

            try
            {
                QLTong<TRANDAU> t = new QLTran();
                t.them(tRANDAU);
                t.getdata();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            QLTong<TRANDAU> t = new QLTran();

            if (!t.istimkiem(id))
            {
                return HttpNotFound();
            }

            ViewBag.MACLB1 = t.getListSelect("CAULACBO", "TENCLB");
            ViewBag.MACLB2 = t.getListSelect("CAULACBO", "TENCLB");
            ViewBag.MASAN = t.getListSelect("SANVD", "TENSAN");
            return View(t.xemChiTiet(id));
        }
        [HttpPost]
        public ActionResult Edit(string id, TRANDAU tRANDAU)
        {
            QLTong<TRANDAU> t = new QLTran();
            t.sua(id, tRANDAU);
            t.getdata();
            return RedirectToAction("Index");
        }


        // POST: QuocGia/Delete/5
        [HttpGet]
        public ActionResult Delete(string id)
        {
            QLTong<TRANDAU> t = new QLTran();
            t.xoa(id);
            t.getdata();
            return View("Index", t.DS);
        }
    }
}