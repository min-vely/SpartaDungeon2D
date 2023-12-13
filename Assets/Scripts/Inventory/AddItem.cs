using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class AddItem : MonoBehaviour
{
    //private Image sourceImage;


    public void LoadItemImage(string purchasedItemFileName)
    {
        Debug.Log("LoadItemImage ����");
        // InventoryCanvas ������Ʈ ������Ʈ ��������
        Canvas inventoryCanvas = GetComponent<Canvas>();

        // InventoryCanvas�� ��� �ڽ� ������Ʈ �˻�
        foreach (Transform child in inventoryCanvas.transform)
        {
            if (child.name == "ItemEquip")
            {
                Image sourceImage = child.GetComponent<Image>();
                Debug.Log(sourceImage.sprite.name);
                if (sourceImage.sprite == null)
                {
                    Debug.Log("�̹����� ���� �� ����!");
                    string imagePath = $"Resources/{purchasedItemFileName}";
                    Sprite sprite = Resources.Load<Sprite>(imagePath);

                    if (sprite != null)
                    {
                        sourceImage.sprite = sprite;
                    }
                    else
                    {
                        Debug.LogWarning($"�̹����� ã�� �� �����ϴ�: {imagePath}");
                    }
                }
            }
        }
    }
}
