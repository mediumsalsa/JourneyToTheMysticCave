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
        public EnemyManager enemyManager;
        public Player player;
        public Map map;
        public Gamelog log;

        public bool IsAlive { get; set; } = true;

        // Constructor
        public Enemy(int count, char character, string name, int damage, Player player, EnemyManager enemyManager, Map map, Gamelog log)
        {
            this.count = count;
            this.character = character;
            this.name = name;
            this.damage = damage;
            this.player = player;
            this.enemyManager = enemyManager;
            this.map = map;
            this.log = log;
        }

        // Movement
        public int dx;
        public int dy;
        public int newDx;
        public int newDy;

        public abstract void Draw();
        public abstract void Update(Random random);

        public int PlayerDistance() //calculates distance to player
        {
            return Math.Abs(pos.x - player.pos.x) + Math.Abs(pos.y - player.pos.y);
        }

        public void AttackPlayer(string attack)
        {
            player.healthSystem.TakeDamage(damage);
            log.enemyAttack = attack;
        }

        #region Enemy Position Check
        public bool CheckValidMovement(int x, int y, int level)
        {
            return CheckBoundaries(x, y) && CheckEnemyPos(x, y, level);
        }

        private bool CheckBoundaries(int x, int y)
        {
            return x > 0 && x < map.GetMapColumnCount() && y > 0 && y < map.GetMapRowCount() &&
                map.GetCurrentMapContent()[y, x] != '#' && map.GetCurrentMapContent()[y, x] != '^' && map.GetCurrentMapContent()[y, x] != '*';
        }
        public bool CheckEnemyPos(int x, int y, int level)
        {
            switch (level)
            {
                case 0:
                    foreach (Enemy Ranger in enemyManager.enemies)
                        if (x == Ranger.pos.x && y == Ranger.pos.y)
                            return true;
                    break;
                case 1:
                    foreach (Enemy Mage in enemyManager.enemies)
                        if (x == Mage.pos.x && y == Mage.pos.y)
                            return true;
                    break;
                case 2:
                    foreach (Enemy Melee in enemyManager.enemies)
                        if (x == Melee.pos.x && y == Melee.pos.y)
                            return true;
                    break;
                default: return false;
            }
            return false;
        }

        #endregion
    }
}
