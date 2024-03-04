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


        public void Init(Player player, Ranger ranged, Mage mage, Melee melee, Boss boss, Potion potion, Money money, Trap trap, _GameStats gamestats)
        {
            this.player = player;
            this.ranged = ranged;
            this.mage = mage;
            this.melee = melee;
            this.potion = potion;
            this.money = money;
            this.trap = trap;
            this.gameStats = gamestats;


        }


        public void Draw()
        {
            Legend();
        }

        private void Legend() // displays legend on the bottom of the map.
        {
            Console.WriteLine("+-----------------------------------------------------------+");
            Console.WriteLine("Map Legend:");
            DisplaySymbolsInColumns(player.character, player.name);
            Console.WriteLine();
            DisplaySymbolsInColumns(ranged.character, ranged.name);
            DisplaySymbolsInColumns(mage.character, mage.name);
            DisplaySymbolsInColumns(melee.character, melee.name);
            Console.WriteLine();
            DisplaySymbolsInColumns(money.character, money.name);
            DisplaySymbolsInColumns(potion.character, potion.name);
            DisplaySymbolsInColumns(trap.character, trap.name);
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
