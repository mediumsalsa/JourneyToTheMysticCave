using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyToTheMysticCave_Beta
{
    internal class _GameManager
    {
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

        EnemyManager enemyManager = new EnemyManager();
        ItemManager itemManager = new ItemManager();

        public _GameManager()
        {
            Init();
        }

        public void Gameplay()
        {

            while (true)
            {
                Update();
                Draw();
            }



            Console.ReadKey();
        }

        private void Init()
        {
            levelManager.Init();
            map.Init(levelManager);
            gameStats.Init(player, ranger, melee, mage, boss, money, potion, trap, sword);
            enemyManager.Init(player, map, ranger, mage, melee, boss);
            legendColors.Init(player, ranger, mage, melee, boss, potion, money, trap, gameStats);
            player.Init(map);
        }

        private void Update()
        {
            map.Update();
            player.Update();
            enemyManager.Update();
            itemManager.Update();
            //levelManager.Update();
        }

        private void Draw()
        {
            map.Draw();
            player.Draw();
            enemyManager.Draw();
            itemManager.Draw();

        }
    }
}
