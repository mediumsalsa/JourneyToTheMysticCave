using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyToTheMysticCave_Beta
{
    internal class Player : GameEntity
    {


        public void Init()
        {

        }

        public void Update()
        {

        }

        public void Draw()
        {
            Console.SetCursorPosition(pos.x, pos.y);
            Console.Write(character);
        }
    }
}
