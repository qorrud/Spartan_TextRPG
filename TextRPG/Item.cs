using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    public enum EquipmentGrade
    {
        Common = 0, Rare = 1, Unique  = 2, Legendary = 3, Mythic = 4  
    }
    public enum EquipmentType
    {
        Weapon = 0,
        Armor = 1       
    }
    public enum PotionGrade
    {
        Low = 0, Mid = 1, High = 2, Max = 3
    }
    public class Equipment
    {
        public string Name { get; set; }
        public EquipmentType Type { get; set; }
        public EquipmentGrade Grade { get; set; }
        public int StatPlus { get; set; }
        public int Price { get; set; }
        public int Count { get; set; }

        //장착 표시를 위한 bool 변수 지정
        public bool IsEquipped {  get; set; } = false;
        public Equipment(string name, EquipmentType type, EquipmentGrade grade, int statPlus, int price)
        {
            IsEquipped = false;
            Name = name;
            Type = type;
            Grade = grade;
            StatPlus = statPlus;
            Price = price;
        }
        public static Dictionary<string, Equipment> EquipmentList = new Dictionary<string, Equipment>()
        {
            // Common (흔함)            
{ "common_sword", new Equipment("평범한 검", EquipmentType.Weapon, EquipmentGrade.Common, 2, 30) { Count = 0 }},
{ "common_bow", new Equipment("평범한 활", EquipmentType.Weapon, EquipmentGrade.Common, 2, 30) { Count = 0 } },
{ "common_wand", new Equipment("평범한 지팡이", EquipmentType.Weapon, EquipmentGrade.Common, 2, 30) { Count = 0 } },
{ "common_armor", new Equipment("가죽 갑옷", EquipmentType.Armor, EquipmentGrade.Common, 2, 30) { Count = 0 } },


// Rare (희귀)
{ "rare_sword", new Equipment("강철 검", EquipmentType.Weapon, EquipmentGrade.Rare, 5, 100) { Count = 0 } },
{ "rare_bow", new Equipment("정밀한 활", EquipmentType.Weapon, EquipmentGrade.Rare, 5, 100) { Count = 0 } },
{ "rare_wand", new Equipment("마법사의 지팡이", EquipmentType.Weapon, EquipmentGrade.Rare, 5, 100) { Count = 0 } },
{ "rare_armor", new Equipment("사슬 갑옷", EquipmentType.Armor, EquipmentGrade.Rare, 5, 100) { Count = 0 } },


// Unique (유일)
{ "unique_sword", new Equipment("기사단장의 검", EquipmentType.Weapon, EquipmentGrade.Unique, 8, 200) { Count = 0 } },
{ "unique_bow", new Equipment("숲지기의 활", EquipmentType.Weapon, EquipmentGrade.Unique, 8, 200) { Count = 0 } },
{ "unique_wand", new Equipment("마도사의 지팡이", EquipmentType.Weapon, EquipmentGrade.Unique, 8, 200) { Count = 0 } },
{ "unique_armor", new Equipment("거울 갑옷", EquipmentType.Armor, EquipmentGrade.Unique, 8, 200) { Count = 0 } },


// Legendary (전설)
{ "legendary_sword", new Equipment("천공의 검", EquipmentType.Weapon, EquipmentGrade.Legendary, 12, 300) { Count = 0 } },
{ "legendary_bow", new Equipment("폭풍의 활", EquipmentType.Weapon, EquipmentGrade.Legendary, 12, 300) { Count = 0 } },
{ "legendary_wand", new Equipment("마신의 지팡이", EquipmentType.Weapon, EquipmentGrade.Legendary, 12, 300) { Count = 0 } },
{ "legendary_armor", new Equipment("용의 비늘 갑옷", EquipmentType.Armor, EquipmentGrade.Legendary, 12, 300) { Count = 0 } },


// Mythic (신화)
{ "mythic_sword", new Equipment("용사의 검", EquipmentType.Weapon, EquipmentGrade.Mythic, 20, 0) { Count = 0 } },
{ "mythic_bow", new Equipment("용사의 활", EquipmentType.Weapon, EquipmentGrade.Mythic, 20, 0) { Count = 0 } },
{ "mythic_wand", new Equipment("용사의 지팡이", EquipmentType.Weapon, EquipmentGrade.Mythic, 20, 0) { Count = 0 } },
{ "mythic_armor", new Equipment("용사의 갑옷", EquipmentType.Armor, EquipmentGrade.Mythic, 20, 0) { Count = 0 } },


        };

        public void ShowItemInfo()
        {
            //?는 삼항 연산자니까 만약 IsEquipped라면 [E]를 출력하고, 아니면 공란으로 둔다 라는 의미가 된다.
            string mark = IsEquipped ? "[E]" : "   ";
            Console.WriteLine($"[{mark}{Grade}] {Name} - {Type} | +{StatPlus} | {Price} Gold | 보유 갯수 : {Count}");

        }
    }

    public class Potion
    {
        public string Name { get; set; }
        public PotionGrade Grade { get; set; }
        public int Price { get; set; }
                
        public Potion(string name, PotionGrade grade, int price)         
            {
            Name = name;
            Grade = grade;
            Price = price;
            }
        public int Count { get; set; }

        public static Dictionary<string, Potion> PotionList = new Dictionary<string, Potion>()
        {
            { "low_potion", new Potion("하급 포션", PotionGrade.Low, 30) { Count = 0 } },
            { "mid_potion", new Potion("중급 포션", PotionGrade.Mid, 50) { Count = 0 } },
            { "high_potion", new Potion("상급 포션", PotionGrade.High, 80) { Count = 0 } },
            { "max_potion", new Potion("최상급 포션", PotionGrade.Max, 0) { Count = 0 } }
        };

        public static double PotionHeal(PotionGrade grade)
        {
            switch (grade)
            {
                case PotionGrade.Low:
                    return 0.2;
                
                case PotionGrade.Mid:
                    return 0.4;
 
                case PotionGrade.High:
                    return 0.6;
               
                case PotionGrade.Max:
                    return 1.0;
                  
                default:
                    return 0.0;  
            }

            

        }
               
    }



}
