using JourneyToTheMysticCave_Beta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyToTheMysticCave_Beta
{
    internal class Mage : Enemy
    {
        LegendColors legendColors;
        public int moveCount = 0;

        public Mage(int count, char character, string name, int damage, LegendColors legendColors, Player player, Gamelog log, Map map, EnemyManager enemyManager) : base(count, character, name, damage, player, enemyManager, map, log)
        {
            this.legendColors = legendColors;
        }

        public override void Update(Random random)
        {
            if (!healthSystem.mapDead)
            {
                Movement(random);
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

        void Movement(Random random)
        {
            if (!healthSystem.mapDead)
            {
                if (moveCount == 10)
                    pos = RandomPlacement(random);
                else
                {
                    if (pos.x == player.pos.x || pos.y == player.pos.y)
                        AttackPlayer();
                    else
                        moveCount++;
                }
            }
        }

        private void AttackPlayer()
        {
            if (PlayerDistance() <= 8)
            {
                player.healthSystem.TakeDamage(damage, "Attacked");
                log.enemyAttack = $"by mage magic - {damage} damage";
            }
        }

        private Point2D RandomPlacement(Random random)
        {
            int x, y;
            Console.SetCursorPosition(0, 36);
            Console.WriteLine(moveCount.ToString());
            x = random.Next(0, map.GetCurrentMapContent().GetLength(1));
            y = random.Next(0, map.GetCurrentMapContent().GetLength(0));

            if (CheckValidMovement(x, y, 2) && x != player.pos.x && y != player.pos.y)
            {
                moveCount = 0;
                return new Point2D { x = x, y = y };
            }
            else
            {
                moveCount = 10;
                return new Point2D { x = pos.x, y = pos.y };
            }
        }
    }
}