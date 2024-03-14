using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyToTheMysticCave_Beta
{
    internal class Boss : Enemy
    {
        Random random = new Random();

        public Boss(int count, char character, string name, int damage, int health) : base(count, character, name, damage, health)
        {
            this.count = count;
            this.character = character;
            this.name = name;
            this.damage = damage;
            this.health = health;
        }

        public override void Update()
        {

        }

        public override void Draw()
        {
            Console.SetCursorPosition(pos.x, pos.y);
            Console.Write(character.ToString());
            Console.CursorVisible = false;
        }
    }
}
