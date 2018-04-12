using System;

namespace JuggedArrayOperations
{
    /// <summary>
    /// Comparer that uses delegate
    /// </summary>
    /// <seealso cref="JuggedArrayOperations.IComparer" />
    public class Comparer : IComparer
    {
        /// <summary>
        /// The predicate
        /// </summary>
        private Func<int[], int[], int> predicate;

        /// <summary>
        /// Initializes a new instance of the <see cref="Comparer"/> class.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        public Comparer(Func<int[], int[], int> predicate)
        {
            this.predicate = predicate;
        }

        /// <summary>
        /// Compares two arrays.
        /// </summary>
        /// <param name="array1">The array1.</param>
        /// <param name="array2">The array2.</param>
        /// <returns> the predicate. </returns>
        public int Compare(int[] array1, int[] array2)
        {
            return this.predicate(array1, array2);
        }
    }
}
