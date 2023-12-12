using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using System;

public class ItemEquip : MonoBehaviour, IPointerClickHandler
{

    private Player player;
    public GameObject EquipItemPanel;
    public GameObject UnEquipItemPanel;
    public TextMeshProUGUI ItemInfo;

    private string sourceImageFileName;
    private int idx;
    private List<Items> playerItems;
    private List<int> equipItems;

    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        playerItems = player.GetPlayerItems();
        equipItems = player.GetEquippedItems();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        //Debug.Log("아이템 클릭");
        GetImageName();
    }

    private void GetImageName()
    {
        Image sourceImage = GetComponent<Image>();

        if (sourceImage != null)
        {
            sourceImageFileName = sourceImage.sprite.name;
            Debug.Log(sourceImageFileName);

            FindItem();
        }
        else
        {
            Debug.LogWarning("이미지 컴포넌트를 찾을 수 없습니다.");
        }
    }

    private void FindItem()
    {
        idx = 0;
        for (int i = 0; i < playerItems.Count; i++)
        {
            if (playerItems[i].FileName == sourceImageFileName)
            {
                idx = i;
                // 장착 여부에 따라 다른 판넬 띄우기
                if (!playerItems[i].IsEquipped)
                {
                    UnEquipItemPanel.SetActive(true);

                }
                else
                {
                    EquipItemPanel.SetActive(true);
                    ItemInfo.text = $"아이템 이름 : \n{playerItems[i].ItemName}\n아이템 설명 : \n{playerItems[i].ItemInfo}\n{playerItems[i].AbilityName} : {playerItems[i].AbilityValue}\n장착 완료";
                }
            }
        }
    }

    public void EquipItem()
    {
        ItemEquipped(equipItems, idx, playerItems[idx]);
        //EquipItemPanel.SetActive(false);
    }


    //장착한 아이템 리스트에 추가/삭제
    private void ItemEquipped(List<int> equippedItems, int itemNum, Items item)
    {
        if (equippedItems.Contains(itemNum))
        {
            // 이미 해당 아이템이 장착되어 있는 경우, 아이템을 장착 해제
            playerItems[idx].IsEquipped = false;
            Debug.Log("아이템 장착 해제");
            equippedItems.Remove(itemNum);
            player.UnEquipCharacterStatus(itemNum);
        }
        else
        {
            playerItems[idx].IsEquipped = true;
            Debug.Log("아이템 장착 완료");
            equippedItems.Add(itemNum);
            player.DisplayCharacterStatus(itemNum);
            Debug.Log(itemNum);
        }
    }
}