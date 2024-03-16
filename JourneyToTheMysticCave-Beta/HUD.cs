using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyToTheMysticCave_Beta
{
    internal class HUD
    {
        Player player;
        EnemyManager enemyManager;
        ItemManager itemManager;
        Map map;
        int columnCount = 0;
        int rowCount = 0;
        int lastEnemyAttacked; // probably not an int but leaving this as place holder

        public void Init(Player player, EnemyManager enemyManager, ItemManager itemManager, Map map)
        {
            this.player = player;
            this.enemyManager = enemyManager;
            this.itemManager = itemManager;
            this.map = map;
        }

        public void Update()
        {
            rowCount = map.GetMapRowCount() + 1;
            columnCount = 0;
        }

        public void Draw()
        {
            rowCount = map.GetMapRowCount() + 1;
            columnCount = 0;
            Console.SetCursorPosition(columnCount, rowCount);
            Console.WriteLine("+---------------------------+");
            Console.WriteLine($"Player Health: {player.health}");
            Console.WriteLine($"Player Damage: {player.damage}");
            Console.WriteLine($"Last Enemy Attacked - enemy: - {lastEnemyAttacked}"); // this should show the last enemy attacked and how much health they have left
            Console.Write("Money Picked Up:");
            // need to add each amount of money in the item manager
            Console.WriteLine();
            Console.WriteLine("+---------------------------+");

        }

    }
}
