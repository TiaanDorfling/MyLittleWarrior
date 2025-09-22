using MLW.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLW.Controller;

public class PlayerFactory : ICharacterFactory
{
    public Character CreateCharacter()
    {
        return Player.Instance;
    }
}
