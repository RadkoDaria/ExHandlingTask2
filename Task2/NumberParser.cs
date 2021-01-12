using System;
using System.Linq;

namespace Task2
{
    public class NumberParser : INumberParser
    {
        public int Parse(string str)
        {

            if (str == null)
            {
                throw new ArgumentNullException(nameof(str));
            }
            if (string.IsNullOrWhiteSpace(str))
            { throw new FormatException("Input string with digits only"); }

            str = str.Trim();
            bool isNegative = (str[0] == '-');
            if (isNegative || str[0] == '+')
            {
                str = str.Substring(1);
            }
            if (ContainsOnlyDigits(str))
            {
                int result = 0;
                int power = str.Length - 1;

                foreach (char c in str)
                {
                    try
                    {
                        checked
                        {

                            if (isNegative)
                            {
                                result -= (c - 48) * (int)Math.Pow(10, power);
                            }
                            else
                            {
                                result += (c - 48) * (int)Math.Pow(10, power);
                            }
                            power--;
                        }
                    }
                    catch (OverflowException e)
                    {
                        throw new OverflowException("The input value was too big or too smal for int.", e);
                    }
                }

                return result;
            }
            else
            {
                throw new FormatException("Input string with digits only");
            }


        }
        private bool ContainsOnlyDigits(string str)
        {
            return str.All(s => char.IsDigit(s));
        }
    }
}