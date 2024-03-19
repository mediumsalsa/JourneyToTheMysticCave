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
        Gamelog log;
        Map map;

        public Melee(int count, char character, string name, int damage, LegendColors legendColors, Player player, Gamelog log, EnemyManager enemyManager, Map map) : base(count, character, name, damage, player, enemyManager)
        {
            this.legendColors = legendColors;
            this.log = log;
            this.map = map;
        }

        public override void Update(Random random)
        {
            if (!healthSystem.mapDead)
            {
                Movement(random);
            }
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

        private void Movement(Random randomMovement)
        {
            if(!healthSystem.mapDead)
            {
                if(PlayerDistance() < 4)
                {
                    do
                    {
                        dx = Math.Sign(player.pos.x - pos.x); // calculations direction to player
                        dy = Math.Sign(player.pos.y - pos.y);

                        newDx = pos.x + dx;
                        newDy = pos.y + dy;

                    } while (map.CheckBoundaries(newDx, newDy) && enemyManager.CheckEnemyPos(newDx, newDy, 0));


                    if (newDx == player.pos.x && newDy == player.pos.y)
                        AttackPlayer();
                    else
                        pos = new Point2D { x =  newDx, y = newDy };
                    //CheckFloor(newDx, newDy)?? for poison or traps? or should trap handle this?
                }
                else
                {
                    do
                    {
                    int direction = randomMovement.Next(0, 4);
                    dx = (direction == 2) ? 1 : (direction == 3) ? -1 : 0;
                    dy = (direction == 0) ? 1 : (direction == 1) ? -1 : 0;

                    newDx = pos.x + dx;
                    newDy = pos.y + dy;

                    } while (map.CheckBoundaries(newDx, newDy) && enemyManager.CheckEnemyPos(newDx, newDy, 0)) ;
                    pos = new Point2D { x = newDx, y = newDy };
                }
                //CheckFloor(newDx, newDy)?? for poison or traps? or should trap handle this?
            }
        }

        private void AttackPlayer()
        {
            player.healthSystem.TakeDamage(damage);
            log.enemyAttack = $"by Slime sludge - {damage} damage";
        }
    }
}
