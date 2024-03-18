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
        Random random = new Random();
        Player player;
        Gamelog log;
        LegendColors legendColors;
        Map map;
        int moveCount = 0;

        public Mage(int count, char character, string name, int damage, int health, LegendColors legendColors, Player player, Gamelog log, Map map) : base(count, character, name, damage, player)
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
            this.map = map;
        }

        public override void Update()
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

        void Movement()
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
                player.healthSystem.TakeDamage(damage);
                log.enemyAttack = $"by mage magic - {damage} damage";
            }
        }

        private Point2D RandomPlacement(Random random)
        {
            int x, y;
            do
            {
                x = random.Next(0, map.GetCurrentMapContent().GetLength(1));
                y = random.Next(0, map.GetCurrentMapContent().GetLength(0));
            } while (x == player.pos.x && y == player.pos.y);

            moveCount = 0;
            return new Point2D { x = x, y = y };
        }
    }
}