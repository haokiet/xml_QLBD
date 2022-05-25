using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using XML.Models;

namespace XML.Controllers
{
    public class SanController : Controller
    {
        XmlDocument doc = new XmlDocument();
        string file2 = System.IO.Path.GetDirectoryName("XMLFile1.xml");
        string file = @"C:\Users\trimi\source\repos\XML\XML\DataSource\XMLFile1.xml";
        XmlElement root;

        private void initValue()
        {
            doc.Load(file);
            root = doc.DocumentElement;
        }
        // GET: San
        public ActionResult Index()
        {

            initValue();
            /*   ViewBag.San = root["TRANDAU"]["MATRAN"].InnerText;*/
            /*ViewBag.San = San.SelectSingleNode("MATRAN").InnerText;*/
            /*ViewBag.San = San["MATRAN"].InnerText;*/

            XmlNodeList San = root.SelectNodes("SANVD");
            List<SAN> sans = new List<SAN>();

            foreach (XmlNode SanNode in San)
            {
                SAN temp = new SAN();
                temp.MASAN = SanNode["MASAN"].InnerText;
                temp.TENSAN = SanNode["TENSAN"].InnerText;
                temp.DIACHI = SanNode["DIACHI"].InnerText;
                sans.Add(temp);
            }
            ViewBag.t = file2;
            return View(sans);
        }

        // GET: San/Details/5
        public ActionResult Details(int id)
        {
            return View();
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
            initValue();

            XmlElement san = doc.CreateElement("SANVD");

            XmlElement MASAN = doc.CreateElement("MASAN");
            MASAN.InnerText = sanMoi.MASAN;
            san.AppendChild(MASAN);

            XmlElement TENSAN = doc.CreateElement("TENSAN");
            TENSAN.InnerText = sanMoi.MASAN;
            san.AppendChild(TENSAN);

            XmlElement DIACHI = doc.CreateElement("DIACHI");
            DIACHI.InnerText = sanMoi.MASAN;
            san.AppendChild(DIACHI);

            XmlNode temp = root.SelectSingleNode("SANVD[last()]");


            root.InsertAfter(san, temp);
            doc.Save(file);
            ViewBag.t = "thanh cong";
            return View();

        }

        // GET: San/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: San/Edit/5
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

        // GET: San/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: San/Delete/5
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
