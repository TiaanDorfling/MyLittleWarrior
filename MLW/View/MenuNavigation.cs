using MLW.Controller;
using MLW.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MLW.View;

public class MenuNavigation
{
    private Character player;

    public MenuNavigation(Character player) { 
        this.player = player;
    }
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

    public void DisplayHomeScreen()
    {
        Console.Clear();
        player.DrawCharacter();
        DisplayGameMenu();
    }

    public void DisplayGameMenu()
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
    public void DisplayBattleMenu()
    {
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("Battle Menu:");
        Console.WriteLine();
        Console.WriteLine("1. Campaign");
        Console.WriteLine("2. Dungeons");
        Console.WriteLine("3. Back");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("Select an option: ");

        int choice = int.Parse(Console.ReadLine());

        NavigateBattleMenu(choice);
    }

    private void NavigateGameMenu(int choice)
    {
        switch (choice)
        {
            case 1:
                DisplayHomeScreen();
                break;
            case 2:
                DisplayBattleMenu();
                break;
            case 3:
                //Shop
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

    private void NavigateBattleMenu(int choice)
    {
        switch (choice)
        {
            case 1:
                //Campaign
                CampaignData cd = CampaignData.Instance;
                Dictionary<int, CampaignStage> campaignData = cd.campaignStageData;

                cd.DisplayStages();

                // Get the user's selection
                int input = int.Parse(Console.ReadLine());

                if (cd.IsValidStage(input))
                {
                    //battle screen
                    Console.WriteLine("This is the battle screen");
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Invalid input.");
                    NavigateBattleMenu(1);
                }
                break;
            case 2:
                //Dungeons
                break;
            case 3:
                Console.Clear();
                DisplayGameMenu();
                break;
            default:
                Console.WriteLine("Invalid input.");
                DisplayBattleMenu();
                break;
        }
    }
}
