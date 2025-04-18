using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    internal class TextManager
    {
        //텍스트 전용 메소드를 만들고 호출하는 방식으로 여러 텍스트의 색과 속도를 구현
        public static void TypingText(string textColor, string text, int speed = 45)
        {
            void SelectColor(string textColor)
            {
                switch(textColor.ToLower()) //ToLowr을 사용함으로써 대문자 입력도 소문자 입력으로 인식
                    {
                    case "red":
                        Console.ForegroundColor = ConsoleColor.Red;
                        break;
                    case "blue":
                        Console.ForegroundColor = ConsoleColor.Blue;
                        break;
                    case "green":
                        Console.ForegroundColor = ConsoleColor.Green;
                        break;
                    case "yellow":
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                }
            }
        }
        //다양한 자료형에 자동으로 대응되게끔 설계
        public static void TypingVar(string textColor, object input, int speed = 45)
        {

        }
        

    }
}
