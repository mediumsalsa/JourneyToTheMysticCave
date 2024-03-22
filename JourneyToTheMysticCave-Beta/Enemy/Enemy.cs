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


        public abstract void Update(Random random);

        public abstract void Draw();

        public int PlayerDistance() //calculates distance to player
        {
            return Math.Abs(pos.x - player.pos.x) + Math.Abs(pos.y - player.pos.y);
        }

        public void AttackPlayer(string attack)
        {
            player.healthSystem.TakeDamage(damage, "Attacked");
            log.enemyAttack = attack;
        }

        #region Enemy Position Check
        public bool CheckValidMovement(int x, int y, int level)
        {
            return CheckBoundaries(x, y) && !CheckEnemyPos(x, y, level);
        }

        public bool CheckBoundaries(int x, int y)
        {
            return x > 0 && x < map.GetMapColumnCount() && y > 0 && y < map.GetMapRowCount() &&
                map.GetCurrentMapContent()[y, x] != '#' && map.GetCurrentMapContent()[y, x] != '^' && map.GetCurrentMapContent()[y, x] != '*';
        }

        public bool CheckEnemyPos(int x, int y, int level)
        {
            foreach (Enemy enemy in enemyManager.enemies)
            {
                if (level == 0 && enemy.GetType().Name == nameof(Ranger))
                {
                    if (enemy.pos.x == x && enemy.pos.y == y)
                        return true;
                }
                else if (level == 1 && enemy.GetType().Name == nameof(Mage))
                {
                        if (enemy.pos.x == x && enemy.pos.y == y)
                            return true;
                }
                else if (level == 2)
                {
                    if (enemy.GetType().Name == nameof(Melee))
                    {
                        if (enemy.pos.x == x && enemy.pos.y == y)
                            return true;
                    }
                }
            }
            return false;
        }
        #endregion
    }
}
