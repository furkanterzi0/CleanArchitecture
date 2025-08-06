using System.Reflection;

namespace CleanArchitecture.Application;

public static class AssemblyReference
{
    private static readonly Assembly Assembly = typeof(Assembly).Assembly;
}

