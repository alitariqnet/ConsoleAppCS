using Humanizer;
using System.Net.Http.Headers;

namespace ConsoleAppCS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("==============");
            //CollectionsPractice collectionsPractice = new CollectionsPractice();
            //collectionsPractice.DoPractice();
            //ValueTypeExample.Maine();
            //NullableType.Maine();
            //SomeQueues.Maine();
            //ConcurrentBagDemo.Man();
            //Example.Man();
            //SealIt.RunSealedLogic();
            //HumanizeQuantities();
            //HumanizeDates();
            //StaticCharge.PrintClassName();
            //Program2.Man();

            //LetsDelegate.RunDelegateExample();

            //HttpRequest.MainAsync().GetAwaiter().GetResult();

            //Variables.Run();

            

            Console.WriteLine("==============");
        }

        static void HumanizeQuantities()
{
    Console.WriteLine("case".ToQuantity(0));
    Console.WriteLine("case".ToQuantity(1));
    Console.WriteLine("case".ToQuantity(5));
}

static void HumanizeDates()
{
    Console.WriteLine(DateTime.UtcNow.AddHours(-24).Humanize());
    Console.WriteLine(DateTime.UtcNow.AddHours(-2).Humanize());
    Console.WriteLine(TimeSpan.FromDays(1).Humanize());
    Console.WriteLine(TimeSpan.FromDays(16).Humanize());
}

        int multiplier(int x, int y)
        {
            return x * y;
        }

        int multiplier(int x, int y, int z)
        {
            return x * y * z;
        }

        static void switchTest()
        {
            int x = 1;
            switch (x)
            {
                case 0:
                    int y;
                    break;
                case var z when z < 10:
                    break;
                default:
                    y = 10;
                    // Valid: y is in scope
                    Console.WriteLine(x + y);
                    // Invalid: z is not scope
                    //Console.WriteLine(x + z);
                    break;
            }
        }
    }

}