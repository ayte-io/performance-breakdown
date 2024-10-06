using BenchmarkDotNet.Attributes;

namespace Io.Ayte.Performance.Breakdown.Basic;

public class IncrementRetrieve {
    private const int Power = 16;
    private const int Count = 1 << Power;
    private const int Mask = Count - 1;

    private static int[] Generate(int count)
    {
        var random = new Random();
        var numbers = new int[count];
        for (int i = 0; i < 1 << count; i++)
        {
            numbers[i] = random.Next();
        }

        return numbers;
    }
    private static readonly int[] Numbers = Generate(Count);

    private int iteration;

    [Benchmark]
    public int Jesus() {
        return Numbers[iteration++ & Mask];
    }

    [Benchmark]
    public int Fucking() {
        return Numbers[++iteration & Mask];
    }

    [Benchmark]
    public int Christ() {
        return Numbers[iteration++ & Mask] + 12;
    }

    [Benchmark]
    public int Loves() {
        return Numbers[++iteration & Mask] + 12;
    }

    [Benchmark]
    public int You() {
        return Numbers[iteration++ & Mask] + Numbers[++iteration & Mask];
    }

    [Benchmark(OperationsPerInvoke = 16)]
    public int While()
    {
        int accumulator = 0;
        for (int i = 0; i < 16; i++)
        {
            accumulator += Numbers[++iteration & Mask];
        }

        return accumulator;
    }

    [Benchmark(OperationsPerInvoke = 256)]
    public int Looping()
    {
        int accumulator = 0;
        for (int i = 0; i < 256; i++)
        {
            accumulator += Numbers[++iteration & Mask];
        }

        return accumulator;
    }
}