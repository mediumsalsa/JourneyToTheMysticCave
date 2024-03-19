using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyToTheMysticCave_Beta
{
    internal class Sword : Item
    {
        public int swordMultiplier;
        LegendColors legendColors;

        public Sword(int count, char character, string name, int swordMultiplier, LegendColors legendColors) : base(count, character, name)
        {
            this.swordMultiplier = swordMultiplier;
            this.legendColors = legendColors;
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
