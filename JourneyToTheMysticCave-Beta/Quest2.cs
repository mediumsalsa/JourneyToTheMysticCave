using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyToTheMysticCave_Beta
{
    internal class Quest2 : Quest
    {

        public Quest2(Player player) :
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
            if (player.moneyCount >= 3)
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
                description = "Quest 2: Collect 3 Money";
            }
            else
            {
                description = "Quest 1: COMPLETED :D";
            }
        }

    }
}
