namespace FirstApp
{
    internal class Program
    {
        static void Main()
        {
            const int numberOfNumbers = 10;
            int sum = 0;

            for (int i = 1; i <= numberOfNumbers; i++)
            {
                Console.Write($"Enter number {i}: ");
                int userNumber = Convert.ToInt32(Console.ReadLine());
                sum += userNumber;
            }

            int average = sum / numberOfNumbers;

            Console.WriteLine($"The average of the 10 numbers is: {average}");
        }


    }
}
