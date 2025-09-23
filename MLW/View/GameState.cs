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

    private Character player;

    public GameState() { }
    public void GameLoop()
    {
        State currentState = State.Home;

        ICharacterFactory playerFactory = new PlayerFactory();
        player = playerFactory.CreateCharacter();

        MenuNavigation menu = new MenuNavigation(player);

        while (true)
        {
            switch (currentState)
            {
                case State.Home:
                    menu.DisplayHomeScreen();
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

}
