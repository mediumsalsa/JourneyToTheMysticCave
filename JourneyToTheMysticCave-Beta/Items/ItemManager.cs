using JourneyToTheMysticCave_Beta;
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

        int itemsLevel0;
        int itemsLevel1;
        int itemsLevel2;

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


            DistributeItems(2, 2, 1, 0, 0);
            DistributeItems(2, 2, 1, 15, 1);
            DistributeItems(2, 2, 1, 15, 2);
        }

        public void Update()
        {
            switch (levelManager.mapLevel)
            {
                case 0:
                    for (int i = 0; i <= 5; i++)
                        items[i].Update();
                    break;
                case 1:
                    for (int i = 6; i <= 20; i++)
                        items[i].Update();
                    break;
                case 2:
                    for (int i = 21; i <= items.Count; i++)
                        items[i].Update();
                    break;
            }
        }

        public void Draw()
        {
            switch (levelManager.mapLevel)
            {
                case 0:
                    for (int i = 0; i <= 5; i++)
                        items[i].Draw();
                    break;
                case 1:
                    for (int i = 6; i <= 20; i++)
                        items[i].Draw();
                    break;
                case 2:
                    for (int i = 21; i <= items.Count; i++)
                        items[i].Draw();
                    break;
            }
        }

        private void DistributeItems(int potionCount, int moneyCount, int swordCount, int trapCount, int level)
        {
            int index = items.Count; // Get the starting index for this level's items

            // Distribute potions
            for (int i = 0; i < potionCount; i++)
            {
                var potion = new Potion(stats.PotionCount, stats.PotionCharacter, stats.PotionName, stats.PotionHeal, legendColors);
                potion.pos = stats.PlaceCharacters(level, random);
                items.Add(potion);
            }

            // Distribute money
            for (int i = 0; i < moneyCount; i++)
            {
                var money = new Money(stats.MoneyCount, stats.MoneyCharacter, stats.MoneyName, legendColors);
                money.pos = stats.PlaceCharacters(level, random);
                items.Add(money);
            }

            // Distribute swords
            for (int i = 0; i < swordCount; i++)
            {
                var sword = new Sword(stats.SwordCount, stats.SwordCharacter, stats.SwordName, stats.SwordMultiplier, legendColors, player);
                sword.pos = stats.PlaceCharacters(level, random);
                items.Add(sword);
            }

            // Distribute traps
            for (int i = 0; i < trapCount; i++)
            {
                var trap = new Trap(stats.TrapCount, stats.TrapCharacter, stats.TrapName, stats.TrapDamage, legendColors, log, player, enemyManager, levelManager);
                trap.pos = stats.PlaceCharacters(level, random);
                items.Add(trap);
            }

            // Update positions for newly added items
            for (int i = index; i < items.Count; i++)
            {
                while (items[i].pos.x == 0 && items[i].pos.y == 0)
                {
                    items[i].pos = stats.PlaceCharacters(level, random);
                }
            }
        }

    }
}
