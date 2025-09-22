using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLW.Model
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
            Hp = level*2 + 3;
            Atk = level*2 - 1;
            Level = level;
            Design = @"
        0           0
       0         0 
      00  .-. .- 00
      |  \o| |o (
      \     ^    \
       '.  ()  .'
         `-----'
         /     \
        /       \
       |         |
      /|         |\
     / |         | \
    *  |         |  *";
        }
    }
}
