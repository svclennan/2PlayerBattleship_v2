using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship_v2
{
    class Bot : Player
    {
        Random rand;
        string previous;
        public Bot(string name)
        {
            this.name = name;
            this.ships = new List<Ship>() { new Carrier(), new Battleship(), new Submarine(), new Destroyer() };
            this.ownBoard = new Board();
            this.targetBoard = new Board();
            rand = new Random();
            previous = "";
            SetupShipDirection();
            SetupShipPosition();
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
        public void SetupShipPosition()
        {
            foreach (Ship ship in ships)
            {
                ChoosePosition(ship);
            }
        }
        public void ChoosePosition(Ship ship)
        {
            int row;
            int col;
            if (ship.direction == "RIGHT")
            {
                 row = rand.Next(0, 20);
                 col = rand.Next(0, (20 - ship.spaces));
            }
            else
            {
                row = rand.Next(0, 20 - ship.spaces);
                col = rand.Next(0, 20);
            }
            ship.setPosition(col, row);
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
            int direction = rand.Next(0, 2);
            if (direction == 0)
            {
                ship.direction = "RIGHT";
            }
            else
            {
                ship.direction = "DOWN";
            }
        }
        public void SetupBoard()
        {
            foreach (Ship ship in ships)
            {
                while (ship.spaces > 0)
                {
                    while (ownBoard.board[ship.rowStart, ship.colStart] != " ")
                    {
                        Console.WriteLine($"{ship.name} collides with another ship.");
                        ChooseDirection(ship);
                        ChoosePosition(ship);
                    }
                    ownBoard.board[ship.rowStart, ship.colStart] = ship.letter;
                    ship.spaces--;
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
            }
            ownBoard.print();
        }
        public override string Attack()
        {
            char part1 = Convert.ToChar(rand.Next(65, 85));
            int part2 = rand.Next(0, 20);
            string output = "" + part1 + part2;
            if (previous.Contains(output))
            {
                return Attack();
            }
            else
            {
                return output;
            }
        }
        public override string Defend(string target)
        {
            int column = target[0] - 65;
            int row = Convert.ToInt32(target.Remove(0, 1));
            if (ownBoard.board[row, column] != " ")//if input is [15,20], it takes input as [1,520]
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
