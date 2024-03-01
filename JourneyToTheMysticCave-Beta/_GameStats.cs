using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyToTheMysticCave_Beta
{
    internal class _GameStats
    {
        Player player;
        EnemyManager[] enemyManager;
        Item[] allItems;
        Ranged ranger;
        Melee slime;
        Mage mage;
        Boss boss;

        public void Init(Player player, EnemyManager[] enemies, Item[] items)
        {
            this.player = player;
            
        }

        public void GameConfig()
        {
            //Player Configs/Stats
            player.character = 'H';
            player.name = "Hero";
            player.damageAmount = 10;
            player.pos = new Point2D { x = 2, y = 5 };
            
            // Ranger Configs/Stats
            ranger.count = 3;
            ranger.character = 'R';
            ranger.name = "Ranger";
            ranger.damageAmount = 3;
            

            // Mage Configs/Stats
            mage.count = 3;
            mage.character = 'M';
            mage.name = "Mage";
            mage.damageAmount = 3;

            // Slime Configs/Stats
            slime.count = 30;
            slime.character = 'S';
            slime.name = "Slime";
            slime.damageAmount = 1;

            // Boss Configs/Stats
            boss.count = 1;
            boss.character = 'B';
            boss.name = "Boss";
            boss.damageAmount = 6;

            // Item Configs
            

        }
    }
}
