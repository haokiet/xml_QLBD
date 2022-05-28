using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using XML.Models;
using System.Web.Mvc;

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

        protected abstract string nameTable();
        protected abstract string namePrimarykey();
        protected abstract T createrOject(XmlNode item);

        protected abstract XmlElement createrNewEle(T t);
        public void getdata()
        {
            XmlNodeList nodeList = root.SelectNodes(nameTable());
            DS.RemoveRange(0, DS.Count);
            foreach (XmlNode item in nodeList)
            {
                DS.Add(createrOject(item));
            }
        }
        protected XmlElement createrNode<H>(string name, H value)
        {
            XmlElement temp = doc.CreateElement(name);
            temp.InnerText = value.ToString();
            return temp;
        }

        public string keyToAttribute(string table, string nameKeyTable, XmlNode item, string nameAttFind)
        {
            return root.SelectSingleNode
                 (@"//" + table + "//" + nameKeyTable + "[contains(normalize-space()," + "'" +
                 item[nameKeyTable].InnerText + "'" + ")]//following-sibling::" + nameAttFind + "//text()").InnerText;

        }
        public string attributeToKey(string table, string nameAttTable, string findValue, string findAtt)
        {
            return root.SelectSingleNode
                    (@"//" + table + "//" + nameAttTable + "[contains(normalize-space()," + "'" + findValue + "'" + ")]//preceding-sibling::" + findAtt + "//text()").InnerText;

        }

        public SelectList getListSelect(string tabble, string nameListGet)
        {
            List<String> memberNames = root.SelectNodes(tabble + "//" + nameListGet)
                                           .Cast<XmlNode>()
                                           .Select(node1 => node1.InnerText)
                               .ToList();
            return new SelectList(memberNames);
        }

        public void them(T t)
        {

            root.InsertAfter(createrNewEle(t), root.SelectSingleNode(nameTable() + "[last()]"));
            DS.Add(t);
            doc.Save(file);
        }


        public void sua(string id, T t)
        {
            XmlNode nodecu = root.SelectSingleNode(nameTable() + "[" + namePrimarykey() + "='" + id + "']");
            if (nodecu != null)
            {
                XmlElement temp = createrNewEle(t);
                root.ReplaceChild(temp, nodecu);
                doc.Save(file);
            }

        }

        public void xoa(string id)
        {
            XmlNode nodecu = root.SelectSingleNode(nameTable() + "[" + namePrimarykey() + "='" + id + "']");
            if (nodecu != null)
            {
                root.RemoveChild(nodecu);
                doc.Save(file);
            }
        }

        public T xemChiTiet(string id)
        {
            XmlNode nodecu = root.SelectSingleNode(nameTable() + "[" + namePrimarykey() + "='" + id + "']");
            if (nodecu != null)
            {
                return createrOject(nodecu);
            }

            return default(T);
        }
        public bool istimkiem(string id)
        {
            XmlNode t = root.SelectSingleNode(nameTable() + "[" + namePrimarykey() + "='" + id + "']");
            if (t != null)
            {
                return true;
            }
            return false;
        }
    }
}