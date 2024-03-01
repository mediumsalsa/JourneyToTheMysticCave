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
        public Player _player;
        public Ranged _ranged;
        public Mage _mage;
        public Melee _slime;
        public Potion _potion;
        public Money _money;
        public Trap _trap;

        public void Init()
        {

        }

        public void Update()
        {

        }

        public void Draw()
        {

        }

        public void Legend() // displays legend on the bottom of the map.
        {
            Console.WriteLine("+-----------------------------------------------------------+");
            Console.WriteLine("Map Legend:");
            DisplaySymbolsInColumns(_player.character, _player.name);
            Console.WriteLine();
            DisplaySymbolsInColumns(_ranged.character, _ranged.name);
            DisplaySymbolsInColumns(_mage.character, _mage.name);
            DisplaySymbolsInColumns(_slime.character, _slime.name);
            Console.WriteLine();
            DisplaySymbolsInColumns(_money.character, _money.name);
            DisplaySymbolsInColumns(_potion.character, _potion.name);
            DisplaySymbolsInColumns(_trap.character, _trap.name);
            Console.WriteLine();
            DisplaySymbolsInColumns('*', "Next Area");
            DisplaySymbolsInColumns('~', "Deep Water");
            DisplaySymbolsInColumns('P', "Poison Spill");
            Console.WriteLine();
            DisplaySymbolsInColumns('^', "Mountains");
            DisplaySymbolsInColumns('#', "Walls");
            Console.WriteLine();
            Console.WriteLine("+-----------------------------------------------------------+");
        }

        private void DisplaySymbolsInColumns(char symbol, string description)
        {
            MapColor(symbol);
            Console.Write(symbol);
            Console.ResetColor();
            Console.Write($" = {description}");

            int spacesCount = 20 - description.Length; // Adjust this number based on your desired column width

            // Add spaces to align the columns
            for (int i = 0; i < spacesCount; i++)
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
                case '$': // money (item)
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.Green;
                    break;
                case 'T': // trap (item)
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.BackgroundColor = ConsoleColor.Black;
                    break;
                case 'S': // Slime
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case 'R': // Ranged enemy
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    break;
                case 'M': // Mage
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    break;
                case 'H': // Hero(player)
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    break;
                case 'δ': // Potion (item)
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
