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
        Player player;

        public Sword(int count, char character, string name, int swordMultiplier, LegendColors legendColors, Player player) : base(count, character, name)
        {
            this.swordMultiplier = swordMultiplier;
            this.legendColors = legendColors;
            this.player = player;
        }

        public override void Update()
        {
            if(pickedUp)
            {
                player.damage += swordMultiplier;
                pickedUp = false;
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
