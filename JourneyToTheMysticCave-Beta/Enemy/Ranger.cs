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
        Player player;
        Gamelog log;
        LegendColors legendColors;

        public Ranger(int count, char character, string name, int damage, int health, LegendColors legendColors, Player player, Gamelog log) : base(count, character, name, damage, player)
        {
            this.count = count;
            this.character = character;
            this.name = name;
            this.damage = damage;
            healthSystem = new HealthSystem();
            healthSystem.health = health;
            this.legendColors = legendColors;
            this.player = player;
            this.log = log;
        }

        public override void Update()
        {
            if (!healthSystem.mapDead)
            {
                //Movement();
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
                    dx = Math.Sign(player.pos.x - pos.x); // calculations direction to player
                    dy = Math.Sign(player.pos.y - pos.y);

                    newDx = pos.x + dx;
                    newDy = pos.y + dy;

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
