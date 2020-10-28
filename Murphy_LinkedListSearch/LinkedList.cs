using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Murphy_LinkedListSearch
{
    class LinkedList
    {
        public Node head;
        public Node tail;
        public int count = 0;

        public Node Add(MetaData inputdata)
        {
            // check for empty list. If empty add to head
            if (head == null)
            {
                head = new Node(inputdata);
                tail = head;
                count++;
                return head;
            }

            Node current = head;

            //if not empty, search the list for insert point
            //temporary search algorithm! WIP
            while (current != null)
            {
                Node nextnode = current.Next;
                //handle null tail
                if (nextnode == null)
                {
                    tail.Next = new Node(inputdata);
                    tail.Next.Previous = tail;
                    tail = tail.Next;
                    count++;
                    return tail;
                }

                //handle new head
                if (current.data.name.CompareTo(inputdata.name) > 0)
                {
                    Node temp = new Node(inputdata);
                    temp.Next = head;
                    head = temp;
                    count++;
                    return temp;
                }

                //insert in middle
                if (current.data.name.CompareTo(inputdata.name) < 0 && nextnode.data.name.CompareTo(inputdata.name) >= 0)
                {
                    current.Next = new Node(inputdata);
                    current.Next.Previous = current;
                    current.Next.Next = nextnode;
                    nextnode.Previous = current.Next;
                    count++;
                    return current.Next;
                }

                //didn't satisfy any of the if statements: move to next option in list and check again
                current = current.Next;
            }
            return null;

        }
    }
}
