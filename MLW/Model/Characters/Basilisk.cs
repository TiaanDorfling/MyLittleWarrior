using MLW.Controller.Sound;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MLW.Model.Characters
{
    internal class Basilisk : Character
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

        public Basilisk(int level)
        {
            Name = "Goblin";
            Hp = level * 3 + 10;
            Atk = level * 3 - 1;
            Level = level;
            Design = @"
##########################################
#                                        #
#                                        #
#                                        #
#           __====__                     #
#          /  o  o  \                    #
#         |    __    |                   #
#          \  \__/  /                    #
#           '------'                     #
#           /||||\                       #
#          / |||| \                      #
#         |  ||||  |                     #
#         |  ||||  |                     #
#          \ |||| /                      #
#           \||||/                       #
#            (  )                        #
#                                        #
#                                        #
#                                        #
#                                        #
##########################################
";
            AtkDesign = @"
##########################################
#                                        #
#                                        #
#                                        #
#           __====__                     #
#          /  o  o  \                    #
#         |    __    |                   #
#          \  \__/  /                    #
#           '------'   |  |  |           #
#           /||||\     |  |  |           #
#          / |||| \     \-=-/            #
#         |  ||||  |      |              #
#         |  ||||  |      |              #
#          \ |||| /       |              #
#           \||||/                       #
#            (  )                        #
#                                        #
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
        public override void AtkSoundEffect()
        {
            SoundManager.PlayRandomAttackSound();
        }
    }
}
