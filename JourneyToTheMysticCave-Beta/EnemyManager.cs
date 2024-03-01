using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyToTheMysticCave_Beta
{
    internal abstract class EnemyManager : GameEntity
    {
        public Player player;
        Ranged ranger;
        Mage mage;
        Melee slime;
        Boss boss;

        public Gamelog gamelog;
        public Map map;
        public _GameStats stats;
        public int count;

        Random randomMovement = new Random();

        public int dx;
        public int dy;
        public int newDx;
        public int newDy;

        List<EnemyManager> enemies = new List<EnemyManager>();

        public virtual void Init(Player player, Gamelog gamelog, Map map) //used for all enemies
        {
            this.player = player;
            this.gamelog = gamelog;
            this.map = map;

            for (int i = 0; i < ranger.count; i++)
                enemies.Add(new Ranged());
            for (int i = 0;i < mage.count; i++)
                enemies.Add(new Mage());
            for(int i = 0;i < slime.count; i++)
                enemies.Add(new Melee());
            for(int i = 0;i < boss.count ; i++)
                enemies.Add(new Boss());
        }

        public virtual void Update()
        {

        }

        public virtual void Draw()
        {

        }

        public int PlayerDistance() //calculates distance to player
        {
            return Math.Abs(pos.x - player.pos.x) + Math.Abs(pos.y - player.pos.y);
        }

        // public bool CheckValidPlacement() <-- needs to be set up properly for this project
    }
}
