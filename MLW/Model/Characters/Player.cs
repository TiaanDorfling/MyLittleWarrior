using MLW.Controller.Sound;

namespace MLW.Model.Characters;

public class Player : Character
{
    // The single instance of the Player class.
    private static Player _instance;

    // A lock object to ensure thread-safe creation.
    private static readonly object _lock = new object();

    // The private constructor prevents direct instantiation.
    private Player()
    {
        Name = getPlayerDetails();
        Atk = 2;
        Hp = 10;
        Level = 1;
        Design = @"
##############################################
#                                            #
#                                            #
#                                            #
#                .-""""--                    #
#               / -   -  \                   #
#              |  .-. .- |                   #
#              |  \o| |o (                   #
#              \     ^    \                  #
#               '.  (_)  .'                  #
#                 `-----'                    #
#                /  ___  \                   #
#               |  |   |  |                  #
#               |  |___|  |                  #
#              /|  |___|  |\                 #
#             / |         | \                #
#            *  |         |  *               #
#                                            #
#                                            #
#                                            #
##############################################";
        AtkDesign = @"
##############################################
#                                            #
#                                            #
#                                            #
#                .-""""--                    #
#               / ⋱   ⋱  \                   #
#              |  .-. .- |                   #
#              |  \-| |- (                   #
#              \     ^    \                  #
#               '.  ()  .'                   #
#                 `-----'      /\            #
#                /  ___  \     ||            #
#               |  |   |  |    ||            #
#               |  |___|  |    ||            #
#              /|  |___|  |\  /==\           #
#             / |         | --*:|            #
#            *  |         |    \/            #
#                                            #
#                                            #
#                                            #
##############################################";
    }


    //Create Character
    private string getPlayerDetails()
    {
        Console.WriteLine("Welcome to our game. Please Create your character.");
        Console.Write("Enter your character name: ");
        string name = Console.ReadLine();
        Console.Clear();
        return name;
    }

    // Public static method to get the single instance.
    public static Player Instance
    {
        get
        {
            // Thread-safe check to ensure only one instance is created.
            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = new Player();
                }
                return _instance;
            }
        }
    }

    public override void DrawCharacter()
    {
        Console.WriteLine("=======================");
        Console.WriteLine(Design);
        Console.WriteLine("=======================");
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Hp: {Hp}");
        Console.WriteLine($"Atk: {Atk}");
        Console.WriteLine($"Level: {Level}");
    }

    public override void Attack(Character target)
    {
        target.Hp -= Atk;
    }

    public override void RestoreHealth()
    {
        //resotre hp after combat
        Hp = 10;
    }

    public override List<Equipment> getInventory()
    {
        return inventory;
    }

    public override void addToInventory(Equipment item)
    {
        inventory.Add(item);
    }

    public override void removeFromInventory(Equipment item)
    {
        inventory.Remove(item);
    }

    public override void AtkSoundEffect()
    {
        SoundManager.PlayRandomAttackSoundForPlayer();
    }
}
