using HvacLibrary;

namespace HvacConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            BinaryInput input = new BinaryInput();
            Console.WriteLine($"input starts off as {input.Status}");
            input.Status = true;
            Console.WriteLine($"input setting to true --> {input.Status}");
            input.Status = false;
            Console.WriteLine($"input setting to false --> {input.Status}");
            input.Status = !input.Status;
            Console.WriteLine($"Toggle the value --> {input.Status}");
        }
    }
}
