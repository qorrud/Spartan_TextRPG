using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    internal class Intro
    {
        public static void IntroStart()
        {
            Console.WriteLine("어두운 동굴. 차가운 돌바닥에서 눈을 떴다. 머리가 멍하다.");

            Console.WriteLine("\n나는.... 나는 누구였지....?");

            Console.WriteLine("\n기억이 나지 않는다. ");

            Console.WriteLine("\n1. 가방이 묵직하다. 쇠붙이 같은 무게감이 손에 익숙하다.");  //직업 대사 출력

            Console.WriteLine("\n2. 손가락에 굳은살이 박혀 있다.활시위를 오래 당긴 흔적일까 ?");

            Console.WriteLine("\n3. 공기 중에 희미한 마력이 느껴진다. 손끝이 반응한다.");
                       
        }
    
        public static void IntroSelect(Player player)
        {
            int selectJob = -1;
            int selectDIfficulty = -1;

            while (true)
            {
                Console.WriteLine("\n나는.... ");
                string input1 = Console.ReadLine();

                if (int.TryParse(input1, out int select) && select >= 1 && select <= 3)
                {
                    if (select == 1)
                    {
                        Console.WriteLine("\n... 그래 나는 전사였어");
                        Console.WriteLine("\n나는 천천히 내 옆에 떨어진 검을 들고 일어섰다.");
                        selectJob = select;
                        break;
                    }

                    else if (select == 2)
                    {
                        Console.WriteLine("\n... 그래 나는 궁수였어");
                        Console.WriteLine("\n나는 천천히 풀어진 활을 다시 감았다.");
                        selectJob = select;
                        break;
                    }

                    else
                    {
                        Console.WriteLine("\n... 그래 나는 마법사였어");
                        Console.WriteLine("\n나는 잠시 눈을 감고 내 안의 마력을 점검했다.");
                        selectJob = select;
                        break;
                    }

                }
                else
                {
                    Console.WriteLine("\n으윽... 머리가...");
                }
            }                  

                Console.WriteLine("\n잠시 주변을 살핀 뒤 천천히 돌이켜본다.");

                Console.WriteLine("\n…나는 어떤 모험자였을까?");
                while (true)
                {
                    Console.WriteLine("\n1. 이 장비들… 이름 있는 모험자였던 것 같다. (쉬움)");

                    Console.WriteLine("\n2. 평범한 장비다. 그냥 그런 모험자였겠지. (보통)");

                    Console.WriteLine("\n3. 너덜너덜한 장비들을 보니 무슨 일이 있었던 것 같다. (어려움)");

                    string input2 = Console.ReadLine();

                switch (input2)
                {
                    case "1":
                        Console.WriteLine("\n미구현 기능입니다. 보통 난이도로 시작합니다.");
                        selectDIfficulty = 2;
                        break;

                    case "2":
                        Console.WriteLine("\n평범한 장비를 얻었다!");
                        selectDIfficulty = 2;
                        break;
                    case "3":
                        Console.WriteLine("\n미구현 기능입니다. 보통 난이도로 시작합니다.");
                        selectDIfficulty = 2;
                        break;
                    default:
                        Console.WriteLine("\n잘못된 입력입니다. 다시 입력해주세요");
                        continue;
                }
                break;
                }
            player.SetJob((Job)(selectJob));
            player.SetDifficulty((DifficultyLevel)selectDIfficulty);

            Console.WriteLine("\n장비를 챙기고 동굴을 나섭니다...");
            Console.WriteLine("\n계속하려면 아무 키나 누르세요...");
            Console.ReadKey();
        }

    }


}
