using System;
using System.Linq;

namespace JuggedArrayOperations
{
    /// <summary>
    /// Sorts methods of jugged array
    /// </summary>
    public static class Sorts
    {
        /// <summary>
        /// Sorts source jugged array by ascending order of elements sum.
        /// </summary>
        /// <param name="array">source jugged array.</param>
        /// <exception cref="System.ArgumentNullException">array is null</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// array length less than 1
        /// or
        /// array contain elements with length less than 1
        /// </exception>
        public static void SortByAscendingOrderOfElementsSum(int[][] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (array.Length < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(array));
            }

            for (int i = 0; i < array.Length; i++) 
            {
                for (int j = 0; j < array.Length - i - 1; j++) 
                {
                    if (array[j] == null)
                    {
                        Swap(ref array[j], ref array[j + 1]);
                    }
                    else if (array[j].Length < 1)
                    {
                        throw new ArgumentOutOfRangeException(nameof(array));
                    }
                    else if (array[j + 1] != null) 
                    {
                        if (array[j].Sum() > array[j + 1].Sum())
                        {
                            Swap(ref array[j], ref array[j + 1]);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Sorts source jugged array by descending order of elements sum.
        /// </summary>
        /// <param name="array">source jugged array.</param>
        /// <exception cref="System.ArgumentNullException">array is null</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// array length less than 1
        /// or
        /// array contain elements with length less than 1
        /// </exception>
        public static void SortByDescendingOrderOfElementsSum(int[][] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (array.Length < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(array));
            }

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - i - 1; j++)
                {
                    if (array[j] == null)
                    {
                        if (j - 1 >= 0)
                        {
                            Swap(ref array[j], ref array[j - 1]);
                        }
                    }
                    else if (array[j].Length < 1)
                    {
                        throw new ArgumentOutOfRangeException(nameof(array));
                    }
                    else if (array[j + 1] != null)
                    {
                        if (array[j].Sum() < array[j + 1].Sum())
                        {
                            Swap(ref array[j], ref array[j + 1]);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Sorts source jugged array by ascending order of maximum elements.
        /// </summary>
        /// <param name="array">source jugged array.</param>
        /// <exception cref="System.ArgumentNullException">array is null</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// array length less than 1
        /// or
        /// array contain elements with length less than 1
        /// </exception>
        public static void SortByAscendingOrderOfMaxElements(int[][] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (array.Length < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(array));
            }

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - i - 1; j++)
                {
                    if (array[j] == null)
                    {
                        Swap(ref array[j], ref array[j + 1]);
                    }
                    else if (array[j].Length < 1)
                    {
                        throw new ArgumentOutOfRangeException(nameof(array));
                    }
                    else if (array[j + 1] != null) 
                    {
                        if (array[j].Max() > array[j + 1].Max())
                        {
                            Swap(ref array[j], ref array[j + 1]);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Sorts source jugged array by descending order of maximum elements.
        /// </summary>
        /// <param name="array">source jugged array.</param>
        /// <exception cref="System.ArgumentNullException">array is null</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// array length less than 1
        /// or
        /// array contain elements with length less than 1
        /// </exception>
        public static void SortByDescendingOrderOfMaxElements(int[][] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (array.Length < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(array));
            }

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - i - 1; j++)
                {
                    if (array[j] == null)
                    {
                        if (j - 1 >= 0)
                        {
                            Swap(ref array[j], ref array[j - 1]);
                        }
                    }
                    else if (array[j].Length < 1)
                    {
                        throw new ArgumentOutOfRangeException(nameof(array));
                    }
                    else if (array[j + 1] != null)
                    {
                        if (array[j].Max() < array[j + 1].Max())
                        {
                            Swap(ref array[j], ref array[j + 1]);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Sorts source jugged array by ascending order of minimum elements.
        /// </summary>
        /// <param name="array">source jugged array.</param>
        /// <exception cref="System.ArgumentNullException">array is null</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// array length less than 1
        /// or
        /// array contain elements with length less than 1
        /// </exception>
        public static void SortByAscendingOrderOfMinElements(int[][] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (array.Length < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(array));
            }

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - i - 1; j++)
                {
                    if (array[j] == null)
                    {
                        Swap(ref array[j], ref array[j + 1]);
                    }
                    else if (array[j].Length < 1)
                    {
                        throw new ArgumentOutOfRangeException(nameof(array));
                    }
                    else if (array[j + 1] != null)
                    {
                        if (array[j].Min() > array[j + 1].Min())
                        {
                            Swap(ref array[j], ref array[j + 1]);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Sorts source jugged array by descending order of minimum elements.
        /// </summary>
        /// <param name="array">source jugged array.</param>
        /// <exception cref="System.ArgumentNullException">array is null</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// array length less than 1
        /// or
        /// array contain elements with length less than 1
        /// </exception>
        public static void SortByDescendingOrderOfMinElements(int[][] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (array.Length < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(array));
            }

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - i - 1; j++)
                {
                    if (array[j] == null)
                    {
                        if (j - 1 >= 0)
                        {
                            Swap(ref array[j], ref array[j - 1]);
                        }
                    }
                    else if (array[j].Length < 1)
                    {
                        throw new ArgumentOutOfRangeException(nameof(array));
                    }
                    else if (array[j + 1] != null)
                    {
                        if (array[j].Min() < array[j + 1].Min())
                        {
                            Swap(ref array[j], ref array[j + 1]);
                        }
                    }
                }
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
