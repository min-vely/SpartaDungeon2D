using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivePanel : MonoBehaviour
{
    public GameObject panel;

    public void Deactive()
    {
        panel.SetActive(false);
    }
}