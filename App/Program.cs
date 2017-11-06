using System;
using System.Reflection;

namespace typeliteconverter
{
    class Program
    {
        static void Main(string[] args)
        {
            var assemblyPath = args[0];
            var outputPath = args[1];

            Generator.Generate(Assembly.LoadFrom(assemblyPath), outputPath);
        }
    }
}
