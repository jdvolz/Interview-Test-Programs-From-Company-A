using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace html_unicode {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine(String.Format("{0} {1}", "html", replace("html")));
            Console.WriteLine(String.Format("{0} {1}", "&#", replace("&#")));
            Console.WriteLine(String.Format("{0} {1}", "&#;", replace("&#;")));
            Console.WriteLine(String.Format("{0} {1}", "&#100;", replace("&#100;")));
            Console.WriteLine(String.Format("{0} {1}", "&#100&#120;", replace("&#100&#120;")));
            Console.WriteLine(String.Format("{0} {1}", "&#ABC;", replace("&#ABC;")));
            Console.WriteLine(String.Format("{0} {1}", "&#20", replace("&#20")));
            Console.WriteLine(String.Format("{0} {1}", "&", replace("&")));
            Console.WriteLine(String.Format("{0} {1}", "&#100; B &#100;", replace("&#100; B &#100;")));
            Console.WriteLine(String.Format("{0} {1}", "<html>&#100;</html>", replace("<html>&#100;</html>")));


        }

        static string replace(string html) {
            StringBuilder sb = new StringBuilder(html.Length);
            for (int pos = 0; pos < html.Length; pos++) {
                if ('&' == html[pos] &&
                    pos + 1 < html.Length &&
                    '#' == html[pos + 1]) {
                    string temp = "&#";
                    int offset = 2;
                    while (pos + offset < html.Length && html[pos + offset] != ';') {
                        temp += html[pos + offset];
                        offset++;
                    }
                    if (pos+offset < html.Length && html[pos + offset] == ';') {
                        temp += ";";
                    }
                    char c = toCh(temp);
                    if ('\0' == c) {
                        sb.Append(html[pos]);                        
                    } else {
                        sb.Append(c);
                        pos += offset;
                    }
                } else {
                    sb.Append(html[pos]);
                }
            }
            return sb.ToString();        
        }

        static char toCh(string s) {
            if (Regex.IsMatch(s, "^&#\\d+;$"))
                return 'A';
            else
                return '\0';
        }
    }
}
