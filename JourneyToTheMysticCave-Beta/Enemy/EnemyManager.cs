using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyToTheMysticCave_Beta
{
    internal class EnemyManager
    {
        public GameStats stats;
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

        public void Init(GameStats stats, LevelManager levelManager, LegendColors legendColors, Gamelog log, Player player, Map map)
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
                switch (levelManager.mapLevel)
                {
                    case 0:
                        if (enemy.GetType().Name == "Ranger")
                            enemy.Update(random);
                        break;
                    case 1:
                        if (enemy.GetType().Name == "Mage")
                            enemy.Update(random);
                        break;
                    case 2:
                        if (enemy.GetType().Name == "Melee")
                            enemy.Update(random);
                        else if (enemy.GetType().Name == "Boss" && AreAllMeleeDead())
                        {
                            if (AreAllMeleeDead() && firstDead == false)
                            {
                                enemy.pos = stats.PlaceCharacters(2, random);
                                firstDead = true;
                            }
                            enemy.Update(random);
                        }
                        break;
                }
            }
        }

        public void Draw()
        {
            foreach (Enemy enemy in enemies)
            {
                switch (levelManager.mapLevel)
                {
                    case 0:
                        if (enemy is Ranger)
                            enemy.Draw();
                        break;
                    case 1:
                        if (enemy is Mage)
                            enemy.Draw();
                        break;
                    case 2:
                        if (enemy is Melee)
                            enemy.Draw();
                        else if (enemy is Boss && AreAllMeleeDead())
                            enemy.Draw();
                        break;
                }
            }
        }

        public bool AreAllMeleeDead()
        {
            return !enemies.Any(enemy => enemy is Melee && enemy.IsAlive);
        }

        //public bool CheckEnemyPos(int x, int y)
        //{
        //    foreach (Enemy enemy in enemies)
        //    {
        //        switch (levelManager.mapLevel)
        //        {
        //            case 0:
        //                if (enemy.GetType().Name == "Ranger" && x == enemy.pos.x && y == enemy.pos.y)
        //                    return true;
        //                break;
        //            case 1:
        //                if (enemy.GetType().Name == "Mage" && x == enemy.pos.x && y == enemy.pos.y)
        //                    return true;
        //                break;
        //            case 2:
        //                if (enemy.GetType().Name == "Melee" && x == enemy.pos.x && y == enemy.pos.y)
        //                    return true;
        //                break;
        //        }
        //    }
        //    return false;
        //}
    }
}
