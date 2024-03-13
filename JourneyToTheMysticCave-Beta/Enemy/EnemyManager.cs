using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyToTheMysticCave_Beta
{
    internal class EnemyManager 
    {
        public List<Enemy> enemies;

        public EnemyManager()
        {
            enemies = new List<Enemy>();
        }

        public _GameStats stats;

        public void Init(_GameStats stats)
        {
            this.stats = stats;

            for (int i = 0; i < stats.RangerCount; i++)
                enemies.Add(new Ranger(stats.RangerCount, stats.RangedCharacter, stats.RangerName, stats.RangerDamage, stats.RangerHealth, stats.RangerPos));
            for (int i = 0;i < stats.MageCount; i++)
                enemies.Add(new Mage(stats.MageCount,stats.MageCharacter, stats.MageName, stats.MageDamage, stats.MageHealth, stats.MagePos));
            for(int i = 0; i < stats.MeleeCount; i++)
                enemies.Add(new Melee(stats.MeleeCount, stats.MeleeCharacter, stats.MeleeName, stats.MeleeDamage, stats.MeleeHealth, stats.MeleePos));
            for(int i = 0;i < stats.BossCount ; i++)
                enemies.Add(new Boss(stats.BossCount, stats.BossCharacter, stats.BossName, stats.BossDamage, stats.BossHealth, stats.BossPos));


            Console.SetCursorPosition(0, 25);
            Console.WriteLine($"{enemies[0].pos.x},{enemies[0].pos.y}");
            Console.WriteLine($"{enemies[1].pos.x},{enemies[1].pos.y}");
            Console.WriteLine($"{enemies[2].pos.x},{enemies[2].pos.y}");
        }

        public void Update()
        {
            foreach (Enemy enemy in enemies)
                enemy.Update();
        }

        public void Draw()
        {
            foreach (Enemy enemy in enemies)
                enemy.Draw();
        }
    }
}
