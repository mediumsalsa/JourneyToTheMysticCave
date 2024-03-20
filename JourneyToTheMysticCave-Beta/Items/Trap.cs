using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyToTheMysticCave_Beta
{
    internal class Trap : Item
    {
        public int trapDamage;
        LegendColors legendColors;
        Gamelog log;
        Player player;
        EnemyManager enemyManager;
        LevelManager levelManager;

        public Trap(int count, char character, string name, int trapDamage, LegendColors legendColors, Gamelog log, Player player, EnemyManager enemyManager, LevelManager levelManager) : base(count, character, name)
        {
            this.trapDamage = trapDamage;
            this.legendColors = legendColors;
            this.log = log;
            this.player = player;
            this.enemyManager = enemyManager;
            this.levelManager = levelManager;
        }

        public override void Update()
        {
            if (pickedUp)
            {
                GetEntityAtPosition(pos.x, pos.y).healthSystem.TakeDamage(trapDamage, "Trap");
                pickedUp = false;
            }
        }

        public override void Draw()
        {
            if (!collected)
            {
                Console.SetCursorPosition(pos.x, pos.y);
                legendColors.MapColor(character);
                Console.Write(character.ToString());
                Console.ResetColor();
            }
            Console.CursorVisible = false;
        }

        private GameEntity GetEntityAtPosition(int x, int y)
        {
            foreach (Enemy enemy in enemyManager.enemies)
            {
                if (enemy is Mage && levelManager.mapLevel == 1)
                {
                    if (enemy.pos.x == x && enemy.pos.y == y)
                        return enemy;
                }
                if (enemy is Melee && levelManager.mapLevel == 2)
                {
                    if (enemy.pos.x == x && enemy.pos.y == y)
                        return enemy;
                }
            }
            if(player.pos.x == x && player.pos.y == y)
                return player;

            return null;
        }
    }
}