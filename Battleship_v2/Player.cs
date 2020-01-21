using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship_v2
{
    abstract class Player
    {
        public string name;
        public List<Ship> ships;
        public Board ownBoard;
        public Board targetBoard;
        abstract public string Attack();
        abstract public string Defend(string target);
        abstract public bool CheckDead();
    }
}
