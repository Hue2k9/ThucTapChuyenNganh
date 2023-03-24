namespace Bai_1
{
    internal class Program
    {
        public class Solution
        {
            /*
             Given an input string s and a pattern p, implement regular expression matching with support for '.' and '*' where:

'.' Matches any single character.​​​​
'*' Matches zero or more of the preceding element.
The matching should cover the entire input string (not partial).
             */
            public bool IsMatch(string s, string p)
            {
                if (string.IsNullOrEmpty(p))
                {
                    return string.IsNullOrEmpty(s);
                }

                bool firstMatch = !string.IsNullOrEmpty(s) && (p[0] == s[0] || p[0] == '.');

                if (p.Length >= 2 && p[1] == '*')
                {
                    return IsMatch(s, p.Substring(2)) || (firstMatch && IsMatch(s.Substring(1), p));
                }
                else
                {
                    return firstMatch && IsMatch(s.Substring(1), p.Substring(1));
                }
            }
        }

        static void Main(string[] args)
        {
            Solution a = new Solution();
            Console.WriteLine(a.IsMatch("aa","a*"));
        }
    }
}