using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyToTheMysticCave_Beta
{
    internal class Enemy : GameEntity
    {
        public Player player;
        public char character;
        public string name;
        public Gamelog gamelog;
        Random randomMovement = new Random();

        public int dx;
        public int dy;
        public int newDx;
        public int newDy;

        public void Init(Player player) //used for all enemies
        {
            this.player = player;
        }

        public int PlayerDistance() //calculates distance to player
        {
            return Math.Abs(pos.x - player.pos.x) + Math.Abs(pos.y - player.pos.y);
        }

        // public bool CheckValidPlacement() <-- needs to be set up properly for this project
    }
}
