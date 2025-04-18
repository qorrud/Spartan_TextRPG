using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    public enum Job { Warrior = 1, Archer = 2, Mage = 3 }
    public enum DifficultyLevel { Easy = 1, Normal = 2, Hard = 3 }

    public class BaseStat
    {
        public int Attack;
        public int Defense;
        public int HP;
        public int MP;
        public int Gold;
        public int Exp;
    }

    public class Stat : BaseStat
    {
        public Stat(int atk, int def, int hp, int mp, int gold, int exp)
    {
        Attack = atk;
        Defense = def;
        HP = hp;
        MP = mp;
        Gold = gold;
        Exp = exp;
    }
        // 적 전용 생성자: MP가 없는 버전
        public Stat(int atk, int def, int hp, int gold, int exp)
        {
            Attack = atk;
            Defense = def;
            HP = hp;
            MP = 0; // 적은 MP 사용하지 않음
            Gold = gold;
            Exp = exp;
        }
    }
    public interface IStatDisplay
    {
        void DisplayStats();
    }


    public class Player : IStatDisplay
    {
        public string PlayerName { get; set; }
        public Job Job { get; set; }
        public DifficultyLevel Difficulty { get; set; }

        public int Attack { get; set; }
        public int Defense { get; set; }

        //  MaxHP / MaxMP 따로 관리
        public int MaxHP { get; set; }
        public int MaxMP { get; set; }

        //  현재 HP / MP는 프로퍼티를 통해 포션으로 최대치 이상 회복할 수 없게 제한
        private int _hp;
        public int HP
        {
            get => _hp;
            set => _hp = Math.Clamp(value, 0, MaxHP); 
        }

        private int _mp;
        public int MP
        {
            get => _mp;
            set => _mp = Math.Clamp(value, 0, MaxMP);
        }

        public int Gold { get; set; }
        public int Exp { get; set; }
        public int Level { get; set; }
        public Equipment EquippedWeapon { get; set; }
        public Equipment EquippedArmor { get; set; }

        private int Karma;
       

        private static Dictionary<Job, Stat> jobStats = new Dictionary<Job, Stat>()
        {                         // atk, def, hp, mp, gold, exp
            { Job.Warrior, new Stat(20, 15, 150, 10, 1500, 0) },
            { Job.Archer,  new Stat(25, 10, 120, 20, 1500, 0) },
            { Job.Mage,    new Stat(25, 5,  100, 50, 1500, 0) }
        };

        public void SetJob(Job job)
        {
            this.Job = job;
            StartingStats();
            DisplayStats();
        }

        public void SetDifficulty(DifficultyLevel difficulty)
        {
            Difficulty = difficulty;
        }

        public void StartingStats()
        {
            Stat stat = jobStats[Job];

            Attack = stat.Attack;
            Defense = stat.Defense;
            MaxHP = stat.HP;
            MaxMP = stat.MP;
            HP = MaxHP; //최대 체력을 현재 체력으로 초기화
            MP = MaxMP; //
            Gold = stat.Gold;
            Exp = stat.Exp;

            Level = 1;
            Karma = 0;
        }
        public void GainExp(int amount)
        {
            Exp += amount; // amount 매개변수 만큼 경험치를 얻고
            int requiredExp = Level * 10; //필요 경험치량은 레벨당 10으로 고정

            while (Exp >= requiredExp)  //반복문 조건을 필요 경험치량보다 획득 경험치량이 높아지게 설정
            {
                Exp -= requiredExp; // 현재 경험치에서 필요 경험치를 뺌
                Level++; //레벨을 올림과 동시에 스탯 추가
                Attack += 2;
                Defense += 2;
                MaxHP += 10;
                MaxMP += 5;

                Console.WriteLine($"레벨업! Lv.{Level}이 되었습니다!"); //메세지 출력 후
                requiredExp = Level * 10; //필요 경험치량 조절 + 이제 현재 경험치량이 필요 경험치량보다 적기 때문에 반복문 탈출
            }
        }

        //획득 아이템을 EquipmentInventroy 딕셔너리를 만들어서 관리
        public Dictionary<string, Equipment> EquipmentInventory { get; set; } = new(); //딕셔너리는 같은 값을 여러개 넣을 수 없음 리스트는 추가 가능 < 추가 공부 중요
        public Dictionary<string, Potion> PotionInventory { get; set; } = new();


        public void DisplayStats()
        {
            Console.WriteLine($"{PlayerName} ({Job})");
            Console.WriteLine($"공격력 : {Attack}");
            Console.WriteLine($"방어력 : {Defense}");
            Console.WriteLine($"HP : {HP}/{MaxHP} | MP: {MP}/{MaxMP}");
            Console.WriteLine($"Gold : {Gold} | Exp: {Exp}");
            Console.WriteLine(new string('-', 30));
        }
        
    }

}
