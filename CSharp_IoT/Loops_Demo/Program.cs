namespace Loops_Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 5; i++)
            {

                string s;
                s = String.Concat(Enumerable.Repeat("*", i));
                Console.WriteLine($"{s}");

            }
            for (int i = 0; i < 5; i++)
            {

                string s;
                s = String.Concat(Enumerable.Repeat("*", i));
                Console.WriteLine($"{PadCenter(s, 4, ' ')}");

            }

        }
        public static string PadCenter(string s, int totalWidth, char paddingChar)
        {
            int totalPadding = totalWidth - s.Length;
            int LeftPadding = totalPadding / 2;
            int RightPadding = totalPadding - LeftPadding;

            return s.PadLeft(s.Length+LeftPadding, paddingChar).PadRight(RightPadding, paddingChar);

        }
    }
}
