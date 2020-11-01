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

            }
            //Console.WriteLine(list.head.data.name);
            //Console.WriteLine(list.tail.data.name);
            //Console.WriteLine("done");
            //Console.ReadLine();

            bool menu = true;
            while (menu)
            {
                Console.WriteLine("Pick an option by entering a number:\n");
                Console.WriteLine("1. Search by name");
                Console.WriteLine("2. Add a name");
                Console.WriteLine("3. See total list count");
                Console.WriteLine("4. See list count by gender");
                Console.WriteLine("5. Quit\n");
                switch(Convert.ToInt32(Console.ReadLine()))
                {
                    case 1:
                        // add search here
                        break;
                    case 2:
                        Console.WriteLine("Enter a name to add:");
                        string n = Console.ReadLine();
                        Console.WriteLine("Enter their gender:");
                        char g = Console.ReadLine().ToCharArray()[0];
                        Console.WriteLine("Enter their rank:");
                        int r = Convert.ToInt32(Console.ReadLine());
                        MetaData metadata = new MetaData(n, g, r);
                        list.Add(metadata);
                        Console.WriteLine("You added " + n + " to the list.\n");
                        break;
                    case 3:
                        int count = list.PrintCount();
                        Console.WriteLine("Total count of names in list: " + count + "\n");
                        break;
                    case 4:
                        Console.WriteLine("Print a count of men or women? Enter M/W");
                        string input = Console.ReadLine().ToUpper();
                        int countg;
                        if (input == "M")
                        {
                            countg = list.PrintCountMale();
                            Console.WriteLine("Total count of men in list: " + countg + "\n");
                        }
                        if (input == "W")
                        {
                            countg = list.PrintCountFemale();
                            Console.WriteLine("Total count of women in list: " + countg + "\n");
                        }
                        break;
                    case 5:
                        menu = false;
                        break;
                }
            }


            //TO DO:

            //Search by name WEIGHTED (case insensitive)

            //xx Add item (require name, gender, and rank) WEIGHTED (case insensitive?) and if duplicate name prompt to add a _1 or cancel

            //xx See current count of all list items

            //xx See current count of list items based on gender, one for male and one for female

            //MENU FOR OPTIONS
        }
    }
}
