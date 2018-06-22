using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDUDecomposition
{
    class Program
    {
        static void Main(string[] args)
        {
            BigFraction temp = new BigFraction("2/4");
            BigFraction[,] a = { { new BigFraction("1/1"), new BigFraction("2/1"), new BigFraction("2/1") },
                                 { new BigFraction("3/1"), new BigFraction("-2/1"), new BigFraction("1/1") },
                                 { new BigFraction("2/1"), new BigFraction("1/1"), new BigFraction("-1/1") } };
            BigFraction[] b = { new BigFraction("5/1"), new BigFraction("-6/1"), new BigFraction("-1/1") };

            LDUSolver solver = new LDUSolver(a,b,3);

            BigFraction[] answer = solver.GetResult();
            for(int i = 0; i < 3; i++)
            {
                Console.WriteLine(answer[i]);
            }
            Console.ReadLine();
        }
    }
}
