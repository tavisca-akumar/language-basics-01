using System;

namespace Tavisca.Bootcamp.LanguageBasics.Exercise1
{
    class Program
    {
        static void Main(string[] args)
        {
            Test("42*47=1?74", 9);
            Test("4?*47=1974", 2);
            Test("42*?7=1974", 4);
            Test("42*?47=1974", -1);
            Test("2*12?=247", -1);
            Console.ReadKey(true);
        }

        private static void Test(string args, int expected)
        {
            var result = FindDigit(args).Equals(expected) ? "PASS" : "FAIL";
            Console.WriteLine($"{args} : {result}");
        }

        public static int FindDigit(string equation)
        {
            string a = "";
            string b = "";
            string c = "";
            int x = 0, y = 0;
            int flag = 0;

            for (int i = 0; i < equation.Length; i++)
            {
                if (equation[i] == '*')
                {
                    break;
                }
                if (equation[i] == '?')
                {
                    flag = 1;
                }
                a = a + equation[i];
            }

            for (int i = 0; i < equation.Length; i++)
            {
                if (equation[i] == '*')
                {
                    x = i;
                }
                if (equation[i] == '=')
                {
                    y = i;
                }
            }

            for (int i = x + 1; i < y; i++)
            {
                if (equation[i] == '?')
                {
                    flag = 2;
                }
                b = b + equation[i];
            }
            for (int i = y + 1; i < equation.Length; i++)
            {
                c = c + equation[i];
                if (equation[i] == '?')
                {
                    flag = 3;
                }
            }
            //System.out.println(a+" "+b+" "+c);
            if (flag == 1)
            {
                int B = Int32.Parse(b);
                int C = Int32.Parse(c);
                int ans = C / B;
                String aa = ans.ToString();

                if (B * ans != C || (aa.Length != x))
                {
                    return -1;
                }
                else
                {
                    for (int i = 0; i < x; i++)
                    {
                        if (aa[i] != equation[i])
                        {
                            //System.out.println(aa.charAt(i));
                            int m = (int)(aa[i] - '0');
                            return m;
                        }
                    }
                }
            }
            if (flag == 2)
            {
                int A = Int32.Parse(a);
                int C = Int32.Parse(c);
                int ans = C / A;
                String aa = ans.ToString();

                if (A * ans != C || (aa.Length != (y - x - 1)))
                {
                    return -1;
                }
                else
                {
                    for (int i = x + 1; i < y; i++)
                    {
                        if (aa[i - (x + 1)] != equation[i])
                        {
                            int m = (int)(aa[i - (x + 1)] - '0');
                            return m;
                        }
                    }
                }
            }
            if (flag == 3)
            {
                int A = Int32.Parse(a);
                int B = Int32.Parse(b);
                int ans = A * B;
                String aa = ans.ToString();


                for (int i = y + 1; i < equation.Length; i++)
                {
                    if (aa[i - (y + 1)] != equation[i])
                    {
                        int m = (int)(aa[i - (y + 1)] - '0');
                        return m;
                    }
                }
            }
            return -1;
            throw new NotImplementedException();
        }
    }
}
