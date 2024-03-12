using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyToTheMysticCave_Beta
{
    internal class Map
    {
        //game entities
        public LevelManager levelManager;
        public LegendColors legendColors;

        char[,] currentMap;

        public void Init(LevelManager levelManager, LegendColors legendColors)
        {
            this.levelManager = levelManager;
            this.legendColors = legendColors;
        }

        public void Update()
        {
            currentMap = GetCurrentMapContent();
        }

        public void Draw()
        {
            Console.SetCursorPosition(0, 0);
            for (int i = 0; i < currentMap.GetLength(0); i++)
            {
                for (int j = 0; j < currentMap.GetLength(1); j++)
                {
                    char characterToDraw = currentMap[i, j];

                    legendColors.MapColor(characterToDraw);
                    Console.Write(currentMap[i, j]);
                    Console.ResetColor();
                }
                Console.WriteLine();
            }
        }
        public int GetMapRowCount()
        {
            return currentMap.GetLength(0);
        }

        public int GetMapColumnCount()
        {
            return currentMap.GetLength(1);
        }

        private char[,] GetCurrentMapContent()
        {
            return levelManager.AllMapContents[levelManager.mapLevel];
        }

        public bool CheckBoundaries(int x, int y)
        {
            return currentMap[y, x] != '#' && currentMap[y, x] != '^';
        }
    }
}
