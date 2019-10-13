using System;
using System.Diagnostics;
using System.Timers;

namespace GCD_with_multiple_inputs
{
    public class FindGCD
    {
        public static int binary_gcd(int a, int b)
        {
            if (a == 0) // if a=0 then answer is b
                return b;
            if (b == 0) // if b=0 then answer is a
                return a;
            if (a == 1 || b == 1) // if a or b equals 1 then asnwer is 1
                return 1;
            if (a == b) // if a equals b then answer is a
                return a;
            if (a % 2 == 0 && b % 2 == 0) // if both are even then we can take outside 2
                return 2*binary_gcd(a / 2, b / 2);
            if (a % 2 == 0)
                return binary_gcd(a / 2, b); // if a is even then a divide by 2
            if (b % 2 == 0)
                return binary_gcd(a, b / 2); // if b is even then b divide by 2
            if (a > b)
                return binary_gcd((a - b) / 2, b); // if a>b then subtract and divide by 2
            if (a < b)
                return binary_gcd((b - a) / 2, a); // if a<b then subtract and divide by 2
            return -1; // just in case something goes wrong
        }

        public static int MyBinaryGCD(params int[] a)
        {

            int temp = a[0]; // need a temporary storage

            for (int i = 1; i < a.Length; i++) // loop through all elements
            {
                temp = binary_gcd(temp, a[i]); // find gcd one by one
            }

            return temp; // return final gcd
        }

        public static int gcd(int a, int b) // taken from https://habr.com/ru/post/205106
        {
            return (b == 0) ? Math.Abs(a) : gcd(b, a % b); // simply get gcd of two elements by recursively calling gcd and taking a remainder of the bigger 
        }

        public static int MyGCD(params int[] a)
        {

            int temp = a[0];

            for (int i=1; i<a.Length; i++)
            {
                temp = gcd(temp, a[i]);
            }
            
            return temp;
        }
        private static void Main(string[] args)
        {
            Console.WriteLine("Inputs are: 100, 50, 150");
            Stopwatch sw = Stopwatch.StartNew();
            Console.Write("multiple input GCD: {0}\t\t", MyGCD(100, 50, 150));
            sw.Stop();
            Console.WriteLine(" Time taken: {0}ms", sw.Elapsed.TotalMilliseconds);
            sw = Stopwatch.StartNew();
            Console.Write("multiple input binary GCD: {0}\t\t", MyBinaryGCD(100, 50, 150));
            sw.Stop();
            Console.WriteLine(" Time taken: {0}ms", sw.Elapsed.TotalMilliseconds);

        }
    }
}
