using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyToTheMysticCave_Beta
{
    internal class Melee : Enemy
    {
        Random random = new Random();

        public Melee()
        {
            healthSystem = new HealthSystem();
            randomHealth = random.Next(minHp, maxHp);
            healthSystem.health = randomHealth;
        }
    }
}
