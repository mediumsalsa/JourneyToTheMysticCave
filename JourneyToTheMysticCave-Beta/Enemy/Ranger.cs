using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyToTheMysticCave_Beta
{
    internal class Ranger : Enemy
    {
        Random random = new Random();

        public Ranger()
        {
            healthSystem = new HealthSystem();
            randomHealth = random.Next(minHp, maxHp);
            healthSystem.health = randomHealth;
        }
    }
}
