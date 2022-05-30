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
    public class HLV_CLBController : Controller
    {
        // GET: HLV_CLB
        public ActionResult Index()
        {

            QLTong<HLV_CLB> qLHLV_CLB = new QLHLV_CLB();
            qLHLV_CLB.getdata();


            return View(qLHLV_CLB.DS);
        }

        // GET: HLV_CLB/Details/5
        public ActionResult Details(string id)
        {
            QLTong<HLV_CLB> t = new QLHLV_CLB();
            if (!t.istimkiem(id))
            {
                return HttpNotFound();
            }

            return View(t.xemChiTiet(id));
        }

        // GET: HLV_CLB/Create
        public ActionResult Create()
        {
            QLTong<HLV_CLB> t = new QLHLV_CLB();
            ViewBag.MACLB = t.getListSelect("CAULACBO", "TENCLB");
            ViewBag.MAHLV = t.getListSelect("HLV", "TENHLV");
            return View();
        }

        // POST: HLV_CLB/Create
        [HttpPost]
        public ActionResult Create(HLV_CLB hLV_CLB)
        {
            try
            {
                QLTong<HLV_CLB> t = new QLHLV_CLB();
                t.them(hLV_CLB);
                t.getdata();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: HLV_CLB/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            QLTong<HLV_CLB> t = new QLHLV_CLB();

            if (!t.istimkiem(id))
            {
                return HttpNotFound();
            }

            ViewBag.MACLB = t.getListSelect("CAULACBO", "TENCLB");
            ViewBag.MAHLV = t.getListSelect("HLV", "TENHLV");
            return View(t.xemChiTiet(id));
        }

        // POST: HLV_CLB/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, HLV_CLB hLV_CLB)
        {
            QLTong<HLV_CLB> t = new QLHLV_CLB();
            t.sua(id, hLV_CLB);
            t.getdata();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(string id, HLV_CLB hLV_CLB)
        {
            QLTong<HLV_CLB> t = new QLHLV_CLB();
            t.xoa(id);
            t.getdata();
            return View("Index", t.DS);
        }
    }
}
