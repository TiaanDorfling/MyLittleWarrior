using MLW.Model.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace MLW.Model.EquipmentModel;

internal class Gloves : Equipment
{
    public Gloves()
    {
        this.type = EquipmentType.Type.gloves;
        this.Level = 1;
        this.BaseStat = Level * 8 - 1;
        this.Rarity = "Common";
    }

    public override void AddStatToCharacter(Character character)
    {
        character.Atk += BaseStat;
    }
}
