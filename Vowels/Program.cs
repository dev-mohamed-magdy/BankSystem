namespace Vowels
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter string includ a vowels");
                string text = Console.ReadLine();
                string vowels = "aeiouAEIOU";
                foreach(char c in text)
                {
                    if(vowels.Contains(c))
                    {
                        throw new Exception("text created success");
                    }
                    else
                    {
                        throw new Exception("the text must include more then 1 vowels");
                    }
                }
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
