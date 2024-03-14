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
        public Map map;
        public LevelManager levelManager;

        int columnCount;
        int rowCount = 0;
        int level;

        public void Init(_GameStats gamestats, Map map, LevelManager levelManager)
        {
            this.gameStats = gamestats;
            this.map = map;
            this.levelManager = levelManager;
        }

        public void Update()
        {
            columnCount = map.GetMapColumnCount() + 2;
            rowCount = 0;
            level = levelManager.mapLevel;
        }

        public void Draw()
        {
            columnCount = map.GetMapColumnCount() + 2;
            rowCount = 0;
            Legend();
        }

        private void Legend() // displays legend on the bottom of the map.
        {
            Console.SetCursorPosition(columnCount, rowCount++);
            Console.WriteLine("+-------------------------------+");
            Console.SetCursorPosition(columnCount, rowCount++);
            Console.WriteLine("Map Legend:");
            Console.SetCursorPosition(columnCount, rowCount++);
            DisplayChar(gameStats.PlayerCharacter, gameStats.PlayerName);
            Console.SetCursorPosition(columnCount, rowCount++);
            if (level == 0)
                DisplayChar(gameStats.RangedCharacter, gameStats.RangerName);
            if (level == 1)
                DisplayChar(gameStats.MageCharacter, gameStats.MageName);
            if (level == 2)
            {
                DisplayInColumns(gameStats.MeleeCharacter, gameStats.MeleeName);
                DisplayChar(gameStats.BossCharacter, gameStats.BossName);
            }
            Console.SetCursorPosition(columnCount, rowCount++);
            DisplayInColumns(gameStats.MoneyCharacter, gameStats.MoneyName);
            DisplayInColumns(gameStats.PotionCharacter, gameStats.PotionName);

            Console.WriteLine();
            Console.SetCursorPosition(columnCount, rowCount++);
            DisplayInColumns(gameStats.TrapCharacter, gameStats.TrapName);
            DisplayInColumns(gameStats.SwordCharacter, gameStats.SwordName);

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
