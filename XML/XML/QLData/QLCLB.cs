using System.Collections.Generic;
using System.Web;
using System.Xml;
using XML.Models;
namespace XML.QLData
{
    public class QLCLB
    {
        protected XmlDocument doc = new XmlDocument();
        string file;
        protected XmlElement root;
        List<CLB> DSCLB = new List<CLB>();
        public QLCLB()
        {
            file = HttpContext.Current.Server.MapPath("/DataSource/XMLFile1.xml");
            doc.Load(file);
            root = doc.DocumentElement;
            DSCLB = getdata();
        }

        public List<CLB> getdata()
        {
            XmlNodeList CLBs = root.SelectNodes("CAULACBO");
            List<CLB> dsclb = new List<CLB>();
            foreach (XmlNode eDS in CLBs)
            {
                CLB temp = new CLB();
                temp.MACLB = eDS["MACLB"].InnerText;
                temp.TENCLB = eDS["TENCLB"].InnerText;
                temp.MATINH = eDS["MATINH"].InnerText;
                temp.MASAN = eDS["MASAN"].InnerText;

                dsclb.Add(temp);
            }
            return dsclb;
        }

        public void them(CLB clbMoi)
        {
            XmlElement temp = doc.CreateElement("CAULACBO");

            XmlElement MACLB = doc.CreateElement("MACLB");
            MACLB.InnerText = clbMoi.MACLB;
            temp.AppendChild(MACLB);

            XmlElement TENCLB = doc.CreateElement("TENCLB");
            TENCLB.InnerText = clbMoi.TENCLB;
            temp.AppendChild(TENCLB);

            XmlElement MASAN = doc.CreateElement("MASAN");
            MASAN.InnerText = clbMoi.MASAN;
            temp.AppendChild(MASAN);

            XmlElement MATINH = doc.CreateElement("MATINH");
            MATINH.InnerText = clbMoi.MATINH;
            temp.AppendChild(MATINH);

            XmlNode t = root.SelectSingleNode("CAULACBO[last()]");
            root.InsertAfter(temp, t);
            DSCLB.Add(clbMoi);

            doc.Save(file);
        }

        public bool timKiem(string id)
        {
            try
            {
                XmlNode clbCu = root.SelectSingleNode("CAULACBO[MACLB='" + id + "']");

                CLB temp = new CLB();
                temp.MACLB = clbCu["MACLB"].InnerText;
                temp.TENCLB = clbCu["TENCLB"].InnerText;
                temp.MATINH = clbCu["MATINH"].InnerText;
                temp.MASAN = clbCu["MASAN"].InnerText;
                return true;
            }
            catch (System.Exception)
            {

                return false;
            }
        }

        public CLB xemChiTiet(string id)
        {
            if (timKiem(id))
            {
                XmlNode clbCu = root.SelectSingleNode("SANVD[MASAN='" + id + "']");

                CLB temp = new CLB();
                temp.MACLB = clbCu["MACLB"].InnerText;
                temp.TENCLB = clbCu["TENCLB"].InnerText;
                temp.MATINH = clbCu["MATINH"].InnerText;
                temp.MASAN = clbCu["MASAN"].InnerText;
                return temp;
            }
            return null;
        }

        public void sua(string id, CLB clbSua)
        {
            XmlNode clbCu = root.SelectSingleNode("SANVD[MASAN='" + clbSua.MASAN + "']");

            XmlElement temp = doc.CreateElement("SANVD");

            XmlElement MACLB = doc.CreateElement("MACLB");
            MACLB.InnerText = clbSua.MACLB;
            temp.AppendChild(MACLB);

            XmlElement TENCLB = doc.CreateElement("TENCLB");
            TENCLB.InnerText = clbSua.TENCLB;
            temp.AppendChild(TENCLB);

            XmlElement MASAN = doc.CreateElement("MASAN");
            MASAN.InnerText = clbSua.MASAN;
            temp.AppendChild(MASAN);

            XmlElement MATINH = doc.CreateElement("MATINH");
            MATINH.InnerText = clbSua.MATINH;
            temp.AppendChild(MATINH);


            root.ReplaceChild(temp, clbCu);
            int i = 0;
            foreach (var value in DSCLB)
            {
                if (value.MACLB != id) i++;
                else break;
            }
            DSCLB.RemoveAt(i);
            DSCLB.Add(clbSua);

            doc.Save(file);
        }

        public void xoa(string id)
        {
            if (timKiem(id))
            {
                XmlNode sanCu = root.SelectSingleNode("SANVD[MASAN='" + id + "']");
                root.RemoveChild(sanCu);
                int i = 0;
                foreach (var value in DSCLB)
                {
                    if (value.MACLB != id) i++;
                    else break;
                }
                DSCLB.RemoveAt(i);
                doc.Save(file);
            }
        }
    }
}