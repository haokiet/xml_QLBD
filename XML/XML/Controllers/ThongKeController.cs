using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Xsl;

namespace XML.Controllers
{
    public class ThongKeController : Controller
    {
        // GET: ThongKe

        public ActionResult Index()
        {
            string baseName = System.Web.HttpContext.Current.Server.MapPath("/DataSource/");

            XslTransform myXslTransform = new XslTransform();
            myXslTransform.Load(baseName + "XSLTFile1.xslt");
            myXslTransform.Transform(baseName + "XMLFile1.xml", baseName + "ThongKe.html");


            return View();
        }

    }
}