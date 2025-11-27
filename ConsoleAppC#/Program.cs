using Humanizer;

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
            SealIt.RunSealedLogic();
            //HumanizeQuantities();
            //HumanizeDates();
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
    }

}