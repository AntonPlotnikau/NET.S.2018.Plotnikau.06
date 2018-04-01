using System;

namespace JuggedArrayOperations
{
    /// <summary>
    /// Sorts methods of jugged array
    /// </summary>
    public static class Sorts
    {
        /// <summary>
        /// Bubble sort.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <param name="comparer">The comparer for that array.</param>
        /// <exception cref="ArgumentNullException">
        /// array is null
        /// or
        /// comparer is null
        /// </exception>
        public static void BubbleSort(int[][] array, IComparer comparer)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (comparer == null) 
            {
                throw new ArgumentNullException(nameof(comparer));
            }

            bool flag = true;
            int i = array.Length - 1;
            while (flag) 
            {
                flag = false;
                for (int j = 0; j < i; j++) 
                 {
                    if (comparer.Compare(array[j], array[j + 1]) > 0)
                    {
                        Swap(ref array[j], ref array[j + 1]);
                        flag = true;
                    }
                }

                i--;
            }
        }

        /// <summary>
        /// Swaps two arrays.
        /// </summary>
        /// <param name="array1">The array1.</param>
        /// <param name="array2">The array2.</param>
        private static void Swap(ref int[] array1, ref int[] array2)
        {
            int[] temp = array1;
            array1 = array2;
            array2 = temp;
        }
    }
}
