using MLW.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLW.Controller;

public enum Enemy 
{
    goblin,
    wizard,
    skeleton
}

internal class EnemyFactory : ICharacterFactory
{
    public Character CreateCharacter()
    {
        return new Goblin(1);
    }

    public Character CreateCharacter(Enemy enemy)
    {
        switch (enemy)
        {
            case Enemy.goblin:
                return new Goblin(1);
            case Enemy.wizard:
                return new Goblin(1);
            case Enemy.skeleton:
                return new Goblin(1);
            default:
                return null;
        }
    }
}
