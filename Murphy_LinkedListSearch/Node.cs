using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Murphy_LinkedListSearch
{
    class Node
    {
        protected Node _Previous;
        protected Node _Next;
        protected MetaData _Data;
        public Node Previous { get { return _Previous; } set { _Previous = value; } }
        public Node Next { get { return _Next; } set { _Next = value; } }
        public MetaData Data { get { return _Data; } set { _Data = value; } }

        public Node (MetaData m)
        {
           
            Data = m;
            Next = null;
            Previous = null;
        }

    }
}
