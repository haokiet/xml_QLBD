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
    public class CauLacBoController : Controller
    {
        XmlDocument doc = new XmlDocument();
        string file;
        XmlElement root;

        public string File1 { get => Server.MapPath("/DataSource/XMLFile1.xml"); set => file = value; }

        private void initValue()
        {
            doc.Load(File1);
            root = doc.DocumentElement;
        }
        // GET: CauLacBo
        public ActionResult Index()
        {


            QLTong<CLB> qLCLB = new QLCLB();
            qLCLB.getdata();


            return View(qLCLB.DS);
        }

        // GET: CauLacBo/Details/5
        public ActionResult Details(string id)
        {
            QLTong<CLB> t = new QLCLB();
            if (!t.istimkiem(id))
            {
                return HttpNotFound();
            }

            return View(t.xemChiTiet(id));
        }

        // GET: CauLacBo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CauLacBo/Create
        [HttpPost]
        public ActionResult Create(CLB cLB)
        {
            try
            {
                QLTong<CLB> t = new QLCLB();
                t.them(cLB);
                t.getdata();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CauLacBo/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            QLTong<CLB> t = new QLCLB();

            if (!t.istimkiem(id))
            {
                return HttpNotFound();
            }


            return View(t.xemChiTiet(id));
        }

        // POST: CauLacBo/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, CLB cLB)
        {
            QLTong<CLB> t = new QLCLB();
            t.sua(id, cLB);
            t.getdata();
            return RedirectToAction("Index");
        }

        // GET: CauLacBo/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CauLacBo/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, CLB cLB)
        {
            QLTong<CLB> t = new QLCLB();
            t.xoa(id);
            t.getdata();
            return View("Index", t.DS);
        }
    }
}
