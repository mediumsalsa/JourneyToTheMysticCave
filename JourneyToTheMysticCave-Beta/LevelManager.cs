using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyToTheMysticCave_Beta
{
    internal class LevelManager
    {
        public int mapLevel = 0;
        public int previousLevel = 0;
        private string[] mapTextFiles = new string[] { "Map0.txt", "Map1.txt", "Map2.txt" };
        private char[][,] mapContents = new char[3][,];

        public Player _player;

        public char[][,] AllMapContents
        {
            get { return mapContents; }
        }

        public void Init() // Initialize level maps.
        {
            for (int i = 0; i < mapTextFiles.Length; i++)
            {
                string[] lines = File.ReadAllLines(mapTextFiles[i]);
                mapContents[i] = new char[lines.Length, lines[0].Length];

                for (int j = 0; j < lines.Length; j++)
                {
                    for (int k = 0; k < lines[j].Length; k++)
                    {
                        mapContents[i][j, k] = lines[j][k];
                    }
                }
            }
        }

        

        public void Update() // are we changing the level or not
        {
            CheckMapChange();
        }

        private void CheckMapChange()
        {
            switch (mapLevel)
            {
                case 0:
                    if (_player.pos.x == 40 && _player.pos.y == 7)
                    {
                        mapLevel = 1;
                        _player.pos = new Point2D { x = 1, y = 7 };
                    }
                    break;
                case 1:
                    if (_player.pos.x == 0 && _player.pos.y == 7)
                    {
                        mapLevel = 0;
                        _player.pos = new Point2D { x = 39, y = 7 };
                    }
                    if (_player.pos.x == 37 && _player.pos.y == 3)
                    {
                        mapLevel = 2;
                        _player.pos = new Point2D {x = 37, y = 14 };
                    }
                    break;
                case 2:
                    if (_player.pos.x == 37 && _player.pos.y == 15)
                    {
                        mapLevel = 1;
                        _player.pos = new Point2D { x = 37, y = 4 };
                    }
                    break;
            }
        }
    }
}
