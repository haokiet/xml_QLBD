using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using XML.Models;
using System.Runtime;

namespace XML.Controllers
{
    public class SanController : Controller
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
            TENSAN.InnerText = sanMoi.TENSAN;
            san.AppendChild(TENSAN);

            XmlElement DIACHI = doc.CreateElement("DIACHI");
            DIACHI.InnerText = sanMoi.DIACHI;
            san.AppendChild(DIACHI);

            XmlNode temp = root.SelectSingleNode("SANVD[last()]");


            root.InsertAfter(san, temp);
            doc.Save(File1);
            ViewBag.t = "thanh cong";


            XmlNodeList tempSan = root.SelectNodes("SANVD");
            List<SAN> tempSans = new List<SAN>();

            foreach (XmlNode SanNode in tempSan)
            {
                SAN temp1 = new SAN();
                temp1.MASAN = SanNode["MASAN"].InnerText;
                temp1.TENSAN = SanNode["TENSAN"].InnerText;
                temp1.DIACHI = SanNode["DIACHI"].InnerText;
                tempSans.Add(temp1);
            }

            return View("Index", tempSans);


        }

        // GET: San/Edit/5
        public ActionResult Edit(string id)
        {
            initValue();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            try
            {
                XmlNode sanCu = root.SelectSingleNode("SANVD[MASAN='" + id + "']");

                SAN temp = new SAN();
                temp.MASAN = sanCu["MASAN"].InnerText;
                temp.TENSAN = sanCu["TENSAN"].InnerText;
                temp.DIACHI = sanCu["DIACHI"].InnerText;

                return View(temp);
            }
            catch (Exception)
            {

                return HttpNotFound();
            }
        }

        // POST: San/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, SAN sanSua)
        {
            initValue();

            XmlNode sanCu = root.SelectSingleNode("SANVD[MASAN='" + sanSua.MASAN + "']");

            XmlElement san = doc.CreateElement("SANVD");

            XmlElement MASAN = doc.CreateElement("MASAN");
            MASAN.InnerText = sanSua.MASAN;
            san.AppendChild(MASAN);

            XmlElement TENSAN = doc.CreateElement("TENSAN");
            TENSAN.InnerText = sanSua.TENSAN;
            san.AppendChild(TENSAN);

            XmlElement DIACHI = doc.CreateElement("DIACHI");
            DIACHI.InnerText = sanSua.DIACHI;
            san.AppendChild(DIACHI);



            root.ReplaceChild(san, sanCu);
            doc.Save(File1);


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

            return View("Index", sans);
        }

        // GET: San/Delete/5

        [HttpGet]
        public ActionResult Delete(string id)
        {
            initValue();

            try
            {
                XmlNode sanCu = root.SelectSingleNode("SANVD[MASAN='" + id + "']");

                if (sanCu != null)
                {
                    root.RemoveChild(sanCu);
                    doc.Save(File1);

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

                    return View("Index", sans);
                }

            }
            catch (Exception)
            {

                return HttpNotFound();
            }


            return View();
        }

    }
}
