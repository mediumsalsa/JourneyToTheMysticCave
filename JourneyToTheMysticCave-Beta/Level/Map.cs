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
        public EnemyManager enemyManager;

        char[,] currentMap;

        public void Init(LevelManager levelManager, LegendColors legendColors, EnemyManager enemyManager)
        {
            this.levelManager = levelManager;
            this.legendColors = legendColors;
            this.enemyManager = enemyManager;
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

        public char[,] GetCurrentMapContent()
        {
            return levelManager.AllMapContents[levelManager.mapLevel];
        }

        public bool CheckBoundaries(int x, int y)
        {
            return x >= 0 && x < currentMap.GetLength(1) && y >= 0 && y < currentMap.GetLength(0) &&
                currentMap[y, x] != '#' && currentMap[y, x] != '^';
        }
    }
}
