using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship_v2
{
    class Human : Player
    {
        public Human(string name)
        {
            this.name = name;
            this.ships = new List<Ship>() { new Carrier(), new Battleship(), new Submarine(), new Destroyer()};
            SetupShipPosition();
        }
        public void SetupShipPosition()
        {
            foreach (Ship ship in ships)
            {
                bool valid = false;
                while (!valid)
                {
                    Console.WriteLine($"{name}, where would you like to place your {ship.name}?(Format: LetterNumber)");
                    string placement = Console.ReadLine().ToUpper();
                    char column = placement[0];
                    int columnIndex = column - 65;
                    int row = TryConvert(placement.Remove(0, 1));
                    if (ValidInput(columnIndex, row))
                    {
                        ship.setPosition(columnIndex, row);
                        valid = true;
                    }
                    else
                    {
                        Console.WriteLine("Your input was invalid. Try again.");
                        valid = false;
                    }
                }
            }
        }
        public void SetupShipDirection()
        {
            foreach (Ship ship in ships)
            {
                bool valid = false;
                while (!valid)
                {
                    Console.WriteLine($"{name}, would you like your {ship.name} to travel right or down?");
                    string face = Console.ReadLine().ToUpper();
                    switch (face)
                    {
                        case "RIGHT":
                            {
                                ship.setDirection("RIGHT");
                                valid = true;
                                break;
                            }
                        case "DOWN":
                            {
                                ship.setDirection("DOWN");
                                valid = true;
                                break;
                            }
                        default:
                            {
                                Console.WriteLine("Invalid direction. Try again.");
                                break;
                            }
                    }
                }
            }
        }
        public int TryConvert(string number)
        {
            try
            {
                return Convert.ToInt32(number);
            }
            catch (Exception)
            {
                Console.WriteLine("That is not a number. Enter a number.");
                return TryConvert(Console.ReadLine());
            }
        }
        public bool ValidInput(int col, int row)
        {
            if (col > -1 && col < 21)
            {
                if (row > -1 && row < 21)
                {
                    return true;
                }
            }
            return false;
        }
    }
}