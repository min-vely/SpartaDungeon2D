using UnityEngine;
using UnityEngine.UI;

public class ActivePanels : MonoBehaviour
{
    public GameObject panel;
    public GameObject statusBtn;
    public GameObject inventoryBtn;
    public GameObject storeBtn;

    public void ActivatePanel()
    {
        panel.SetActive(true);
        ActiveBtns(true);
        //Time.timeScale = 0.0f;
    }

    public void DeactivatePanel()
    {
        panel.SetActive(false);
        ActiveBtns(false);
        //Time.timeScale = 1.0f;
    }

    private void ActiveBtns(bool isActive)
    {
        if (isActive)
        {
            // 버튼 비활성화
            statusBtn.SetActive(false);
            inventoryBtn.SetActive(false);
            storeBtn.SetActive(false);
        }
        else
        {
            statusBtn.SetActive(true);
            inventoryBtn.SetActive(true);
            storeBtn.SetActive(true);
        }
    }
}
