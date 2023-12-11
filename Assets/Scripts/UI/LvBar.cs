using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LvBar : MonoBehaviour
{
    Slider exp;
    float fSliderBarTime;
    void Start()
    {
        exp = GetComponent<Slider>();
    }


    void Update()
    {
        if (exp.value <= 0)
        {
            transform.Find("Fill Area").gameObject.SetActive(false);
        }
            
        else
        {
            transform.Find("Fill Area").gameObject.SetActive(true);
        }
            
    }
}
