namespace Methods
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            var numbers = GetNumbers(50, 13, -13, 30);
            Print(numbers);

            Console.ReadLine();
        }

        private static void Print(int[] numbers)
            => Console.WriteLine(string.Join(", ", numbers));

        private static int[] GetNumbers(int numberCount, int divisibleBy, int min, int max)
        {
            var result = new int[numberCount];

            var position = 0;
            for (int i = min; i < max; i++)
            {
                if (position == numberCount)
                    break;

                if (i % divisibleBy == 0)
                {
                    result[position] = i;
                    position++;
                }
            }

            return result;
        }
    }
}