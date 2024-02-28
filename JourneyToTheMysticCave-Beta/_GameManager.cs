using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyToTheMysticCave_Beta
{
    internal class _GameManager
    {
        public Map map = new Map();
        public Player player = new Player();
        public Ranged[] rangers = new Ranged[3];
        public Mage[] mages = new Mage[3];
        public Melee[] melee = new Melee[30];
        public Boss boss = new Boss();

        public void Gameplay()
        {
            map.Init();
            map.Draw();
            Console.ReadKey();
        }
    }
}
