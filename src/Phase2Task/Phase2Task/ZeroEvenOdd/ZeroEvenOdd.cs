namespace ZeroEvenOdd
{
    /// <summary>
    /// ZeroEvenOdd Class
    /// </summary>
    internal class ZeroEvenOdd
    {
        private int number;
        private int count = 1;
        private int value = 0;
        public static object padlock = new object();

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroEvenOdd"/> class.
        /// </summary>
        /// <param name="number">Number of the iteration</param>
        public ZeroEvenOdd(int number)
        {
            this.number = number;
        }

        /// <summary>
        /// Call the printNumber method when value is divisible by 2
        /// </summary>
        /// <param name="printNumber">Reference of the printNumber Method</param>
        public void Zero(Action<int> printNumber)
        {
            while(count <= number)
            {
                if (value % 2 == 0)
                {
                    lock (padlock)
                    {
                        if (count > number)
                        {
                            return;
                        }
                        if (value % 2 == 0)
                        {
                            printNumber(0);
                            value++;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Call the printNumber method when count is divisible by 2
        /// </summary>
        /// <param name="printNumber">Reference of the printNumber Method</param>
        public void Even(Action<int> printNumber)
        {
            while (count <= number)
            {
                lock (padlock)
                {
                    if (count > number)
                    {
                        return;
                    }
                    if (count % 2 == 0)
                    {
                        printNumber(count);
                        count++;
                        value++;
                    }
                }
            }
        }

        /// <summary>
        /// Call the printNumber method when count is not divisible by 2
        /// </summary>
        /// <param name="printNumber">Reference of the printNumber Method</param>
        public void Odd(Action<int> printNumber)
        {
            while (count <= number)
            {
                lock (padlock)
                {
                    if (count > number)
                    {
                        return;
                    }
                    if (count % 2 != 0)
                    {
                        printNumber(count);
                        count++;
                        value++;
                    }
                }
            }
        }
    }
}