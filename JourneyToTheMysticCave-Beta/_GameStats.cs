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
        Ranger ranger;
        Melee melee;
        Mage mage;
        Boss boss;
        Money money;
        Potion potion;
        Trap trap;
        Sword sword;

        public char PlayerCharacter { get; set; }
        public char RangedCharacter {  get; set; }
        public char MeleeCharacter { get; set; }
        public char BossCharacter { get; set; }
        public char MageCharacter { get; set; }
        public char MoneyCharacter { get; set; }
        public char PotionCharacter { get; set; }
        public char TrapCharacter { get; set; }
        public char SwordCharacter { get; set; }


        public void Init(Player player, Ranger ranger, Melee melee, Mage mage, Boss boss, Money money, Potion potion, Trap trap, Sword sword)
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

            // Mage Configs/Stats
            mage.count = 3;
            mage.character = 'M';
            MageCharacter = mage.character;
            mage.name = "Mage";
            mage.damageAmount = 3;
            mage.maxHp = 65;
            mage.minHp = 40;

            // Slime Configs/Stats
            melee.count = 30;
            melee.character = 'S';
            MeleeCharacter = melee.character;
            melee.name = "Slime";
            melee.damageAmount = 1;
            melee.maxHp = 50;
            melee.minHp = 25;

            // Boss Configs/Stats
            boss.count = 1;
            boss.character = 'B';
            BossCharacter = boss.character;
            boss.name = "Boss";
            boss.damageAmount = 6;
            boss.maxHp = 120;
            boss.minHp = 80;

            // Money Configs
            money.count = 4;
            money.character = '$';
            MoneyCharacter = money.character;

            // Potion Configs
            potion.count = 4;
            potion.character = '☼';
            PotionCharacter = potion.character;

            // Trap Configs
            trap.count = 4;
            trap.character = 'T';
            TrapCharacter = trap.character;

            // Sword Configs
            sword.count = 3;
            sword.character = 't';
            SwordCharacter = sword.character;
        }
    }
}