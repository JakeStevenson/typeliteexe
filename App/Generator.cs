using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using TypeLite;

public class Generator
{
    public static void Generate(Assembly assembly, string outputPath)
    {
        List<Type> conversions = new List<Type>();
        var decorator = assembly.GetTypes().FirstOrDefault(d=>d.Name=="TypeScriptModel");
        var classes = assembly.GetTypes();
        foreach (var t in classes)
        {
            if (t.GetCustomAttributes(decorator, true).Length > 0)
            {
                conversions.Add(t);
            }
        }
        var generator = new TypeScriptFluent()
                       .WithConvertor<Guid>(c => "string");

        foreach (var model in conversions)
        {
            generator.ModelBuilder.Add(model);
        }
        var tsEnumDefinitions = generator.Generate(TsGeneratorOutput.Enums);
        File.WriteAllText(Path.Combine(outputPath, "enums.ts"), tsEnumDefinitions);
        //Generate interface definitions for all classes
        var tsClassDefinitions = generator.Generate(TsGeneratorOutput.Properties | TsGeneratorOutput.Fields);
        File.WriteAllText(Path.Combine(outputPath, "classes.d.ts"), tsClassDefinitions);
    }
}
