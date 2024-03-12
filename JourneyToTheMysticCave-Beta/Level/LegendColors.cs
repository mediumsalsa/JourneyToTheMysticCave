using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace JourneyToTheMysticCave_Beta
{
    internal class LegendColors
    {
        public _GameStats gameStats;
        public Player player;
        public Ranger ranged;
        public Mage mage;
        public Melee melee;
        public Potion potion;
        public Money money;
        public Trap trap;
        public Sword sword;
        public Boss boss;
        public Map map;
        public LevelManager levelManager;

        int columnCount;
        int rowCount = 0;
        int level;

        public void Init(Player player, Ranger ranged, Mage mage, Melee melee, Boss boss, Potion potion, Money money, Trap trap, Sword sword, _GameStats gamestats, Map map, LevelManager levelManager)
        {
            this.player = player;
            this.ranged = ranged;
            this.mage = mage;
            this.melee = melee;
            this.boss = boss;
            this.potion = potion;
            this.money = money;
            this.trap = trap;
            this.sword = sword;
            this.gameStats = gamestats;
            this.map = map;
            this.levelManager = levelManager;
        }

        public void Update()
        {
            columnCount = map.GetMapColumnCount() + 2;
            level = levelManager.mapLevel;
            rowCount = 0;
        }

        public void Draw()
        {
            Legend();
        }

        private void Legend() // displays legend on the bottom of the map.
        {
            Console.SetCursorPosition(columnCount, rowCount++);
            Console.WriteLine("+-------------------------------+");
            Console.SetCursorPosition(columnCount, rowCount++);
            Console.WriteLine("Map Legend:");
            Console.SetCursorPosition(columnCount, rowCount++);
            DisplayChar(player.character, player.name);
            Console.SetCursorPosition(columnCount, rowCount++);
            if (level == 0)
                DisplayChar(ranged.character, ranged.name);
            if (level == 1)
                DisplayChar(mage.character, mage.name);
            if (level == 2)
            {
                DisplayInColumns(melee.character, melee.name);
                DisplayChar(boss.character, boss.name);
            }
            Console.SetCursorPosition(columnCount, rowCount++);
            DisplayInColumns(money.character, money.name);
            DisplayInColumns(potion.character, potion.name);

            Console.WriteLine();
            Console.SetCursorPosition(columnCount, rowCount++);
            DisplayInColumns(trap.character, trap.name);
            DisplayInColumns(sword.character, sword.name);

            Console.WriteLine();
            Console.SetCursorPosition(columnCount, rowCount++);
            DisplayInColumns('*', "Next Area");
            DisplayInColumns('~', "Deep Water");

            Console.WriteLine();
            Console.SetCursorPosition(columnCount, rowCount++);
            DisplayInColumns('P', "Poison Spill");
            DisplayInColumns('^', "Mountains");

            Console.WriteLine();
            Console.SetCursorPosition(columnCount, rowCount++);
            DisplayInColumns('#', "Walls");

            Console.WriteLine();
            Console.SetCursorPosition(columnCount, rowCount++);
            Console.WriteLine("+-------------------------------+");
        }

        private void DisplayChar(char symbol, string description)
        {
            MapColor(symbol);
            Console.Write(symbol);
            Console.ResetColor();
            Console.Write($" = {description}\n");
            Console.WriteLine();
        }

        private void DisplayInColumns(char symbol, string description)
        {
            MapColor(symbol);
            Console.Write(symbol);
            Console.ResetColor();
            Console.Write($" = {description}");

            int spacesCount = 15 - description.Length; // Adjust this number based on desired column width

            for (int i = 0; i < spacesCount; i++)  // Add spaces to align the columns
            {
                Console.Write(" ");
            }
        }

        public void MapColor(char c)    // handles map color
        {
            switch (c)
            {
                case '#': // Boundaries
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    break;
                case '^': // Mountain
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.BackgroundColor = ConsoleColor.Gray;
                    break;
                case '~': // Water
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.BackgroundColor = ConsoleColor.Blue;
                    break;
                case var _ when c == gameStats.SwordCharacter: // Sword (item)
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    break;
                case var _ when c == gameStats.MoneyCharacter: // money (item)
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.Green;
                    break;
                case var _ when c == gameStats.TrapCharacter: // trap (item)
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.BackgroundColor = ConsoleColor.Black;
                    break;
                case var _ when c == gameStats.MeleeCharacter: // Slime
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case var _ when c == gameStats.RangedCharacter: // Ranged enemy
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    break;
                case var _ when c == gameStats.MageCharacter: // Mage
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    break;
                case var _ when c == gameStats.PlayerCharacter: // (Player)
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    break;
                case var _ when c == gameStats.PotionCharacter: // Potion (item)
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case '*': // next area
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case 'P': // poison floor
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                    break;
            }
        }
    }
}
