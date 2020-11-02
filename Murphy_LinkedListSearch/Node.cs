using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Murphy_LinkedListSearch
{
    class Node
    {
        public Node Previous;
        public Node Next;
        public MetaData data;

        public Node (MetaData m)
        {
           
            data = m;
            Next = null;
            Previous = null;
        }

    }
}
