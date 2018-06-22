using System;
using System.Numerics;

namespace LDUDecomposition
{
    /// <summary>
    /// Class to represent large number in fraction format to entact efficieny. 
    /// The number can be divided into the numerator and denominator which is separated by "/".
    /// Both numerator and denominator are BigInteger objects.
    /// </summary>
    public class BigFraction
    {
        private BigInteger numerator;
        private BigInteger denominator;

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
        public BigFraction Add(BigFraction b)
        {
            BigInteger numeratorB = GetNumerator(b.ToString());
            BigInteger denominatorB = GetDenominator(b.ToString());

            BigInteger lcm = GetLCM(this.denominator, denominatorB);
            BigInteger finalNumerator = this.numerator * (lcm / this.denominator) +
                                        numeratorB * (lcm / denominatorB);
            
            BigFraction result = new BigFraction(finalNumerator.ToString()+"/"+lcm.ToString());
            return GetSimplestForm(result);

        }
        
        /// <summary>
        /// Method to subtract two BigFraction datatypes
        /// </summary>
        /// <param name="b">BigFraction being subtracted from current BigFraction</param>
        /// <returns>result of subtraction in its simplest form</returns>
        public BigFraction Subtract(BigFraction b)
        {
            BigInteger numeratorB = GetNumerator(b.ToString());
            BigInteger denominatorB = GetDenominator(b.ToString());

            BigInteger lcm = GetLCM(this.denominator, denominatorB);
            BigInteger finalNumerator = this.numerator * (lcm / this.denominator) -
                                        numeratorB * (lcm / denominatorB);

            BigFraction result = new BigFraction(finalNumerator.ToString() + "/" + lcm.ToString());

            return GetSimplestForm(result);
        }

        /// <summary>
        /// Method to multiply two BigFraction datatypes
        /// </summary>
        /// <param name="b">BigFraction being multiplied from current BigFraction</param>
        /// <returns>result of multiplication in its simplest form</returns>
        public BigFraction Multiply(BigFraction b)
        {
            BigInteger numeratorB = GetNumerator(b.ToString());
            BigInteger denominatorB = GetDenominator(b.ToString());

            BigInteger finalNumerator = this.numerator * numeratorB;
            BigInteger finalDenominator = this.denominator * denominatorB;

            BigFraction result = new BigFraction(finalNumerator.ToString()+"/"+ finalDenominator.ToString());

            return GetSimplestForm(result);
        }

        /// <summary>
        /// Method to divide two BigFraction objects
        /// </summary>
        /// <param name="b">BigFraction object being divided from the current object</param>
        /// <returns>result of division in its simplest form</returns>
        public BigFraction Divide(BigFraction b)
        {
            /*When you divide a fraction by another fraction we multiply the dividend by the reciprocal of the divisor
             * So, we will multiply the numerator of a with denominator of b and denominator of a with numerator of b
             */
            BigInteger numeratorB = GetNumerator(b.ToString());
            BigInteger denominatorB = GetDenominator(b.ToString());

            //Negate the numerator and denominator if numerator is negative
            if(numeratorB.Sign == -1)
            {
                numeratorB = -numeratorB;
                denominatorB = -denominatorB;
            }

            BigInteger finalNumerator = BigInteger.One;
            BigInteger finalDenominator = BigInteger.One;
            
            if (numeratorB.IsZero)
            {
                finalNumerator = BigInteger.Zero;
                finalDenominator = BigInteger.One;
            }
            else
            {
                finalNumerator = this.numerator * denominatorB;
                finalDenominator = this.denominator * numeratorB;
            }
            BigFraction result = new BigFraction(finalNumerator.ToString() + "/" + finalDenominator.ToString());
            return GetSimplestForm(result);
        }
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

        /// <summary>
        /// Method to get the fraction in its simplest form
        /// </summary>
        /// <param name="frac"></param>
        /// <returns></returns>
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
