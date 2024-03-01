using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyToTheMysticCave_Beta
{
    internal class _GameManager
    {
        Map map = new Map();
        Player player = new Player();
     

        public void Gameplay()
        {
            map.Init();
            map.Draw();
            Console.ReadKey();
        }
    }
}
