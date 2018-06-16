using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace MSK
{

    class XMLTree
    {
        private string filePath = @"C:\Users\Kamil\Desktop\MSK\MSK\FT2.xml";
        private List<Node> NodesFTAList;

        public XMLTree()
        {
            this.NodesFTAList = new List<Node>();
            XDocument xmlDoc = XDocument.Load(filePath);
            var status = xmlDoc.Descendants("NODE").First();
            Console.WriteLine(status.Value);
            
        }
        }
    }
