using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;

namespace JourneyToTheMysticCave_Beta
{
    internal class Quest1 : Quest
    {
        private Player player;
        private string description;
        private bool completion;

        public Quest1(Player player, string desc, bool completion) :
        base(player, desc, completion)
        {
            this.player = player;
            this.description = desc;
            this.completion = completion;
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
                description = "Quest 1: Kill 10 Enemies.";
            }
            else
            {
                description = "Quest 1: COMPLETED :D";
            }
        }



    }
}
