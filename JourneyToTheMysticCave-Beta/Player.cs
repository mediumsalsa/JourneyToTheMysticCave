using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyToTheMysticCave_Beta
{
    internal class Player : GameEntity
    {
        int dirX;
        int dirY;

        public bool attackedEnemy = false;
        public bool itemPickedUp = false;

        Map map;


        public Player()
        {
            healthSystem = new HealthSystem();
            healthSystem.health = health;
        }

        public void Init(Map map)
        {
            this.map = map;
        }

        public void Update()
        {
            Movement();
        }

        public void Draw()
        {
            Console.SetCursorPosition(pos.x, pos.y);
            Console.Write(character);
            Console.CursorVisible = false;
        }

        private void Movement()
        {
            if (!healthSystem.mapDead)
            {
                PlayerInput();

                int newX = pos.x + dirX;
                int newY = pos.y + dirY;

                if(map.CheckBoundaries(newX,newY))
                {
                    pos.x = newX;
                    pos.y = newY;
                }
            }
        }

        private void PlayerInput()
        {
            ConsoleKeyInfo input = Console.ReadKey();

            dirX = 0;
            dirY = 0;

            switch (input.Key)
            {
                case ConsoleKey.W:
                    dirY = -1;
                    break;
                case ConsoleKey.S:
                    dirY = 1;
                    break;
                case ConsoleKey.A:
                    dirX = -1;
                    break;
                case ConsoleKey.D:
                    dirX = 1;
                    break;
                case ConsoleKey.Q:
                    dirY = -1; dirX = -1;
                    break;
                case ConsoleKey.E:
                    dirY = -1; dirX = 1;
                    break;
                case ConsoleKey.Z:
                    dirY = 1; dirX = -1;
                    break;
                case ConsoleKey.C:
                    dirY = 1; dirX = 1;
                    break;
                case ConsoleKey.Spacebar:
                    return; // using for testing, player doesn't move
                case ConsoleKey.Escape:
                    System.Environment.Exit(0);
                    return;
            }
        }
    }
}
