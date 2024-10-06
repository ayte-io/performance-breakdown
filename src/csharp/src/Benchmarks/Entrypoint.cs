using BenchmarkDotNet.Running;

namespace Io.Ayte.Performance.Breakdown;

public class Entrypoint {
    private static readonly string[] DefaultArguments = ["--filter", "*"];
    
    public static void Main(string[] arguments) {
        BenchmarkSwitcher.FromAssembly(typeof(Entrypoint).Assembly).Run(ResolveArguments(arguments));
    }

    private static string[] ResolveArguments(string[] provided) {
        return provided.Length == 0 ? DefaultArguments : provided;
    }
}