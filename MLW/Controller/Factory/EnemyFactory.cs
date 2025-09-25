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
            case CharacterType.Type.Marauder:
                return new Marauder(1);
            case CharacterType.Type.Raider:
                return new Raider(1);
            case CharacterType.Type.Inquisitor:
                return new Inquisitor(1);
            case CharacterType.Type.Assassin:
                return new Assassin(1);
            case CharacterType.Type.Witch:
                return new Witch(1);
            case CharacterType.Type.Basilisk:
                return new Basilisk(1);
            case CharacterType.Type.Huskbeast:
                return new Huskbeast(1);
            case CharacterType.Type.Vulture:
                return new Vulture(1);
            case CharacterType.Type.Golem:
                return new Golem(1);
            case CharacterType.Type.Myconid:
                return new Myconid(1);
            case CharacterType.Type.Fiend:
                return new Fiend(1);
            case CharacterType.Type.Wraith:
                return new Wraith(1);
            case CharacterType.Type.Ifrit:
                return new Ifrit(1);
            case CharacterType.Type.Revenant:
                return new Revenant(1);
            case CharacterType.Type.Horror:
                return new Horror(1);
            default:
                throw new ArgumentException("Invalid character type.", nameof(type));
        }

    }

    public EnemyFactory() { }
}
