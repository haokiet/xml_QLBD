using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using XML.Models;

namespace XML.Controllers
{
    public class HuanLuyenVienController : Controller
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
        // GET: HuanLuyenVien
        public ActionResult Index()
        {
            initValue();

            XmlNodeList HLVs = root.SelectNodes("HUANLUYENVIEN");
            List<HLV> DSHLV = new List<HLV>();

            foreach (XmlNode HLV in HLVs)
            {
                HLV temp = new HLV();
                temp.MAHLV = HLV["MAHLV"].InnerText;
                temp.TENHLV = HLV["TENHLV"].InnerText;
                temp.NGAYSINH = HLV["NGAYSINH"].InnerText;
                temp.DIACHI = HLV["DIACHI"].InnerText;
                temp.DIENTHOAI = HLV["DIENTHOAI"].InnerText;
                DSHLV.Add(temp);
            }
            return View(DSHLV);
        }

        // GET: HuanLuyenVien/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: HuanLuyenVien/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HuanLuyenVien/Create
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

        // GET: HuanLuyenVien/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HuanLuyenVien/Edit/5
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

        // GET: HuanLuyenVien/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HuanLuyenVien/Delete/5
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
