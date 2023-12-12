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
        //Debug.Log("������ Ŭ��");
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
            Debug.LogWarning("�̹��� ������Ʈ�� ã�� �� �����ϴ�.");
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
                // ���� ���ο� ���� �ٸ� �ǳ� ����
                if (!playerItems[i].IsEquipped)
                {
                    UnEquipItemPanel.SetActive(true);

                }
                else
                {
                    EquipItemPanel.SetActive(true);
                    ItemInfo.text = $"������ �̸� : \n{playerItems[i].ItemName}\n������ ���� : \n{playerItems[i].ItemInfo}\n{playerItems[i].AbilityName} : {playerItems[i].AbilityValue}\n���� �Ϸ�";
                }
            }
        }
    }

    public void EquipItem()
    {
        ItemEquipped(equipItems, idx, playerItems[idx]);
        //EquipItemPanel.SetActive(false);
    }


    //������ ������ ����Ʈ�� �߰�/����
    private void ItemEquipped(List<int> equippedItems, int itemNum, Items item)
    {
        if (equippedItems.Contains(itemNum))
        {
            // �̹� �ش� �������� �����Ǿ� �ִ� ���, �������� ���� ����
            playerItems[idx].IsEquipped = false;
            Debug.Log("������ ���� ����");
            equippedItems.Remove(itemNum);
            player.UnEquipCharacterStatus(itemNum);
        }
        else
        {
            playerItems[idx].IsEquipped = true;
            Debug.Log("������ ���� �Ϸ�");
            equippedItems.Add(itemNum);
            player.DisplayCharacterStatus(itemNum);
            Debug.Log(itemNum);
        }
    }
}