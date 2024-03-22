using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyToTheMysticCave_Beta
{
    internal abstract class Item : GameObject
    {
        public bool collected = false;
        public bool pickedUp = false;
        public int count;

        public Item(int count, char character, string name)
        {
            this.count = count;
            this.character = character;
            this.name = name;
        }

        public virtual void Init() { }
        public virtual void Update() { }
        public virtual void Draw() { }

        public void TryCollect()
        {
            if (!collected)
            {
                collected = true;
                pickedUp = true;
                pos = new Point2D { x = 0, y = 0 };
            }
        }

        public bool ItemAtPos(int x, int y)
        {
            return true;
        }
    }
}
