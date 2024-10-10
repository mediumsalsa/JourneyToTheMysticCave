using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyToTheMysticCave_Beta
{
    internal abstract class Quest
    {

        public Player player;
        public string description;
        public bool completion;

        public bool IsAlive { get; set; } = true;

        // Constructor
        public Quest(Player player)
        {
            this.player = player;
        }

        //Initiates the quest 
        public abstract void Init();

        //Updates quest completion status
        public abstract void Update();

        //Draws the desc/completion text
        public abstract void Draw();

    }
}
