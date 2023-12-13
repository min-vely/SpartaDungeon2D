using System.Numerics;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class Store : MonoBehaviour, IPointerClickHandler
{
    private Player player;
    public TextMeshProUGUI ItemInfo;

    private string sourceImageFileName;
    private int idx;
    private List<StoreItems> storeItems;
    private List<Items> playerItems;
    private List<int> boughtItems;


    //public Store(Character player)
    //{
    //    this.player = player;
    //}

    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        storeItems = player.GetStoreItems();
        playerItems = player.GetPlayerItems();
        boughtItems = player.GetBoughtItems();
        GetStoreItemName();
    }


    public void OnPointerClick(PointerEventData eventData)
    {
        //Debug.Log("������ Ŭ��");
        BuyStore(boughtItems);
    }

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
        //Debug.Log(storeItems[idx].ItemName);
    }

    // ������ ������ ���� ȭ��
    private void BuyStore(List<int> boughtItems)
    {
        StoreItems selectedItem = storeItems[idx];

        // �̹� ������ ���������� Ȯ��
        if (boughtItems.Contains(idx))
        {
            // ������ ��ư Ŭ�� ���ϰ� ����
            GetComponent<Button>().interactable = false;
            Debug.Log("�̹� ������ �������Դϴ�.");
        }
        // ���� ��尡 ������ ���ݺ��� ���ٸ�
        else if (player.Gold < selectedItem.Gold)
        {
            Debug.Log("���� ��尡 �����ؿ� �Ф���");
        }
        else
        {
            Debug.Log("���� �Ϸ�!");
            // ������ ���� �� ��� ����
            player.Gold -= selectedItem.Gold;
            boughtItems.Add(idx);

            // ������ �������� items ����Ʈ�� �߰�
            Items purchasedItem = new Items(selectedItem.ItemName, selectedItem.FileName, selectedItem.AbilityName, selectedItem.AbilityValue, selectedItem.ItemInfo, selectedItem.Gold);
            playerItems.Add(purchasedItem);
        }
    }


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