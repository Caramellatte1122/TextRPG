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
        public bool isOwned = false;
        public bool isEquipped = false;

        public Item(string name, string info, int effect, int price, bool isOwned, bool isEquipped)
        {
            this.name = name;
            this.info = info;
            this.effect = effect;
            this.price = price;
            this.isOwned = isOwned;
            this.isEquipped = isEquipped;
        }
    }

    private void AddStoreItem()
    {
        storeItem.Add(new Item("수련자 갑옷", "수련에 도움을 주는 갑옷입니다.", 5, 1000, false, false));
        storeItem.Add(new Item("무쇠갑옷", "무쇠로 만들어져 튼튼한 갑옷입니다.", 9, 0, false, false)); //구매완료 = 0 G
        storeItem.Add(new Item("스파르타의 갑옷", "스파르타의 전사들이 사용했다는 전설의 갑옷입니다.", 15, 3500, false, false));
        storeItem.Add(new Item("낡은 검", "쉽게 볼 수 있는 낡은 검 입니다.", 2, 600, false, false));
        storeItem.Add(new Item("청동 도끼", "어디선가 사용됐던거 같은 도끼입니다.", 5, 1500, false, false));
        storeItem.Add(new Item("스파르타의 창", "스파르타의 전사들이 사용했다는 전설의 창입니다.", 7, 0, false, false)); //구매완료 = 0 G
    }

    private void ManageItem()
    {
        playerItem.Add(new Item("무쇠갑옷", "무쇠로 만들어져 튼튼한 갑옷입니다.", 5, 1000, true, false));
        playerItem.Add(new Item("스파르타의 창", "스파르타의 전사들이 사용했다는 전설의 창입니다.", 7, 0, true, false));
        playerItem.Add(new Item("낡은 검", "쉽게 볼 수 있는 낡은 검 입니다.", 2, 600, true, false));

        while (true)
        {
            Console.WriteLine("인벤토리 - 장착관리");
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
            Console.WriteLine();
            Console.WriteLine("[아이템 목록]");
            Console.WriteLine($"- 1 {(playerItem[1].isEquipped ? "[E]" : "")}{playerItem[1].name}      | 방어력 +{playerItem[1].effect} | {playerItem[1].info} ");
            Console.WriteLine($"- 2 {(playerItem[2].isEquipped ? "[E]" : "")}{playerItem[2].name}  | 공격력 +{playerItem[1].effect}  | {playerItem[1].info}");
            Console.WriteLine($"- 3 {(playerItem[3].isEquipped ? "[E]" : "")}{playerItem[3].name}         | 공격력 +{playerItem[1].effect}  | {playerItem[1].info}");
            Console.WriteLine();
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
            PrintInputMessage();
            string input = GetPlayerInput();

            if (input == "1")
            {
                if (playerItem[1].isEquipped == false)
                {
                    playerItem[1].isEquipped = true;
                    addArmor += playerItem[1].effect;
                    armor += addArmor;

                    Console.WriteLine("방어력 + 5.");
                }

                else
                {
                    playerItem[1].isEquipped = false;
                    armor -= addArmor;
                    addArmor -= playerItem[1].effect;
                    Console.WriteLine("방어력 - 5.");

                }
            }

            else if (input == "2")
            {
                if (playerItem[2].isEquipped == false)
                {
                    playerItem[2].isEquipped = true;
                    addAttack += playerItem[2].effect;
                    attack += addAttack;
                    Console.WriteLine("공격력 + 7.");
                }

                else
                {
                    playerItem[2].isEquipped = false;
                    attack -= addAttack;
                    addAttack -= playerItem[2].effect;
                    Console.WriteLine("방어력 - 7.");
                }
            }

            else if (input == "3")
            {
                if (playerItem[3].isEquipped == false)
                {
                    playerItem[3].isEquipped = true;
                    addAttack += playerItem[3].effect;
                    attack += addAttack;
                    Console.WriteLine("공격력 + 2.");
                }

                else
                {
                    playerItem[3].isEquipped = false;
                    attack -= addAttack;
                    addAttack -= playerItem[3].effect;
                    Console.WriteLine("방어력 - 2.");
                }
            }

            else if (input == "0") return;

            else PrintErrorMsg();
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
            Console.WriteLine($"- 1 {storeItem[1].name}    | 방어력 +{storeItem[1].effect}  | {storeItem[1].info}             |  {(storeItem[1].isOwned ? "판매완료" : storeItem[1].price)} G");
            Console.WriteLine($"- 2 {storeItem[2].name}      | 방어력 +{storeItem[2].effect} | {storeItem[2].info}           | {(storeItem[2].isOwned ? "판매완료" : storeItem[2].price)} G");
            Console.WriteLine($"- 3 {storeItem[3].name} | 방어력 +{storeItem[3].effect} | {storeItem[3].info}|  {(storeItem[3].isOwned ? "판매완료" : storeItem[3].price)} G");
            Console.WriteLine($"- 4 {storeItem[4].name}      | 공격력 +{storeItem[4].effect}  | {storeItem[4].info}            |  {(storeItem[4].isOwned ? "판매완료" : storeItem[4].price)} G");
            Console.WriteLine($"- 5 {storeItem[5].name}     | 공격력 +{storeItem[5].effect}  |  {storeItem[5].info}        |  {(storeItem[5].isOwned ? "판매완료" : storeItem[5].price)} G");
            Console.WriteLine($"- 6 {storeItem[6].name}  | 공격력 +{storeItem[6].effect}  | {storeItem[6].info} |  {(storeItem[6].isOwned ? "판매완료" : storeItem[6].price)} G");
            Console.WriteLine();
            Console.WriteLine("1. 아이템 구매");
            Console.WriteLine("0. 나가기");
            PrintInputMessage();
            string input = GetPlayerInput();

            if (input == "1")
            {
                if (playerItem[1].isOwned == true) Console.WriteLine("이미 구매한 아이템입니다.");

                if (gold < storeItem[1].price) Console.WriteLine("Gold 가 부족합니다.");

                if (playerItem[1].isOwned != true && gold > storeItem[1].price)
                {
                    playerItem.Add(new Item("수련자 갑옷", "수련에 도움을 주는 갑옷입니다.", 5, 1000, true, false));
                }
            }

            else if (input == "2")
            {

            }

            else if (input == "3")
            {

            }

            else if (input == "4")
            {

            }

            else if (input == "5")
            {

            }

            else if (input == "6")
            {

            }

            else if (input == "0") return;

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

