using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLW.Model;

public class Equipment
{
    public string Type { get; set; }
    public string Rarity { get; set; }
    public int Level { get; set; }
    public int BaseStat {  get; set; }

    public void Upgrade()
    {
        Level++;
        BaseStat += 5;
        Console.WriteLine($"This item was upgraded from level {Level - 1} to level {Level}");
    }

    public Equipment()
    {
        Type = "sword";
        Rarity = "common";
        Level = 1;
        BaseStat = 2;
    }

    public Equipment(string type, string rarity, int level, int baseStat)
    {
        Type = type;
        Rarity = rarity;
        Level = level;
        BaseStat = baseStat;
    }

    public override string ToString()
    {
        return $"{Type} Level: {Level} Rarity: {Rarity}";
    }
}
