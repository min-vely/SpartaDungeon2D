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
        //Console.WriteLine("인벤토리");
        //Console.ResetColor();
        //Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
        //Console.WriteLine();
        //Console.ForegroundColor = ConsoleColor.Magenta;
        //Console.WriteLine("[아이템 목록]");
        //Console.ResetColor();

        //var table = new ConsoleTable("아이템명", "효과", "아이템 설명");

        //// 모든 아이템 목록을 표시 (기존 보유 아이템과 상점에서 구매한 아이템)
        //for (int i = 0; i < Program.items.Count; i++)
        //{
        //    table.AddRow($"- {(Program.items[i].IsEquipped ? "[E]" : "")}{Program.items[i].ItemName}", $"{Program.items[i].AbilityName} +{Program.items[i].AbilityValue}", $"{Program.items[i].ItemInfo}");
        //}
        //table.Write();
        
    }


    private void OnInventoryClick()
    {
        // 자식 오브젝트 중 이름이 "ItemImage"인 이미지 찾기
        Image[] childImages = GetComponentsInChildren<Image>(true);

        int setActiveCount = 0;

        foreach (Image childImage in childImages)
        {
            if (childImage.gameObject.name == "ItemImage" && childImage.gameObject.activeSelf)
            {
                // "ItemImage" 이름의 이미지가 활성화돼있으면 개수 세기
                setActiveCount++;
            }
        }

        itemAmount.text = setActiveCount.ToString() + " / 8";
        //Debug.Log($"인벤토리에 들어 있는 아이템 개수: {setActiveCount}");
    }





    //장착 관리 화면
    private void EquipItems()
    {


        //Console.ForegroundColor = ConsoleColor.Cyan;
        //Console.WriteLine("인벤토리 - 장착 관리");
        //Console.ResetColor();
        //Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
        //Console.WriteLine();
        //Console.ForegroundColor = ConsoleColor.Magenta;
        //Console.WriteLine("[아이템 목록]");
        //Console.ResetColor();

        //var table = new ConsoleTable("아이템명", "효과", "아이템 설명");

        //// 기존 보유 아이템
        //for (int i = 0; i < Program.items.Count; i++)
        //{
        //    table.AddRow($"- {i + 1} {(Program.items[i].IsEquipped ? "[E]" : "")}{Program.items[i].ItemName}", $"{Program.items[i].AbilityName} +{Program.items[i].AbilityValue}", $"{Program.items[i].ItemInfo}");
        //}
        //table.Write();

        //Console.WriteLine();
        //Console.WriteLine("0. 나가기");
        //Console.WriteLine();
        //Console.ForegroundColor = ConsoleColor.Yellow;
        //Console.WriteLine("원하시는 행동을 입력해주세요.");
        //Console.ResetColor();

        //int input = Program.CheckValidInput(0, Program.items.Count);

        //if (input == 0)
        //{
        //    Program.DisplayGameIntro();
        //    return;
        //}
        //// 사용자 입력값에서 1을 뺴서 아이템의 인덱스로 변환
        //int itemIndex = input - 1;
        //ItemEquipped(Program.equippedItems, itemIndex, Program.items[itemIndex]);
        //EquipItems();
    }

    //장착한 아이템 리스트에 추가/삭제
    //private void ItemEquipped(List<int> equippedItems, int itemNum, Items item)
    //{
    //    List<Items> playerItems = player.GetPlayerItems();

    //    if (equippedItems.Contains(itemNum))
    //    {
    //        // 이미 해당 아이템이 장착되어 있는 경우, 아이템을 장착 해제
    //        playerItems.IsEquipped = false;
    //        equippedItems.Remove(itemNum);
    //    }
    //    else
    //    {
    //        // 이미 같은 종류의 능력을 가진 아이템이 장착되어 있는지 확인
    //        foreach (int equippedIndex in equippedItems)
    //        {
    //            Items equippedItem = playerItems[equippedIndex];
    //            if (equippedItem.AbilityName == item.AbilityName)
    //            {
    //                // 이미 해당 종류의 능력을 가진 아이템이 장착되어 있으므로 장착 불가

    //                Console.WriteLine("이미 같은 종류의 능력을 가진 아이템이 장착되어 있습니다. 2초 후 인벤토리 화면으로 돌아갑니다.");

    //                return;
    //            }
    //        }
    //        playerItems.IsEquipped = true;
    //        equippedItems.Add(itemNum);
    //    }
    //}
}
