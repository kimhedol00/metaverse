using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG1
{
    enum ClassType
    {
        None = 0,
        Knight = 1,
        Archer = 2,
        Mage = 3
    }
    enum MonsterType
    {
        None = 0,
        Slime = 1,
        Orc = 2,
        Skeleton = 3
    }
    struct Player
    {
        public int hp;
        public int att;
    }
    struct Monster
    {
        public int hp;
        public int att;
    }
    class Program
    {
        static ClassType ChooseClass()
        {
            ClassType choice = ClassType.None;
            Console.WriteLine("직업을 선택하세요");
            Console.WriteLine("[1] 기사");
            Console.WriteLine("[2] 궁수");
            Console.WriteLine("[3] 법사");

            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    choice = ClassType.Knight;
                    break;
                case "2":
                    choice = ClassType.Archer;
                    break;
                case "3":
                    choice = ClassType.Mage;
                    break;

            }
            return choice;
        }
        static void CreatePlayer(ClassType choice, out Player player)
        {
            switch(choice)
            {
                case ClassType.Knight:
                    player.hp = 100;
                    player.att = 10;
                    break;
                case ClassType.Archer:
                    player.hp = 75;
                    player.att = 12;
                    break;
                case ClassType.Mage:
                    player.hp = 50;
                    player.att = 15;
                    break;
                default:
                    player.hp = 0;
                    player.att = 0;
                    break;
            }

        }

        static void CreateRandomMonster(out Monster monster)
        {
            Random rand = new Random();
            int randMonster = rand.Next(1, 4);
            switch (randMonster)
            {
                case (int)MonsterType.Slime:
                    Console.WriteLine("슬라임이 스폰되었습니다!");
                    monster.hp = 20;
                    monster.att = 2;
                    break;
                case (int)MonsterType.Orc:
                    Console.WriteLine("오크가 스폰되었습니다!");
                    monster.hp = 40;
                    monster.att = 4;
                    break;
                case (int)MonsterType.Skeleton:
                    Console.WriteLine("스켈레톤이 스폰되었습니다!");
                    monster.hp = 30;
                    monster.att = 3;
                    break;
                default:
                    monster.hp = 0;
                    monster.att = 0;
                    break;

            }
        }

        static void Fight(ref Player player, ref Monster monster)
        {
            while (true)
            {
                monster.hp -= player.att;
                if (monster.hp <= 0)
                {
                    Console.WriteLine("승리했습니다!");
                    Console.WriteLine($"남은 체력 : {player.hp}");
                    break;
                }
                player.hp -= monster.att;
                if (player.hp <= 0)
                {
                    Console.WriteLine("패배했습니다");
                    break;
                }
            }
            

        }
        static void EnterField(ref Player player)
        {
            while(true)
            {
                Console.WriteLine("필드에 접속했습니다!");
                Monster monster;
                CreateRandomMonster(out monster);
                Console.WriteLine("[1] 전투 모드로 돌입");
                Console.WriteLine("[2] 일정 확률로 마을로 도망");
                string input = Console.ReadLine();
                if (input == "1")
                {
                    Fight(ref player, ref monster);
                }
                else if (input == "2")
                {
                    Random rand = new Random();
                    int randValue = rand.Next(0, 101);
                    if (randValue <= 33)
                    {
                        Console.WriteLine("도망치는데 성공했습니다!");
                        break;
                    }
                    else
                    {
                        Fight(ref player, ref monster);
                    }
                }
            }
            

        }
        static void EnterGame(ref Player player)
        {
            while (true)
            {
                Console.WriteLine("마을에 접속했습니다!");
                Console.WriteLine("[1]필드로 간다");
                Console.WriteLine("[2] 로비로 돌아가기");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        EnterField(ref player);
                        break;
                    case "2":
                        return;
                }
            }
            

        }

        static void Main(string[] args)
        {
            while (true)
            {
                ClassType choice = ChooseClass();
                if (choice != ClassType.None)
                {
                    Player player;
                    CreatePlayer(choice, out player);

                    EnterGame(ref player);

                }
            }
            

        }
    }
}
