namespace ConsoleAppCS;

//source: https://learn.microsoft.com/en-us/dotnet/csharp/iterators
internal class YieldShield
{
    public YieldShield() { }

    public static void Test()
    {
        Console.WriteLine(GetSingleDigitNumbers().ToString());
    }

    public static IEnumerable<int> GetSingleDigitNumbers()
    {
        yield return 0;
        yield return 1;
        yield return 2;
        yield return 3;
        yield return 4;
        yield return 5;
        yield return 6;
        yield return 7;
        yield return 8;
        yield return 9;
    }

    public static IEnumerable<int> GetSingleDigitNumbersLoop()
    {
        int index = 0;
        while (index < 10)
            yield return index++;
    }

    public IEnumerable<int> GetSetsOfNumbers()
    {
        int index = 0;
        while (index < 10)
            yield return index++;

        yield return 50;

        index = 100;
        while (index < 110)
            yield return index++;
    }

    public async IAsyncEnumerable<int> GetSetsOfNumbersAsync()
    {
        int index = 0;
        while (index < 10)
            yield return index++;

        await Task.Delay(500);

        yield return 50;

        await Task.Delay(500);

        index = 100;
        while (index < 110)
            yield return index++;
    }

    
}
