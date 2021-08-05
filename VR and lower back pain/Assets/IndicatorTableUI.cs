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
        discomfortText.text = ReturnToHundreths(input).ToString();
    }

    public void SetPainText(float input)
    {
        painText.text = ReturnToHundreths(input).ToString();
    }

    float ReturnToHundreths(float input)
    {
        // Return input rounded to two decimal places
        Debug.LogWarning("ReturnToHundreths() NOT IMPLEMENTED");
        return input;
    }
}
