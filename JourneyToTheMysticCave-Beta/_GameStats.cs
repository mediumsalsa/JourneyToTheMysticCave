using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace JourneyToTheMysticCave_Beta
{
    internal class _GameStats
    {
        Player player;
        EnemyManager enemyManager;
        Item allItems;
        Ranger ranger;
        Melee melee;
        Mage mage;
        Boss boss;
        Money money;
        Potion potion;
        Trap trap;
        Sword sword;
        LevelManager levelManager;

        public char PlayerCharacter { get; set; }
        public char RangedCharacter {  get; set; }
        public char MeleeCharacter { get; set; }
        public char BossCharacter { get; set; }
        public char MageCharacter { get; set; }
        public char MoneyCharacter { get; set; }
        public char PotionCharacter { get; set; }
        public char TrapCharacter { get; set; }
        public char SwordCharacter { get; set; }


        public void Init(Player player, Ranger ranger, Melee melee, Mage mage, Boss boss, Money money, Potion potion, Trap trap, Sword sword, LevelManager levelManager, EnemyManager enemyManager)
        {
            this.player = player;
            this.ranger = ranger;
            this.melee = melee;
            this.mage = mage;
            this.boss = boss;
            this.money = money;
            this.potion = potion;
            this.trap = trap;
            this.sword = sword;
            this.levelManager = levelManager;
            this.enemyManager = enemyManager;

            GameConfig();
        }

        public void GameConfig()
        {
            //Player Configs/Stats
            player.character = 'H';
            PlayerCharacter = player.character;
            player.name = "Hero";
            player.health = 100;
            player.damageAmount = 10;
            player.pos = new Point2D { x = 2, y = 5 };
            
            // Ranger Configs/Stats
            ranger.count = 3;
            ranger.character = 'R';
            RangedCharacter = ranger.character;
            ranger.name = "Ranger";
            ranger.damageAmount = 3;
            ranger.maxHp = 60;
            ranger.minHp = 35;
            PlaceCharacters(0);

            // Mage Configs/Stats
            mage.count = 3;
            mage.character = 'M';
            MageCharacter = mage.character;
            mage.name = "Mage";
            mage.damageAmount = 3;
            mage.maxHp = 65;
            mage.minHp = 40;
            PlaceCharacters(1);

            // Slime Configs/Stats
            melee.count = 30;
            melee.character = 'S';
            MeleeCharacter = melee.character;
            melee.name = "Slime";
            melee.damageAmount = 1;
            melee.maxHp = 50;
            melee.minHp = 25;
            PlaceCharacters(2);

            // Boss Configs/Stats
            boss.count = 1;
            boss.character = 'B';
            BossCharacter = boss.character;
            boss.name = "Boss";
            boss.damageAmount = 6;
            boss.maxHp = 120;
            boss.minHp = 80;
            PlaceCharacters(2);

            // Money Configs
            money.count = 4;
            money.character = '$';
            money.name = "Money";
            MoneyCharacter = money.character;

            // Potion Configs
            potion.count = 4;
            potion.healAmount = 6;
            potion.character = '☼';
            potion.name = "Potion";
            PotionCharacter = potion.character;

            // Trap Configs
            trap.count = 4;
            trap.character = 'T';
            trap.name = "Trap";
            TrapCharacter = trap.character;

            // Sword Configs
            sword.count = 3;
            sword.character = 't';
            sword.name = "Sword";
            SwordCharacter = sword.character;
        }

        private void PlaceCharacters(int levelNumber)
        {
            Random random = new Random();
            foreach (Enemy enemy in enemyManager.enemies)
            {
                int x, y;

                if ((levelNumber == 0 && enemy is Ranger) ||
                    (levelNumber == 1 && enemy is Mage) ||
                    (levelNumber == 2 && (enemy is Melee || enemy is Boss)))
                {
                    do
                    {
                        x = random.Next(0, levelManager.AllMapContents[levelNumber].GetLength(1));
                        y = random.Next(0, levelManager.AllMapContents[levelNumber].GetLength(0));
                    } while (!CheckInitialPlacement(x, y, levelNumber));

                    enemy.pos = new Point2D { x = x, y = y };
                }
            }
        }

        private bool CheckInitialPlacement(int x, int y, int levelNumber)
        {
            return levelManager.InitialBoundaries(x,y,levelNumber);
        }

        //private bool IsEmpty(int x, int y, int levelNumber)
        //{
        //    if (player.pos.x == x && player.pos.y == y)
        //        return false;

        //    switch(levelNumber)
        //    {
        //        case 0:
        //            foreach (Ranger[] ranger in Ranger)
        //            {

        //            }
        //    }
        //}
    }
}