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
        public bool processed;
        public bool inDeep;
        GameStats stats;
        public int moveCount;

        public bool IsAlive { get; set; } = true;

        // Constructor
        public Enemy(int count, char character, string name, int damage, Player player, EnemyManager enemyManager, Map map, Gamelog log, GameStats stats)
        {
            this.count = count;
            this.character = character;
            this.name = name;
            this.damage = damage;
            this.player = player;
            this.enemyManager = enemyManager;
            this.map = map;
            this.log = log;
            this.stats = stats;
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

        public bool CheckBoundaries(int x, int y)
        {
            return x > 0 && x < map.GetMapColumnCount() && y > 0 && y < map.GetMapRowCount() &&
                map.GetCurrentMapContent()[y, x] != '#' && map.GetCurrentMapContent()[y, x] != '^' && map.GetCurrentMapContent()[y, x] != '*';
        }

        public void CheckFloor(int x, int y)
        {
            if (map.GetCurrentMapContent()[y, x] == 'P')
            {
                healthSystem.TakeDamage(stats.PoisonDamage, "Floor");
            }
            else if (map.GetCurrentMapContent()[y, x] == '~' && !inDeep)
            {
                inDeep = true;
                pos.x = x; pos.y = y;
                moveCount = 0;
            }
            else if (inDeep)
                moveCount++;
            if(moveCount == 1)
                moveCount = 0;
        }
    }
}
