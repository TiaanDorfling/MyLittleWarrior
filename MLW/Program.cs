namespace MLW;

using MLW.Controller;
using MLW.Model;
using System.Runtime.CompilerServices;

public class Program
{
    public static void Main(string[] args)
    {
        ICharacterFactory playerFactory = new PlayerFactory();
        Character player = playerFactory.CreateCharacter();

        player.DrawCharacter();

        Console.Read();
    }
}