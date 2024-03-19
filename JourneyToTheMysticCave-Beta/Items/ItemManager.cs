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
        Gamelog log;
        Player player;
        Map map;

        int potionsForEachLevel;
        int moneyForEachLevel;
        int trapsForEachLevel;


        public ItemManager()
        {
            items = new List<Item>();
        }

        public void Init(GameStats stats, LevelManager levelManager, LegendColors legendColors, Gamelog log, Player player, Map map)
        {
            this.stats = stats;
            this.levelManager = levelManager;
            this.legendColors = legendColors;
            this.log = log;
            this.player = player;
            this.map = map;

            for(int i = 0; i < stats.MoneyCount; i++)
                items.Add(new Money(stats.MoneyCount, stats.MoneyCharacter, stats.MoneyName, legendColors));
            for(int i = 0; i < stats.PotionCount; i++)
                items.Add(new Potion(stats.PotionCount, stats.PotionCharacter, stats.PotionName, stats.PotionHeal, legendColors));
            for(int i = 0; i < stats.TrapCount; i++)
                items.Add(new Trap(stats.TrapCount, stats.TrapCharacter, stats.TrapName, stats.TrapDamage, legendColors));
            for(int i = 0; i < stats.SwordCount; i++)
                items.Add(new Sword(stats.SwordCount, stats.SwordCharacter, stats.SwordName, stats.SwordMultiplier, legendColors));

            //switch (levelManager.mapLevel) // this might be where i set the positions?!
            //{
            //    case 0:
            //        for (int i = 0; i < AmountForThisLevel("Potion", 3); i++)
            //            items.Add(new Potion(stats.PotionCount, stats.PotionCharacter, stats.PotionName, stats.PotionHeal));
            //        for (int i = 0; i < AmountForThisLevel("Money", 3); i++)
            //            items.Add(new Money(stats.MoneyCount, stats.MoneyCharacter, stats.MoneyName));
            //        break;
            //    case 1:
            //        items.Add(new Potion(stats.PotionCount, stats.PotionCharacter, stats.PotionName, stats.PotionHeal));
            //        for (int i = 0; i < AmountForThisLevel("Money", 3); i++)
            //            items.Add(new Money(stats.MoneyCount, stats.MoneyCharacter, stats.MoneyName));
            //        for (int i = 0; i < AmountForThisLevel("Trap", 2); i++)
            //            items.Add(new Trap(stats.TrapCount, stats.TrapCharacter, stats.TrapName, stats.TrapDamage));
            //        break;
            //        case 2:
            //        items.Add(new Potion(stats.PotionCount, stats.PotionCharacter, stats.PotionName, stats.PotionHeal));
            //        for (int i = 0; i < AmountForThisLevel("Money", 3); i++)
            //            items.Add(new Money(stats.MoneyCount, stats.MoneyCharacter, stats.MoneyName));
            //        for (int i = 0; i < AmountForThisLevel("Trap", 2); i++)
            //            items.Add(new Trap(stats.TrapCount, stats.TrapCharacter, stats.TrapName, stats.TrapDamage));
            //        for (int i = 0; i < stats.SwordCount; i++)
            //            items.Add(new Sword(stats.SwordCount, stats.SwordCharacter, stats.SwordName, stats.SwordMultiplier)); 
            //        break;
            //}


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


        private int AmountForThisLevel(string name, int amount)
        {
            switch (name)
            {
                case "Potion":
                    potionsForEachLevel = amount;
                    return potionsForEachLevel;
                case "Money":
                    moneyForEachLevel = amount;
                    return moneyForEachLevel;
                case "Trap":
                    trapsForEachLevel = amount;
                    return trapsForEachLevel;
                default: return amount;
            }
        }
    }
}
