using System;
using System.Windows.Input;
using System.Collections.Generic;
using System.Diagnostics;
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
        private Enemy lastEncountered;
        private Item itemPickup;

        public Enemy GetLastEnountered()
        {
            return lastEncountered;
        }

        Map map;
        GameStats gameStats;
        EnemyManager enemyManager;
        LegendColors legendColors;
        LevelManager levelManager;
        ItemManager itemManager;


        public Player()
        {
            healthSystem = new HealthSystem();
        }

        public void Init(Map map, GameStats gameStats, LegendColors legendColors, EnemyManager enemyManager, LevelManager levelManager, ItemManager itemManager)
        {
            this.map = map;
            this.gameStats = gameStats;
            this.legendColors = legendColors;
            this.enemyManager = enemyManager;
            this.levelManager = levelManager;
            this.itemManager = itemManager;

            healthSystem.health = gameStats.PlayerHealth;
            character = gameStats.PlayerCharacter;
            pos = gameStats.PlayerPos;
            damage = gameStats.PlayerDamage;
            name = gameStats.PlayerName;
        }

        public void Update()
        {
            Movement();
        }

        public void Draw()
        {
            Console.SetCursorPosition(pos.x, pos.y);
            legendColors.MapColor(character);
            Console.Write(character);
            Console.ResetColor();
            Console.CursorVisible = false;
        }

        private void Movement()
        {
            if (!healthSystem.mapDead)
            {
                PlayerInput();

                int newX = pos.x + dirX;
                int newY = pos.y + dirY;

                if (CheckBoundaries(newX, newY))
                {
                    lastEncountered = GetEnemyAtPosition(newX, newY);
                    itemPickup = GetItemAtPosition(newX, newY);

                    if (lastEncountered != null)
                        AttackEnemy(lastEncountered);
                    else if (itemPickup != null)
                        itemPickup.TryCollect();
                    else
                        pos.x = newX;
                    pos.y = newY;
                }
            }
        }

        private void PlayerInput()
        {
            ConsoleKeyInfo input = Console.ReadKey(true); // Read key without displaying it

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

        private Enemy GetEnemyAtPosition(int x, int y)
        {
            foreach (Enemy enemy in enemyManager.enemies)
            {
                if (enemy is Ranger && levelManager.mapLevel == 0)
                {
                    if (enemy.pos.x == x && enemy.pos.y == y)
                        return enemy;
                }
                if (enemy is Mage && levelManager.mapLevel == 1)
                {
                    if (enemy.pos.x == x && enemy.pos.y == y)
                        return enemy;
                }
                if (enemy is Melee && levelManager.mapLevel == 2)
                {
                    if (enemy.pos.x == x && enemy.pos.y == y)
                        return enemy;
                }
            }
            return null;
        }

        private Item GetItemAtPosition(int x, int y)
        {
            foreach (Item item in itemManager.items)
            {
                switch (levelManager.mapLevel)
                {
                    case 0:
                        for (int i = 0; i <= 5; i++)
                        {
                            if (item.pos.x == x && item.pos.y == y)
                                return item;
                        }
                        break;
                    case 1:
                        for (int i = 6; i <= 20; i++)
                        {
                            if (item.pos.x == x && item.pos.y == y)
                                return item;
                        }
                        break;
                    case 2:
                        for (int i = 21; i <= itemManager.items.Count; i++)
                        {
                            if (item.pos.x == x && item.pos.y == y)
                                return item;
                        }
                        break;
                }
            }
            return null;
        }

        private void AttackEnemy(Enemy enemy)
        {
            enemy.healthSystem.TakeDamage(damage, "Attacked");
        }

        private bool CheckBoundaries(int x, int y)
        {
            return x > 0 && x < map.GetMapColumnCount() && y > 0 && y < map.GetMapRowCount() &&
                map.GetCurrentMapContent()[y, x] != '#' && map.GetCurrentMapContent()[y, x] != '^';
        }
    }
}