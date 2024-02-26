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
        public int mapLevel = 0;
        public int previousLevel = 0;
        private string[] mapTextFiles = new string[] { "Map0.txt", "Map1.txt", "Map2.txt" };
        private char[][,] allMapContents = new char[3][,];

        //game entities
        public Player _player;


        public char[][,] AllMapContents
        {
            get { return allMapContents; }
        }

        public char[,] GetMapContent(int mapLevel)
        {
            if (mapLevel >= 0 && mapLevel < allMapContents.Length)
                return allMapContents[mapLevel];
            else
                throw new IndexOutOfRangeException("Index is out of range.");
        }

        public void Init()
        {
            for (int i = 0; i < mapTextFiles.Length; i++)
            {
                string[] lines = File.ReadAllLines(mapTextFiles[i]);
                allMapContents[i] = new char[lines.Length, lines[0].Length];

                for (int j = 0; j < lines.Length; j++)
                {
                    for (int k = 0; k < lines[j].Length; k++)
                    {
                        allMapContents[i][j, k] = lines[j][k];
                    }
                }
            }
        }

        public void Draw()
        {
            for (int i = 0; i < GetMapContent(mapLevel).GetLength(0); i++)
            {
                for (int j = 0; j < GetMapContent(mapLevel).GetLength(1); j++)
                {
                    char characterToDraw = GetCharacterToDraw(i, j);
                    //legendColours.MapColor(characterToDraw);
                    Console.Write(characterToDraw);
                    //Console.ResetColor();
                }
                Console.WriteLine();
            }
        }

        private char GetCharacterToDraw(int i, int j)
        {
            return allMapContents[2][i, j];
        }
    }
}
