using System;
using System.Collections.Generic;
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
        public Quest(Player player, string desc, bool completion)
        {
            this.player = player;
            this.description = desc;
            this.completion = completion;
        }

        public abstract void Update();

        public abstract void Draw();

    }
}
