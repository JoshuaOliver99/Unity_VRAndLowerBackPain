using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class IndicatorTableUI : MonoBehaviour
{
    [Header("References")]
    [SerializeField] References references;
    [SerializeField] TMP_Text discomfortText;
    [SerializeField] TMP_Text painText;


    public void SetDiscomfortText(float input)
    {
        input *= 100;
        discomfortText.text = input.ToString("F2") + "°";
    }

    public void SetPainText(float input)
    {
        input *= 100;
        painText.text = input.ToString("F2") + "°";
    }

}
