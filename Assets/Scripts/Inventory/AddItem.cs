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
        Debug.Log($"LoadItemImage 실행");
        // InventoryCanvas 오브젝트의 Transform 컴포넌트 가져오기
        Transform inventoryCanvasTransform = GameObject.Find("InventoryCanvas").transform;

        // InventoryCanvas의 모든 자식 오브젝트 검사
        foreach (Transform child in inventoryCanvasTransform)
        {
            // 자식 오브젝트가 Image 컴포넌트를 가지고 있는지 확인
            Image imageComponent = child.GetComponent<Image>();

            if (imageComponent != null && child.name == "ItemEquip")
            {
                
                if (sourceImage.sprite == null)
                {
                    Debug.Log("이미지를 넣을 수 있음!");
                    string imagePath = $"Resources/{purchasedItemFileName}";
                    Sprite sprite = Resources.Load<Sprite>(imagePath);

                    if (sprite != null)
                    {
                        sourceImage.sprite = sprite;
                    }
                    else
                    {
                        Debug.LogWarning($"이미지를 찾을 수 없습니다: {imagePath}");
                    }
                }
            }
        }
    }
}
