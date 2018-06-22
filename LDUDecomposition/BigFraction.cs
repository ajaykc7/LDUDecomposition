using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace LDUDecomposition
{
    public class BigFraction
    {
        private BigInteger numerator;
        private BigInteger denominator;

        private BigInteger zero = new BigInteger(0);
        private BigInteger one = new BigInteger(1);

        public BigFraction(string fraction)
        {
            numerator = GetNumerator(fraction);
            denominator = GetDenominator(fraction);
        }

        /// <summary>
        /// Method to add the two BigFraction datatypes
        /// </summary>
        /// <param name="b">BigFraction being added to the current BigFraction</param>
        /// <returns>result of the addition in the simplest form</returns>
        /*
        public BigFraction Add(BigFraction b)
        {
            BigInteger numeratorB = GetNumerator(b.ToString());
            BigInteger denominatorB = GetDenominator(b.ToString());

            BigInteger lcm = GetLCM(this.denominator, denominatorB);
            BigInteger finalNumerator = this.numerator * (lcm / this.denominator) +
                                        numeratorB * (lcm / denominatorB);
            
            BigFraction result = finalNumerator.ToString()+"/"+lcm.ToString();
            return GetSimplestForm(result);

        }*/
        
        /// <summary>
        /// Method to get the numerator of the BigFraction
        /// </summary>
        /// <param name="fraction"></param>
        /// <returns></returns>
        private BigInteger GetNumerator(string fraction)
        {
            return new BigInteger(Int64.Parse(fraction.Substring(0, fraction.IndexOf("/"))));
        }

        /// <summary>
        /// Method to get the denominator of the BigFraction
        /// </summary>
        /// <param name="fraction"></param>
        /// <returns></returns>
        private BigInteger GetDenominator(string fraction)
        {
            return new BigInteger(Int64.Parse(fraction.Substring(fraction.IndexOf("/")+1)));
        }

        /// <summary>
        /// Method overridden to convert the BigFraction to string
        /// </summary>
        /// <returns>String representation of the BigFraction type</returns>
        public override string ToString()
        {
            return numerator.ToString() + "/" + denominator.ToString();
        }

        /// <summary>
        /// Method to return the LCM of two BigIntegers
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        private BigInteger GetLCM(BigInteger a, BigInteger b)
        {
            return (a * b)/GetGCF(a,b);
        }
        
        /// <summary>
        /// Method to return the Greatest Common Factor of two BigIntegers
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        private BigInteger GetGCF(BigInteger a, BigInteger b)
        {
            return b.IsZero ? BigInteger.Abs(a) : GetGCF(b, a%b);
        }

        private BigFraction GetSimplestForm(BigFraction frac)
        {
            BigInteger num = GetNumerator(frac.ToString());
            BigInteger deno = GetDenominator(frac.ToString());
            BigInteger gcf = GetGCF(num, deno);

            while (!gcf.IsOne)
            {
                num = num / gcf;
                deno = deno / gcf;
                gcf = GetGCF(num, deno);
            }

            return new BigFraction(num.ToString() + "/" + deno.ToString());
        }
    }
}
