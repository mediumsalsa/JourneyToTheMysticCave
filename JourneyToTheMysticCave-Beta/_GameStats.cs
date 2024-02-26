using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyToTheMysticCave_Beta
{
    internal class _GameStats
    {
        Player _player;

        public _GameStats(Player player)
        {
            this._player = player;
        }

        public void GameConfig()
        {
            //Player Configs/Stats
            _player.character = 'H';
            _player.name = "Hero";
            _player.damageAmount = 10;
            _player.pos = new Point2D { x = 2, y = 5 };

            // Ranger Configs/Stats


            // Mage Configs/Stats


            // Slime Configs/Stats


            // Boss Configs/Stats


        }
    }
}
