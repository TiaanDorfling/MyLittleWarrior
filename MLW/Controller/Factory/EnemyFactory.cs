using MLW.Model.Characters;

namespace MLW.Controller.Factory;

internal class EnemyFactory
{
    public Character CreateCharacter(CharacterType.Type type)
    {
        switch (type)
        {
            case CharacterType.Type.Goblin:
                return new Goblin(1); 
            case CharacterType.Type.Orc:
                return new Orc(1);
            case CharacterType.Type.Dragon:
            // Return a new Dragon instance
            // return new Dragon(1);
            default:
                throw new ArgumentException("Invalid character type.", nameof(type));
        }
    }

    public EnemyFactory() { }
}
