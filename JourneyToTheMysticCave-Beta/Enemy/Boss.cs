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

        public Boss(int count, char character, string name, int damage, LegendColors legendColors, Player player, Gamelog log, EnemyManager enemyManager, Map map) : base(count, character, name, damage, player, enemyManager, map, log)
        {
            this.legendColors = legendColors;
        }

        public override void Update(Random random)
        {
            if (!healthSystem.mapDead)
                Movement();
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
            dx = Math.Sign(player.pos.x - pos.x);
            dy = Math.Sign(player.pos.y - pos.y);

            newDx = pos.x + dx;
            newDy = pos.y + dy;

            if (CheckBoundaries(newDx, newDy))
            {
                if (player.pos.x == newDx && player.pos.y == newDy)
                    AttackPlayer();
                else
                    pos = new Point2D { x = newDx, y = newDy };
            }
        }

        private void AttackPlayer()
        {
            player.healthSystem.TakeDamage(damage, "Attacked");
            log.enemyAttack = $"by a giant fist - {damage} damage";
        }
    }
}
