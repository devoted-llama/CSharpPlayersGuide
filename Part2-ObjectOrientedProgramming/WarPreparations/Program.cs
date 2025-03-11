// See https://aka.ms/new-console-template for more information
Sword basicSword = new Sword(Material.iron, Gemstone.none, 80, 25);
Sword goodSword = basicSword with {material = Material.steel};
Sword bestSword = goodSword with {gemstone = Gemstone.bitstone} ;
Console.WriteLine(basicSword);
Console.WriteLine(goodSword);
Console.WriteLine(bestSword);

public enum Material { wood, bronze, iron, steel, binarium}
public enum Gemstone {none, emerald, amber, sapphire, diamond, bitstone}

public record Sword (Material material, Gemstone gemstone, float length, float crossGuardWidth) {}


