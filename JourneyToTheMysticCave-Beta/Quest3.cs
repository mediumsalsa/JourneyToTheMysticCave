using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyToTheMysticCave_Beta
{
    internal class Quest3 : Quest
    {

        public Quest3(Player player) :
        base(player)
        {
            this.player = player;
        }


        public override void Init()
        {
            completion = false;
        }


        public override void Update()
        {
            if (player.killCount >= 10)
            {
                completion = true;
            }
            else
            {
                completion = false;
            }
        }

        public override void Draw()
        {
            if (completion == false)
            {
                description = "Quest 1: Kill the Boss";
            }
            else
            {
                description = "Quest 1: COMPLETED :D";
            }
        }

    }
}
