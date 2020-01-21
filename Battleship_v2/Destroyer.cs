using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship_v2
{
    class Destroyer : Ship
    {
        public Destroyer()
        {
            this.name = "Destroyer";
            this.spaces = 2;
            this.letter = "D";
        }
        public override void setPosition(int column, int row)
        {
            this.colStart = column;
            this.rowStart = row;
        }
        public override void setDirection(string direction)
        {
            this.direction = direction;
        }
    }
}
