namespace Interface_Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            List<int> list= new List<int>();
            List<int> list2= new List<int>();
            list2.Add(1);
            list2.Add(2);
            Console.WriteLine(String.Join(',', list2.Append(3)));

        }
    }
}
