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
        Map map;
        public List<Enemy> enemies;
        public int meleeCount;
        bool firstDead = false;

        public EnemyManager()
        {
            enemies = new List<Enemy>();
        }

        public void Init(_GameStats stats, LevelManager levelManager, LegendColors legendColors, Gamelog log, Player player, Map map)
        {
            this.stats = stats;
            this.levelManager = levelManager;
            this.legendColors = legendColors;
            this.log = log;
            this.player = player;
            this.map = map;

            for (int i = 0; i < stats.RangerCount; i++)
                enemies.Add(new Ranger(stats.RangerCount, stats.RangedCharacter, stats.RangerName, stats.RangerDamage, legendColors, player, log, this, map));
            for (int i = 0; i < stats.MageCount; i++)
                enemies.Add(new Mage(stats.MageCount, stats.MageCharacter, stats.MageName, stats.MageDamage, legendColors, player, log, map, this));
            for (int i = 0; i < stats.MeleeCount; i++)
                enemies.Add(new Melee(stats.MeleeCount, stats.MeleeCharacter, stats.MeleeName, stats.MeleeDamage, legendColors, player, log, this, map));
            for (int i = 0; i < stats.BossCount; i++)
                enemies.Add(new Boss(stats.BossCount, stats.BossCharacter, stats.BossName, stats.BossDamage, stats.BossHealth, legendColors, player, log, this, map));

            foreach (Enemy enemy in enemies)
            {
                switch (enemy.GetType().Name)
                {
                    case nameof(Ranger):
                        enemy.healthSystem = new HealthSystem();
                        enemy.healthSystem.health = stats.GiveHealth(random, "Ranger");
                        enemy.pos = stats.PlaceCharacters(0, random);
                        break;
                    case nameof(Mage):
                        enemy.healthSystem = new HealthSystem();
                        enemy.healthSystem.health = stats.GiveHealth(random, "Mage");
                        enemy.pos = stats.PlaceCharacters(1, random);
                        break;
                    case nameof(Melee):
                        enemy.healthSystem = new HealthSystem();
                        enemy.healthSystem.health = stats.GiveHealth(random, "Melee");
                        enemy.pos = stats.PlaceCharacters(2, random);
                        meleeCount++;
                        break;
                    case nameof(Boss):
                        enemy.healthSystem = new HealthSystem();
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
                            enemy.Update(random);
                        break;
                    case nameof(Mage):
                        if (levelManager.mapLevel == 1)
                            enemy.Update(random);
                        break;
                    case nameof(Melee):
                        if (levelManager.mapLevel == 2)
                            enemy.Update(random);
                        break;
                    case nameof(Boss):
                        if (AreAllMeleeDead() && firstDead == false)
                        {
                            enemy.pos = stats.PlaceCharacters(2, random);
                            firstDead = true;
                        }
                        if (levelManager.mapLevel == 2 && AreAllMeleeDead())
                            enemy.Update(random);
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
                        if (levelManager.mapLevel == 2 && AreAllMeleeDead())
                            enemy.Draw();
                        break;
                }
            }
        }

        public bool AreAllMeleeDead()
        {
            return !enemies.Any(enemy => enemy is Melee && enemy.IsAlive);
        }

        public bool CheckEnemyPos(int x, int y, int level)
        {
            switch (level)
            {
                case 0:
                    foreach (Enemy Ranger in enemies)
                        if (x == Ranger.pos.x && y == Ranger.pos.y)
                            return true;
                    break;
                case 1:
                    foreach (Enemy Mage in enemies)
                        if (x == Mage.pos.x && y == Mage.pos.y)
                            return true;
                    break;
                case 2:
                    foreach (Enemy Melee in enemies)
                        if (x == Melee.pos.x && y == Melee.pos.y)
                            return true;
                    break;
                default: return false;
            }
            return false;
        }

    }
}
