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

    private ItemEquip itemEquip;
    public TextMeshProUGUI jobTxt;
    public TextMeshProUGUI nameTxt;
    public TextMeshProUGUI lvTxt;
    public TextMeshProUGUI goldTxt;
    public TextMeshProUGUI attackTxt;
    public TextMeshProUGUI defenseTxt;
    public TextMeshProUGUI hpTxt;
    public TextMeshProUGUI criticalTxt;

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
        player = new Character("���", "������", 1, 47, 26, 595, 20, 15000);

        // ���� ������ 1 = �ε��� 0��!!!!!
        // �⺻ ���� ���� ������ ���� ����(�迭 -> ����Ʈ�� ����)
        items.Add(new Items("������ �𷡽ð�", "zhonya", "����", 45, "�� - ", 1500));
        items.Add(new Items("���μ��� �ݳ��", "guinsoo", "���ݷ�", 30, "AD��� �ʼ���", 1600));
        //items.Add(new Items("������ ���� ��", "���ݷ�", 40, "ü�� ��� ������", 1600));
        //items.Add(new Items("�μ��� ������ �հ�", "ü��", 250, "è�Ǿ� ��ȣ ȿ��", 1400));
        
        // ������ ������ ���� ����(�迭 -> ����Ʈ�� ����) 
        storeItems.Add(new StoreItems("����ƽ�� �ܰ�", "statikk", "ġ��Ÿ", 20, "��", 1500));
        storeItems.Add(new StoreItems("��ö����", "heartsteel", "ü��", 800, "��!", 1600));
        //storeItems.Add(new StoreItems("������ ������", "����", 60, "���� �̰� �� ��", 1600));
    }
    #endregion


    // ���º��� ȭ��
    private void DisplayMyInfo()
    {
        jobTxt.text = player.Job;
        nameTxt.text = player.Name;
        lvTxt.text = "Lv " + player.Level;
        goldTxt.text = player.Gold.ToString("N0");
    }

    private void panelStats()
    {
        attackTxt.text = "���ݷ� : " + player.Atk;
        defenseTxt.text = "���� : " + player.Def;
        hpTxt.text = "ü�� : " + player.Hp;
        criticalTxt.text = "ġ��Ÿ : " + player.Critical;
    }

    public List<Items> GetPlayerItems()
    {
        return items;
    }

    public List<StoreItems> GetStoreItems()
    {
        return storeItems;
    }

    public List<int> GetEquippedItems()
    {
        return equippedItems;
    }

    public List<int> GetBoughtItems()
    {
        return boughtItems;
    }

    // �������� ���� �ɷ�ġ�� ǥ���ϴ� �޼ҵ�
    public void DisplayCharacterStatus(int itemNum)
    {
        // ������ �������� �ϳ��� ���ٸ�
        if (equippedItems.Count == 0)
        {
            Debug.Log("������ �������� �����ϴ�");
        }
        // ������ �������� �ϳ� �̻� �����Ѵٸ�
        else
        {
            int bonusAtk = 0;
            int bonusDef = 0;
            int bonusHp = 0;
            int bonusCrit = 0;

            // ������ �ε����� ���� �������� ������
            Items equippedItem = items[itemNum];
            Debug.Log(equippedItem.ItemName);

            // ���������� ���� �ɷ�ġ�� ���
            if (equippedItem.AbilityName == "���ݷ�")
            {
                bonusAtk += equippedItem.AbilityValue;
                player.Atk += bonusAtk;
            }
            else if (equippedItem.AbilityName == "����")
            {
                bonusDef += equippedItem.AbilityValue;
                player.Def += bonusDef;
            }
            else if (equippedItem.AbilityName == "ü��")
            {
                bonusHp += equippedItem.AbilityValue;
                player.Hp += bonusHp;
            }
            else if (equippedItem.AbilityName == "ġ��Ÿ")
            {
                bonusCrit += equippedItem.AbilityValue;
                player.Critical += bonusCrit;
            }
            Debug.Log($"{bonusDef}��ŭ �ɷ�ġ ����");
            Debug.Log($"���� �� ������ {player.Def}");
            panelStats();
        }
    }

    // ���� ������ ���� �ɷ�ġ�� ǥ���ϴ� �޼ҵ�
    public void UnEquipCharacterStatus(int itemNum)
    {
        int bonusAtk = 0;
        int bonusDef = 0;
        int bonusHp = 0;
        int bonusCrit = 0;

        // ������ �ε����� ���� �������� ������
        Items equippedItem = items[itemNum];
        Debug.Log(equippedItem.ItemName);

        // ���������� ���� �ɷ�ġ�� ���
        if (equippedItem.AbilityName == "���ݷ�")
        {
            bonusAtk += equippedItem.AbilityValue;
            player.Atk -= bonusAtk;
        }
        else if (equippedItem.AbilityName == "����")
        {
            bonusDef += equippedItem.AbilityValue;
            player.Def -= bonusDef;
        }
        else if (equippedItem.AbilityName == "ü��")
        {
            bonusHp += equippedItem.AbilityValue;
            player.Hp -= bonusHp;
        }
        else if (equippedItem.AbilityName == "ġ��Ÿ")
        {
            bonusCrit += equippedItem.AbilityValue;
            player.Critical -= bonusCrit;
        }
        panelStats();
    }
}
