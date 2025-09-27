using MLW.Model.EquipmentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLW.Controller.Factory;

internal class EquipmentFactory : IEquipmentFactory
{
    public Equipment CreateEquipment(EquipmentType.Type type)
    {
        switch (type)
        {
            case EquipmentType.Type.weapon:
                return new Weapon();  
            case EquipmentType.Type.helmet:
                return new Helmet(); 
            case EquipmentType.Type.chest:
                return new Chest();
            case EquipmentType.Type.gloves:
                return new Gloves();
            case EquipmentType.Type.boots:
                return new Boots();
            default:
                return new Weapon();
        }
    }
}
