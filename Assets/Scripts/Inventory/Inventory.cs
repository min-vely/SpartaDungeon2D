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
    public Image itemImage;
    public TextMeshProUGUI itemAmount;

    private void Start()
    {
        OnInventoryClick();
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
}
