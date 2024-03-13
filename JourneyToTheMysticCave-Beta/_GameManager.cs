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
        _GameStats gameStats = new _GameStats();
        Player player = new Player();
        LevelManager levelManager = new LevelManager();
        LegendColors legendColors = new LegendColors();

        Money money = new Money();
        Potion potion = new Potion();
        Trap trap = new Trap();
        Sword sword = new Sword();

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
            legendColors.Update();


            while (true)
            {
                Update();
                Draw();

                //Console.SetCursorPosition(0, 25);
                //Console.WriteLine(player.damageAmount.ToString());
                //Console.WriteLine(player.pos.x + "," + player.pos.y);


            }
        }

        private void Init()
        {
            levelManager.Init(player);
            map.Init(levelManager, legendColors);
            gameStats.Init(levelManager, enemyManager);
            player.Init(map, gameStats);
            legendColors.Init(gameStats, map, levelManager);
            enemyManager.Init(gameStats);
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
            legendColors.Draw();
            enemyManager.Draw();
            //   itemManager.Draw();
        }
    }
}
