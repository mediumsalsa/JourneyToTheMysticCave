using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyToTheMysticCave_Beta
{
    internal abstract class Enemy : GameEntity
    {
        protected int count;
        Player player;

       
        // Constructor
        public Enemy(int count, char character, string name, int damage, Player player)
        {
            this.count = count;
            this.character = character;
            this.name = name;
            this.damage = damage;
            this.player = player;
        }

        // Movement
        public int dx;
        public int dy;
        public int newDx;
        public int newDy;
        
        public abstract void Draw();
        public abstract void Update();

        public int PlayerDistance() //calculates distance to player
        {
            return Math.Abs(pos.x - player.pos.x) + Math.Abs(pos.y - player.pos.y);
        }
    }
}
