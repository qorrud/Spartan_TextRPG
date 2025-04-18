using System.Security.Cryptography.X509Certificates;

namespace TextRPG
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 실행 흐름 시작
            Intro.IntroStart();
            Player player = new Player();
            Intro.IntroSelect(player);
            Menu.MainMenu(player);
            Event.FirstEvent();
            Event.SecondEvent(player);

        }

        

   



    }

}
