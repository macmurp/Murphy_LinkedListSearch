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
        public int countfemale = 0;
        public int countmale = 0;

        public Node Add(MetaData inputdata)
        {
            // check for empty list. If empty add to head
            if (head == null)
            {
                head = new Node(inputdata);
                tail = head;
                Count(inputdata);
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
                    Count(inputdata);
                    return tail;
                }

                //handle new head
                if (current.data.name.CompareTo(inputdata.name) > 0)
                {
                    Node temp = new Node(inputdata);
                    temp.Next = head;
                    head = temp;
                    Count(inputdata);
                    return temp;
                }

                if ((current.data.name == inputdata.name) && (current.data.gender == inputdata.gender))
                {
                    //prompt to add a _1 if a duplicate in name (and gender)
                    Console.WriteLine("Duplicate found for " + inputdata.name + ". Add anyway? Yes/no");
                    if (Console.ReadLine() == "yes")
                    {
                        inputdata.name = inputdata.name + "_1";
                        current.Next = new Node(inputdata);
                        current.Next.Previous = current;
                        current.Next.Next = nextnode;
                        nextnode.Previous = current.Next;
                        Count(inputdata);
                        return current.Next;
                    }
                    else
                    {
                        Console.WriteLine("Duplicate discarded");
                        return null;
                    }
                }

                //insert in middle
                if (current.data.name.CompareTo(inputdata.name) < 0 && nextnode.data.name.CompareTo(inputdata.name) >= 0)
                {
                    current.Next = new Node(inputdata);
                    current.Next.Previous = current;
                    current.Next.Next = nextnode;
                    nextnode.Previous = current.Next;
                    Count(inputdata);
                    return current.Next;
                }

                //didn't satisfy any of the if statements: move to next option in list and check again
                current = current.Next;
            }
            return null;

        }

        public void Count(MetaData inputdata)
        {
            if (inputdata.gender == 'M')
            {
                countmale++;
            }
            else
            {
                countfemale++;
            }

        }
        public int PrintCount()
        {
            int count = countfemale + countmale;
            return count;
        }
        public int PrintCountMale()
        {
            return countmale;
        }
        public int PrintCountFemale()
        {
            return countfemale;
        }
    }
}
