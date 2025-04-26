public class CounterService
{
    public int Counter { get; private set; } = 0;
    public int Increment()
    {
        return ++ Counter;
    }
}