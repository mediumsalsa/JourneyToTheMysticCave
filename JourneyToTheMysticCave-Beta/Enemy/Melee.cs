using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyToTheMysticCave_Beta
{
    internal class Melee : Enemy
    {
        LegendColors legendColors;

        public Melee(int count, char character, string name, int damage, LegendColors legendColors, Player player, Gamelog log, EnemyManager enemyManager, Map map) : 
            base(count, character, name, damage, player, enemyManager, map, log)
        {
            this.legendColors = legendColors;
        }

        public override void Update(Random random)
        {
            if (!healthSystem.mapDead)
                Movement(random);
            else
            {
                IsAlive = false;
                pos = new Point2D { x = 0, y = 0 };
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

        private void Movement(Random random)
        {
            if (PlayerDistance() < 4)
            {
                do
                {
                    dx = Math.Sign(player.pos.x - pos.x); // Calculate direction to player
                    dy = Math.Sign(player.pos.y - pos.y);

                    newDx = pos.x + dx; // Calculate new position
                    newDy = pos.y + dy;

                    if (CheckValidMovement(newDx, newDy, 2))
                    {
                        if (newDx == player.pos.x && newDy == player.pos.y)
                            AttackPlayer($"by Slime sludge - {damage} damage");
                        else
                            pos = new Point2D { x = newDx, y = newDy };
                        break; // Break the loop if movement is valid
                    }
                } while (true);
            }
            else
            {
                do
                {
                    int direction = random.Next(0, 4);
                    dx = (direction == 2) ? 1 : (direction == 3) ? -1 : 0;
                    dy = (direction == 0) ? 1 : (direction == 1) ? -1 : 0;

                    newDx = pos.x + dx; // Calculate new position
                    newDy = pos.y + dy;

                    if (CheckValidMovement(newDx, newDy, 2))
                    {
                        pos = new Point2D { x = newDx, y = newDy }; // Update position
                        break; // Break the loop if movement is valid
                    }
                } while (true);
            }
        }
    }
}
