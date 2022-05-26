using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using XML.Models;

namespace XML.Controllers
{
    public class CauThuController : Controller
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
        // GET: CauThu
        public ActionResult Index()
        {
            initValue();

            XmlNodeList cauThus = root.SelectNodes("CAUTHU");
            List<CAUTHU> DScauThu = new List<CAUTHU>();

            foreach (XmlNode cauThu in cauThus)
            {
                CAUTHU temp = new CAUTHU();
                temp.MACT = cauThu["MACT"].InnerText;
                temp.HOTEN = cauThu["HOTEN"].InnerText;
                temp.VITRI = cauThu["VITRI"].InnerText;
                temp.DIACHI = cauThu["DIACHI"].InnerText;
                temp.SO = cauThu["SO"].InnerText;
                DScauThu.Add(temp);
            }

            return View(DScauThu);
        }

        // GET: CauThu/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CauThu/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CauThu/Create
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

        // GET: CauThu/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CauThu/Edit/5
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

        // GET: CauThu/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CauThu/Delete/5
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
