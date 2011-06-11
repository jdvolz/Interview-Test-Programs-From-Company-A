/*
 * Author:  Joshua Volz
 * email:   jdvolz@gmail.com
 * cell:    909-957-4278
 * test:    Implementation of sine function
 * Date:    Sunday May 18th
 */

using System;

namespace sine
{
    class Sine
    {
        /// <summary>
        /// Main is used to test the function and compare it to the Math.Sin library function
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine(Math.Sin(Math.PI / 2)); //should be 1
            Console.WriteLine(sin(Math.PI / 2));
            Console.WriteLine(Math.Sin(Math.PI )); //should be 0
            Console.WriteLine(sin(Math.PI ));
            Console.WriteLine(Math.Sin(Math.PI * 3 / 2)); //should be -1
            Console.WriteLine(sin(Math.PI * 3 / 2));
            Console.WriteLine(Math.Sin(0)); //should be 0
            Console.WriteLine(sin(0));

            Console.WriteLine(Factorial(3)); //should be 6
            Console.WriteLine(Factorial(5)); //should be 120
            Console.WriteLine(Factorial(6)); //should be 720
        }

        /// <summary>
        /// sin implementation.
        /// 
        /// Note:  i in the for loop below is analogous to N in my discussion in the Word document.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static double sin(double x) { 
            //radians
            double result = 0;
            for (int i = 1; i < 7; i++) {
                result += Math.Pow(-1.0, i-1) * (Math.Pow(x, (2 * i - 1)) / Factorial(2 * i - 1));
            }
            return result;
        }

        /// <summary>
        /// Helper function that calculates the factorial of an int.
        /// 
        /// This function assumes an x of 1 or greater (we didn't throw an ArgumentException otherwise 
        /// because of time constrains)
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static int Factorial(int x) {
            int result = 1;
            for (int i = 1; i <= x; i++) { result *= i; }
            return result;
        }

    }
}
