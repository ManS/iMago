using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utilities
{
    public class Sorter
    {
        private static int Partitioning(int[] Array, int first, int last)
        {
            int i = first - 1;
            int pivot = Array[last];
            for (int j = first; j < last; j++)
            {
                if (pivot >= Array[j])
                {
                    i++;
                    int temp = Array[i];
                    Array[i] = Array[j];
                    Array[j] = temp;
                }
            }
            Array[last] = Array[i + 1];
            Array[i + 1] = pivot;

            return i + 1;
        }
        public static void QuickSort(ref int[] Array, int first, int last)
        {
            if (first < last)
            {
                int spliter = Partitioning(Array, first, last);
                QuickSort(ref Array, first, spliter - 1);
                QuickSort(ref Array, spliter + 1, last);
            }
        }
        public static void RadixSort(ref int[] x, int large_number_of_digits_in_numbers)
        {
            List<int>[] _buckets = new List<int>[10];
            int _temp, _index = 0, length = x.GetLength(0);
            for (int i = 0; i < 10; i++)
                _buckets[i] = new List<int>();

            for (int i = 0; i < large_number_of_digits_in_numbers; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    _temp = (int)((x[j]) / Math.Pow(10, i)) % 10;
                    _buckets[_temp].Add(x[j]);


                }
                for (int k = 0; k < 10; k++)
                {
                    for (int l = 0; l < _buckets[k].Count; l++)
                    {
                        x[_index] = _buckets[k][l];
                        _index++;

                    }
                    _buckets[k].Clear();
                }
                _index = 0;
            }

        }
    }
}
