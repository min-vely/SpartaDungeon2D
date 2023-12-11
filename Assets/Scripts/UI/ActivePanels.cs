using UnityEngine;
using UnityEngine.UI;

public class ActivePanels : MonoBehaviour
{
    public GameObject panel;
    public GameObject statusBtn;
    public GameObject inventoryBtn;
    public GameObject storeBtn;
    public Image background;


    public void ActivatePanel()
    {
        panel.SetActive(true);
        SetBackgroundTransparency(true);
        //Time.timeScale = 0.0f;
    }

    public void DeactivatePanel()
    {
        panel.SetActive(false);
        SetBackgroundTransparency(false);
        //Time.timeScale = 1.0f;
    }

    private void SetBackgroundTransparency(bool isTransparent)
    {
        Color backgroundColor = background.color;

        if (isTransparent)
        {
            // ����� �ణ ������ ���������� ����
            backgroundColor = new Color(0, 0, 0, 0.5f);

            // ��ư ��Ȱ��ȭ
            statusBtn.SetActive(false);
            inventoryBtn.SetActive(false);
            storeBtn.SetActive(false);
        }
        else
        {
            // ��� �������
            backgroundColor = new Color(0, 0, 0, 0);

            statusBtn.SetActive(true);
            inventoryBtn.SetActive(true);
            storeBtn.SetActive(true);
        }

        background.color = backgroundColor;
    }
}
