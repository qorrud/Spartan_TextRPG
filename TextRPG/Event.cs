using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    public class Event
    {
        public static void FirstEvent()
        {
            Console.WriteLine("\n무거운 몸을 이끌고 동굴 밖으로 나가자 가까운 곳에 연기가 보인다.");
            Console.WriteLine("\n일단 저기로 가볼까....");


            while (true)
            {
                Console.WriteLine("\n1. 일단 안전한 곳으로 가야해");
                Console.WriteLine("\n2. 몬스터가 있을지도 몰라, 주변을 더 둘러보자");

                string input1 = Console.ReadLine();

                switch(input1)
                {
                    case "1":
                        Console.WriteLine("\n일단 정비가 필요해... 제발 마을이 나오길....");
                        Console.ReadKey();
                        break;

                    case "2":
                        Console.Clear();
                        Console.WriteLine("\n미구현 기능입니다. 연기가 나는 곳으로 이동합니다.");
                        Console.ReadKey();
                        break;

                    default:
                        Console.WriteLine("\n잘못된 입력입니다. 다시 입력해주세요.");
                        Thread.Sleep(1000); //문자 속도 조절
                        break;
                }
                Console.WriteLine("\n 다행히 마을이 보인다...");
                Console.WriteLine("\n 나는 마을에 들어섰다.");
                break;
            }
        }

        public static void SecondEvent(Player player)
        {
            Console.WriteLine("\n스파르타 마을에 오신 여러분 환영합니다.");
            Console.WriteLine("\n이곳에서 던전으로 들어가기전 활동을 할 수 있습니다");

            while (true)
            {
                Console.WriteLine("\n1. 상태 보기");
                Console.WriteLine("\n2. 인벤토리");
                Console.WriteLine("\n3. 상점 가기");
                Console.WriteLine("\n >>> 선택: ");

                string input = Console.ReadLine();

                switch(input)
                {
                    case "1":
                        player.DisplayStats();
                            break;
                    case "2":
                        ItemManager.ShowInventory(player);
                        break;
                    case "3":
                        Console.WriteLine("미구현 기능입니다.");
                        break;
                    default:
                        Console.WriteLine("잘못된 입력입니다.");
                        break;

                }

            }

        }

    }

}
