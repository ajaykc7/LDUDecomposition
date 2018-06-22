using System;

public class BigFraction
{
    private BigInteger numerator;
    private BigInteger denominator;

    private const BigInteger zero = new BigInteger("0");
    private const BigInteger one = new BigInteger("1");

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


    }

	/// <summary>
    /// Method to get the numerator of the BigFraction
    /// </summary>
    /// <param name="fraction"></param>
    /// <returns></returns>
	private BigInteger GetNumerator(string fraction)
    {
        return new BigInteger(fraction.Substring(0, fraction.IndexOf("/")));
    }

	/// <summary>
    /// Method to get the denominator of the BigFraction
    /// </summary>
    /// <param name="fraction"></param>
    /// <returns></returns>
	private BigInteger GetDenominator(string fraction)
    {
        return new BigInteger(fraction.Substring(fraction.IndexOf("/"), fraction.Length));
    }

	/// <summary>
    /// Method overridden to convert the BigFraction to string
    /// </summary>
    /// <returns>String representation of the BigFraction type</returns>
    public override string ToString()
    {
        return numerator.ToString() + "/" + denominator.ToString();
    }

	private BigInteger GetLCM(BigInteger a, BigInteger b)
    {
        BigInteger min = a < b ? a : b;

        BigInteger max = a >= b ? a: b;

        if (max.mod(min) == 0)
        {
            return max;
        }
    }

	private BigInteger GetGCF(BigInteger a, BigInteger b)
    {
		if(a.)
    }
}