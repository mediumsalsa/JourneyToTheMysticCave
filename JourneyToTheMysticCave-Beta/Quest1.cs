﻿using System;
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
        public Quest1(Player player) :
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
            if (player.killCount >= 2)
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
                description = "Quest 1: Kill 10 Enemies";
            }
            else
            {
                description = "Quest 1: COMPLETED :D";
            }
        }



    }
}
