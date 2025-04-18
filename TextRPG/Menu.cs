using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
     public class Menu
    {
        public static void MainMenu(Player player)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("================");
                Console.WriteLine("     메인 메뉴");
                Console.WriteLine("================");
                Console.WriteLine("\n1. 내 정보 보기");
                Console.WriteLine("\n2. 인벤토리 보기");
                Console.WriteLine("\n0. 게임 계속 진행");
                Console.Write("\n>> 선택: ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Console.Clear();
                        player.DisplayStats();
                        Console.WriteLine("\n[메인 메뉴로 돌아가려면 아무 키나 입력해주세요.]");
                        Console.ReadKey();
                        break;

                    case "2":
                        Console.Clear();
                        ItemManager.ShowInventory(player);
                        Console.WriteLine("\n[메인 메뉴로 돌아가려면 아무 키나 입력해주세요.]");
                        Console.ReadKey();
                        break;

                    case "0":
                        Console.WriteLine("\n게임을 계속 진행합니다...");
                        return; // 메인 메뉴 종료 → 게임 흐름 이어감

                    default:
                        Console.WriteLine("\n잘못된 입력입니다. 다시 입력해주세요.");
                        Thread.Sleep(1000); //문자 속도 조절
                        break;
                }
            }
        }

    }
}
