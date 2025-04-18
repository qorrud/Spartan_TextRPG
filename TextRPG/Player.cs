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
        // �� ���� ������: MP�� ���� ����
        public Stat(int atk, int def, int hp, int gold, int exp)
        {
            Attack = atk;
            Defense = def;
            HP = hp;
            MP = 0; // ���� MP ������� ����
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

        //  MaxHP / MaxMP ���� ����
        public int MaxHP { get; set; }
        public int MaxMP { get; set; }

        //  ���� HP / MP�� ������Ƽ�� ���� �������� �ִ�ġ �̻� ȸ���� �� ���� ����
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
            HP = MaxHP; //�ִ� ü���� ���� ü������ �ʱ�ȭ
            MP = MaxMP; //
            Gold = stat.Gold;
            Exp = stat.Exp;

            Level = 1;
            Karma = 0;
        }
        public void GainExp(int amount)
        {
            Exp += amount; // amount �Ű����� ��ŭ ����ġ�� ���
            int requiredExp = Level * 10; //�ʿ� ����ġ���� ������ 10���� ����

            while (Exp >= requiredExp)  //�ݺ��� ������ �ʿ� ����ġ������ ȹ�� ����ġ���� �������� ����
            {
                Exp -= requiredExp; // ���� ����ġ���� �ʿ� ����ġ�� ��
                Level++; //������ �ø��� ���ÿ� ���� �߰�
                Attack += 2;
                Defense += 2;
                MaxHP += 10;
                MaxMP += 5;

                Console.WriteLine($"������! Lv.{Level}�� �Ǿ����ϴ�!"); //�޼��� ��� ��
                requiredExp = Level * 10; //�ʿ� ����ġ�� ���� + ���� ���� ����ġ���� �ʿ� ����ġ������ ���� ������ �ݺ��� Ż��
            }
        }

        //ȹ�� �������� EquipmentInventroy ��ųʸ��� ���� ����
        public Dictionary<string, Equipment> EquipmentInventory { get; set; } = new(); //��ųʸ��� ���� ���� ������ ���� �� ���� ����Ʈ�� �߰� ���� < �߰� ���� �߿�
        public Dictionary<string, Potion> PotionInventory { get; set; } = new();


        public void DisplayStats()
        {
            Console.WriteLine($"{PlayerName} ({Job})");
            Console.WriteLine($"���ݷ� : {Attack}");
            Console.WriteLine($"���� : {Defense}");
            Console.WriteLine($"HP : {HP}/{MaxHP} | MP: {MP}/{MaxMP}");
            Console.WriteLine($"Gold : {Gold} | Exp: {Exp}");
            Console.WriteLine(new string('-', 30));
        }
        
    }

}
