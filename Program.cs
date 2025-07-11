using System;
using System.Runtime.CompilerServices;

class TextRPG
{
    private int Lvl;
    private string Chad;
    private int attack;
    private int armor;
    private int health;
    private int gold;

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
        while (true)
        {
            MainMenu();
            string input = GetPlayerInput();

            if (input == "0")
            {
                QuitGame();
                break;
            }

            else if (input == "1")
                {
                    ViewPlayerStat();
                }

            else if (input == "2")
            {
                OpenInventory();
            }

            else if (input == "3")
            {
                VisitStore();
            }

            else
            {
                PrintErrorMsg();
            }
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
            Console.WriteLine($"공격력: {attack}");
            Console.WriteLine($"방어력: {armor}");
            Console.WriteLine($"체력: {health}");
            Console.WriteLine($"Gold: {gold} G");
            Console.WriteLine();
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
            PrintInputMessage();
            string input = GetPlayerInput();

            if (input == "0")
            {
                return;
            }

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

            else if (input == "0")
            {
                return;
            }

            else PrintErrorMsg();
        }
    }

    private void ManageItem()
    {
        bool isEquipped1 = false;
        bool isEquipped2 = false;
        bool isEquipped3 = false;

        while (true)
        {
            Console.WriteLine("인벤토리 - 장착관리");
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
            Console.WriteLine();
            Console.WriteLine("[아이템 목록]");
            Console.WriteLine("- 1 [E]무쇠갑옷      | 방어력 +5 | 무쇠로 만들어져 튼튼한 갑옷입니다.");
            Console.WriteLine("- 2 [E]스파르타의 창  | 공격력 +7 | 스파르타의 전사들이 사용했다는 전설의 창입니다.");
            Console.WriteLine("- 3 낡은 검         | 공격력 +2 | 쉽게 볼 수 있는 낡은 검 입니다.");
            Console.WriteLine();
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
            PrintInputMessage();
            string input = GetPlayerInput();

            if (input == "1")
            {
                if (isEquipped1 == false)
                {
                    isEquipped1 = true;
                    armor += 5;
                    Console.WriteLine("방어력 + 5.");
                }
            }

            else if (input == "2")
            {
                if (isEquipped2 == false)
                {
                    isEquipped2 = true;
                    attack += 7;
                    Console.WriteLine("공격력 + 7.");
                }
            }

            else if (input == "3")
            {
                if (isEquipped3 == false)
                {
                    isEquipped3 = true;
                    attack += 2;
                    Console.WriteLine("공격력 + 2.");
                }
            }

            else if (input == "0")
            {
                return;
            }

            else PrintErrorMsg();
        }
    }

    private void VisitStore()
    {
        while (true)
        {

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