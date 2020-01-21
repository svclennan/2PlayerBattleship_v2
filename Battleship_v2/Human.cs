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
            this.ownBoard = new Board();
            this.targetBoard = new Board();
            SetupShips();
            SetupBoard();
        }
        public override bool CheckDead()
        {
            bool output = true;
            foreach (string value in ownBoard.board)
            {
                if (value != " ")
                {
                    output = false;
                }
            }
            return output;
        }
        public void SetupShips()
        {
            foreach (Ship ship in ships)
            {
                ChoosePosition(ship);
                ChooseDirection(ship);
                while (!ValidInput(ship.colStart, ship.rowStart, ship))
                {
                    ChoosePosition(ship);
                    ChooseDirection(ship);
                }
            }
        }
        public void SetupShipPosition()
        {
            foreach (Ship ship in ships)
            {
                ChoosePosition(ship);
            }
        }
        public void ChoosePosition(Ship ship)
        {
            Console.WriteLine($"{name}, where would you like to place your {ship.name}?(Format: LetterNumber)");
            string placement = Console.ReadLine().ToUpper();
            char column = placement[0];
            int columnIndex = column - 65;
            int row = TryConvert(placement.Remove(0, 1));
            if (columnIndex >= 0)
            {
                ship.setPosition(columnIndex, row - 1);
            }
            else
            {
                ChoosePosition(ship);
            }
        }
        public void SetupShipDirection()
        {
            foreach (Ship ship in ships)
            {
                ChooseDirection(ship);
            }
        }
        public void ChooseDirection(Ship ship)
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
        public void SetupBoard()
        {
            foreach (Ship ship in ships)
            {
                int tiles = ship.spaces;
                while(!OpenWater(ship))
                {
                    Console.WriteLine($"{ship.name} collides.");
                    ChoosePosition(ship);
                    ChooseDirection(ship);
                    while (!ValidInput(ship.colStart, ship.rowStart, ship))
                    {
                        ChoosePosition(ship);
                        ChooseDirection(ship);
                    }
                }
                while (tiles > 0)
                {
                    ownBoard.board[ship.rowStart, ship.colStart] = ship.letter;
                    tiles--;
                    switch (ship.direction)
                    {
                        case ("DOWN"):
                            {
                                ship.rowStart++;
                                break;
                            }
                        case ("RIGHT"):
                            {
                                ship.colStart++;
                                break;
                            }
                    }
                }
                ownBoard.print();
            }
            ownBoard.print();
        }
        public bool OpenWater(Ship ship)
        {
            bool output = true;
            if (ship.direction == "RIGHT")
            {
                for (int i = 0; i < ship.spaces; i++)
                {
                    if (ownBoard.board[ship.rowStart, ship.colStart + i] != " ")
                    {
                        output = false;
                        break;
                    }
                }
            }
            if(ship.direction == "DOWN")
            {
                for (int i = 0; i < ship.spaces; i++)
                {
                    if (ownBoard.board[ship.rowStart+i, ship.colStart] != " ")
                    {
                        output = false;
                        break;
                    }
                }
            }
            return output;
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
        public bool ValidInput(int col, int row, Ship ship)
        {
            if (ship.direction == "RIGHT")
            {
                if (col > -1 && col < 21-ship.spaces)
                {
                    if (row > -1 && row < 21)
                    {
                        return true;
                    }
                }
            }
            if (ship.direction == "DOWN")
            {
                if (col > -1 && col < 21)
                {
                    if (row > -1 && row < 21 - ship.spaces)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public override string Attack()
        {
            Console.WriteLine("Your previous attacks:");
            targetBoard.print();
            Console.WriteLine("Choose a location to attack.(NumberLetter)");
            string target = Console.ReadLine().ToUpper();
            char column = target[0];
            int columnIndex = column - 65;
            int row = TryConvert(target.Remove(0, 1));
            return "" + column + row;
        }
        public override string Defend(string target)
        {
            int column = target[0]-65;
            int row = Convert.ToInt32(target.Remove(0, 1));
            if (ownBoard.board[row, column] != " ")
            {
                ownBoard.board[row, column] = " ";
                return "hit";
            }
            else
            {
                return "miss";
            }
        }
    }
}