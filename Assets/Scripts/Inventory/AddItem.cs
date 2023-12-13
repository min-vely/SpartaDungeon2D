using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class AddItem : MonoBehaviour
{
    private Image sourceImage;


    public void LoadItemImage(string purchasedItemFileName)
    {
        Debug.Log($"LoadItemImage ����");
        // InventoryCanvas ������Ʈ�� Transform ������Ʈ ��������
        Transform inventoryCanvasTransform = GameObject.Find("InventoryCanvas").transform;

        // InventoryCanvas�� ��� �ڽ� ������Ʈ �˻�
        foreach (Transform child in inventoryCanvasTransform)
        {
            // �ڽ� ������Ʈ�� Image ������Ʈ�� ������ �ִ��� Ȯ��
            Image imageComponent = child.GetComponent<Image>();

            if (imageComponent != null && child.name == "ItemEquip")
            {
                
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
