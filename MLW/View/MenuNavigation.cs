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

    public MenuNavigation() { 
        player = Player.Instance;
    }

    private enum Menu
    {
        Home,
        Battle,
        Shop,
        Exit
    }

    public int DisplayMainMenu()
    {
        Console.Clear();
        player.DrawCharacter();

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

        while (true)
        {
            if (int.TryParse(Console.ReadLine(), out int choice) && choice >= 1 && choice <= 4)
            {
                return choice;
            }
            Console.WriteLine("Invalid input. Please enter a number from the menu.");
            Console.Write("Select an option: ");
        }
    }
    public int DisplayBattleMenu()
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

        while (true)
        {
            if (int.TryParse(Console.ReadLine(), out int choice) && choice >= 1 && choice <= 3)
            {
                return choice;
            }
            Console.WriteLine("Invalid input. Please enter a number from the menu.");
            Console.Write("Select an option: ");
        }
    }
    public int DisplayCampaignSelection()
    {
        CampaignData cd = CampaignData.Instance;
        Dictionary<int, CampaignStage> campaignData = cd.campaignStageData;

        cd.DisplayStages();

        while (true)
        {
            if (int.TryParse(Console.ReadLine(), out int choice) && cd.IsValidStage(choice))
            {
                return choice;
            }
            Console.WriteLine("Invalid input. Please enter a number from the menu.");
            Console.Write("Select an option: ");
        }
    }
}
