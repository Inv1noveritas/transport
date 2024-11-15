using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Zeroes
{
    public static class Metod
    {

        //public static List<int> Zeroes
        //{
        //    get{ return zeroes;  }
        //}
        //
        // ищем степень нуля
        // мин по столбцу и строке ( за исключением самого элемента) суммируются
        //
        public static int sum_place(int[,] price, int r, int c)
        {
            // расчет коэффициентов

            int row_min, column_min;
            row_min = int.MaxValue;
            column_min = int.MaxValue;

            // обход строки и столбца
            for (int i = 1; i < price.GetLength(0); i++)
            {
                if (i != r)
                {
                    row_min = Math.Min(row_min, price[i, c]);
                }

                if (i != c)
                {
                    column_min = Math.Min(column_min, price[r, i]);
                }
            }

            int result = row_min + column_min;

            return result;
        }

        //
        // нулевые степени 
        // у каждого элемента = 0 находим его степень
        // и после выбираем самое большое значение
        //
        public static List<int> best_zeroes(int[,] price)
        {
            List<int> zeroes;
            // список координат нулевых элементов
            zeroes = new List<int>();

            // список их коэффициентов
            List<int> pow_zeroes = new List<int>();

            // максимальный коэффициент
            double max_pow_zeroes = 0;

            // поиск нулевых элементов
            for (int i = 0; i < price.GetLength(0); ++i)
            {
                for (int j = 0; j < price.GetLength(0); ++j)
                {
                    // если равен нулю
                    if (price[i, j] == 0)
                    {
                        // добавление в список координат
                        zeroes.Add(price.GetLength(0) * i + j);

                        // расчет коэффициента и добавление в список
                        pow_zeroes.Add(sum_place(price, i, j));

                        // сравнение с максимальным
                        max_pow_zeroes = Math.Max(max_pow_zeroes, pow_zeroes[pow_zeroes.Count - 1]);
                    }
                }
            }

            int k = 0;

            // ищем max, запихнув все в листы, мы после выискиваем максимальный и удаляем ненужное
            while (k < pow_zeroes.Count)
            {
                if (pow_zeroes[k] != max_pow_zeroes)
                {
                    pow_zeroes.RemoveAt(k);
                    zeroes.RemoveAt(k);
                }
                else
                {
                    k++;
                }
            }

            return zeroes;
        }
    }
}