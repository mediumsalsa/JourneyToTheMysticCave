using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace JourneyToTheMysticCave_Beta.Items
{
    internal class Shop
    {
        Player player;
        Map map;

        public bool isShopOpen = true;
        private int col;
        private int row;

        public void Init(Player player, Map map)
        {
            this.player = player;
            this.map = map;
        }

        public void BuyItem(int itemNum)
        {
            if (isShopOpen == false) return;

            if (itemNum == 1 && player.moneyCount >= 1)
            {
                player.healthSystem.Heal(10);
                player.moneyCount -= 1;
            }
            else if (itemNum == 2 && player.moneyCount >= 2)
            {
                player.damage += 10;
                player.moneyCount -= 2;
            }
            else if (itemNum == 3 && player.moneyCount >= 6)
            {
                player.poisonBoots = true;
                player.moneyCount -= 6;
            }
        }

        public void PlayerEnters()
        {
            isShopOpen = true;
        }

        public void PlayerExits()
        {
            isShopOpen = false;
        }

        public void Update()
        {
            ShopInfo();
        }

        private void ShopInfo()
        {
            col = map.GetMapColumnCount() + 2;
            row = map.GetMapRowCount() + 1;

            if (isShopOpen == false)
            {
                Console.SetCursorPosition(col, row);
                Console.WriteLine("+--------------------------------------------------------+");
                Console.SetCursorPosition(col, row+1);
                Console.WriteLine("Shop closed");
                Console.SetCursorPosition(col, row+2);
                Console.WriteLine("+--------------------------------------------------------+");
            }
            else if (isShopOpen == true)
            {
                Console.SetCursorPosition(col, row);
                Console.WriteLine("+--------------------------------------------------------+");
                Console.SetCursorPosition(col, row+1);
                Console.WriteLine("Welcome to the shop!");
                Console.SetCursorPosition(col, row+2);
                Console.WriteLine("Click '1' to buy health potion(+10 Health): 1$");
                Console.SetCursorPosition(col, row+3);
                Console.WriteLine("Click '2' to upgrade sword(+10 Damage): 2$");
                Console.SetCursorPosition(col, row+4);
                Console.WriteLine("Click '3' to buy Poison Boots(No poison damage): 6$");
                Console.SetCursorPosition(col, row+5);
                Console.WriteLine("+--------------------------------------------------------+");
            }
        }


    }
}
