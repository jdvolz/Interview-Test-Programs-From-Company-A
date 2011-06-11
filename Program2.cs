using System;
using System.Collections.Generic;
using System.Text;

namespace Multiply_Except {
    class Program {
        static void Main(string[] args) {
            int[] a = new int[] { 3, 5, 7, 10 };
            int[] b = new int[] { 0, 1, 2, 3 };
            int[] c = new int[] { 3, 2, 1, 0 };
            int[] oneZero = new int[] { 3, 5, 7, 0 };
            int[] twoZero = new int[] { 0, 5, 7, 0 };
            Console.WriteLine(String.Format("{0} {1}", toPrint(a), toPrint(op(a, b))));
            Console.WriteLine(String.Format("{0} {1}", toPrint(oneZero), toPrint(op(oneZero, b))));
            Console.WriteLine(String.Format("{0} {1}", toPrint(twoZero), toPrint(op(twoZero, b))));
            Console.WriteLine(String.Format("{0} {1}", toPrint(a), toPrint(op(a, c))));
            Console.WriteLine(String.Format("{0} {1}", toPrint(oneZero), toPrint(op(oneZero, c))));
            Console.WriteLine(String.Format("{0} {1}", toPrint(twoZero), toPrint(op(twoZero, c))));

        }

        static string toPrint(int[] a) {
            StringBuilder sb = new StringBuilder();
            foreach (int i in a)
                sb.Append(i + " ");
            return sb.ToString();
        }

        static int[] op(int[] a, int[] b) {
            int[] res = new int[a.Length];
            int zeroCount = 0;
            int zeroPosition = -1;
            for (int i = 0; i < a.Length; i++)
                if (a[i] == 0) {
                    zeroCount++;
                    zeroPosition = i;
                }
            for (int i = 0; i < a.Length; i++) res[i] = 0;
            if (zeroCount == 0) {
                int total = 1;
                for (int i = 0; i < a.Length; i++) total *= a[i];
                for (int i = 0; i < a.Length; i++) res[i] = total / a[b[i]];
            } else if (zeroCount == 1) {
                int nonZeroTotal = 1;
                for (int i = 0; i < a.Length; i++)  if (a[i] != 0) nonZeroTotal *= a[i];                    
                for (int i = 0; i < a.Length; i++) if (b[i] == zeroPosition) res[i] = nonZeroTotal;
            }   
            return res;
        }
    }
}
