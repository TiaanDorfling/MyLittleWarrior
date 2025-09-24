using MLW.Model;
using MLW.View;
namespace MLW.Controller;

internal class CombatHandler
{
    DisplayCombat displayCombat = new DisplayCombat();
    int Stage {  get; set; }
    Character player = Player.Instance;
    Character enemy;
    bool Victory { get; set; }

    public CombatHandler(int stage)
    {
        Stage = stage;
    }

    public void BattleLoop()
    {
        BattleStart();
        bool playerTurn = true;
        while (BattleState())
        {
            if (playerTurn)
            {
                PlayerTurn();
                playerTurn = false;
            }
            else if (!playerTurn)
            {
                EnemyTurn();
                playerTurn = true;
            }
        }
        BattleEnd();
    }

    private void BattleStart()
    {
        Console.Clear();
        displayCombat.Draw(Stage);
        enemy = displayCombat.enemy;
    }

    private void PlayerTurn()
    {
        displayCombat.Draw(Stage);
        Console.WriteLine("\n\nThe player is preparing to attack...");
        Thread.Sleep(3000);
    }

    private void EnemyTurn()
    {
        displayCombat.Draw(Stage);
        Console.WriteLine("\n\nThe enemy is preparing to attack...");
        Thread.Sleep(3000);
    }

    private bool BattleState()
    {
        if (enemy.Hp <= 0)
        {
            Victory = true;
            return false;
        }
        else if (player.Hp <= 0)
        {
            Victory = false;
            return false;
        }
        //if neither is defeated
        return true;
    }

    private void BattleEnd()
    {
        if (Victory)
        Console.WriteLine($"The battle ended in victory");
        else
        Console.WriteLine("The battle ended in defeat");
    }
}
