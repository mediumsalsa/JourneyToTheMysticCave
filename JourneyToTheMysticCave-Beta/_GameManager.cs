using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyToTheMysticCave_Beta
{
    internal class _GameManager
    {
        Map map = new Map();
        Player player = new Player();
        LevelManager levelManager = new LevelManager();
     
        public _GameManager()
        {
            Init();
        }

        public void Gameplay()
        {

            //while (true)
            //{
                Update();
                Draw();
           // }
   
            Console.ReadKey();
        }

        private void Init()
        {
            levelManager.Init();
            map.Init(levelManager);
        }

        private void Update()
        {
            map.Update();
            //levelManager.Update();
        }

        private void Draw()
        {
            map.Draw();

        }
    }
}
