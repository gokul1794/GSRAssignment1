using System;
using System.Collections;
using System.Collections.Generic;

namespace Assignment1_Spring2020
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 5;
            PrintPattern(n); //Time taken is 15 minutes

            int n2 = 7;
            PrintSeries(n2); //Time taken 5 minutes

            string s = "09:15:35PM";
            string t = UsfTime(s); //
            Console.WriteLine(t);

            int n3 = 110;
            int k = 11;
            UsfNumbers(n3, k);

            string[] words = new string[] { "abcd", "dcba", "lls", "s", "sssll" };
            PalindromePairs(words);

            int n4 = 19;
            Stones(n4);

        }

        /// <summary>
        /// This is a method that prints the pattern in the format as
        /// 3,2,1
        /// 2,1
        /// 1
        /// for the param n as 3.
        /// </summary>
        /// <param name="n">A natural number n, greater than 0 </param>
        private static void PrintPattern(int n)
        {
            try
            {
                if (n < 1) return;
                String pattern = "";
                for(int i = n; i > 0; i--)
                {
                    pattern = pattern + i;
                }
                Console.Write(pattern);
                Console.Write("\n");
                PrintPattern(n - 1);
            }
            catch
            {
                Console.WriteLine("Exception Occured while computing printPattern");
            }
        }

        /// <summary>
        /// Prints a Series till n terms where n is a natural number
        /// if n2 = 6, output will be 1,3,6,10,15,21
        /// </summary>
        /// <param name="n2">A natural number greater than 0</param>
        private static void PrintSeries(int n2)
        {
            try
            {
                if (n2 > 0)
                {
                    int[] series = new int[n2];
                    series[0] = 1;
                    Console.Write(1);
                    for (int i = 1; i < n2; i++)
                    {
                        //Sum of current = current iteration + sum of previous element in array
                        series[i] = i + series[i - 1] + 1;
                        Console.Write(", " + series[i]);
                    }
                    Console.Write("\n");
                }
                else
                {
                    Console.Write("Enter a number greater than 0");
                }
            }
            catch
            {
                Console.WriteLine("Exception Occured while computing printSeries");
            }
        }

        /// <summary>
        /// Converts time from earth format to USF format
        /// A string s with time in 12 hour clock format (i.e. hh:mm:ssAM or hh:mm:ssPM) where 01<= hh<=12, 00<=mm,ss,<=60
        /// Output format: a string with converted time in USF clock format(i.e.UU:SS:FF )
        /// where 01<= UU<=36, 00<=SS<=59,00<=FF<=45
        /// Logic for this method can be found here at
        /// https://www.inchcalculator.com/seconds-to-time-calculator/
        /// </summary>
        /// <param name="s">String in the format hh:mm:ssAM or hh:mm:ssPM</param>
        /// <returns>Returns a String with the time in USF format</returns>
        public static string UsfTime(string s)
        {
            string USF = "";
            try
            {
                string[] words = s.Split(':');      
                int hours = int.Parse(words[0]);
                int minutes = int.Parse(words[1]);
                bool PM = words[2].Contains("PM")?true:false;   //Check if the time is in PM
                int totalTimeinSeconds = 0;
                if (PM)
                {
                    if (hours == 12)
                        hours = 0;
                    totalTimeinSeconds = (hours * 60 * 60 + (12 * 60 * 60))     //Adding 12 hours if time is in PM
                        + (minutes * 60)
                        + int.Parse(words[2].Substring(0, 2));
                }
                else
                {
                    totalTimeinSeconds = (hours * 60 * 60)
                        + (minutes * 60)
                        + int.Parse(words[2].Substring(0, 2));
                }
                    double U = (double)totalTimeinSeconds / (double)2700;
                    double S = U - (int)(U);
                    double S1 = S * 60;
                    double F = S1 - (int)(S1);
                    double F1 = F * 45;
                    USF = (int)U + ":" + (int)S1 + ":" + string.Format("{0:0}", F1);
                    
            }
            catch
            {
                Console.WriteLine("Exception Occured while computing UsfTime, Enter in HH:MM:SSPM format");
            }
            return USF;
        }

        /// <summary>
        /// USF Numbers : This method prints the numbers 1 to 110, 11 numbers per line.
        /// The method shall print 'U' in place of numbers which are multiple of 3,"S" for 
        /// multiples of 5,"F" for multiples of 7, 'US' in place of numbers which are multiple 
        /// of 3 and 5,'SF' in place of numbers which are multiple of 5 and 7 and so on.
        /// </summary>
        /// <param name="n3">Total number of Integers to be printed.</param>
        /// <param name="k">Number of numbers per line</param>
        public static void UsfNumbers(int n3, int k)
        {
            try
            {
                for(int i = 1;i <= n3; i++)
                {
                    if (i % 3 == 0)
                    {
                        if (i % 5 == 0)
                        {
                            if (i % 7 == 0)
                            {
                                Console.Write("USF ");
                            }else
                                Console.Write("US ");
                        }
                        if (i % 7 == 0)
                        {
                            Console.Write("UF ");
                        }
                        else
                            Console.Write("U ");
                    }
                    else if(i % 5 == 0)
                    {
                        if (i % 7 == 0)
                        {
                            Console.Write("SF ");
                        }
                        else
                            Console.Write("S ");
                    }
                    else if (i % 7 == 0)
                        Console.Write("F ");
                    else
                    Console.Write(i + " ");
                    if (i%k == 0)
                    {
                        Console.Write("\n");
                    }
                }
            }
            catch
            {
                Console.WriteLine("Exception occured while computing UsfNumbers()");
            }
        }


        /// <summary>
        /// Finding palindromes in a list of strings by combining each string with every other string.
        /// </summary>
        /// <param name="words">A list of unique strings</param>
        public static void PalindromePairs(string[] words)
        {
            try
            {
                if (words.Length > 1) { 
                string pairs = "[";
                for(int i =0; i< words.Length; i++)
                {
                    for(int j = 0; j < words.Length; j++)
                    {
                        if (i != j)
                        {
                            string palindrome = words[i] + words[j];
                            //Reversing a string
                            string reverse = "";
                            int len = palindrome.Length - 1;
                            while (len >= 0)
                            {
                                reverse = reverse + palindrome[len];
                                len--;
                            }
                            if (palindrome == reverse)
                            {
                                pairs = pairs + "[" + i+ ","+ j +"]";
                            }
                        }
                    }
                }
                Console.WriteLine(pairs + "]");
                }
                else
                {
                    Console.WriteLine("Length of array should be at least 2");
                }
            }
            catch
            {

                Console.WriteLine("Exception occured while computing PalindromePairs()");
            }
        }


        /// <summary>
        /// A Game of stones where each user picks between 1 to 3 stones,
        /// the last person to pick the stone wins.
        /// </summary>
        /// <param name="n4">Total number of stones in the game.</param>
        public static void Stones(int n4)
        {
            try
            {
                //You always lose if the number of stones is a multiple of 4 at your turn.
                if (n4 % 4 == 0)
                {
                    Console.WriteLine("You lose");
                }
                else
                {
                    int take = 0;
                    if (n4 > 0 && n4%4!=0)
                    {
                        take = n4 % 4;
                        n4 = n4 - take;
                        Console.WriteLine("You win!");
                        Console.Write("["+take);
                    }

                    int totalpairs = n4 / 4; //Total number of turns/2
                    int[] loser = new int[] { 1, 2, 3 };
                    Random r = new Random();
                    int[] values = new[] { 1, 2, 3 };
                    while (totalpairs > 0)
                    {
                        int result = values[r.Next(values.Length)];
                        Console.Write(","+result+",");
                        int me = 4 - result;
                        Console.Write(me);
                        totalpairs--;
                    }
                    Console.Write("]");
                }
            }
            catch
            {
                Console.WriteLine("Exception occured while computing Stones()");
            }
        }
    }
}

