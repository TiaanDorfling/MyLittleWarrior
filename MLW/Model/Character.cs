using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLW.Model;

public abstract class Character
{
    public string Name {  get; set; }
    public int Hp {  get; set; }
    public int Atk { get; set; }
    public int Level { get; set; }
    public string Design { get; set; }
    public List<Equipment> inventory { get; set; } = new List<Equipment>();
    public abstract void DrawCharacter();

    public abstract void Attack(Character target);

    public abstract void RestoreHealth();

    public abstract void addToInventory(Equipment item);

    public abstract void removeFromInventory(Equipment item);

    public abstract List<Equipment> getInventory();
}
