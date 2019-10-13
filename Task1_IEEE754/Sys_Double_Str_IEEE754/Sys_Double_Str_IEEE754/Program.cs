// header


namespace Sys_Double_Str_IEEE754
{
    using System;

    public class Program
    {
        public static string decimal2binary(string str)
        {
            int a = Convert.ToInt32(str);
            Console.WriteLine("decimal: {0}", a);
            int i = 0;
            string result = "";
            while (a > 0 && i < 30)
            {
                i++;
                result = Convert.ToString(a % 2) + result;
                a = a / 2;
            }

            return result;
        }

        public static string decimal2binary1(string str)
        {
            int a = Convert.ToInt32(str);
            int a_size = (int) Math.Pow(10, str.Length);
            int i = 0;
            string result = "";
            while (a != 0 & i < 10)
            {
                i++;
                a *= 2;
                if (a > a_size)
                {
                    result = result + "1";
                    a = a - a_size;
                }
                else
                {
                    result = result + "0";
                }
            }
 
            return result;
        }


        // summary
        // My Converter takes System.Double which is 52 bits (~15 decimals digits)
        // and has a range of +/-5.0 x 10^-324 to +/-1.7 x 10^308
        // converts it to string that is
        // /summary
        public static void MyConverter(double a)
        {
            Console.WriteLine(a);
            string str = Convert.ToString(Math.Abs(a));
            str.Replace(",", ".");
            int point_pos = str.IndexOf('.');
            int e_pos = (str.IndexOf('E') != -1) ? str.IndexOf('E') - 1 : str.Length - 1;
            string str_0 = (a > 0) ? "0" : "1";
            string str_1 = str.Substring(0, point_pos);
            string str_2 = str.Substring(point_pos + 1, str.Length - 1 - point_pos - (str.Length - 1 - e_pos));
            string str_3 = str.Substring(e_pos + 1, str.Length - 1 - e_pos);
            Console.WriteLine(str_0 + " " + str_1 + " " + str_2 + " " + str_3);

            string str_11 = decimal2binary(str_1);
            Console.WriteLine("str_1: " + str_1 + "\nstr_11: " + str_11);

            string str_21 = decimal2binary(Convert.ToString(127 + str_11.Length - 1));
            Console.WriteLine(str_21);

            string str_31 = decimal2binary1(str_2);



            Console.WriteLine(str_0 +" " + str_21 + " " + str_11 + " " + str_31);


        }

        // summary
        // My main
        // /summary
        private static void Main(string[] args)
        {
            MyConverter(263.3);//68.85);//
            Console.WriteLine("--------------------------");
            MyConverter(-255.255);
            Console.WriteLine("--------------------------");
          //  MyConverter(-263123456789123456789.3);
        }
    }
}
