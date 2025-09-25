using MLW.Model;

namespace MLW.View;

internal class DisplayEquipment
{
    Character player;

    public DisplayEquipment()
    {
        player = Player.Instance;
    }

    public void Draw()
    {
        FullClear.ClearFullConsole();

        for (int i = 0; i < player.inventory.Count; i++)
        {
            // The counter 'i' starts at 0. Add 1 to make the list start at 1.
            Console.WriteLine($"{i + 1}. {player.inventory[i].ToString()}");
        }
        //for that to work you need to add state for equipment edit screen
        DisplayItem();
    }

    public void DisplayItem() 
    {
        Console.Write("Choose an item to display: ");
        int option = int.Parse(Console.ReadLine());

        Console.WriteLine(player.inventory[option-1].ToString());
    }
}