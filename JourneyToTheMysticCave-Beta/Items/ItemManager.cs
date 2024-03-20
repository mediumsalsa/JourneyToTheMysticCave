using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyToTheMysticCave_Beta
{
    internal class ItemManager
    {
        public List<Item> items;
        public GameStats stats;
        LegendColors legendColors;
        LevelManager levelManager;
        EnemyManager enemyManager;
        Gamelog log;
        Player player;
        Map map;
        Random random = new Random();

        int potionsForEachLevel;
        int moneyForEachLevel;
        int trapsForEachLevel;


        public ItemManager()
        {
            items = new List<Item>();
        }

        public void Init(GameStats stats, LevelManager levelManager, LegendColors legendColors, Gamelog log, Player player, Map map, EnemyManager enemyManager)
        {
            this.stats = stats;
            this.levelManager = levelManager;
            this.legendColors = legendColors;
            this.log = log;
            this.player = player;
            this.map = map;
            this.enemyManager = enemyManager;

            for(int i = 0; i < stats.MoneyCount; i++)
                items.Add(new Money(stats.MoneyCount, stats.MoneyCharacter, stats.MoneyName, legendColors));
            for(int i = 0; i < stats.PotionCount; i++)
                items.Add(new Potion(stats.PotionCount, stats.PotionCharacter, stats.PotionName, stats.PotionHeal, legendColors));
            for(int i = 0; i < stats.TrapCount; i++)
                items.Add(new Trap(stats.TrapCount, stats.TrapCharacter, stats.TrapName, stats.TrapDamage, legendColors,log, player, enemyManager, levelManager));
            for(int i = 0; i < stats.SwordCount; i++)
                items.Add(new Sword(stats.SwordCount, stats.SwordCharacter, stats.SwordName, stats.SwordMultiplier, legendColors, player));


            PlaceItemsForLevel(0);
            PlaceItemsForLevel(1);
            PlaceItemsForLevel(2);
        }

        public void Update()
        {
            foreach (Item item in items)
            {
                item.Update();
            }
        }

        public void Draw()
        {
            foreach (Item item in items)
            {
                //switch (levelManager.mapLevel)
                //{
                //    case 0:
                //        foreach(Potion potion in items)
                //        {

                //        }
                //    //case nameof(Potion): item.Draw(); break;
                //    //case nameof(Money): item.Draw(); break;
                //    //case nameof(Sword): item.Draw(); break;
                //    //case nameof(Trap): item.Draw(); break;
                //}
            }
        }
        private void PlaceItemsForLevel(int level)
        {
            foreach (Item item in items)
            {
                switch (item.GetType().Name)
                {
                    case nameof(Money):
                        item.pos = stats.PlaceCharacters(AmountForThisLevel(nameof(Money), level), random);
                        break;
                    case nameof(Potion):
                        item.pos = stats.PlaceCharacters(AmountForThisLevel(nameof(Potion), level), random);
                        break;
                    case nameof(Trap):
                        item.pos = stats.PlaceCharacters(AmountForThisLevel(nameof(Trap), level), random);
                        break;
                    case nameof(Sword):
                        item.pos = stats.PlaceCharacters(AmountForThisLevel(nameof(Sword), level), random);
                        break;
                }
            }
        }


        private int AmountForThisLevel(string name, int level)
        {
            switch (name)
            {
                case "Potion":
                    return level <= 2 ? 2 : 0; // 2 potions for levels 0, 1, and 2
                case "Money":
                    return level <= 2 ? 2 : 0; // 2 money for levels 0, 1, and 2
                case "Trap":
                    return level >= 1 && level <= 2 ? 15 : 0; // 15 traps for level 1, 0 otherwise
                case "Sword":
                    return 1; // 1 sword for each level
                default:
                    return 0;
            }
        }
    }
}
