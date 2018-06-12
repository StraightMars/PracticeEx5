using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Заполнение_по_диагонали
{
    class Program
    {
        /* 
         * do
         * {
         * Спуститься вниз на 1
         * Пройти по диагонали вверх
         * Если можно
         *      пройти вправо
         *  Иначе 
         *       пройти вниз
         * Пройти вниз
         * Если можно 
         *       пройти вправо
         *   Иначе
         *       пройти вниз        *                 
         * while (не все элементы заполнены) 
         */

        //Ввод натурального числа
        private static int InputIntNNumber()
        {
            bool ok;
            int number;
            do
            {
                string buf = Console.ReadLine();
                ok = Int32.TryParse(buf, out number);
                if ((!ok) || (number <= 0))
                {
                    Console.WriteLine("Введите натуральное число");
                    ok = false;
                }
            } while (!ok);

            return number;
        }


        private static void OutputArray(int[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write("{0,4}", arr[i, j]);

                }
                Console.WriteLine();
            }

        }
        private static void RightOrDown(int[,] arr, ref int x, ref int y, ref int First)
        {
            if ((x == 0) && (y == 0)) x = x + 1;
            else if ((x == 0) && (y < arr.GetLength(1) - 1)) y = y + 1;
            else if ((y == arr.GetLength(1) - 1) && (x != 0)) x = x + 1;
            else if ((y == 0) && (x < arr.GetLength(0) - 1)) x = x + 1;
            else if ((x == arr.GetLength(0) - 1) && (y < arr.GetLength(1) - 1)) y = y + 1;
            else if ((x == 0) && (y == arr.GetLength(1) - 1)) x = x + 1;
            else if ((x == arr.GetLength(0) - 1) && (y == 0)) x = x + 1;

        }

        private static void UpDiagonal (int [,] arr, ref int x, ref int y, ref int First)
        {
            do
            {
                arr[x, y] = First;
                x--;
                y++;
                First++;
            } while ((x != -1) && (y != arr.GetLength(1) ));
            x++;
            y--;
        }

        private static void DownDiagonal(int[,] arr, ref int x, ref int y, ref int First)
        {
            do
            {
                arr[x, y] = First;
                y--;
                x++;
                First++;
            } while ((y != -1) && (x != arr.GetLength(0)));
            y++;
            x--;

        }


        static void Main(string[] args)
        {
            Console.WriteLine("Введите количество строк массива ");
            int x = InputIntNNumber();

            Console.WriteLine("Введите количество столбцов массива ");
            int y = InputIntNNumber();

            int[,] arr = new int[x, y];
            int n = x * y;

            if (x != 1)
            {

                arr[0, 0] = 1;
                arr[x - 1, y - 1] = n;
                int k1 = 0;
                int k2 = 0;
                int First = 2;
                do
                {
                    RightOrDown(arr, ref k1, ref k2, ref First);
                    if (First <= n) UpDiagonal(arr, ref k1, ref k2, ref First);
                    RightOrDown(arr, ref k1, ref k2, ref First);
                    if (First <= n) DownDiagonal(arr, ref k1, ref k2, ref First);
                } while (First <= n);
            }
            else
            {
                for (int i = 0; i < arr.GetLength(1); i++)
                    arr[0, i] = i + 1;
            }

            OutputArray(arr);

        }
    }
}
