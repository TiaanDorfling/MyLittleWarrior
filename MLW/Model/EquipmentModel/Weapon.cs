using MLW.Model.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MLW.Model.EquipmentModel;

internal class Weapon : Equipment
{
    public Weapon() 
    {
        this.type = EquipmentType.Type.weapon;
        this.Level = 1;
        this.BaseStat = Level * 5 + 1;
        this.Rarity = "Common";
    }

    public override void Equip(Character character)
    {
        character.Atk += BaseStat;
        IsEquipped = true;
    }

    public override void UnEquip(Character character)
    {
        character.Atk -= BaseStat;
        IsEquipped = false;
    }
}
