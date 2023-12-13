using System.Numerics;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class Store : MonoBehaviour/*, IPointerClickHandler*/
{
    private Player player;
    public TextMeshProUGUI ItemInfo;

    private string sourceImageFileName;
    private int idx;
    private List<StoreItems> storeItems;

    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        storeItems = player.GetStoreItems();

        GetStoreItemName();
    }


    //public void OnPointerClick(PointerEventData eventData)
    //{
    //    //Debug.Log("������ Ŭ��");
    //    //GetStoreItemName();
    //}

    private void GetStoreItemName()
    {
        Image sourceImage = GetComponent<Image>();

        if (sourceImage != null)
        {
            sourceImageFileName = sourceImage.sprite.name;
            Debug.Log(sourceImageFileName);

            ShowItemInfo();
        }
        else
        {
            Debug.LogWarning("�̹��� ������Ʈ�� ã�� �� �����ϴ�.");
        }
    }

    private void ShowItemInfo()
    {
        idx = -1;
        for (int i = 0; i < storeItems.Count; i++)
        {
            if (storeItems[i].FileName == sourceImageFileName)
            {
                idx = i;
                ItemInfo.text = $"{storeItems[i].ItemName}, {storeItems[i].AbilityName} : {storeItems[i].AbilityValue}, {storeItems[i].Gold}G";
                break;
            }
            else
            {
                ItemInfo.text = "";
            }
        }
        Debug.Log(storeItems[idx].ItemName);
    }


    // ���� ȭ��
    public void DisplayStore()
    {
        //Console.WriteLine("����");
        //Console.WriteLine("�ʿ��� �������� ���� �� �ִ� �����Դϴ�.");
        //Console.WriteLine("[���� ���]");

        //Console.WriteLine($"{player.Gold} G");
        //Console.WriteLine("[������ ���]");

        //var table = new ConsoleTable("�����۸�", "ȿ��", "������ ����", "����");

        //for (int i = 0; i < Program.storeItems.Count; i++)
        //{
        //    // ������ ���� ���� Ȯ��
        //    string priceOrSoldOut = Program.boughtItems.Contains(i) ? "���ſϷ�" : $"{Program.storeItems[i].Gold}";
        //    table.AddRow($"- {Program.storeItems[i].ItemName}", $"{Program.storeItems[i].AbilityName} +{Program.storeItems[i].AbilityValue}", $"{Program.storeItems[i].ItemInfo}", priceOrSoldOut);
        //}
        //table.Write();

        //Console.WriteLine("1. ������ ����");
        //Console.WriteLine("2. ������ �Ǹ�");
        //Console.WriteLine("0. ������");
        //Console.WriteLine("���Ͻô� �ൿ�� �Է����ּ���.");

        //int input = Program.CheckValidInput(0, 2);
        //switch (input)
        //{
        //    case 0:
        //        Program.DisplayGameIntro();
        //        break;
        //    case 1:
        //        BuyStore(Program.boughtItems);
        //        break;
        //    case 2:
        //        SellStore();
        //        break;
        //}
    }

    // ������ ������ ���� ȭ��
    //void BuyStore(List<int> boughtItems)
    //{
    //    Console.WriteLine("���� - ������ ����");
    //    Console.WriteLine("�ʿ��� �������� ���� �� �ִ� �����Դϴ�.");
    //    Console.WriteLine("[���� ���]");
    //    Console.WriteLine($"{player.Gold} G");
    //    Console.WriteLine("[������ ���]");

    //    var table = new ConsoleTable("�����۸�", "ȿ��", "������ ����", "����");

    //    for (int i = 0; i < Program.storeItems.Count; i++)
    //    {
    //        // ������ ���� ���� Ȯ��
    //        string priceOrSoldOut = boughtItems.Contains(i) ? "���ſϷ�" : $"{Program.storeItems[i].Gold}";
    //        table.AddRow($"- {i + 1} {Program.storeItems[i].ItemName}", $"{Program.storeItems[i].AbilityName} +{Program.storeItems[i].AbilityValue}", $"{Program.storeItems[i].ItemInfo}", priceOrSoldOut);
    //    }
    //    table.Write();

    //    Console.WriteLine("0. ������");
    //    Console.WriteLine("���Ͻô� �ൿ�� �Է����ּ���.");

    //    int input = Program.CheckValidInput(0, Program.storeItems.Count);

    //    if (input == 0)
    //    {
    //        Program.DisplayGameIntro();
    //        return;
    //    }

    //    int itemIndex = input - 1;
    //    StoreItems selectedItem = Program.storeItems[itemIndex];

    //    // �̹� ������ ���������� Ȯ��
    //    if (boughtItems.Contains(itemIndex))
    //    {
    //        Console.ForegroundColor = ConsoleColor.DarkRed;
    //        Console.WriteLine("�̹� ������ �������Դϴ�. 2�� �� ���� â���� ���ư��ϴ�.");
    //        Console.ResetColor();
    //        Thread.Sleep(2000);
    //        Store(boughtItems);
    //    }
    //    // ���� ��尡 ������ ���ݺ��� ���ٸ�
    //    else if (player.Gold < selectedItem.Gold)
    //    {
    //        Console.ForegroundColor = ConsoleColor.DarkRed;
    //        Console.WriteLine("���� ��尡 �����ؿ� �Ф��� 2�� �� ���� â���� ���ư��ϴ�.");
    //        Console.ResetColor();
    //        Thread.Sleep(2000);
    //        Store(boughtItems);
    //    }
    //    else
    //    {
    //        Console.WriteLine("���� �Ϸ�! 2�� �� ���� â���� ���ư��ϴ�.");
    //        // ������ ���� �� ��� ����
    //        player.Gold -= selectedItem.Gold;
    //        boughtItems.Add(itemIndex);

    //        // ������ �������� items ����Ʈ�� �߰�
    //        Items purchasedItem = new Items(selectedItem.ItemName, selectedItem.AbilityName, selectedItem.AbilityValue, selectedItem.ItemInfo, selectedItem.Gold);
    //        Program.items.Add(purchasedItem);
    //        Thread.Sleep(2000);
    //        Store(boughtItems);
    //    }
    //}

    // ������ ������ �Ǹ� ȭ��
    void SellStore()
    {
        //Console.WriteLine("���� - ������ �Ǹ�");
        //Console.WriteLine("�ʿ��� �������� ���� �� �ִ� �����Դϴ�.");
        //Console.WriteLine("[���� ���]");
        //Console.WriteLine($"{player.Gold} G");
        //Console.WriteLine("[������ ���]");

        //var table = new ConsoleTable("�����۸�", "ȿ��", "������ ����", "�Ǹ� ����");

        //for (int i = 0; i < Program.items.Count; i++)
        //{
        //    // ������ �Ǹ� ���� Ȯ��
        //    if (!Program.soldItemsIndexes.Contains(i))
        //    {
        //        string priceOrSoldOut = (Program.items[i] != null) ? (Program.items[i].Gold * 85 / 100).ToString() : "�ǸſϷ�"; // ������ ������ 85%
        //        table.AddRow($"- {i + 1} {Program.items[i].ItemName}", $"{Program.items[i].AbilityName} +{Program.items[i].AbilityValue}", $"{Program.items[i].ItemInfo}", priceOrSoldOut);
        //    }
        //}
        //table.Write();


        //Console.WriteLine("0. ������");
        //Console.WriteLine("���Ͻô� �ൿ�� �Է����ּ���.");

        //int input = Program.CheckValidInput(0, Program.items.Count);

        //if (input == 0)
        //{
        //    Program.DisplayGameIntro();
        //    return;
        //}

        //int itemIndex = input - 1;

        //// �̹� �Ǹ��� ���������� Ȯ��
        //if (Program.soldItemsIndexes.Contains(itemIndex))
        //{
        //    Console.WriteLine("�̹� �Ǹ��� �������Դϴ�. 2�� �� �Ǹ� â���� ���ư��ϴ�.");
        //    SellStore();
        //}
        //else
        //{
        //    // ������ �Ǹ� �� ��� ����
        //    int sellPrice = Program.items[itemIndex].Gold * 85 / 100; // ������ ������ 85%
        //    player.Gold += sellPrice;

        //    // �Ǹŵ� ������ �ε����� ����
        //    //soldItemsIndexes.Add(itemIndex);

        //    // 'items' ��ϰ� ���õ� ����Ʈ���� ������ ����
        //    Program.items.RemoveAt(itemIndex);
        //    Program.equippedItems.Remove(itemIndex); // ������ ������ ��Ͽ����� ����

        //    Console.WriteLine($"������ �Ǹ� �Ϸ�! {sellPrice} G�� ������ϴ�. 2�� �� �Ǹ� â���� ���ư��ϴ�.");
        //    SellStore();
        //}
    }
}