using MLW.Controller;
using MLW.Model;

namespace MLW.View;

public class DisplayCombat
{
    Character player = Player.Instance;
    CampaignData cd = CampaignData.Instance;
    public Character enemy;
    public DisplayCombat() { }
    
    public void Draw(int stage)
    {
        if (enemy == null) 
        enemy = cd.campaignStageData[stage].Enemy;

        Console.Clear();
        Console.WriteLine($"------{cd.campaignStageData[stage].Name}------\n\n");

        DrawCharactersSideBySide(player, enemy);

    }

    private void DrawCharactersSideBySide(Character player, Character enemy)
    {
        // Split the ASCII art strings into arrays of lines.
        string[] playerLines = player.Design.Split('\n');
        string[] enemyLines = enemy.Design.Split('\n');

        // Get the stat lines for both characters.
        string[] playerStats = DrawCharacterStats(player);
        string[] enemyStats = DrawCharacterStats(enemy);

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

    private string[] DrawCharacterStats(Character character)
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
