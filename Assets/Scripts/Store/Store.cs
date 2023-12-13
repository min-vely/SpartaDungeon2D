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
        //Debug.Log("아이템 클릭");
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
            Debug.LogWarning("이미지 컴포넌트를 찾을 수 없습니다.");
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

    // 상점의 아이템 구매 화면
    private void BuyStore(List<int> boughtItems)
    {
        StoreItems selectedItem = storeItems[idx];

        // 이미 구매한 아이템인지 확인
        if (boughtItems.Contains(idx))
        {
            // 아이템 버튼 클릭 못하게 막기
            GetComponent<Button>().interactable = false;
            Debug.Log("이미 구매한 아이템입니다.");
        }
        // 보유 골드가 아이템 가격보다 적다면
        else if (player.Gold < selectedItem.Gold)
        {
            Debug.Log("보유 골드가 부족해요 ㅠㅅㅠ");
        }
        else
        {
            Debug.Log("구매 완료!");
            // 아이템 구매 시 골드 차감
            player.Gold -= selectedItem.Gold;
            boughtItems.Add(idx);

            // 구매한 아이템을 items 리스트에 추가
            Items purchasedItem = new Items(selectedItem.ItemName, selectedItem.FileName, selectedItem.AbilityName, selectedItem.AbilityValue, selectedItem.ItemInfo, selectedItem.Gold);
            playerItems.Add(purchasedItem);
        }
    }


    // 상점의 아이템 판매 화면
    void SellStore()
    {
        //Console.WriteLine("상점 - 아이템 판매");
        //Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
        //Console.WriteLine("[보유 골드]");
        //Console.WriteLine($"{player.Gold} G");
        //Console.WriteLine("[아이템 목록]");

        //var table = new ConsoleTable("아이템명", "효과", "아이템 설명", "판매 가격");

        //for (int i = 0; i < Program.items.Count; i++)
        //{
        //    // 아이템 판매 여부 확인
        //    if (!Program.soldItemsIndexes.Contains(i))
        //    {
        //        string priceOrSoldOut = (Program.items[i] != null) ? (Program.items[i].Gold * 85 / 100).ToString() : "판매완료"; // 아이템 가격의 85%
        //        table.AddRow($"- {i + 1} {Program.items[i].ItemName}", $"{Program.items[i].AbilityName} +{Program.items[i].AbilityValue}", $"{Program.items[i].ItemInfo}", priceOrSoldOut);
        //    }
        //}
        //table.Write();


        //Console.WriteLine("0. 나가기");
        //Console.WriteLine("원하시는 행동을 입력해주세요.");

        //int input = Program.CheckValidInput(0, Program.items.Count);

        //if (input == 0)
        //{
        //    Program.DisplayGameIntro();
        //    return;
        //}

        //int itemIndex = input - 1;

        //// 이미 판매한 아이템인지 확인
        //if (Program.soldItemsIndexes.Contains(itemIndex))
        //{
        //    Console.WriteLine("이미 판매한 아이템입니다. 2초 후 판매 창으로 돌아갑니다.");
        //    SellStore();
        //}
        //else
        //{
        //    // 아이템 판매 시 골드 얻음
        //    int sellPrice = Program.items[itemIndex].Gold * 85 / 100; // 아이템 가격의 85%
        //    player.Gold += sellPrice;

        //    // 판매된 아이템 인덱스를 저장
        //    //soldItemsIndexes.Add(itemIndex);

        //    // 'items' 목록과 관련된 리스트에서 아이템 삭제
        //    Program.items.RemoveAt(itemIndex);
        //    Program.equippedItems.Remove(itemIndex); // 장착한 아이템 목록에서도 삭제

        //    Console.WriteLine($"아이템 판매 완료! {sellPrice} G를 얻었습니다. 2초 후 판매 창으로 돌아갑니다.");
        //    SellStore();
        //}
    }
}