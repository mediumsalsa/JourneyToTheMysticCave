using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyToTheMysticCave_Beta
{
    internal class Potion : Item
    {
        public int healAmount;
        LegendColors legendColors;
        Player player;

        public Potion(int count, char character, string name, int healAmount, LegendColors legendColors, Player player) : base(count, character, name)
        {
            this.healAmount = healAmount;
            this.legendColors = legendColors;
            this.player = player;
        }

        public override void Update()
        {
            if (player.pos.x == pos.x && player.pos.y == pos.y)
            {
                TryCollect();
                player.healthSystem.Heal(healAmount);
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
