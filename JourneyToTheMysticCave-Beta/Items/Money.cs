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
        Player player;
        
        public Money(int count, char character, string name, LegendColors legendColors, Player player) : base(count, character, name)
        {
            this.legendColors = legendColors;
            this.player = player;
        }

        public override void Update()
        {
            if (player.pos.x == pos.x && player.pos.y == pos.y)
                TryCollect();
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
