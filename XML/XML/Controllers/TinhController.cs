using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XML.Models;
using XML.QLData;
using System.Runtime;
using System.Xml;
using System.Net;

namespace XML.Controllers
{
    public class TinhController : Controller
    {
        // GET: Tinh
        public ActionResult Index()
        {

            QLTong<TINH> qLTinh = new QLTinh();
            qLTinh.getdata();


            return View(qLTinh.DS);
        }

        // GET: San/Details/5
        public ActionResult Details(string id)
        {
            QLTong<TINH> t = new QLTinh();
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
        public ActionResult Create(TINH tinhMoi)
        {

            try
            {
                QLTong<TINH> t = new QLTinh();
                t.them(tinhMoi);
                t.getdata();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }


        }

        // GET: San/Edit/5
        public ActionResult Edit(string id)
        {
            QLTong<TINH> t = new QLTinh();
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
        public ActionResult Edit(string id, TINH TinhSua)
        {


            ViewBag.t = "Thành công";
            QLTong<TINH> qLTinh = new QLTinh();
            qLTinh.sua(id, TinhSua);
            qLTinh.getdata();
            return View("Index", qLTinh.DS);
        }

        // GET: San/Delete/5

        [HttpGet]
        public ActionResult Delete(string id)
        {
            QLTong<TINH> qLTinh = new QLTinh();
            qLTinh.xoa(id);
            qLTinh.getdata();
            return View("Index", qLTinh.DS);
        }
    }
}