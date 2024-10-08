using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyToTheMysticCave_Beta
{
    internal class QuestManager
    {
        Player player;
        EnemyManager enemyManager;
        ItemManager itemManager;
        Map map;
        int columnCount;
        int rowCount;

        Quest1 quest1;

        public void Init(Player player, EnemyManager enemyManager, ItemManager itemManager, Map map)
        {
            this.player = player;
            this.enemyManager = enemyManager;
            this.itemManager = itemManager;
            this.map = map;
        }

        public void Update()
        {
            rowCount = map.GetMapRowCount() + 15;
            columnCount = 0;

            for (int i = 0; i < 9; i++) 
            {
                Console.SetCursorPosition(columnCount, rowCount + i);
                Console.Write(new string(' ', Console.WindowWidth));
            }
        }

        public void Draw()
        {
            Console.SetCursorPosition(columnCount, rowCount);
            QuestInfo();
        }

        private void QuestInfo()
        {
            Console.WriteLine(quest1.description);
            Console.WriteLine("Quest 2: Collect 3 Money.");
            Console.WriteLine("Quest 3: Kill The Boss.");
            Console.WriteLine();
            Console.WriteLine("+-------------------------------+");
        }


    }
}
