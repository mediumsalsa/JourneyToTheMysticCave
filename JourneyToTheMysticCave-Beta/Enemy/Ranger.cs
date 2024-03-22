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

        public Ranger(int count, char character, string name, int damage, LegendColors legendColors, Player player, Gamelog log, EnemyManager enemyManager, Map map, GameStats stats) : 
            base(count, character, name, damage, player, enemyManager, map, log, stats)
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
            {
                pos = new Point2D { x = 0, y = 0 };
                IsAlive = false;
            }
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
                if (PlayerDistance() < 10 && PlayerDistance() >= 4)
                {
                     
                    dx = Math.Sign(player.pos.x - pos.x); // calculations direction to player
                    dy = Math.Sign(player.pos.y - pos.y);

                        newDx = pos.x + dx; // Calculate new position
                        newDy = pos.y + dy;

                    if(CheckValidMovement(newDx, newDy))
                    {
                        CheckFloor(newDx, newDy);
                        pos = new Point2D { x = newDx, y = newDy };
                    }
                }
                if (PlayerDistance() <= 3)
                    AttackPlayer();
            }
        }

        private void AttackPlayer()
        {
            player.healthSystem.TakeDamage(damage, "Attacked");
            log.enemyAttack = $"by Ranger arrow - {damage} damage";
        }
        private bool CheckValidMovement(int x, int y)
        {
            return CheckBoundaries(x, y) && !CheckRangerPos(x, y) && (player.pos.x != x && player.pos.y != y);
        }

        public bool CheckRangerPos(int x, int y)
        {
            foreach (Enemy enemy in enemyManager.enemies)
            {
                if (enemy.GetType().Name == nameof(Ranger))
                {
                    if (enemy.pos.x == x && enemy.pos.y == y)
                        return true;
                }
            }
            return false;
        }
    }
}
