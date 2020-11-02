using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Murphy_LinkedListSearch
{
    class LinkedList
    {
        protected Node head;
        protected Node tail;
        protected int countfemale = 0;
        protected int countmale = 0;

       
        public Node Search(string name)
        {

            if (head == null)
            {
                return null;
            }
            if(head.Data.name == name)
            {
                return head;
            }

            Node fastpointer = head;
            Node slowpointer = head;
            while ((fastpointer.Next != null) && (fastpointer.Next.Next != null))
            {
                fastpointer = fastpointer.Next.Next;
                slowpointer = slowpointer.Next;
            }

            Node middle = slowpointer;

            if (middle.Data.name.ToLower().CompareTo(name.ToLower()) >= 0)
            {
                return LinearSearch(name, head, middle);
            }
            else
            {
                return LinearSearch(name, middle, tail);
            }
        }



        public Node LinearSearch(string name, Node current, Node end)
        {

            while (current != end.Next)
            {
                if (current.Data.name.ToLower().CompareTo(name.ToLower()) == 0)
                {
                    return current;
                }

                current = current.Next;
            }

            return null;
        }



        public Node Popular()
        {

            if (head == null)
            {
                return null;
            }
            Node maxrank, current;
            maxrank = current = head;

            while (current != null)
            {
                if(current.Data.rank > maxrank.Data.rank)
                {
                    maxrank = current;
                }
                current = current.Next;
            }
            return maxrank;
        }



        public Node Add(MetaData inputdata)
        {
            if (head == null)
            {
                head = new Node(inputdata);
                tail = head;
                Count(inputdata);
                return head;
            }


            Node fastpointer = head;
            Node slowpointer = head;
            while ((fastpointer.Next != null) && (fastpointer.Next.Next != null))
            {
                fastpointer = fastpointer.Next.Next;
                slowpointer = slowpointer.Next;
            }

            Node middle = slowpointer;

            
            if (middle.Data.name.ToLower().CompareTo(inputdata.name.ToLower()) >= 0)
            {
                return LinearAdd(inputdata, head, middle);
            }
            else
            {
                return LinearAdd(inputdata, middle, tail);
            }
        }



        public Node LinearAdd(MetaData inputdata, Node current, Node end)
        {

            while (current != end.Next)
            {
                Node nextnode = current.Next;
                if (nextnode == null)
                {
                    tail.Next = new Node(inputdata);
                    tail.Next.Previous = tail;
                    tail = tail.Next;
                    Count(inputdata);
                    return tail;
                }
                if (head.Data.name.CompareTo(inputdata.name) > 0)
                {
                    Node temp = new Node(inputdata);
                    temp.Next = head;
                    head = temp;
                    Count(inputdata);
                    return temp;
                }
                if ((current.Data.name == inputdata.name) && (current.Data.gender == inputdata.gender))
                {
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

                if (current.Data.name.CompareTo(inputdata.name) < 0 && nextnode.Data.name.CompareTo(inputdata.name) >= 0)
                {
                    current.Next = new Node(inputdata);
                    current.Next.Previous = current;
                    current.Next.Next = nextnode;
                    nextnode.Previous = current.Next;
                    Count(inputdata);
                    return current.Next;
                }

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
            else if (inputdata.gender == 'W' || inputdata.gender == 'F')
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
