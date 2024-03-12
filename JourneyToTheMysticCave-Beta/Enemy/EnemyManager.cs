using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyToTheMysticCave_Beta
{
    internal class EnemyManager 
    {
        public List<Enemy> enemies;

        public EnemyManager()
        {
            enemies = new List<Enemy>();
        }

        public Player player;
        Ranger ranger;
        Mage mage;
        Melee melee;
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

        public void Init(Player player, Map map, Ranger ranger, Mage mage, Melee melee, Boss boss) //used for all enemies
        {
            this.player = player;
            //this.gamelog = gamelog;
            this.map = map;
            this.ranger = ranger;
            this.mage = mage;
            this.melee = melee;
            this.boss = boss;

            for (int i = 0; i < ranger.count; i++)
                enemies.Add(new Ranger());
            for (int i = 0;i < mage.count; i++)
                enemies.Add(new Mage());
            for(int i = 0; i < this.melee.count; i++)
                enemies.Add(new Melee());
            for(int i = 0;i < boss.count ; i++)
                enemies.Add(new Boss());
        }

        public void Update()
        {
            foreach(Enemy enemy in enemies)
                enemy.Update();
        }

        public void Draw()
        {
            foreach (Enemy enemy in enemies)
                enemy.Draw();
        }

        //public int PlayerDistance() //calculates distance to player
        //{
        //    return Math.Abs(pos.x - player.pos.x) + Math.Abs(pos.y - player.pos.y);
        //}

        // public bool CheckValidPlacement() <-- needs to be set up properly for this project
    }
}
