using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyToTheMysticCave_Beta
{
    internal class _GameManager
    {
        #region Declarations
        Map map = new Map();
        Player player = new Player();
        LevelManager levelManager = new LevelManager();
        LegendColors legendColors = new LegendColors();
        _GameStats gameStats = new _GameStats();

        Ranger ranger = new Ranger();
        Mage mage = new Mage();
        Melee melee = new Melee();
        Boss boss = new Boss();

        Money money = new Money();
        Potion potion = new Potion();
        Trap trap = new Trap();
        Sword sword = new Sword();

        public int rowCount;

        EnemyManager enemyManager = new EnemyManager();
        ItemManager itemManager = new ItemManager();
        #endregion

        public _GameManager()
        {
            Init();
        }

        public void Gameplay()
        {
            map.Update();
            map.Draw();
            player.Draw();
            while (true)
            {
                Update();
                rowCount = map.GetMapRowCount();
                Draw();

                Console.SetCursorPosition(0, 25);
                Console.WriteLine(map.GetMapColumnCount()); 
                Console.WriteLine(player.pos.x + "," + player.pos.y);

            }
        }

        private void Init()
        {
            levelManager.Init(player);
            map.Init(levelManager, legendColors);
            gameStats.Init(player, ranger, melee, mage, boss, money, potion, trap, sword, levelManager, enemyManager);
            enemyManager.Init(player, map, ranger, mage, melee, boss);
            legendColors.Init(player, ranger, mage, melee, boss, potion, money, trap, sword, gameStats, map, levelManager);
            player.Init(map);
        }

        private void Update()
        {
            player.Update();
            levelManager.Update();
            map.Update();
            legendColors.Update();
            enemyManager.Update();
            // itemManager.Update();
        }

        private void Draw()
        {
            map.Draw();
            player.Draw();
            Console.SetCursorPosition(0, rowCount++);
            legendColors.Draw();
            enemyManager.Draw();
            //   itemManager.Draw();
        }
    }
}
