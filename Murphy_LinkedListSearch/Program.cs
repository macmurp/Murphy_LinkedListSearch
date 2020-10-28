using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Murphy_LinkedListSearch
{
    class Program
    {
        static void Main(string[] args)
        {

            var path = "yob2019.txt";
            LinkedList list = new LinkedList();

            string[] lines = File.ReadAllLines(path, Encoding.UTF8);
            foreach (string line in lines)
            {
                string[] lineitems = line.Split(',');
                MetaData metadata = new MetaData(lineitems[0], lineitems[1].ToCharArray()[0], Convert.ToInt32(lineitems[2]));
                list.Add(metadata);
                //create a temporary print function to test success?
            }



            //TO DO:

            //Search by name WEIGHTED (case insensitive)

            //Add item (require name, gender, and rank) WEIGHTED (case insensitive?) and if duplicate name prompt to add a _1 or cancel

            //See current count of all list items

            //See current count of list items based on gender, one for male and one for female

            //MENU FOR OPTIONS
        }
    }
}
