﻿// See https://aka.ms/new-console-template for more information

using Exercise1_07;

var aGolden = new GoldenRetriever() { Name = "Aspen"};
var anotherGolden = new GoldenRetriever() { Name = "Aspen"};

var aBorder = new BorderCollie() { Name = "Aspen"};
var anotherBorder = new BorderCollie() { Name = "Aspen"};

var aBernese = new Bernese() { Name = "Aspen"};
var anotherBernese = new Bernese() { Name = "Aspen"};

var goldenComparison = aGolden.Equals(anotherGolden) ? "These Golden Retrivers have the same name." : "These Goldens have different names.";

var borderComparison = aBorder.Equals(anotherBorder) ? "These Border Collies have the same name." : "These Border Collies have different names.";

var berneseComparison = aBernese.Equals(anotherBernese) ? "These Bernese dogs have the same name." : "These bernese dogs have different names.";

Console.WriteLine(goldenComparison);
Console.WriteLine(borderComparison);
Console.WriteLine(berneseComparison);

namespace Exercise1_07
{
    internal struct GoldenRetriever
    {
        public string Name { get; set; }
    }

    internal struct BorderCollie
    {
        public string Name { get; set; }
    }

    internal struct Bernese
    {
        public string Name { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is Bernese borderCollie && obj != null) return Name == borderCollie.Name;
            return false;
        }
    }
}