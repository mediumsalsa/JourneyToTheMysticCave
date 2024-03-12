using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyToTheMysticCave_Beta
{
    internal abstract class Enemy : GameEntity
    {
        public enum State
        {
            Attacking,
            Chasing,
            Patroling
        }

        Player player;
        Ranger ranger;
        Mage mage;
        Melee slime;
        Boss boss;
        Gamelog gamelog;
        Map map;
        _GameStats stats;
        
        // Amount of enemies
        public int count;
        
        // Movement
        public int dx;
        public int dy;
        public int newDx;
        public int newDy;

        //Health
        public int maxHp;
        public int minHp;
        public int randomHealth;

        public void Init(Player player)
        {
            this.player = player;
        }

        public virtual void Update()
        {
            //enemy movements would be here
        }

        public virtual void Draw()
        {
            Console.SetCursorPosition(pos.x, pos.y);
            Console.Write(character);
            Console.CursorVisible = false;
        }

        public void RandomHealthAmount()
        {

        }
    }
}
