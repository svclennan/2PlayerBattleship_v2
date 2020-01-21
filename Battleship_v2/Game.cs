using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Battleship_v2
{
    class Game
    {
        Player p1;
        Player p2;
        public Game()
        {
            ChooseGameType();
            while (!p1.CheckDead() && !p2.CheckDead())
            {
                string attack = p1.Attack();
                Console.WriteLine($"{p1.name} {p2.Defend(attack)}");
                p2.ownBoard.print();
                Console.Clear();
                attack = p2.Attack();
                Console.WriteLine($"{p2.name} {p1.Defend(attack)}");
                p1.ownBoard.print();
                Console.Clear();
            }
            if (p1.CheckDead())
            {
                Console.WriteLine($"{p1.name} wins!");
            }
            else
            {
                Console.WriteLine($"{p2.name} wins!");
            }
        }
        public void ChooseGameType()
        {
            Console.WriteLine("Would you like to play\n1)PvP\n2)PvB\n3)BvB");
            bool input = false;
            while (!input)
            {
                switch (Console.ReadLine())
                {
                    case ("1"):
                        {
                            Console.WriteLine("What is player one's name?");
                            p1 = new Human(Console.ReadLine());
                            Console.ReadLine();
                            Console.Clear();
                            Console.WriteLine("What is player two's name?");
                            p2 = new Human(Console.ReadLine());
                            Console.ReadLine();
                            Console.Clear();
                            input = true;
                            break;
                        }
                    case ("2"):
                        {
                            Console.WriteLine("What is the player's name?");
                            p1 = new Human(Console.ReadLine());
                            Console.ReadLine();
                            Console.Clear();
                            Console.WriteLine("What is the bot's name?");
                            p2 = new Bot(Console.ReadLine());
                            Console.ReadLine();
                            Console.Clear();
                            input = true;
                            break;
                        }
                    case ("3"):
                        {
                            Console.WriteLine("What is bot one's name?");
                            p1 = new Bot(Console.ReadLine());
                            Console.ReadLine();
                            Console.Clear();
                            Console.WriteLine("What is bot two's name?");
                            p2 = new Bot(Console.ReadLine());
                            Console.ReadLine();
                            Console.Clear();
                            input = true;
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Not a valid option. Choose again.");
                            break;
                        }
                }
            }
        }
    }
}
