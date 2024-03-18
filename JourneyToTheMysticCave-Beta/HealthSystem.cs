using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyToTheMysticCave_Beta
{
    internal class HealthSystem
    {
        public int health;
        public bool hurt;
        public bool hurtByTrap;
        public bool floorDamage;

        // one of these is used for the game log
        public bool mapDead;
        public bool dead;

        public bool cannotHeal;
        public bool healed;


        public void TakeDamage(int damage) // can be used for floor damage, player attack, trap damage
        {
            health -= damage;
            hurt = true;

            if(health <= 0)
            {
                health = 0;
                mapDead = true;
                dead = true;
            }
        }

        public void Heal(int hp)
        {
            health += hp;
            healed = true;

            if(health >= 100)
            {
                health = 100;
                cannotHeal = true;
            }
        }
    }
}
