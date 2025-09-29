using MLW.Model.Characters;
using MLW.Model.EquipmentModel;
using System.Globalization;
using System.Net.Sockets;

namespace MLW.View;

internal class DisplayEquipment
{
    Character player;
    
    List<Equipment> weapons = new List<Equipment> ();
    List<Equipment> helmets = new List<Equipment>();
    List<Equipment> chest = new List<Equipment>();
    List<Equipment> gloves = new List<Equipment>();
    List<Equipment> boots = new List<Equipment>();
    public DisplayEquipment()
    {
        player = Player.Instance;
    }

    public void Draw()
    {
        FullClear.ClearFullConsole();
        //init lists
        getItems();
        //display character with stats
        player.DrawCharacter();
        //display lists
        DisplayWeapons();
        DisplayHelmets();
        DisplayChests();
        DisplayGloves();
        DisplayBoots();

        if (player.inventory.Count > 0)
        {
            DrawItem(DisplayItem());
        }
        else
        {
            Console.WriteLine("Press any key to return to home");
            Console.Read();
        }
    }
    private void getItems()
    {
        if (player.inventory != null) {
            for (int i = 0; i < player.inventory.Count; i++)
            {
                switch (player.inventory[i].type)
                {
                    case EquipmentType.Type.weapon:
                        weapons.Add(player.inventory[i]);
                        break;
                    case EquipmentType.Type.helmet:
                        helmets.Add(player.inventory[i]);
                        break;
                    case EquipmentType.Type.chest:
                        chest.Add(player.inventory[i]);
                        break;
                    case EquipmentType.Type.gloves:
                        gloves.Add(player.inventory[i]);
                        break;
                    case EquipmentType.Type.boots:
                        boots.Add(player.inventory[i]);
                        break;
                }
            }
        }
    }
    private void DisplayWeapons()
    {
        if (weapons != null)
        {
            Console.WriteLine("WEAPONS\n\n");
            for (int i = 0; i < weapons.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {weapons[i].ToString()}");
            }
        }
        else
        {
            Console.WriteLine("WEAPONS\n\n none yet");
        }
    }

    private void DisplayHelmets()
    {
        if (helmets != null)
        {
            Console.WriteLine("HELMETS\n\n");
            for (int i = 0; i < helmets.Count; i++)
            {
                Console.WriteLine($"{i + weapons.Count}. {helmets[i].ToString()}");
            }
        }
        else
        {
            Console.WriteLine("HELMETS\n\n none yet");
        }
    }
    private void DisplayChests()
    {
        if (chest != null)
        {
            Console.WriteLine("CHESTS\n\n");
            for (int i = 0; i < chest.Count; i++)
            {
                Console.WriteLine($"{i + helmets.Count + weapons.Count}. {chest[i].ToString()}");
            }
        }
        else
        {
            Console.WriteLine("CHESTS\n\n none yet");
        }
    }
    private void DisplayGloves()
    {
        if (gloves != null)
        {
            Console.WriteLine("GLOVES\n\n");
            for (int i = 0; i < gloves.Count; i++)
            {
                Console.WriteLine($"{i + chest.Count+ helmets.Count + weapons.Count}. {gloves[i].ToString()}");
            }
        }
        else
        {
            Console.WriteLine("GLOVES\n\n none yet");
        }
    }
    private void DisplayBoots()
    {
        if (boots != null)
        {
            Console.WriteLine("BOOTS\n\n");
            for (int i = 0; i < boots.Count; i++)
            {
                Console.WriteLine($"{i + gloves.Count + chest.Count + helmets.Count + weapons.Count}. {boots[i].ToString()}");
            }
        }
        else
        {
            Console.WriteLine("BOOTS\n\n none yet");
        }
    }

    private int DisplayItem() 
    {
        Console.Write("Choose an item to display: ");

        while (true)
        {
            if (int.TryParse(Console.ReadLine(), out int option) && player.inventory != null && option - 1 < player.inventory.Count)
            {
                return option;
            }
            Console.WriteLine("Invalid input. Please enter a number from the menu.");
            Console.Write("Choose an item to display: ");
        }
    }

    private void DrawItem(int item)
    {
        FullClear.ClearFullConsole();
        Equipment equipment = player.inventory[item - 1];
        Console.WriteLine(equipment.ToString());

        EquipmentMenu(equipment);
    }

    private void EquipmentMenu(Equipment equipment)
    {
        int choice;
        if (!equipment.IsEquipped)
        {
            Console.WriteLine("Menu\n1. Upgrade\t2. Equip\t3. Home");
            Console.Write("Enter your option: ");
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int option) && option < 4 && option > 0)
                {
                    choice = option;
                    break;
                }
                Console.WriteLine("Invalid input. Please enter a number from the menu.");
                Console.Write("Choose an item to display: ");
            }
            if (choice == 1)
            {
                Console.WriteLine("Here comes menu to upgrade, equip, unequip items.\nPress any key to return to home");
                Console.Read();
            }
            else if (choice == 2)
            {
                equipment.Equip(player);
                DrawItem(DisplayItem());
            }
            else
            {
                Console.WriteLine("Press any key to return to home");
                Console.Read();
            }
        }
        else
        {
            Console.WriteLine("Menu\n1. Upgrade\t2. Unequip\t3. Home");
            Console.Write("Enter your option: ");
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int option) && option < 4 && option > 0)
                {
                    choice = option;
                    break;
                }
                Console.WriteLine("Invalid input. Please enter a number from the menu.");
                Console.Write("Choose an item to display: ");
            }
            if (choice == 1)
            {
                Console.WriteLine("Here comes menu to upgrade, equip, unequip items.\nPress any key to return to home");
                Console.Read();
            }
            else if (choice == 2) 
            {
                equipment.UnEquip(player);
                DrawItem(DisplayItem());

            }
            else
            {
                Console.WriteLine("Press any key to return to home");
                Console.Read();
            }
        }



    }
}