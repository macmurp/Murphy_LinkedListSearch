using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Murphy_LinkedListSearch
{
    class MetaData
    {
        protected string _name;
        protected char _gender;
        protected int _rank;
        public string name { get { return _name; } set { _name = value; } }
        public char gender { get { return _gender; } set { _gender = value; } }
        public int rank { get { return _rank; } set { _rank = value; } }

        public MetaData(string n, char g, int r)
        {
            name = n;
            gender = g;
            rank = r;
        }
    }
}
