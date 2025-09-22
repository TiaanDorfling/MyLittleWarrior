using MLW.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLW.Controller;

internal class GoblinFactory : ICharacterFactory
{
    public Character CreateCharacter()
    {
        return new Goblin(1);
    }
}
