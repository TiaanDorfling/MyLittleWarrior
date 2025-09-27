using MLW.Model.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLW.Model.EquipmentModel;

public abstract class Equipment
{
    public int Id { get; set; }
    public string Name { get; set; }
    public EquipmentType.Type type { get; set; }
    public string Rarity { get; set; }
    public int Level { get; set; }
    public int BaseStat {  get; set; }

    public void Upgrade()
    {
        Level++;
        BaseStat += 5;
        Console.WriteLine($"This item was upgraded from level {Level - 1} to level {Level}");
    }

    public override string ToString()
    {
        return $"{type.ToString()} Level: {Level} Rarity: {Rarity}";
    }

    public abstract void AddStatToCharacter(Character character);
}
