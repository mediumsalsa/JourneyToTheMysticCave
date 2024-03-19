using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyToTheMysticCave_Beta
{
    internal class Ranger : Enemy
    {
        Random random = new Random();
        LegendColors legendColors;

        public Ranger(int count, char character, string name, int damage, LegendColors legendColors, Player player, Gamelog log, EnemyManager enemyManager, Map map) : base(count, character, name, damage, player, enemyManager, map, log)
        {
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
            if (!healthSystem.mapDead)
            {
                if (PlayerDistance() < 10 && PlayerDistance() >= 3)
                {
                    do
                    {
                        dx = Math.Sign(player.pos.x - pos.x); // calculations direction to player
                        dy = Math.Sign(player.pos.y - pos.y);

                        newDx = pos.x + dx;
                        newDy = pos.y + dy;

                    } while (CheckValidMovement(newDx, newDy, 0) && newDx != player.pos.x && newDy != player.pos.y);

                    pos = new Point2D { x = newDx, y = newDy};
                }
                if (PlayerDistance() <= 4)
                    AttackPlayer();
            }
        }

        private void AttackPlayer()
        {
            player.healthSystem.TakeDamage(damage);
            log.enemyAttack = $"by Ranger arrow - {damage} damage";
        }
    }
}
