using MLW.Controller.Factory;
using MLW.Model.Characters;
using MLW.View;
namespace MLW.Controller;

public class GameState
{
    public enum State
    {
        Home,
        BattleMenu,
        CampaignSelection,
        DungeonSelection,
        Equipment,
        Shop,
        Combat,
        Exit
    }
    public State CurrentState { get; set; } = State.Home;

    private Character player;

    private MenuNavigation menu;

    private DisplayEquipment displayEquipment;

    private int combatStage;
    // The single instance of the Gamestate class.
    private static GameState _instance;

    // A lock object to ensure thread-safe creation.
    private static readonly object _lock = new object();

    private GameState() 
    {
        ICharacterFactory playerFactory = new PlayerFactory();
        player = playerFactory.CreateCharacter();

        menu = new MenuNavigation();
        displayEquipment = new DisplayEquipment();
    }

    // Public static method to get the single instance.
    public static GameState Instance
    {
        get
        {
            // Thread-safe check to ensure only one instance is created.
            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = new GameState();
                }
                return _instance;
            }
        }
    }

    public void GameLoop()
    {
        while (CurrentState != State.Exit)
        {
            switch (CurrentState)
            {
                case State.Home:
                    int homeChoice =  menu.DisplayMainMenu();

                    switch (homeChoice) 
                    {
                        case 1:
                            CurrentState = State.Home;
                            break;
                        case 2:
                            CurrentState = State.Equipment;
                            break;
                        case 3:
                            CurrentState = State.BattleMenu;
                            break;
                        case 4:
                            CurrentState = State.Shop;
                            break;
                        case 5:
                            CurrentState = State.Exit;
                            break;
                    }
                break;

                case State.Equipment:
                    displayEquipment.Draw();
                    CurrentState = State.Home;
                     //problem with loop
                    break;

                case State.BattleMenu:
                    int battleChoice = menu.DisplayBattleMenu();

                    switch (battleChoice)
                    {
                        case 1:
                            CurrentState = State.CampaignSelection;
                            break;
                        case 2:
                            CurrentState = State.DungeonSelection;
                            break;
                        case 3:
                            CurrentState = State.Home;
                            break;
                    }
                    break;

                case State.CampaignSelection:
                    combatStage = menu.DisplayCampaignSelection();
                    CurrentState = State.Combat;
                break;

                case State.Combat:
                    CombatHandler combat = new CombatHandler(combatStage);
                    combat.BattleLoop();
                    CurrentState = State.Home;
                break;

                case State.Exit:
                    Environment.Exit(0);
                break;

            }
        }
    }

}
