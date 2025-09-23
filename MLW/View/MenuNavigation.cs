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

    public void DisplayCombat(int stage)
    {
        CampaignData cd = CampaignData.Instance;
        Character enemy = cd.campaignStageData[stage].Enemy;
        while (true)
        {
            Console.Clear();
            Console.WriteLine($"------{cd.campaignStageData[stage].Name}------\n\n");

            DrawCharactersSideBySide(player, enemy);

            Console.WriteLine("\n\nThe enemy is preparing to attack...");
            Thread.Sleep(3000);

            if (player.Hp <= 0 || enemy.Hp <= 0)
                return;
        }
    }

    private void DrawCharactersSideBySide(Character player, Character enemy)
    {
        // Split the ASCII art strings into arrays of lines.
        string[] playerLines = player.Design.Split('\n');
        string[] enemyLines = enemy.Design.Split('\n');

        // Get the stat lines for both characters.
        string[] playerStats = GetCharacterStats(player);
        string[] enemyStats = GetCharacterStats(enemy);

        // Find the total number of lines to draw (art + stats).
        int maxLines = Math.Max(playerLines.Length, enemyLines.Length);
        int totalLines = maxLines + playerStats.Length;

        // Get the maximum width of the player's design for padding.
        int playerMaxWidth = playerLines.Max(line => line.Trim().Length);

        // A space to separate the two characters.
        string separator = "  |  ";

        // Loop through each line, combine them, and print.
        for (int i = 0; i < totalLines; i++)
        {
            string playerLine = "";
            string enemyLine = "";

            // Check if we are drawing an art line or a stat line.
            if (i < playerLines.Length)
            {
                playerLine = playerLines[i].Trim();
            }
            else if (i - playerLines.Length < playerStats.Length)
            {
                // If the art is finished, draw a stat line.
                playerLine = playerStats[i - playerLines.Length];
            }

            if (i < enemyLines.Length)
            {
                enemyLine = enemyLines[i].Trim();
            }
            else if (i - enemyLines.Length < enemyStats.Length)
            {
                enemyLine = enemyStats[i - enemyLines.Length];
            }

            // Pad the player's line to ensure consistent spacing.
            string paddedPlayerLine = playerLine.PadRight(playerMaxWidth);

            // Combine the lines and print.
            Console.WriteLine(paddedPlayerLine + separator + enemyLine);
        }
    }

    private string[] GetCharacterStats(Character character)
    {
        return new string[]
        {
        $"Name: {character.Name}",
        $"Hp: {character.Hp}",
        $"Atk: {character.Atk}",
        $"Level: {character.Level}"
        };
    }
}
