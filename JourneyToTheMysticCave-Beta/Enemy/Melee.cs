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
        Random randomMovement = new Random();   
        Player player;
        Gamelog log;

        public Melee(int count, char character, string name, int damage, int health, LegendColors legendColors, Player player, Gamelog log) : base(count, character, name, damage, health, player)
        {
            this.count = count;
            this.character = character;
            this.name = name;
            this.damage = damage;
            healthSystem = new HealthSystem();
            this.health = health;
            this.legendColors = legendColors;
            this.player = player;
            this.log = log;
        }

        public override void Update()
        {
            Movement();
        }

        public override void Draw()
        {
            Console.SetCursorPosition(pos.x, pos.y);
            legendColors.MapColor(character);
            Console.Write(character);
            Console.ResetColor();
            Console.CursorVisible = false;
        }

        private void Movement()
        {
            if(!healthSystem.mapDead)
            {
                if(PlayerDistance() < 4)
                {
                    dx = Math.Sign(player.pos.x - pos.x);
                    dy = Math.Sign(player.pos.y - pos.y);

                    newDx = pos.x + dx;
                    newDy = pos.y + dy;

                    if (newDx == player.pos.x && newDy == player.pos.y)
                        AttackPlayer();
                    else
                    {
                        pos.x = newDx;
                        pos.y = newDy;
                    }
                    //CheckFloor(newDx, newDy)?? for poison or traps? or should trap handle this?
                }

                else
                {
                    int direction = randomMovement.Next(0, 4);
                    dx = (direction == 2) ? 1 : (direction == 3) ? -1 : 0;
                    dy = (direction == 0) ? 1 : (direction == 1) ? -1 : 0;

                    newDx = pos.x + dx;
                    newDy = pos.y + dy;
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
