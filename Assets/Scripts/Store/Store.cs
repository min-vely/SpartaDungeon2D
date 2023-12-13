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


    // �����ڸ� �̿��Ͽ� addItem ������Ʈ�� �޾ƿ�
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
        //Debug.Log("������ Ŭ��");
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
            // �Ǹ� �Ϸ� �ǳ�
            soldOutPanel.gameObject.SetActive(true);
            
            // ������ ��ư Ŭ�� ���ϰ� ����
            GetComponent<Button>().interactable = false;
            Debug.Log("�̹� ������ �������Դϴ�.");
        }
        // ���� ��尡 ������ ���ݺ��� ���ٸ�
        else if (player.player.Gold < selectedItem.Gold)
        {
            Debug.Log("���� ��尡 �����ؿ� �Ф���");
        }
        else
        {
            Debug.Log("���� �Ϸ�!");
            // ������ ���� �� ��� ����
            player.player.Gold -= selectedItem.Gold;
            boughtItems.Add(idx);
            
            // ������ �������� items ����Ʈ�� �߰�
            Items purchasedItem = new Items(selectedItem.ItemName, selectedItem.FileName, selectedItem.AbilityName, selectedItem.AbilityValue, selectedItem.ItemInfo, selectedItem.Gold);
            playerItems.Add(purchasedItem);
            
            UpdateGold();

            //Debug.Log(purchasedItem.FileName);
            addItem.LoadItemImage(purchasedItem.FileName);

            // ���ſϷ� �ǳ�, ǥ�� ����
            buyItemPanel.gameObject.SetActive(true);
            boughtImage.gameObject.SetActive(true);
        }
    }

    private void UpdateGold()
    {
        goldTxt.text = player.player.Gold.ToString("N0");
    }
}