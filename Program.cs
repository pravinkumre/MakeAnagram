using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp16_makeAnagram
{
    class Program
    {
        static void Main(string[] args)
        {
            //string inp1 = "fcrxzwscanmligyxyvym", inp2 = "FVjxwtrhvujlmrpdoqbisbwhmgpmeoke";
            //Console.WriteLine("No of deletions : " + makeAnagram(inp1, inp2)); //o/p : 30

            //List<string> strLst = new List<string> { "AAAA", "BBBBB", "ABABABAB", "BABABA", "AAABBB" };
            //foreach (var str in strLst)
            //{
            //    Console.WriteLine("No of deletions : " + alternatingCharacters(str)); //o/p : 3 4 0 0 4
            //}

            //Console.WriteLine("IsValid : " + isValid("abcdefghhgfedecba")); // o/p YES

            //Console.WriteLine("IsValid : " + isValid("aabbcd")); // o/p NO

            rotLeft(new int[] { 1, 2, 3, 4, 5 }, 4); //o/p : 5 1 2 3 4  /Note: 4 is no. of left rotations

           // rotLeft(new int[] { 5, 1, 3, 4, 2 }, 2); //o/p : 3 4 2 5 1  /Note: 2 is no. of left rotations
        }

        readonly static int CHARS = 26;
        // Complete the makeAnagram function below.
        static int makeAnagram(string a, string b)
        {
            //It's cumpulsory to make lower
            a = a.ToLower();
            b = b.ToLower();
            int[] arr = new int[CHARS];
            for (int i = 0; i < a.Length; i++)
            {
                arr[a[i] - 'a']++;
            }

            for (int i = 0; i < b.Length; i++)
            {
                arr[b[i] - 'a']--;
            }

            int ans = 0;
            for (int i = 0; i < CHARS; i++)
            {
                ans += Math.Abs(arr[i]);
            }
            return ans;

        }
        public static int alternatingCharacters(string s)
        {
            int numOfDeletions = 0;
            char old = 'X', nextChar = 'X';
            for (int i = 0; i < s.Length; i++)
            {
                if (old != s[i])
                    old = s[i];
                else
                    continue;

                if (i == s.Length - 1)
                    continue;
                else
                    nextChar = s[i + 1];

                if (s[i] == nextChar)
                {
                    numOfDeletions++;

                    for (int j = i + 2; j < s.Length; j++)
                    {
                        if (s[i] == s[j])
                        {
                            numOfDeletions++;
                        }
                        else
                            break;
                    }
                }
            }
            return numOfDeletions;
        }

        public static string isValid(string s)
        {
            string isvalid = "NO";
            Dictionary<char, int> dict = new Dictionary<char, int>();
            char[] chrArr = s.ToLower().ToCharArray();
            Array.Sort(chrArr);
            foreach (char c in chrArr)
            {

                if (!dict.ContainsKey(c))
                    dict.Add(c, 1);
                else
                    dict[c] = dict[c] + 1;
            }

            var distnct = dict.Values;

            if (distnct.Count() == 1)
                isvalid = "YES";
            if (distnct.Count() == 2)
            {
                if (distnct.Max() - distnct.Min() == 1)
                    isvalid = "YES";
            }

            return isvalid;
        }

        public static void rotLeft(int[] a, int d)
        {
            int[] newArr = new int[a.Length];
            int[] tempArr = new int[d];
            int[] tempArr2 = new int[a.Length - d];
            for (int i = 0; i < d; i++)
            {
                tempArr[i] = a[i];
            }
            for (int i = 0; i < a.Length - d; i++)
            {
                tempArr2[i] = a[d + i];
            }

            newArr = tempArr2.Concat(tempArr).ToArray();

            Console.WriteLine();
        }

    }
}
