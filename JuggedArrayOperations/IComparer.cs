namespace JuggedArrayOperations
{
    /// <summary>
    /// interface for comparing two arrays
    /// </summary>
    public interface IComparer
    {
        /// <summary>
        /// Compares two arrays.
        /// </summary>
        /// <param name="array1">The array1.</param>
        /// <param name="array2">The array2.</param>
        /// <returns>
        /// zero if the arrays are equal, 
        /// a positive number if the first array is greater than the second, 
        /// and negative if the second array is greater than the first.
        /// </returns>
        int Compare(int[] array1, int[] array2);
    }
}
