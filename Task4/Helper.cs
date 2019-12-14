using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    public static class Helper
    {
        public static int SumOfElements(this int[] array)
        {
            int sum = 0;
            foreach (var item in array)
            {
                sum += item;
            }

            return sum;
        }

        public static double SumOfElements(this double[] array)
        {
            double sum = 0;
            foreach (var item in array)
            {
                sum += item;
            }

            return sum;
        }

        public static float SumOfElements(this float[] array)
        {
            float sum = 0;
            foreach (var item in array)
            {
                sum += item;
            }

            return sum;
        }

        public static decimal SumOfElements(this decimal[] array)
        {
            decimal sum = 0;

            foreach (var item in array)
            {
                sum += item;
            }

            return sum;
        }

        public static bool IsIntegerAndPositiveNumber(this string str)
        {
            int countOfZero = 0;

            for (int i = 0; i < str.Length; i++)
            {
                if (i == 0 && str[0] == '+')
                {
                    continue;
                }

                if (str[i] == '0')
                {
                    countOfZero++;
                }

                if (!char.IsNumber(str[i]) || countOfZero == str.Length)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
