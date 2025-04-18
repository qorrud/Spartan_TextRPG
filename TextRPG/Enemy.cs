using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    public enum EnemyType
    {
        // 일반 몬스터
        고블린, 늑대, 슬라임, 오크, 해골병사,
        임프, 맹독거미, 광신도, 암흑기사, 와이번,

        // 정예 몬스터
        오우거, 리치, 맹독여왕거미, 암흑기사단장, 드래곤,

        // 최종 보스
        마왕
    }

    
    public class EnemyStat
    {
        public EnemyType EnemyType;
        public int Attack;
        public int Defense;
        public int HP;
        public int Gold;
        public int Exp;
        public int Level;
        public DifficultyLevel Difficulty { get; private set; }

        private static Dictionary<EnemyType, Stat> enemyStats = new Dictionary<EnemyType, Stat>()
        {
                                 //atk, def, hp, gold, exp  
    // 일반 적
    { EnemyType.고블린,   new Stat(7, 3, 20, 50, 10) },
    { EnemyType.늑대,     new Stat(10, 0, 15, 50, 10) },
    { EnemyType.슬라임,   new Stat(5, 10, 30, 50, 8) },
    { EnemyType.오크,     new Stat(15, 6, 50, 70, 18) },
    { EnemyType.해골병사, new Stat(12, 8, 35, 70, 14) },
    { EnemyType.임프,     new Stat(9, 4, 28, 70, 15) },
    { EnemyType.맹독거미, new Stat(10, 5, 30, 100, 16) },
    { EnemyType.광신도,   new Stat(11, 4, 30, 100, 17) },
    { EnemyType.암흑기사, new Stat(30, 30, 80, 100, 20) },
    { EnemyType.와이번,   new Stat(50, 50, 100, 300, 700) },

    // 정예 적
    { EnemyType.오우거,       new Stat(40, 40, 100, 1500, 300) },
    { EnemyType.리치,         new Stat(60, 20, 200, 2000, 500) },
    { EnemyType.맹독여왕거미, new Stat(70, 50, 100, 3000, 600) },
    { EnemyType.암흑기사단장, new Stat(60, 70, 120, 4000, 800) },
    { EnemyType.드래곤,       new Stat(70, 70, 180, 5000, 1000) },

    // 최종 보스
    { EnemyType.마왕, new Stat(100, 100, 200, 10000, 10000) }
};


        public void StartingStats()
        {
            Stat stat = enemyStats[EnemyType];

            Attack = stat.Attack;
            Defense = stat.Defense;
            HP = stat.HP;
            Gold = stat.Gold;
            Exp = stat.Exp;
        }

        public void DisplayStats()
        {
            Console.WriteLine($"[{EnemyType}]");
            Console.WriteLine($"공격력 : {Attack}, 방어력 : {Defense}");
            Console.WriteLine($"HP : {HP}, Gold : {Gold}, Exp : {Exp}");
            Console.WriteLine("---------------------------");
        }

    }

}
