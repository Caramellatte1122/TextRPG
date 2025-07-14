using System;
using System.Formats.Asn1;
using System.Runtime.CompilerServices;

class TextRPG
{
    private List<Item> playerItem = new List<Item>();
    private List<Item> storeItem = new List<Item>();
    private int Lvl;
    private string Chad;
    private int attack;
    private int addAttack = 0;
    private int armor;
    private int addArmor = 0;
    private int health;
    private int addHealth = 0;
    private int gold;
    private int addGold = 0;

    public TextRPG(int Lvl, string Chad, int attack, int armor, int health, int gold)
    {
        this.Lvl = Lvl;
        this.Chad = Chad;
        this.attack = attack;
        this.armor = armor;
        this.health = health;
        this.gold = gold;
    }
    static void Main()
    {
        TextRPG newGame = new TextRPG(01, "전사", 10, 5, 100, 1500);
        newGame.StartGame();
    }

    private void StartGame()
    {
        AddStoreItem();
        while (true)
        {
            MainMenu();
            string input = GetPlayerInput();

            if (input == "0")
            {
                QuitGame();
                break;
            }

            else if (input == "1") ViewPlayerStat();

            else if (input == "2") OpenInventory();

            else if (input == "3") VisitStore();

            else PrintErrorMsg();
        }

    }

    private void MainMenu()
    {
        Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
        Console.WriteLine("이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.");
        Console.WriteLine();
        Console.WriteLine("1. 상태 보기");
        Console.WriteLine("2. 인벤토리");
        Console.WriteLine("3. 상점");
        Console.WriteLine();
        PrintInputMessage();
    }

    private void PrintInputMessage()
    {
        Console.WriteLine("원하시는 행동을 입력해주세요.");
        Console.WriteLine(">>");
        Console.WriteLine();
    }

    private string GetPlayerInput()
    {
        return Console.ReadLine();
    }

    private void ViewPlayerStat()
    {
        while (true)
        {
            Console.WriteLine("캐릭터 정보.");
            Console.WriteLine($"Lv. {Lvl}");
            Console.WriteLine($"Chad ({Chad})");
            Console.WriteLine($"공격력: {attack} + ({addAttack})");
            Console.WriteLine($"방어력: {armor} + ({addArmor})");
            Console.WriteLine($"체력: {health}");
            Console.WriteLine($"Gold: {gold} G");
            Console.WriteLine();
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
            PrintInputMessage();
            string input = GetPlayerInput();

            if (input == "0") return;

            else PrintErrorMsg();
        }
    }

    private void OpenInventory()
    {
        while (true)
        {
            Console.WriteLine("인벤토리.");
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
            Console.WriteLine();
            Console.WriteLine("[아이템 목록]");
            Console.WriteLine();
            Console.WriteLine("1. 장착 관리");
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
            PrintInputMessage();
            string input = GetPlayerInput();

            if (input == "1")
            {
                ManageItem();
            }

            else if (input == "0") return;

            else PrintErrorMsg();
        }
    }

    public class Item
    {
        public string name;
        public string info;
        public int effect;
        public int price;
        public string type;
        public bool isOwned = false;
        public bool isEquipped = false;

        public Item(string name, string info, int effect, int price, string type, bool isOwned, bool isEquipped)
        {
            this.name = name;
            this.info = info;
            this.effect = effect;
            this.price = price;
            this.type = type;
            this.isOwned = isOwned;
            this.isEquipped = isEquipped;
        }

        public Item(Item other) //복사 생성자
        {
            this.name = other.name;
            this.info = other.info;
            this.effect = other.effect;
            this.price = other.price;
            this.type = other.type;
            this.isOwned = true;
            this.isEquipped = false;
        }
    }

    private void AddStoreItem()
    {
        storeItem.Add(new Item("수련자 갑옷", "수련에 도움을 주는 갑옷입니다.", 5, 1000, "방어력", false, false));
        storeItem.Add(new Item("무쇠갑옷", "무쇠로 만들어져 튼튼한 갑옷입니다.", 9, 2000, "방어력", false, false)); 
        storeItem.Add(new Item("스파르타의 갑옷", "스파르타의 전사들이 사용했다는 전설의 갑옷입니다.", 15, 3500, "방어력", false, false));
        storeItem.Add(new Item("낡은 검", "쉽게 볼 수 있는 낡은 검 입니다.", 2, 600, "공격력",false, false));
        storeItem.Add(new Item("청동 도끼", "어디선가 사용됐던거 같은 도끼입니다.", 5, 1500, "공격력", false, false));
        storeItem.Add(new Item("스파르타의 창", "스파르타의 전사들이 사용했다는 전설의 창입니다.", 7, 3500, "공격력",false, false)); 
    }

    private void ManageItem()
    {
        while (true)
        {
            Console.WriteLine("인벤토리 - 장착관리");
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
            Console.WriteLine();
            Console.WriteLine("[아이템 목록]");

            if (playerItem.Count > 0)
            {
                for (int i = 0; i < playerItem.Count; i++)
                {
                    var item = playerItem[i];
                    var equip = item.isEquipped ? "[E]" : "";
                    Console.WriteLine($" -{i + 1} {item.name} {equip} | {item.type} + {item.effect} | {item.info}");
                }

                Console.WriteLine();
                Console.WriteLine("0. 나가기");
                Console.WriteLine();
                PrintInputMessage();
                string input = GetPlayerInput();

                if (input == "0") return;

                if (int.TryParse(input, out int index) && index >= 1 && index <= playerItem.Count)
                {
                    var item = playerItem[index - 1];

                    if (item.isEquipped == true)
                    {
                        item.isEquipped = false;

                        if (item.type == "공격력") addAttack -= item.effect;

                        else if (item.type == "방어력") addArmor -= item.effect;

                        Console.WriteLine($"{item.name} 장착 해제!");
                    }

                    else
                    {
                        item.isEquipped = true;

                        if (item.type == "공격력") addAttack += item.effect;

                        else if (item.type == "방어력") addArmor += item.effect;

                        Console.WriteLine($"{item.name} 장착 완료!");
                    }
                }
                else PrintErrorMsg();
            }

            else
            {
                Console.WriteLine("보유 중인 아이템이 없습니다.");
                Console.WriteLine();
                Console.WriteLine("0. 나가기");
                Console.WriteLine();
                PrintInputMessage();
                string input = GetPlayerInput();

                if (input == "0") return;

                else PrintErrorMsg();
            }
        }
    }

    private void VisitStore()
    {
        while (true)
        {
            Console.WriteLine("상점.");
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
            Console.WriteLine();
            Console.WriteLine("[보유 골드]");
            Console.WriteLine($"{gold} G");
            Console.WriteLine();
            Console.WriteLine("[아이템 목록]");

            for (int i = 0; i < storeItem.Count; i++)
            {
                var item = storeItem[i];
                var priceTag = item.isOwned ? "구매완료" : item.price + "G";
                Console.WriteLine($" - {i + 1}. {item.name} | {item.type} + {item.effect} | {item.info} | {priceTag}");
            }

            Console.WriteLine();
            Console.WriteLine("1. 아이템 구매");
            Console.WriteLine("0. 나가기");
            PrintInputMessage();
            string input = GetPlayerInput();

            if (input == "0") return;

            else if (int.TryParse(input, out int storeIndex) && storeIndex >= 1 && storeIndex <= storeItem.Count)
            {
                var purchaseItem = storeItem[storeIndex - 1];

                if (purchaseItem.isOwned) Console.WriteLine("이미 구매한 아이템입니다.");

                else if (gold < purchaseItem.price) Console.WriteLine("Gold 가 부족합니다.");

                else
                {
                    gold -= purchaseItem.price;
                    purchaseItem.isOwned = true;
                    playerItem.Add(new Item(purchaseItem)); //복사 생성자 호출
                    Console.WriteLine($"{purchaseItem.name} 구매 완료!");
                }
            }

            else PrintErrorMsg();
        }
    }

    private void QuitGame()
    {
        Console.WriteLine("게임 종료.");
    }

    private void PrintErrorMsg()
    {
        Console.WriteLine("잘못 입력했습니다. 다시 입력해 주세요.");
    }
}

