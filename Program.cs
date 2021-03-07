using System;

namespace ManakersAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(LongestPalindrome("автомобиль"));
        }

        public static string LongestPalindrome(string s)
        {
            char[] arrayOfCentres = new char[s.Length * 2 + 1];
            for (short i = 0; i != s.Length; ++i)
            {
                arrayOfCentres[i * 2 + 1] = s[i];
            }

            int[] radOfPal = new int[arrayOfCentres.Length];
            int rightBorder = 0;
            int centrOfPal = 0;
            int index = 0;
            int i_mir = 0;
            int maxLen = 1;

            for (int i = 1; i != arrayOfCentres.Length - 1; ++i)
            {
                i_mir = 2 * centrOfPal - i;
                radOfPal[i] = rightBorder > i ? Math.Min(radOfPal[i_mir], rightBorder - i) : 0;

                while ((i > radOfPal[i]) && ((i + radOfPal[i] + 1) < arrayOfCentres.Length) && (arrayOfCentres[i - radOfPal[i] - 1] == arrayOfCentres[i + radOfPal[i] + 1]))
                {
                    ++radOfPal[i];
                }

                if (radOfPal[i] + i > rightBorder)
                {
                    centrOfPal = i;
                    rightBorder = i + radOfPal[i];
                }

                if (maxLen < radOfPal[i])
                {
                    maxLen = radOfPal[i];
                    index = i;
                }
            }
            return s.Substring((index - maxLen) / 2, maxLen);
        }
    }
}
