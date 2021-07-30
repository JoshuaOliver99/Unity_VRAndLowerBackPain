using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MySetFillArea : MonoBehaviour
{
    References references;


    public float setLevelSlider;
    RectTransform rectTransform;
    public float value;


    void Start()
    {
        if (references == null)
            references = GameObject.FindGameObjectWithTag("GameController").GetComponent<References>();
        if (references == null)
            Debug.Log("References.cs not found");


        rectTransform = GetComponent<RectTransform>();

        //top = rectTransform.offsetMax;
        //bottom = rectTransform.offsetMin;
    }



    void Update()
    {
        value = setLevelSlider;
        rectTransform.offsetMin = new Vector2(0f, value * 200f);
        
    }
}
