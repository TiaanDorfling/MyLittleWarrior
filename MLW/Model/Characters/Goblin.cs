namespace MLW.Model.Characters
{
    internal class Goblin : Character
    {
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

        public Goblin(int level)
        {
            Name = "Goblin";
            Hp = level*2 + 7;
            Atk = level*2;
            Level = level;
            Design = @"
##########################################
#                                        #
#                                        #
#                                        #
#            0           0               #
#           0         0                  #
#          00  .-. .- 00                 #
#          |  \o| |o (                   #
#          \     ^    \                  #
#           '.  ()  .'                   #
#             `-----'                    #
#             /     \                    #
#            /       \                   #
#           |         |                  #
#          /|         |\                 #
#         / |         | \                #
#        *  |         |  *               #
#                                        #
#                                        #
#                                        #
##########################################
";
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
    }
}
