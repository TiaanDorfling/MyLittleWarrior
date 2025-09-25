using MLW.Model.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLW.Controller.Factory;

internal interface ICharacterFactory
{
    Character CreateCharacter();
}
