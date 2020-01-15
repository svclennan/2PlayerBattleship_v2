using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship_v2
{
    abstract class Ship
    {
        public string name;
        public int spaces;
        public int colStart;
        public int rowStart;
        public string direction;
        public abstract void setPosition(int column, int row);
        public abstract void setDirection(string direction);
    }
}
