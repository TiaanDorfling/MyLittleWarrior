using MLW.Model.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLW.Model.EquipmentModel;

internal class Helmet : Equipment
{
    public Helmet()
    {
        this.type = EquipmentType.Type.helmet;
        this.Level = 1;
        this.BaseStat = Level * 7 - 3;
        this.Rarity = "Common";
    }

    public override void AddStatToCharacter(Character character)
    {
        character.Hp += BaseStat;
    }
}
