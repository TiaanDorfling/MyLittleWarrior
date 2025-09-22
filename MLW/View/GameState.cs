using MLW.Controller;
using MLW.Model;
using System.Numerics;
using System.Runtime.CompilerServices;
namespace MLW.View;

public class GameState
{
    private enum State
    {
        Home,
        BattleMenu,
        CampaignSelection,
        DungeonSelection,
        Equipment,
        Shop,
        Combat
    }

    private enum Menu
    {
        Home,
        Battle,
        Shop,
        Exit
    }

    private Character player;

    public GameState() { }
    public void GameLoop()
    {
        State currentState = State.Home;

        ICharacterFactory playerFactory = new PlayerFactory();
        player = playerFactory.CreateCharacter();

        while (true)
        {
            switch (currentState)
            {
                case State.Home:
                    DisplayHomeScreen(player);
                    Console.Read();
                    break;

                case State.BattleMenu:
                    // Display 'Campaign' and 'Dungeon' options
                    // Check if Dungeons are unlocked to display the option
                    // e.g., if player.CampaignProgress > 5, show Dungeon option
                    // Get player input and change currentState
                    break;
                    // ... and so on for other states
            }
        }
    }

    private void DisplayHomeScreen(Character player)
    {
        Console.Clear();
        player.DrawCharacter();
        DisplayGameMenu();
    }

    private void DisplayGameMenu()
    {
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("Game Menu:");
        Console.WriteLine();
        foreach (var item in Enum.GetValues(typeof(Menu)))
        {
            Console.Write($" | {(int)item + 1}. {item} |");
        }
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("Select an option: ");

        int choice = int.Parse(Console.ReadLine());

        NavigateGameMenu(choice);
    }

    private void NavigateGameMenu(int choice)
    {
        switch (choice)
        {
            case 1:
                DisplayHomeScreen(player);
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Invalid input.");
                DisplayGameMenu();
                break;
        }
    }

}
