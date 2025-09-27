using MLW.Model.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLW.Model.EquipmentModel;

internal class Chest : Equipment
{
    public Chest()
    {
        this.type = EquipmentType.Type.chest;
        this.Level = 1;
        this.BaseStat = Level * 15;
        this.Rarity = "Common";
    }

    public override void Equip(Character character)
    {
        character.Hp += BaseStat;
        IsEquipped = true;
    }
    public override void UnEquip(Character character)
    {
        character.Hp -= BaseStat;
        IsEquipped = false;
    }
}
