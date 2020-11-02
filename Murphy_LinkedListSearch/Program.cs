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

            bool menu = true;
            while (menu)
            {
                Console.WriteLine("Pick an option by entering a number:\n");
                Console.WriteLine("1. Search by name");
                Console.WriteLine("2. Add a name");
                Console.WriteLine("3. See total list count");
                Console.WriteLine("4. See list count by gender");
                Console.WriteLine("5. Find most popular name");
                Console.WriteLine("6. Quit\n");
                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 1:
                        Console.WriteLine("Enter a name to search:");
                        Node searched = list.Search(Console.ReadLine());
                        if (searched == null)
                        {
                            Console.WriteLine("There is no such name in the list\n");
                        }
                        else
                        {
                            Console.WriteLine(searched.data.name + " is in the list\n");
                        }
                        break;
                    case 2:
                        Console.WriteLine("Enter a name to add:");
                        string n = Console.ReadLine();
                        Console.WriteLine("Enter their gender (M/F):");
                        char g = Console.ReadLine().ToUpper().ToCharArray()[0];
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
                        Console.WriteLine("Print a count of men or women? Enter M/F");
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
                        Node popular = list.Popular();
                        string output = "The most popular name is " + popular.data.name + ", a ";
                        if (popular.data.gender == 'M')
                            output += "male name";
                        else
                            output += "female name";
                        output += " at rank " + popular.data.rank + "\n";
                        Console.WriteLine(output);
                        break;
                    case 6:
                        menu = false;
                        break;
                }
            }
        }
    }
}
