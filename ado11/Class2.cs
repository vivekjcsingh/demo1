using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ado11
{
    class classA
    {
        
        
       
    }
    class Class2
    { 
        public void display2()
        {
            for (int j = 0; j < 10; j++)
            {
                Console.WriteLine("b" + j);
            }
        }
        public void display1()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("a" + i);
            }
        }
        static void Main()
        {
            Class2 obj = new Class2();
            ThreadStart tr = new ThreadStart(obj.display1);
            ThreadStart te = new ThreadStart(obj.display2);
            Thread t1 = new Thread(tr);
            Thread t2 = new Thread(te);
            t1.Start();
            t2.Start();


            Console.ReadLine();

        }
       
    }
}
