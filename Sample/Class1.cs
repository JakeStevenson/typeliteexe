using System;



namespace Sample

{

    [TypeScriptModel]
    public class SampleModel

    {

        public Guid ID { get; set; }

        public string Name { get; set; }

    }

    public class TypeScriptModel : Attribute
    {

    }
}

