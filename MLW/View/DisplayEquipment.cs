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
        //to test inventory
        if (player.inventory.Count == 0)
        {
            TestAddEquipment();
        }

        ClearFullConsole();

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

    public void TestAddEquipment()
    {
        // Create the first unique object
        Equipment chest = new Equipment();
        chest.Type = "Chest";
        player.addToInventory(chest);

        // Create a second unique object
        Equipment gloves = new Equipment();
        gloves.Type = "Gloves";
        player.addToInventory(gloves);

        // Create a third unique object
        Equipment boots = new Equipment();
        boots.Type = "Boots";
        player.addToInventory(boots);

        // Create a fourth unique object
        Equipment helmet = new Equipment();
        helmet.Type = "Helmet";
        player.addToInventory(helmet);
    }

    void ClearFullConsole()
    {
        // Clear the visible screen and move the cursor to the top-left corner.
        Console.Clear();

        // Send the ANSI escape code to clear the scrollback buffer.
        // \x1b is the escape character, [3J is the command to erase the scrollback.
        Console.Write("\x1b[3J");

        // Optional: Reset the cursor position just to be safe.
        Console.SetCursorPosition(0, 0);
    }
}