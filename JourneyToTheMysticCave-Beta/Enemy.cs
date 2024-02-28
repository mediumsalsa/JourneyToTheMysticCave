using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyToTheMysticCave_Beta
{
    internal abstract class Enemy : GameEntity
    {
        public Player player;
        public Gamelog gamelog;
        public Map map;

        Random randomMovement = new Random();

        public int dx;
        public int dy;
        public int newDx;
        public int newDy;

        public virtual void Init(Player player, Gamelog gamelog, Map map) //used for all enemies
        {
            this.player = player;
            this.gamelog = gamelog;
            this.map = map;
        }

        public virtual void Update()
        {

        }

        public int PlayerDistance() //calculates distance to player
        {
            return Math.Abs(pos.x - player.pos.x) + Math.Abs(pos.y - player.pos.y);
        }

        // public bool CheckValidPlacement() <-- needs to be set up properly for this project
    }
}
