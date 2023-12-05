namespace FizzBuzzMultiThreaded
{
    /// <summary>
    /// FizzBuzz Class
    /// </summary>
    internal class FizzBuzz
    {
        private int number;
        private int currentInt = 1;
        private object locker = new object();

        /// <summary>
        /// Sets the number value
        /// </summary>
        /// <param name="number">Number of the Iteration</param>
        public FizzBuzz(int number)
        {
            this.number = number;
        }

        /// <summary>
        /// Call the printFizz method when it is divisible by 3
        /// </summary>
        /// <param name="printFizz">Reference of the printFizz Method</param>
        public void Fizz(Action printFizz)
        {
            while(currentInt <= number)
            {
                lock(locker)
                {
                    if(currentInt > number)
                    {
                        return;
                    }
                    if(currentInt % 3 == 0 && currentInt % 5 != 0) 
                    { 
                        printFizz();
                        currentInt++;
                    }
                }
            }
        }
        /// <summary>
        /// Call the printBuzz method when it is divisible by 5
        /// </summary>
        /// <param name="printFizz">Reference of the printBuzz Method</param>
        public void Buzz(Action printBuzz)
        {
            while(currentInt <= number)
            {
                lock(locker)
                {
                    if(currentInt > number)
                    {
                        return;
                    }
                    if(currentInt % 5 == 0 && currentInt % 3 != 0)
                    {
                        printBuzz();
                        currentInt++;
                    }
                }
            }
        }
        /// <summary>
        /// Call the printFizz method when it is divisible by 3 and 5
        /// </summary>
        /// <param name="printFizz">Reference of the print Fizzbuzz Method</param>
        public void Fizzbuzz(Action printFizzBuzz)
        {
            while (currentInt <= number)
            {
                lock (locker)
                {
                    if (currentInt > number)
                    {
                        return;
                    }
                    if (currentInt % 5 == 0 && currentInt % 3 == 0)
                    {
                        printFizzBuzz();
                        currentInt++;
                    }
                }
            }
        }
        /// <summary>
        /// Call the printFizz method when it is not divisible by 3 and 5
        /// </summary>
        /// <param name="printFizz">Reference of the printNumber Method</param>
        public void Number(Action<int> printNumber)
        {
            while (currentInt <= number)
            {
                lock (locker)
                {
                    if (currentInt > number)
                    {
                        return;
                    }
                    if (currentInt % 5 != 0 && currentInt % 3 != 0)
                    {
                        printNumber(currentInt);
                        currentInt++;
                    }
                }
            }
        }
    }
}