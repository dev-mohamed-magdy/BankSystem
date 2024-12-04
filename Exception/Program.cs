namespace Exceptions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //try
            //{
            //    int[] numbers = { 1, 2, 3 };
            //    Console.WriteLine(numbers[10]);
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.Message);
            //}
            try
            {
                Console.WriteLine("Enter list of numbers separated by spaces");
                string input = Console.ReadLine();
                List<int> numbers = input.Split(' ').Select(int.Parse).ToList();
                int number = numbers[0];
                for(int i = 0; i < numbers.Count; i++)
                {
                    if(numbers[i] == number)
                    {
                        throw new Exception("pleas don't enter duplicated numbers");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
