using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSK
{
    class Node
    {
        private int _id;
        private string _text;
        private int _type;
        private int _level;
        private List<int> _childrenIDList;

        public Node(int id, string text, int type, int level)
        {
            this._id = id;
            this._text = text;
            this._type = type;
            this._level = level;

        }
        public Node(int id, string text, int type, int level, List<int> childrenIdList)
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
        public List<int> getChildrenList()
        {
            return _childrenIDList;
        }
    }
}
