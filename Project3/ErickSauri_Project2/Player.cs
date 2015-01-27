using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sauri_Project3
{
    public class Player: Tile
    {
        int health;
        int dice;
        int gold;

        public Player(int c, int r) : base(c, r, "player")
        {
            health = 100;
            gold = 0;
            dice = 1;
        }

        public int Dice
        {
            get { return dice; }
            set { dice = value; }
        }

        public int Health
        {
            get { return health; }
            set { health = value; }
        }

        public int Gold
        {
            get { return gold; }
            set { gold = value; }
        }
        public void takeDamage(int h)
        {
            health -= h;
        }
    }
}
