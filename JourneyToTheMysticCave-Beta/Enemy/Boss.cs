using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyToTheMysticCave_Beta
{
    internal class Boss : Enemy
    {
        LegendColors legendColors;

        public Boss(int count, char character, string name, int damage, int health, LegendColors legendColors, Player player, Gamelog log, EnemyManager enemyManager, Map map) : base(count, character, name, damage, player, enemyManager, map, log)
        {
            this.count = count;
            this.character = character;
            this.name = name;
            this.damage = damage;
            healthSystem = new HealthSystem();
            healthSystem.health = health;
            this.legendColors = legendColors;
        }

        public override void Update(Random random)
        {
            if (!healthSystem.mapDead)
            {
                Movement();
            }
            else
                pos = new Point2D { x = 0, y = 0 };
        }

        public override void Draw()
        {
            if (!healthSystem.mapDead)
            {
                Console.SetCursorPosition(pos.x, pos.y);
                legendColors.MapColor(character);
                Console.Write(character.ToString());
                Console.ResetColor();
            }
            Console.CursorVisible = false;
        }

        private void Movement()
        {

        }
    }
}
