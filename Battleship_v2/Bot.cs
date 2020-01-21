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
        public Bot(string name)
        {
            this.name = name;
            this.ships = new List<Ship>() { new Carrier(), new Battleship(), new Submarine(), new Destroyer() };
            this.ownBoard = new Board();
            this.targetBoard = new Board();
            rand = new Random();
            SetupShipDirection();
            SetupShipPosition();
            SetupBoard();
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
    }
}
