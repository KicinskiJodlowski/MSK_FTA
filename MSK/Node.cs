using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSK.Properties;

namespace DSK
{
    class Node
    {
        private int _id;
        private string _text;
        private int _type;
        private double _level;
        private List<int> _childrenIDList;

        public Node(int id, string text, int type, double level)
        {
            this._id = id;
            this._text = text;
            this._type = type;
            this._level = level;

        }
        public Node(int id, string text, int type, double level, List<int> childrenIdList)
        {
            this._id = id;
            this._text = text;
            this._type = type;
            this._level = level;
            this._childrenIDList = childrenIdList;

        }

        public string getText()
        {
            return _text;
        }

        public Image getImage()
        {
            
            switch (_type)
            {
                case 1:
                    return Resources.AND;
                    break;
                case 2:
                    return Resources.inhibit_gate;
                    break;
                case 3:
                    return Resources.OR;
                    break;
                case 4:
                    return Resources.podstawowe_zdarzenie;
                    break;
                case 5:
                    return Resources.priority_AND;
                    break;
                case 6:
                    return Resources.transfer_in;
                    break;
                case 7:
                    return Resources.transfer_out;
                    break;
                case 8:
                    return Resources.XOR;
                    break;
                case 9:
                    return Resources.zdarzenie_nierozwieniete;
                    break;
                case 10:
                    return Resources.zdarzenie_posrednie;
                    break;
                case 11:
                    return Resources.zdarzenie_warunkowe;
                    break;
                case 12:
                    return Resources.zdarzenie_zewnetrzne;
                    break;
                default:
                    return Resources.ERROR;
                    break;
            }
        }

        internal double getProbability()
        {
            
            return _level;
        }

        public List<int> getChildrenList()
        {
            return _childrenIDList;
        }
    }
}
