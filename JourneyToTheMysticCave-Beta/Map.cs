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
        //Used to build map / display map
        //private string[] mapTextFiles = new string[] { "Map0.txt", "Map1.txt", "Map2.txt" };
        //private char[][,] mapContents = new char[3][,];

        //game entities
        //public Player player;
        public LevelManager levelManager;

        char[,] currentMap;

        public void Init()
        {
            
        }

        public void Update()
        {
            currentMap = GetCurrentMapContent();

        }

        public void Draw()
        {
            for (int i = 0; i < currentMap.GetLength(0); i++)
            {
                for (int j = 0; j < currentMap.GetLength(1); j++)
                {
                    char characterToDraw = GetCharacterToDraw(i, j);
                    //legendColours.MapColor(characterToDraw);
                    Console.Write(characterToDraw);
                    //Console.ResetColor();
                }
                Console.WriteLine();
            }
        }


        private char[,] GetCurrentMapContent()
        {
            return levelManager.AllMapContents[levelManager.mapLevel];
        }

        public bool CheckBoundaries(int x, int y)
        {
            return x >= 0 && x < currentMap.GetLength(1) && y >= 0 && y < currentMap.GetLength(0) &&
                currentMap[x,y] != '#' && currentMap[x,y] != '^';
        }

    }
}
