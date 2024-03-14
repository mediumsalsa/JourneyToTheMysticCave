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
        LevelManager levelManager;
        Random random = new Random();

        #region PlayerStat Declarations
        public string PlayerName { get; set; }
        public char PlayerCharacter { get; set; }
        public int PlayerDamage { get; set; }
        public int PlayerHealth { get; set; }
        public Point2D PlayerPos { get; set; }

        #endregion

        #region RangerStat Declarations
        public int RangerCount { get; set; }
        public char RangedCharacter { get; set; }
        public string RangerName { get; set; }
        public int RangerDamage { get; set; }
        public int RangerHealth { get; set; }
        private int rangerMaxHp;
        private int rangerMinHp;
        #endregion

        #region MageStat Declarations
        public int MageCount { get; set; }
        public char MageCharacter { get; set; }
        public string MageName { get; set; }
        public int MageDamage { get; set; }
        public int MageHealth { get; set; }
        private int mageMaxHp;
        private int mageMinHp;
        #endregion

        #region MeleeStat Declarations
        public int MeleeCount { get; set; }
        public char MeleeCharacter { get; set; }
        public string MeleeName { get; set; }
        public int MeleeDamage { get; set; }
        public int MeleeHealth { get; set; }
        private int meleeMaxHp;
        private int meleeMinHp;
        #endregion

        #region BossStat Declarations
        public int BossCount { get; set; }
        public char BossCharacter { get; set; }
        public string BossName { get; set; }
        public int BossDamage { get; set; }
        public int BossHealth { get; set; }
        #endregion

        #region MoneyStat Declarations
        public int MoneyCount { get; set; }
        public char MoneyCharacter { get; set; }
        public string MoneyName { get; set; }
        #endregion

        #region PotionStat Declarations
        public int PotionCount { get; set; }
        public char PotionCharacter { get; set; }
        public string PotionName { get; set; }
        public int PotionHeal { get; set; }
        #endregion

        #region TrapStat Declarations
        public int TrapCount { get; set; }
        public char TrapCharacter { get; set; }
        public string TrapName { get; set; }
        public int TrapDamage { get; set; }
        #endregion

        #region SwordStat Declarations
        public int SwordCount { get; set; }
        public char SwordCharacter { get; set; }
        public string SwordName { get; set; }
        public int SwordMultiplier { get; set; }
        #endregion

        public void Init(LevelManager levelManager, EnemyManager enemyManager)
        {
            this.levelManager = levelManager;
            this.enemyManager = enemyManager;

            GameConfig();
        }

        public void GameConfig()
        {
            //Player Configs/Stats
            PlayerCharacter = 'H';
            PlayerName = "Hero";
            PlayerHealth = 100;
            PlayerDamage = 10;
            PlayerPos = new Point2D { x = 2, y = 5 };

            // Ranger Configs/Stats
            RangerCount = 3;
            RangedCharacter = 'R';
            RangerName = "Ranger";
            RangerDamage = 3;
            rangerMinHp = 35;
            rangerMaxHp = 60;
            RangerHealth = random.Next(rangerMinHp, rangerMaxHp);
            

            // Mage Configs/Stats
            MageCount = 3;
            MageCharacter = 'M';
            MageName = "Mage";
            MageDamage = 3;
            mageMinHp = 40;
            mageMaxHp = 65;
            MageHealth = random.Next(mageMinHp, mageMaxHp);

            // Melee Configs/Stats
            MeleeCount = 30;
            MeleeCharacter = 'S';
            MeleeName = "Slime";
            MeleeDamage = 1;
            meleeMinHp = 2;
            meleeMaxHp = 10;
            MeleeHealth = random.Next(meleeMinHp, meleeMaxHp);

            // Boss Configs/Stats
            BossCount = 1;
            BossCharacter = 'B';
            BossName = "Boss";
            BossDamage = 6;

            // Money Configs
            MoneyCount = 4;
            MoneyCharacter = '$';
            MoneyName = "Money";

            // Potion Configs
            PotionCount = 4;
            PotionCharacter = '☼';
            PotionName = "Potion";
            PotionHeal = 6;

            // Trap Configs
            TrapCount = 4;
            TrapCharacter = 'T';
            TrapName = "Trap";
            TrapDamage = 4;

            // Sword Configs
            SwordCount = 3;
            SwordCharacter = 't';
            SwordName = "Sword";
            SwordMultiplier = 2;
        }


        public Point2D PlaceCharacters(int levelNumber, Random random)
        {
            int x, y;

            do
            {
                x = random.Next(0, levelManager.AllMapContents[levelNumber].GetLength(1));
                y = random.Next(0, levelManager.AllMapContents[levelNumber].GetLength(0));
            } while (!CheckInitialPlacement(x, y, levelNumber));

            return new Point2D { x = x, y = y };
        }


        private bool CheckInitialPlacement(int x, int y, int levelNumber)
        {
            return levelManager.InitialBoundaries(x, y, levelNumber);
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