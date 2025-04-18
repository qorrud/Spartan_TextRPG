using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
     
        public static class ItemManager
        {
            // 무기 필터: 직업별 장착 가능한 무기 키워드
            private static Dictionary<Job, string> jobWeaponKeyword = new Dictionary<Job, string>()
        {
            { Job.Warrior, "sword" },
            { Job.Archer,  "bow" },
            { Job.Mage,    "wand" }
        };

            public static void UsePotion(Player player, Potion potion)
            {
                if (potion.Count <= 0)
                {
                    Console.WriteLine($"{potion.Name}이 없다!");
                    return;
                }

                if (player.HP == player.MaxHP && player.MP == player.MaxMP)
                {
                    Console.WriteLine("포션을 사용하기엔 너무 아깝다.");
                    return;
                }

                double rate = Potion.PotionHeal(potion.Grade);
                int healHP = (int)(rate * player.MaxHP);
                int healMP = (int)(rate * player.MaxMP);

                player.HP += healHP;
                player.MP += healMP;
                potion.Count--;

                Console.WriteLine($"{potion.Name}을 사용하여 HP {healHP}, MP {healMP} 회복!");
                Console.WriteLine($"현재 HP: {player.HP}/{player.MaxHP} | MP: {player.MP}/{player.MaxMP}");
            }

            public static void AddPotion(Player player, string key)
            {
                if (Potion.PotionList.ContainsKey(key))
                {
                    Potion potion = Potion.PotionList[key];

                    if (!player.PotionInventory.ContainsKey(key))
                        player.PotionInventory[key] = potion;

                    player.PotionInventory[key].Count++;
                    Console.WriteLine($"{potion.Name}을(를) 획득했습니다!");
                }
            }

            public static void AddEquipment(Player player, string key)
            {
                if (Equipment.EquipmentList.ContainsKey(key))
                {
                    Equipment item = Equipment.EquipmentList[key];

                    if (!player.EquipmentInventory.ContainsKey(key))
                        player.EquipmentInventory[key] = item;

                    player.EquipmentInventory[key].Count++;
                    Console.WriteLine($"{item.Name}을(를) 얻었다!");
                }
            }

        public static void EquipItem(Player player)
        {
            //List<string> 형태로 Key 목록을 저장해서 매핑할 것... 전부 딕셔너리로 짜놔서 어쩔수가 없다...
            //int index = 1을 통해 인벤토리에 있는 장비 목록에 번호를 붙임.
            Console.WriteLine("소유하고 있는 아이템");
            int index = 1;

            List<Equipment> selectableItems = new List<Equipment>();
            string keyword = jobWeaponKeyword[player.Job];

            //player.EquipmentInventory라는 딕셔너리를 하나씩 순회하면서, 각 요소를 entry라는 이름의 변수로 받아오는 반복문
            foreach (KeyValuePair<string, Equipment> entry in player.EquipmentInventory)
            {
                Equipment item = entry.Value;
                if (item.Count <= 0) continue;
                if (item.Type == EquipmentType.Weapon && !entry.Key.Contains(keyword)) continue;

                Console.WriteLine($"{index}. {(item.IsEquipped ? "[E]" : "   ")} {item.Name} (+{item.StatPlus})");
                selectableItems.Add(item);
                index++;
            }
            if (selectableItems.Count == 0)
            {
                Console.WriteLine("장착 가능한 아이템이 없습니다.");
                return;
            }

            Console.Write("장착할 아이템 번호를 입력하세요: ");
            string input = Console.ReadLine();
            if (int.TryParse(input, out int choice) && choice >= 1 && choice <= selectableItems.Count)
            {
                Equipment selectedItem = selectableItems[choice - 1];

                if (selectedItem.IsEquipped)
                {
                    Console.WriteLine($"{selectedItem.Name}은(는) 이미 장착 중입니다.");
                    return;
                }

                if (selectedItem.Type == EquipmentType.Weapon)
                {
                    if (player.EquippedWeapon != null)
                    {
                        player.Attack -= player.EquippedWeapon.StatPlus;
                        player.EquippedWeapon.IsEquipped = false;
                    }
                    player.EquippedWeapon = selectedItem;
                    player.Attack += selectedItem.StatPlus;
                }
                else if (selectedItem.Type == EquipmentType.Armor)
                {
                    if (player.EquippedArmor != null)
                    {
                        player.Defense -= player.EquippedArmor.StatPlus;
                        player.EquippedArmor.IsEquipped = false;
                    }
                    player.EquippedArmor = selectedItem;
                    player.Defense += selectedItem.StatPlus;
                }

                selectedItem.IsEquipped = true;
                Console.WriteLine($"{selectedItem.Name}을(를) 장착했습니다!");
            }
            else
            {
                Console.WriteLine("잘못된 입력입니다.");
            }
        }
           
           
        

        public static void ShowInventory(Player player)
            {
                Console.WriteLine("인벤토리");
                Console.WriteLine("\n보유 중인 아이템:");
           
                foreach (KeyValuePair<string, Equipment> item in player.EquipmentInventory)
                {
                    if (item.Value.Count > 0)
                    {
                        string mark = item.Value.IsEquipped ? "[E]" : "   ";
                        Console.WriteLine($"{mark}{item.Value.Name} (+{item.Value.StatPlus}) x{item.Value.Count}");
                    }
                }

                Console.WriteLine("\n포션:");
                foreach (KeyValuePair<string, Potion> potion in player.PotionInventory)
                {
                    if (potion.Value.Count > 0)
                    {
                        Console.WriteLine($"{potion.Value.Name} x{potion.Value.Count}");
                    }
                }

                Console.WriteLine("\n1. 장비 장착\n2. 포션 사용\n0. 나가기");
                Console.Write(">> 선택: ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        EquipItem(player); // 변수 명을 알아보기 쉽게, 지금은 player라고 해놔서 헷갈릴 수 있음.
                        break;
                    case "2":
                        Console.Write("사용할 포션 이름을 선택하세요");
                        string potionKey = Console.ReadLine();
                    //포션 선택 추가
                        Console.WriteLine("미구현 기능입니다.");
                        break;
                    case "0":
                        Console.WriteLine("메인 메뉴로 돌아갑니다.");
                        break;
                    default:
                        Console.WriteLine("잘못된 입력입니다.");
                        break;
                }
            }
        }
    }

