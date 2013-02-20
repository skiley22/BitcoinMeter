using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JSONreader;

namespace Debug
{
    class Program
    {
        static void Main(string[] args)
        {
            var ser = new Serializer();
            Console.WriteLine(ser.getString());
            Console.ReadLine();

        }
    }
}
