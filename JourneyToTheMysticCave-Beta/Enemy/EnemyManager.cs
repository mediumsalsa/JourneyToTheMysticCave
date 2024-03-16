using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyToTheMysticCave_Beta
{
    internal class EnemyManager
    {
        public _GameStats stats;
        public LevelManager levelManager;
        LegendColors legendColors;
        Gamelog log;
        Player player;
        Random random = new Random();
        public List<Enemy> enemies;

        public EnemyManager()
        {
            enemies = new List<Enemy>();
        }

        public void Init(_GameStats stats, LevelManager levelManager, LegendColors legendColors, Gamelog log, Player player)
        {
            this.stats = stats;
            this.levelManager = levelManager;
            this.legendColors = legendColors;
            this.log = log;
            this.player = player;

            for (int i = 0; i < stats.RangerCount; i++)
                enemies.Add(new Ranger(stats.RangerCount, stats.RangedCharacter, stats.RangerName, stats.RangerDamage, stats.RangerHealth, legendColors, player, log));
            for (int i = 0; i < stats.MageCount; i++)
                enemies.Add(new Mage(stats.MageCount, stats.MageCharacter, stats.MageName, stats.MageDamage, stats.MageHealth, legendColors, player, log));
            for (int i = 0; i < stats.MeleeCount; i++)
                enemies.Add(new Melee(stats.MeleeCount, stats.MeleeCharacter, stats.MeleeName, stats.MeleeDamage, stats.MeleeHealth, legendColors, player, log));
            for (int i = 0; i < stats.BossCount; i++)
                enemies.Add(new Boss(stats.BossCount, stats.BossCharacter, stats.BossName, stats.BossDamage, stats.BossHealth, legendColors, player, log));

            foreach (Enemy enemy in enemies)
            {
                switch (enemy.GetType().Name)
                {
                    case nameof(Ranger):
                        enemy.pos = stats.PlaceCharacters(0, random);
                        break;
                    case nameof(Mage):
                        enemy.pos = stats.PlaceCharacters(1, random);
                        break;
                    case nameof(Melee):
                    case nameof(Boss):
                        enemy.pos = stats.PlaceCharacters(2, random);
                        break;
                }
            }
        }

        public void Update()
        {
            foreach (Enemy enemy in enemies)
            {
                switch (enemy.GetType().Name)
                {
                    case nameof(Ranger):
                        if (levelManager.mapLevel == 0)
                            enemy.Update();
                        break;
                    case nameof(Mage):
                        if (levelManager.mapLevel == 1)
                            enemy.Update();
                        break;
                    case nameof(Melee):
                        if (levelManager.mapLevel == 2)
                            enemy.Update();
                        break;
                    case nameof(Boss):
                        if (levelManager.mapLevel == 2)// && meleeCount == 0 <-- need to figure out how to count dead melee
                            enemy.Update();
                        break;
                }
            }
        }

        public void Draw()
        {
            foreach (Enemy enemy in enemies)
            {
                switch (enemy.GetType().Name)
                {
                    case nameof(Ranger):
                        if (levelManager.mapLevel == 0)
                            enemy.Draw();
                        break;
                    case nameof(Mage):
                        if (levelManager.mapLevel == 1)
                            enemy.Draw();
                        break;
                    case nameof(Melee):
                        if (levelManager.mapLevel == 2)
                            enemy.Draw();
                        break;
                    case nameof(Boss):
                        if (levelManager.mapLevel == 2)// && meleeCount == 0 <-- need to figure out how to count dead melee
                            enemy.Draw();
                        break;
                }
            }
        }
    }
}
