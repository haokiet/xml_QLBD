using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using XML.Models;

namespace XML.Controllers
{
    public class BangXepHangController : Controller
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
        // GET: BangXepHang
        public ActionResult Index()
        {
            initValue();

            XmlNodeList BXHs = root.SelectNodes("BANGXH");
            List<BANGXH> DSBXH = new List<BANGXH>();

            foreach (XmlNode BXH in BXHs)
            {
                BANGXH temp = new BANGXH();
                temp.NAM = BXH["NAM"].InnerText;
                temp.THUA = BXH["THUA"].InnerText;
                temp.VONG = BXH["VONG"].InnerText;
                temp.THANG = BXH["THANG"].InnerText;
                temp.SOTRAN = BXH["SOTRAN"].InnerText;
                temp.HOA = BXH["HOA"].InnerText;
                temp.DIEM = BXH["DIEM"].InnerText;
                temp.HIEUSO = BXH["HIEUSO"].InnerText;
                temp.HANG = BXH["HANG"].InnerText;
                DSBXH.Add(temp);
            }
            return View(DSBXH);
        }

        // GET: BangXepHang/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BangXepHang/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BangXepHang/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: BangXepHang/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BangXepHang/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: BangXepHang/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BangXepHang/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
