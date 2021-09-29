using System;

namespace TretiaHodina
{
    class Program
    {

        [Flags]
        public enum ParseIntOption
        {
            NONE = 0,
            ALLOW_WHITESPACES = 1,
            ALLOW_NEGATIVE_NUMBERS = 2,
            IGNORE_INVALID_CHARS = 4
        }

        static void Main(string[] args)
        {

            while (true)
            {
                Console.WriteLine("Zadajte číslo : \n");
                string my_num = Console.ReadLine();

                //  1.
                //int new_num = ParseInt( my_num);


                //2.
                /*int? new_num;
                ParseIntOrNull( my_num,out new_num);*/
                /*if (new_num == null)
                    Console.WriteLine("It is NULL");
                else
                    Console.WriteLine(new_num);*/

                //Console.WriteLine("vase cislo: " + (new_num?.ToString() ?? "It is NULL"));

                //3.

                /* if(TryParseInt(my_num, out int val))
                 {
                     Console.WriteLine("Zadane cislo :" + val);
                 }
                 else
                 {
                     Console.WriteLine("Neni cislo");
                 }*/

                //4,
                if(TryParseInt2(my_num, (ParseIntOption.ALLOW_WHITESPACES | ParseIntOption.IGNORE_INVALID_CHARS),out int value))
                {
                    Console.WriteLine(value);
                }
                else
                {
                    Console.WriteLine("nic");
                }

            }

        }
       

        public static bool TryParseInt2(string my_num, ParseIntOption options, out int value)
        {

            if((options & ParseIntOption.ALLOW_WHITESPACES) == ParseIntOption.ALLOW_WHITESPACES)
            {
                Console.WriteLine("whitespaces mam");
            }

            value = 0;

            if (my_num == null) { return false; }

            int tmp = 0;
            for (int i = 0; i < my_num.Length; i++)
            {
                tmp *= 10;
                char c = my_num[i];
                int cNum = (int)c;
                cNum = cNum - 48;
                if (cNum < 0) { return false; }
                if (cNum > 9) { return false; }
                tmp += cNum;
            }

            value = tmp;
            return true;
        }

        static public bool TryParseInt(string my_num, out int value)
        {
            value = 0;

            if (my_num == null) { return false; }

            int tmp = 0;
            for (int i = 0; i < my_num.Length; i++)
            {
                tmp *= 10;
                char c = my_num[i];
                int cNum = (int)c;
                cNum = cNum - 48;
                if (cNum < 0) { return false; }
                if (cNum > 9) { return false; }
                tmp += cNum;
            }

            value = tmp;
            return true;
        }

        static public void ParseIntOrNull(string my_num, out int? new_num)
        {
            if (my_num == null) { new_num = null; return; }

            int tmp = 0;
            for (int i = 0; i < my_num.Length; i++)
            {
                tmp *= 10;
                char c = my_num[i];
                int cNum = (int)c;
                cNum = cNum - 48;
                if (cNum < 0) { new_num = null; return; }
                if (cNum > 9) { new_num = null; return; }

                tmp += cNum;

            }

            new_num = tmp;
        }

        static public int ParseInt(string my_num)
        {
            /* int new_num;
             try
             {
                 new_num = int.Parse(my_num);
             }
             catch (FormatException e)
             {
                 new_num = -1;
             }*/
            if (my_num == null) { return -1; }

            int tmp = 0;
            for (int i = 0; i < my_num.Length; i++)
            {
                tmp *= 10;
                char c = my_num[i];
                int cNum = (int)c;
                cNum = cNum - 48;
                if (cNum < 0) { return -1; }
                if (cNum > 9) { return -1; }

                tmp += cNum;

            }


            return tmp;
        }
    }
}
