using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MySetFillArea : MonoBehaviour
{
    public float setLevelSlider;
    RectTransform rectTransform;
    public float value;
    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();

        //top = rectTransform.offsetMax;
        //bottom = rectTransform.offsetMin;
    }

    // Update is called once per frame
    void Update()
    {
        value = setLevelSlider;
        rectTransform.offsetMin = new Vector2(0f, value * 200f);
        
    }
}
