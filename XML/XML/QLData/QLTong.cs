using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using XML.Models;

namespace XML.QLData
{
    public abstract class QLTong<T>
    {
        protected XmlDocument doc = new XmlDocument();
        string file;
        XmlElement root;
        public List<T> DS = new List<T>();
        public QLTong()
        {
            file = HttpContext.Current.Server.MapPath("/DataSource/XMLFile1.xml");
            doc.Load(file);
            root = doc.DocumentElement;
        }

        protected abstract string nameData();
        protected abstract string nameKey();
        protected abstract T createrOject(XmlNode item);

        protected abstract XmlElement createrNewEle(T t);
        public void getdata()
        {
            XmlNodeList nodeList = root.SelectNodes(nameData());
            DS.RemoveRange(0, DS.Count);
            foreach (XmlNode item in nodeList)
            {
                DS.Add(createrOject(item));
            }
        }

        public void them(T t)
        {

            root.InsertAfter(createrNewEle(t), root.SelectSingleNode(nameData() + "[last()]"));
            DS.Add(t);
            doc.Save(file);
        }


        public void sua(string id, T t)
        {
            XmlNode nodecu = root.SelectSingleNode(nameData() + "[" + nameKey() + "='" + id + "']");
            if (nodecu != null)
            {
                XmlElement temp = createrNewEle(t);
                root.ReplaceChild(temp, nodecu);
                doc.Save(file);
                /* nếu cần xóa lun cái list 
                 int i = 0;
                 foreach (var value in DSCLB)
                 {
                     if (value.MACLB != id) i++;
                     else break;
                 }
                 DS.RemoveAt(i);
                 DS.Add(t);*/
            }

        }

        public void xoa(string id)
        {
            XmlNode nodecu = root.SelectSingleNode(nameData() + "[" + nameKey() + "='" + id + "']");
            if (nodecu != null)
            {
                root.RemoveChild(nodecu);
                doc.Save(file);

                /* nếu cần xóa lun trên list
                  int i = 0;
                foreach (var value in DSCLB)
                {
                    if (value.MACLB != id) i++;
                    else break;
                }
                DSCLB.RemoveAt(i);*/
            }
        }

        public T xemChiTiet(string id)
        {
            XmlNode nodecu = root.SelectSingleNode(nameData() + "[" + nameKey() + "='" + id + "']");
            if (nodecu != null)
            {
                return createrOject(nodecu);
            }

            return default(T);
        }
    }
}