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
        Debug.Log("LoadItemImage 실행");
        // InventoryCanvas 오브젝트 컴포넌트 가져오기
        Canvas inventoryCanvas = GetComponent<Canvas>();

        // InventoryCanvas의 모든 자식 오브젝트 검사
        foreach (Transform child in inventoryCanvas.transform)
        {
            if (child.name == "ItemEquip")
            {
                Image sourceImage = child.GetComponent<Image>();
                Debug.Log(sourceImage.sprite.name);
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
