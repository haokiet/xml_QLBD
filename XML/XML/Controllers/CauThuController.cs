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
                    temp.NGAYSINH = cauThu["NGAYSINH"].InnerText;
                    temp.DIACHI = cauThu["DIACHI"].InnerText;
                    temp.SO = cauThu["SO"].InnerText;
                temp.MACLB = root.SelectNodes
                    (String.Format("//CAULACBO//MACLB[contains(normalize-space(),{0})]/following-sibling::TENCLB", cauThu["MACLB"].InnerText)).Item(0).InnerText;
                temp.MAQG = root.SelectNodes
                    (String.Format("//QUOCGIA//MAQG[contains(normalize-space(),{0})]/following-sibling::TENQG" , cauThu["MAQG"].InnerText)).Item(0).InnerText;
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
           // ViewBag.MACLB = new SelectList(root.SelectNodes("//CAULACBO//MACLB"));
            return View();
        }

        // POST: CauThu/Create
        [HttpPost]
        public ActionResult Create(CAUTHU cauthu)
        {
            try
            {
                initValue();

                XmlElement san = doc.CreateElement("CAUTHU");

                XmlElement MACT = doc.CreateElement("MACT");
                MACT.InnerText = cauthu.MACT;
                san.AppendChild(MACT);

                XmlElement HOTEN = doc.CreateElement("HOTEN");
                HOTEN.InnerText = cauthu.HOTEN;
                san.AppendChild(HOTEN);

                XmlElement VITRI = doc.CreateElement("VITRI");
                VITRI.InnerText = cauthu.VITRI;
                san.AppendChild(VITRI);

                XmlElement NGAYSINH = doc.CreateElement("NGAYSINH");
                NGAYSINH.InnerText = cauthu.NGAYSINH;
                san.AppendChild(NGAYSINH);

                XmlElement DIACHI = doc.CreateElement("DIACHI");
                DIACHI.InnerText = cauthu.DIACHI;
                san.AppendChild(DIACHI);

                XmlElement MACLB = doc.CreateElement("MACLB");
                MACLB.InnerText = cauthu.MACLB;
                san.AppendChild(MACLB);

                XmlElement MAQG = doc.CreateElement("MAQG");
                MAQG.InnerText = cauthu.MAQG;
                san.AppendChild(MAQG);

                XmlElement SO = doc.CreateElement("SO");
                SO.InnerText = cauthu.SO;
                san.AppendChild(SO);

                XmlNode temp = root.SelectSingleNode("CAUTHU[last()]");


                root.InsertAfter(san, temp);
                doc.Save(File1);
                ViewBag.t = "thanh cong";


                XmlNodeList tempSan = root.SelectNodes("CAUTHU");
                List<CAUTHU> tempSans = new List<CAUTHU>();

                //foreach (XmlNode SanNode in tempSan)
                // {
                //  SAN temp1 = new SAN();
                //  temp1.MASAN = SanNode["MASAN"].InnerText;
                //   temp1.TENSAN = SanNode["TENSAN"].InnerText;
                //  temp1.DIACHI = SanNode["DIACHI"].InnerText;
                //  tempSans.Add(temp1);
                // }

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
