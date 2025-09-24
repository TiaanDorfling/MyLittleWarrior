using MLW.Model;
using MLW.View;
namespace MLW.Controller;

internal class CombatHandler
{
    DisplayCombat displayCombat;
    int Stage {  get; set; }
    Character player = Player.Instance;
    Character enemy;
    bool Victory { get; set; }

    public CombatHandler(int stage)
    {
        Stage = stage;
        displayCombat = new DisplayCombat(stage);
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
        //to not have garbage text output
        Thread.Sleep(10);
        displayCombat.Draw(Stage);
        enemy = displayCombat.Enemy;
    }

    private void PlayerTurn()
    {
        displayCombat.DisplayTurn(player, enemy);
    }

    private void EnemyTurn()
    {
        displayCombat.DisplayTurn(enemy, player);
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
        displayCombat.DisplayBattleEnd(Victory);
    }
}
