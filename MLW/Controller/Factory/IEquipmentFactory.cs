using MLW.Model.EquipmentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLW.Controller.Factory;

internal interface IEquipmentFactory
{
    Equipment CreateEquipment(EquipmentType.Type type);
}
