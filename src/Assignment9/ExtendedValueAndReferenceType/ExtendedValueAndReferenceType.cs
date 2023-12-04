namespace ExtendedValueAndReferenceType
{
    /// <summary>
    /// Extended Project of the Value and Reference Type
    /// </summary>
    public class ExtendedValueAndReferenceType
    {
        /// <summary>
        /// Method assigns the value to each index in the large array of Integers.
        /// </summary>
        public static void LargeArray()
        {
            int[] arr = new int[1000000000];
            for (int i = 0; i < 1000000000; i++)
            {
                arr[i] = i;
            }
        }

        /// <summary>
        /// Method creates the large numbers of local variables and assigns the value to it.
        /// </summary>
        public static void LargeNumberLocalVariable()
        {
            for (int i = 0; i < 1000000000; i++)
            {
                int a = i;
            }
        }
    }
}