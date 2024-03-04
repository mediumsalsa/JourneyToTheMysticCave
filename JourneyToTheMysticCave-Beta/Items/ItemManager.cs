using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyToTheMysticCave_Beta
{
    internal class ItemManager
    {
        private List<Item> items;
        Potion potion;
        Money money;
        Trap trap;
        public int count;

        public ItemManager()
        {
            items = new List<Item>();
        }

        public virtual void Init()
        {
            for (int i = 0; i < money.count; i++)
                items.Add(new Money());
            for (int i = 0; i < potion.count; i++)
                items.Add(new Potion());
            for (int i = 0; i < trap.count; i++)
                items.Add(new Trap());
        }

        public void Update()
        {
            foreach (Item item in items)
            {
                item.Update();
            }
        }

        public void Draw()
        {
            foreach (Item item in items)
            {
                item.Draw();
            }
        }
    }
}
