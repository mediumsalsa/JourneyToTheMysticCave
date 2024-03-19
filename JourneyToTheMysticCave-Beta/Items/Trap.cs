using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyToTheMysticCave_Beta
{
    internal class Trap : Item
    {
        public int trapDamage;
        LegendColors legendColors;

        public Trap(int count, char character, string name, int trapDamage, LegendColors legendColors) : base(count, character, name)
        {
            this.trapDamage = trapDamage;
            this.legendColors = legendColors;
        }

        public override void Update()
        {
            if (pickedUp)
            {

            }
        }

        public override void Draw()
        {
            if (!collected)
            {
                Console.SetCursorPosition(pos.x, pos.y);
                legendColors.MapColor(character);
                Console.Write(character.ToString());
                Console.ResetColor();
            }
            Console.CursorVisible = false;
        }
    }
}