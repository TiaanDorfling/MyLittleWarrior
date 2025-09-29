using MLW.Model.Characters;
using MLW.Model.EquipmentModel;

namespace MLW.View;

internal class DisplayEquipment
{
    Character player;
    
    List<Equipment> weapons = new List<Equipment> ();
    List<Equipment> helmets = new List<Equipment>();
    List<Equipment> chest = new List<Equipment>();
    List<Equipment> gloves = new List<Equipment>();
    List<Equipment> boots = new List<Equipment>();
    List<Equipment> equiped = new List<Equipment>();
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
        DisplayEquiped();
        DisplayWeapons();
        DisplayHelmets();
        DisplayChests();
        DisplayGloves();
        DisplayBoots();
        //menu
        if (player.inventory.Count > 0)
        {
            int option = DisplayOrHome();
            if (option == 1)
            {
                DrawItem(DisplayItem());
            }
            //goes home of choose 2
        }
        else
        {
            Console.WriteLine("Press any key to return to home");
            Console.Read();
        }
    }
    private int DisplayOrHome()
    {
        Console.Write("Option\n1. Select an item\t2. Home\nEnter your option: ");
        while (true)
        {
            if (int.TryParse(Console.ReadLine(), out int option) && option > 0 && option < 3)
            {
                return option;
            }
            Console.WriteLine("Invalid input. Please enter a number from the menu.");
            Console.Write("Option\n1. Select an item\t2. Home\nEnter your option: ");
        }
    } 
    private void getItems()
    {
        // Clear previous lists to avoid duplicates
        weapons.Clear();
        helmets.Clear();
        chest.Clear();
        gloves.Clear();
        boots.Clear();
        equiped.Clear();
        if (player.inventory != null) {
            for (int i = 0; i < player.inventory.Count; i++)
            {
                switch (player.inventory[i].type)
                {
                    case EquipmentType.Type.weapon:
                        if (player.inventory[i].IsEquipped)
                        {
                            equiped.Add(player.inventory[i]);
                        }
                        else
                        {
                            weapons.Add(player.inventory[i]);
                        }
                        break;
                    case EquipmentType.Type.helmet:
                        if (player.inventory[i].IsEquipped)
                        {
                            equiped.Add(player.inventory[i]);
                        }
                        else
                        {
                            helmets.Add(player.inventory[i]);
                        }
                        break;
                    case EquipmentType.Type.chest:
                        if (player.inventory[i].IsEquipped)
                        {
                            equiped.Add(player.inventory[i]);
                        }
                        else
                        {
                            chest.Add(player.inventory[i]);
                        }
                        break;
                    case EquipmentType.Type.gloves:
                        if (player.inventory[i].IsEquipped)
                        {
                            equiped.Add(player.inventory[i]);
                        }
                        else
                        {
                            gloves.Add(player.inventory[i]);
                        }
                        break;
                    case EquipmentType.Type.boots:
                        if (player.inventory[i].IsEquipped)
                        {
                            equiped.Add(player.inventory[i]);
                        }
                        else
                        {
                            boots.Add(player.inventory[i]);
                        }
                        break;
                }
            }
        }
    }

    private void DisplayEquiped()
    {
        if (equiped != null)
        {
            Console.WriteLine("Equiped\n\n");
            for (int i = 0; i < equiped.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {equiped[i].ToString()}");
            }
        }
        else
        {
            Console.WriteLine("Equiped\n\n none yet");
        }
    }
    private void DisplayWeapons()
    {
        if (weapons != null)
        {
            Console.WriteLine("WEAPONS\n\n");
            for (int i = 0; i < weapons.Count; i++)
            {
                Console.WriteLine($"{i + 1 + equiped.Count}. {weapons[i].ToString()}");
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
                Console.WriteLine($"{i + 1 + equiped.Count + weapons.Count}. {helmets[i].ToString()}");
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
                Console.WriteLine($"{i + 1 + equiped.Count + helmets.Count + weapons.Count}. {chest[i].ToString()}");
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
                Console.WriteLine($"{i + 1 + equiped.Count + chest.Count+ helmets.Count + weapons.Count}. {gloves[i].ToString()}");
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
                Console.WriteLine($"{i + 1 + equiped.Count + gloves.Count + chest.Count + helmets.Count + weapons.Count}. {boots[i].ToString()}");
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
        Console.WriteLine(player.inventory[item - 1].ToString());

        EquipmentMenu(item);
    }
    private bool CanEquip(int item)
    {
        // validate if equip already exist
        for (int i = 0; i < equiped.Count; i++)
        {
            if (player.inventory[item - 1].type == equiped[i].type)
            {
                return false;
            }
        }
        return true;
    }
    private void EquipmentMenu(int item)
    {
        int choice;
        if (!player.inventory[item - 1].IsEquipped)
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
                player.inventory[item - 1].Upgrade();
                Console.Read();
            }
            else if (choice == 2)
            {
                bool b = CanEquip(item);
                if (b)
                {
                    player.inventory[item - 1].Equip(player);
                    DrawItem(DisplayItem());
                }
                else
                {
                    Console.WriteLine($"Already have {player.inventory[item - 1].type.ToString()}");
                }
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
                player.inventory[item - 1].Upgrade();
                Console.Read();
            }
            else if (choice == 2) 
            {
                player.inventory[item - 1].UnEquip(player);
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