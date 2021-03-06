﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace DSK
{

    class XMLTree
    {
        private string filePath = @"C:\Users\Zalman\Source\Repos\MSK_FTA\MSK\FT_explosion.xml";
        private List<Node> NodesFTAList;

        public XMLTree()
        {

            this.NodesFTAList = new List<Node>();
            xmlImport();
            
        }

        public XMLTree(string path)
        {
            this.NodesFTAList = new List<Node>();
            this.filePath = @path;
            xmlImport();
        }

        public Node getNodeFromXMLTree(int i)
        {
            return NodesFTAList[i];
        }

        public List<Node> GetNodesFTAList()
        {
            return NodesFTAList;
        }

        public void setFilePath(string path)
        {
            filePath = path;
        }

        public void clearList()
        {
            NodesFTAList.Clear();
        }

        public void xmlImport() {
            XDocument xmlDoc = XDocument.Load(filePath);
            
            foreach (XElement level1Element in XElement.Load(filePath).Elements("NODE"))
            {
                Node n;
                int id, type, child = 0;
                double level = 0.0;
                string name, text;
                List<int> childrenIDList = new List<int>();
                Int32.TryParse(level1Element.Attribute("ID").Value, out id);
                name = level1Element.Attribute("NAME").Value;
                text = level1Element.Attribute("TEXT").Value;
                Int32.TryParse(level1Element.Attribute("TYPE").Value, out type);
                Double.TryParse(level1Element.Attribute("LEVEL").Value, out level);

                foreach (XElement level2Element in level1Element.Elements("CHILD"))
                {
                    Int32.TryParse(level2Element.Value, out child);
                    childrenIDList.Add(child);
                }
                n = new Node(id, text, type, level, childrenIDList);
                NodesFTAList.Add(n);
            }

            Console.WriteLine(NodesFTAList.ToString());
            
        }
    }
}
