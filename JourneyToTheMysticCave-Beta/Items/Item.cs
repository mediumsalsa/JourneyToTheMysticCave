using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyToTheMysticCave_Beta
{
    internal abstract class Item
    {
        public bool collected = false;
        public bool pickedUp = false;
        public char character;
        public string name;
        public int count;

        public virtual void Init()
        {

        }

        public virtual void Update()
        {

        }

        public virtual void Draw()
        {

        }
    }
}
