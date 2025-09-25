using MLW.Controller;
using MLW.Model;


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
        Equipment,
        Battle,
        Shop,
        Exit
    }

    public int DisplayMainMenu()
    {
        Console.Clear();
        player.DrawCharacter();

        Console.WriteLine("\n\n\n\nGame Menu:\n");
        foreach (var item in Enum.GetValues(typeof(Menu)))
        {
            Console.Write($" | {(int)item + 1}. {item} |");
        }
        Console.Write("\n\nSelect an option: ");

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
        Console.Clear();
        Console.WriteLine("Battle Menu:\n");
        Console.WriteLine("1. Campaign");
        Console.WriteLine("2. Dungeons");
        Console.WriteLine("3. Back\n\n");
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
