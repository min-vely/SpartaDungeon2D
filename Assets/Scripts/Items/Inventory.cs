using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using Unity.Jobs;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class Inventory : MonoBehaviour
{

    private Player player;
    public Image itemImage;
    public TextMeshProUGUI itemAmount;

    private void Start()
    {
        OnInventoryClick();
    }


    private void DisplayInventory()
    {

        




        //Console.ForegroundColor = ConsoleColor.Cyan;
        //Console.WriteLine("�κ��丮");
        //Console.ResetColor();
        //Console.WriteLine("���� ���� �������� ������ �� �ֽ��ϴ�.");
        //Console.WriteLine();
        //Console.ForegroundColor = ConsoleColor.Magenta;
        //Console.WriteLine("[������ ���]");
        //Console.ResetColor();

        //var table = new ConsoleTable("�����۸�", "ȿ��", "������ ����");

        //// ��� ������ ����� ǥ�� (���� ���� �����۰� �������� ������ ������)
        //for (int i = 0; i < Program.items.Count; i++)
        //{
        //    table.AddRow($"- {(Program.items[i].IsEquipped ? "[E]" : "")}{Program.items[i].ItemName}", $"{Program.items[i].AbilityName} +{Program.items[i].AbilityValue}", $"{Program.items[i].ItemInfo}");
        //}
        //table.Write();
        
    }


    private void OnInventoryClick()
    {
        // �ڽ� ������Ʈ �� �̸��� "ItemImage"�� �̹��� ã��
        Image[] childImages = GetComponentsInChildren<Image>(true);

        int setActiveCount = 0;

        foreach (Image childImage in childImages)
        {
            if (childImage.gameObject.name == "ItemImage" && childImage.gameObject.activeSelf)
            {
                // "ItemImage" �̸��� �̹����� Ȱ��ȭ�������� ���� ����
                setActiveCount++;
            }
        }

        itemAmount.text = setActiveCount.ToString() + " / 8";
        //Debug.Log($"�κ��丮�� ��� �ִ� ������ ����: {setActiveCount}");
    }





    //���� ���� ȭ��
    private void EquipItems()
    {


        //Console.ForegroundColor = ConsoleColor.Cyan;
        //Console.WriteLine("�κ��丮 - ���� ����");
        //Console.ResetColor();
        //Console.WriteLine("���� ���� �������� ������ �� �ֽ��ϴ�.");
        //Console.WriteLine();
        //Console.ForegroundColor = ConsoleColor.Magenta;
        //Console.WriteLine("[������ ���]");
        //Console.ResetColor();

        //var table = new ConsoleTable("�����۸�", "ȿ��", "������ ����");

        //// ���� ���� ������
        //for (int i = 0; i < Program.items.Count; i++)
        //{
        //    table.AddRow($"- {i + 1} {(Program.items[i].IsEquipped ? "[E]" : "")}{Program.items[i].ItemName}", $"{Program.items[i].AbilityName} +{Program.items[i].AbilityValue}", $"{Program.items[i].ItemInfo}");
        //}
        //table.Write();

        //Console.WriteLine();
        //Console.WriteLine("0. ������");
        //Console.WriteLine();
        //Console.ForegroundColor = ConsoleColor.Yellow;
        //Console.WriteLine("���Ͻô� �ൿ�� �Է����ּ���.");
        //Console.ResetColor();

        //int input = Program.CheckValidInput(0, Program.items.Count);

        //if (input == 0)
        //{
        //    Program.DisplayGameIntro();
        //    return;
        //}
        //// ����� �Է°����� 1�� ���� �������� �ε����� ��ȯ
        //int itemIndex = input - 1;
        //ItemEquipped(Program.equippedItems, itemIndex, Program.items[itemIndex]);
        //EquipItems();
    }

    //������ ������ ����Ʈ�� �߰�/����
    //private void ItemEquipped(List<int> equippedItems, int itemNum, Items item)
    //{
    //    List<Items> playerItems = player.GetPlayerItems();

    //    if (equippedItems.Contains(itemNum))
    //    {
    //        // �̹� �ش� �������� �����Ǿ� �ִ� ���, �������� ���� ����
    //        playerItems.IsEquipped = false;
    //        equippedItems.Remove(itemNum);
    //    }
    //    else
    //    {
    //        // �̹� ���� ������ �ɷ��� ���� �������� �����Ǿ� �ִ��� Ȯ��
    //        foreach (int equippedIndex in equippedItems)
    //        {
    //            Items equippedItem = playerItems[equippedIndex];
    //            if (equippedItem.AbilityName == item.AbilityName)
    //            {
    //                // �̹� �ش� ������ �ɷ��� ���� �������� �����Ǿ� �����Ƿ� ���� �Ұ�

    //                Console.WriteLine("�̹� ���� ������ �ɷ��� ���� �������� �����Ǿ� �ֽ��ϴ�. 2�� �� �κ��丮 ȭ������ ���ư��ϴ�.");

    //                return;
    //            }
    //        }
    //        playerItems.IsEquipped = true;
    //        equippedItems.Add(itemNum);
    //    }
    //}
}
