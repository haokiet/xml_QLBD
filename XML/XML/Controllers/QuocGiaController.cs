using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using XML.Models;

namespace XML.Controllers
{
    public class QuocGiaController : Controller
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
        // GET: QuocGia
        public ActionResult Index()
        {
            initValue();

            XmlNodeList QGs = root.SelectNodes("QUOCGIA");
            List<QG> DSQG = new List<QG>();

            foreach (XmlNode QG in QGs)
            {
                QG temp = new QG();
                temp.MAQG = QG["MAQG"].InnerText;
                temp.TENQG = QG["TENQG"].InnerText;
                DSQG.Add(temp);
            }
            return View(DSQG);
        }

        // GET: QuocGia/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: QuocGia/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: QuocGia/Create
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

        // GET: QuocGia/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: QuocGia/Edit/5
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

        // GET: QuocGia/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: QuocGia/Delete/5
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
