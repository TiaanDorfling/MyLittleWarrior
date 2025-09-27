using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLW.Model.EquipmentModel;

internal class EquipmentType
{
    public enum Type
    {
        weapon,
        helmet,
        chest,
        gloves,
        boots
    }

    public EquipmentType() { }
}
