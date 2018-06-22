using MSK.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DSK
{
    public partial class Form1 : Form
    {
        private System.Windows.Forms.PictureBox picTree;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblNodeText;


        public Form1()
        {
            InitializeComponent();
            
        }
        private static XMLTree xmlTree = new XMLTree();
        private static List<Node> nodeList = xmlTree.GetNodesFTAList();
        private TreeNode<PictureNode> root =
            new TreeNode<PictureNode>(
                new PictureNode(nodeList.ElementAt(0).getText(),
                    nodeList.ElementAt(0).getImage()));

       


        private void Form1_Load(object sender, EventArgs e)
        {
            

        List<int> childList = nodeList.ElementAt(0).getChildrenList();
            foreach (int child in childList)
            {
                TreeNode<PictureNode> childNode = new TreeNode<PictureNode>(
                    new PictureNode(nodeList.ElementAt(child - 1).getText(),
                        nodeList.ElementAt(child - 1).getImage()));
                root.AddChild(childNode);
                if (nodeList.ElementAt(child - 1).getChildrenList().Count > 0)
                {
                    foreach (int childLevel2 in nodeList.ElementAt((child - 1)).getChildrenList())
                    {
                        TreeNode<PictureNode> childNodeLevel2 = new TreeNode<PictureNode>(
                            new PictureNode(nodeList.ElementAt(childLevel2 - 1).getText(),
                                nodeList.ElementAt(childLevel2 - 1).getImage()));
                        childNode.AddChild(childNodeLevel2);

                    }
                }
            }
            ArrangeTree();
        }

        private void ArrangeTree()
        {
            using (Graphics gr = picTree.CreateGraphics())
            {
                // Arrange the tree once to see how big it is.
                float xmin = 200, ymin = 200;
                root.Arrange(gr, ref xmin, ref ymin);

                // Arrange the tree again to center it horizontally.
                xmin = (this.ClientSize.Width - xmin) / 2;
                ymin = 10;
                root.Arrange(gr, ref xmin, ref ymin);
            }

            picTree.Refresh();
        }

        private void FTA_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";
            openFileDialog.ShowDialog();
            string path = openFileDialog.FileName;
            xmlTree.setFilePath(path);
            xmlTree.clearList();
            xmlTree = new XMLTree(path);
            nodeList = xmlTree.GetNodesFTAList();
            root =
                new TreeNode<PictureNode>(
                    new PictureNode(nodeList.ElementAt(0).getText(),
                        nodeList.ElementAt(0).getImage()));
            Form1_Load(sender, e);

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void picTree_Click(object sender, EventArgs e)
        {

        }
        // Draw the tree.
        private void picTree_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
            root.DrawTree(e.Graphics);
        }


        // Center the tree on the form.
        private void picTree_Resize(object sender, EventArgs e)
        {
            ArrangeTree();
        }


        // The currently selected node.
        private TreeNode<PictureNode> SelectedNode;

        private void picTree_MouseClick(object sender, MouseEventArgs e)
        {
            FindNodeUnderMouse(e.Location);
        }
        // Set SelectedNode to the node under the mouse.
        private void FindNodeUnderMouse(PointF pt)
        {
            // Deselect the previously selected node.
            if (SelectedNode != null)
            {
                SelectedNode.Data.Selected = false;
                lblNodeText.Text = "";
            }

            // Find the node at this position (if any).
            using (Graphics gr = picTree.CreateGraphics())
            {
                SelectedNode = root.NodeAtPoint(gr, pt);
            }

            // Select the node.
            if (SelectedNode != null)
            {
                SelectedNode.Data.Selected = true;
                lblNodeText.Text = SelectedNode.Data.Description;
            }

            // Redraw.
            picTree.Refresh();
        }
    }
}
