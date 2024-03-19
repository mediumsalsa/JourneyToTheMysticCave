using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyToTheMysticCave_Beta
{
    internal class Money : Item
    {
        LegendColors legendColors;
        
        public Money(int count, char character, string name, LegendColors legendColors) : base(count, character, name)
        {
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
