using System.Linq;

namespace JuggedArrayOperations.Tests
{
    public class TestComparers
    {
        public class SumArrayRowIncComparer: IComparer
        {
            public int Compare(int[] array1, int[] array2)
            {
                if (ReferenceEquals(array1, array2))
                {
                    return 0;
                }

                if (array1 == null)
                {
                    return 1;
                }

                if (array2 == null)
                {
                    return -1;
                }

                return array1.Sum() - array2.Sum();
            }
        }

        public class SumArrayRowDecComparer : IComparer
        {
            public int Compare(int[] array1, int[] array2)
            {
                if (ReferenceEquals(array1, array2))
                {
                    return 0;
                }

                if (array1 == null)
                {
                    return -1;
                }

                if (array2 == null)
                {
                    return 1;
                }

                return array2.Sum() - array1.Sum();
            }
        }

        public class MaxArrayRowIncComparer : IComparer
        {
            public int Compare(int[] array1, int[] array2)
            {
                if (ReferenceEquals(array1, array2))
                {
                    return 0;
                }

                if (array1 == null)
                {
                    return 1;
                }

                if (array2 == null)
                {
                    return -1;
                }

                return array1.Max() - array2.Max();
            }
        }

        public class MaxArrayRowDecComparer : IComparer
        {
            public int Compare(int[] array1, int[] array2)
            {
                if (ReferenceEquals(array1, array2))
                {
                    return 0;
                }

                if (array1 == null)
                {
                    return -1;
                }

                if (array2 == null)
                {
                    return 1;
                }

                return array2.Max() - array1.Max();
            }
        }

        public class MinArrayRowIncComparer : IComparer
        {
            public int Compare(int[] array1, int[] array2)
            {
                if (ReferenceEquals(array1, array2))
                {
                    return 0;
                }

                if (array1 == null)
                {
                    return 1;
                }

                if (array2 == null)
                {
                    return -1;
                }

                return array1.Min() - array2.Min();
            }
        }

        public class MinArrayRowDecComparer : IComparer
        {
            public int Compare(int[] array1, int[] array2)
            {
                if (ReferenceEquals(array1, array2))
                {
                    return 0;
                }

                if (array1 == null)
                {
                    return -1;
                }

                if (array2 == null)
                {
                    return 1;
                }

                return array2.Min() - array1.Min();
            }
        }
    }
}
