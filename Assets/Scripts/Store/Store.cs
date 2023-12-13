using System.Numerics;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class Store : MonoBehaviour, IPointerClickHandler
{
    private Player player;
    private AddItem addItem;

    public TextMeshProUGUI ItemInfo;
    public TextMeshProUGUI goldTxt;
    public Image boughtImage;
    public Image buyItemPanel;
    public Image soldOutPanel;


    private string sourceImageFileName;
    private int idx;
    private List<StoreItems> storeItems;
    private List<Items> playerItems;
    private List<int> boughtItems;


    // 생성자를 이용하여 addItem 오브젝트를 받아옴
    public Store(AddItem addItem)
    {
        this.addItem = addItem;
    }

    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        addItem = new AddItem();
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
            //Debug.Log(sourceImageFileName);

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
            // 판매 완료 판넬
            soldOutPanel.gameObject.SetActive(true);
            
            // 아이템 버튼 클릭 못하게 막기
            GetComponent<Button>().interactable = false;
            Debug.Log("이미 구매한 아이템입니다.");
        }
        // 보유 골드가 아이템 가격보다 적다면
        else if (player.player.Gold < selectedItem.Gold)
        {
            Debug.Log("보유 골드가 부족해요 ㅠㅅㅠ");
        }
        else
        {
            Debug.Log("구매 완료!");
            // 아이템 구매 시 골드 차감
            player.player.Gold -= selectedItem.Gold;
            boughtItems.Add(idx);
            
            // 구매한 아이템을 items 리스트에 추가
            Items purchasedItem = new Items(selectedItem.ItemName, selectedItem.FileName, selectedItem.AbilityName, selectedItem.AbilityValue, selectedItem.ItemInfo, selectedItem.Gold);
            playerItems.Add(purchasedItem);
            
            UpdateGold();

            //Debug.Log(purchasedItem.FileName);
            addItem.LoadItemImage(purchasedItem.FileName);

            // 구매완료 판넬, 표시 띄우기
            buyItemPanel.gameObject.SetActive(true);
            boughtImage.gameObject.SetActive(true);
        }
    }

    private void UpdateGold()
    {
        goldTxt.text = player.player.Gold.ToString("N0");
    }
}