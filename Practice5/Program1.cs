using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZapMas2
{
    class Program
    {
        static void Main(string[] args)
        {
            int strings = 8;
            int columns = 8;
            int[,] mas = new int[strings, columns];
            int el = 1;
            int curString = 0, curColumn = 0;
            do
            {
                while (curColumn >= 0 && curString < strings)
                {
                    mas[curString, curColumn] = el;
                    el++;
                    curString++;
                    curColumn--;
                }
                curColumn++;
                if (curString == strings)
                {
                    curColumn++;
                    curString--;
                }
                if (el > strings * columns)
                    break;
                while (curString >= 0 && curColumn < columns)
                {
                    mas[curString, curColumn] = el;
                    el++;
                    curString--;
                    curColumn++;
                }
                curString++;
                if (curColumn == columns)
                {
                    curColumn--;
                    curString++;
                }

            } while (el <= strings * columns);

            for (int i = 0; i < strings; i++)
            {
                for (int j = 0; j < columns; j++)
                    Console.Write("{0,5}", mas[i, j]);
                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }
}
