using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{

    public Character player;
    //public static StoreManager storeManager;
    //public static InventoryManager inventoryManager;
    //public static DungeonManager dungeonManager;

    #region Field

    // ������ ���� ���� ������ ����Ʈ
    private List<int> equippedItems = new List<int>();
    // ������ ���� ������ ����Ʈ
    private List<int> boughtItems = new List<int>();
    // ������ �Ǹ� ������ ����Ʈ
    private List<int> soldItems = new List<int>();
    // �������� �Ǹ��� �� �Ǹŵ� �������� ������ ����Ʈ
    private List<int> soldItemsIndexes = new List<int>();

    // ������ items �迭 ��� List<Items>�� ���
    private List<Items> items = new List<Items>();

    // ������ ������ ������ �迭 storeItems ��� ����Ʈ ���
    private List<StoreItems> storeItems = new List<StoreItems>();

    public TextMeshProUGUI job;
    public TextMeshProUGUI name;
    public TextMeshProUGUI lv;
    public TextMeshProUGUI gold;
    public TextMeshProUGUI attack;
    public TextMeshProUGUI defense;
    public TextMeshProUGUI hp;
    public TextMeshProUGUI critical;

    #endregion

    #region Init
    // ĳ����, �κ��丮 ������, ���� ������ ����
    private void Start()
    {
        GameDataSetting();
        //storeManager = new StoreManager(player);
        //inventoryManager = new InventoryManager();
        //dungeonManager = new DungeonManager(player);
        //DisplayGameIntro();
        DisplayMyInfo();
        panelStats();
    }

    private void GameDataSetting()
    {
        // ĳ���� ���� ����(�̸�, ����, ����, ���ݷ�, ����, ü��, ġ��Ÿ, ��)
        player = new Character("���", "������", 1, 47, 26, 595, 25, 15000);

        // ���� ������ 1 = �ε��� 0��!!!!!
        // �⺻ ���� ���� ������ ���� ����(�迭 -> ����Ʈ�� ����)
        items.Add(new Items("������ �𷡽ð�", "����", 45, "�� - ", 1500));
        items.Add(new Items("���μ��� �ݳ��", "���ݷ�", 30, "AD��� �ʼ���", 1600));
        items.Add(new Items("������ ���� ��", "���ݷ�", 40, "ü�� ��� ������", 1600));
        items.Add(new Items("�μ��� ������ �հ�", "ü��", 250, "è�Ǿ� ��ȣ ȿ��", 1400));

        // ������ ������ ���� ����(�迭 -> ����Ʈ�� ����) 
        storeItems.Add(new StoreItems("����ƽ�� �ܰ�", "���ݷ�", 50, "��", 1500));
        storeItems.Add(new StoreItems("��ö����", "ü��", 800, "��!", 1600));
        storeItems.Add(new StoreItems("������ ������", "����", 60, "���� �̰� �� ��", 1600));
    }
    #endregion

    // �ܼ� ���� �������� �ߴ� ȭ��
    public void DisplayGameIntro()
    {
        Console.WriteLine("1. ���º���");
        Console.WriteLine("2. �κ��丮");
        Console.WriteLine("3. ����");
        Console.WriteLine("4. ��������");
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("���Ͻô� �ൿ�� �Է����ּ���.");
        Console.ResetColor();

        int input = CheckValidInput(1, 4);
        switch (input)
        {
            case 1:
                DisplayMyInfo();
                break;
            //case 2:
            //    inventoryManager.DisplayInventory();
            //    break;
            //case 3:
            //    storeManager.DisplayStore();
            //    break;
            //case 4:
            //    dungeonManager.DisplayDungeon();
            //    break;
        }
    }

    // ���º��� ȭ��
    private void DisplayMyInfo()
    {
        job.text = player.Job;
        name.text = player.Name;
        lv.text = "Lv " + player.Level;
        gold.text = player.Gold.ToString("N0");


        //Console.WriteLine("���º���");
        //Console.ResetColor();
        //Console.WriteLine("ĳ������ ������ ǥ���մϴ�.");
        //Console.WriteLine();

        //Console.WriteLine();

        //Console.WriteLine($"Lv. {player.Level}");
        //Console.WriteLine($"{player.Name} ( {player.Job} )");

        //DisplayCharacterStatus();

        //Console.WriteLine($"Gold : {player.Gold} G");
        //Console.WriteLine();
        //Console.WriteLine("0. ������");
        //Console.WriteLine();
        //Console.ForegroundColor = ConsoleColor.Yellow;
        //Console.WriteLine("���Ͻô� �ൿ�� �Է����ּ���");
        //Console.ResetColor();

        //int input = CheckValidInput(0, 0);
        //switch (input)
        //{
        //    case 0:
        //        DisplayGameIntro();
        //        break;
        //}
    }

    private void panelStats()
    {
        attack.text = "���ݷ� : " + player.Atk;
        defense.text = "���� : " + player.Def;
        hp.text = "ü�� : " + player.Hp;
        critical.text = "ġ��Ÿ : " + player.Critical;
    }

    // ĳ���� �ɷ�ġ�� ǥ���ϴ� �޼ҵ�
    void DisplayCharacterStatus()
    {
        // ������ �������� �ϳ��� ���ٸ�
        if (equippedItems.Count == 0)
        {
            // �⺻ �ɷ�ġ ���
            Console.WriteLine($"���ݷ� : {player.Atk}");
            Console.WriteLine($"���� : {player.Def}");
            Console.WriteLine($"ü�� : {player.Hp}");
        }
        // ������ �������� �ϳ� �̻� �����Ѵٸ�
        else
        {
            int bonusAtk = 0;
            int bonusDef = 0;
            int bonusHp = 0;

            // ������ ������ ����Ʈ�� 1~4���� �� �ִٸ�
            foreach (int itemIndex in equippedItems)
            {
                // ������ �ε����� ���� �������� ������
                Items equippedItem = items[itemIndex];

                // ���������� ���� �ɷ�ġ�� ���
                if (equippedItem.AbilityName == "���ݷ�")
                {
                    bonusAtk += equippedItem.AbilityValue;
                }
                else if (equippedItem.AbilityName == "����")
                {
                    bonusDef += equippedItem.AbilityValue;
                }
                else if (equippedItem.AbilityName == "ü��")
                {
                    bonusHp += equippedItem.AbilityValue;
                }
            }

            // ���������� ���� �ɷ�ġ�� 0���� ū ��쿡�� ǥ��
            DisplayBonusStat("���ݷ�", bonusAtk);
            DisplayBonusStat("����", bonusDef);
            DisplayBonusStat("ü��", bonusHp);
        }
    }

    // ���������� ���� �ɷ�ġ�� ǥ���ϴ� �޼ҵ�
    void DisplayBonusStat(string statName, int bonusValue)
    {
        // ���������� ���� �ɷ�ġ�� 0���� ū ��쿡�� ǥ��
        if (bonusValue > 0)
        {
            Console.WriteLine($"{statName} : {GetPlayerStatValue(statName) + bonusValue} (+{bonusValue})");
        }
        else
        {
            Console.WriteLine($"{statName} : {GetPlayerStatValue(statName)}");
        }
    }

    // ĳ������ Ư�� ���� ���� �������� �޼ҵ�
    int GetPlayerStatValue(string statName)
    {
        switch (statName)
        {
            case "���ݷ�":
                return player.Atk;
            case "����":
                return player.Def;
            case "ü��":
                return player.Hp;
            default:
                return 0;
        }
    }

    // ������� �ܼ�â �Է� �� ����ó��
    public int CheckValidInput(int min, int max)
    {
        while (true)
        {
            string input = Console.ReadLine();

            bool parseSuccess = int.TryParse(input, out var ret);
            if (parseSuccess)
            {
                if (ret >= min && ret <= max)
                    return ret;
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("     ���������������������������������������ѣ�");
            Console.WriteLine("     ���߸��� �Է��Դϴ�. �ٽ� �Է��� �ּ���.��");
            Console.WriteLine("     ��^Y^Y^Y^Y^Y^Y^Y^Y^Y^Y^Y^Y^Y^Y^Y^Y^Y^Y^Y��");
            Console.ResetColor();
            Console.WriteLine();
        }
    }
}
