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
}
