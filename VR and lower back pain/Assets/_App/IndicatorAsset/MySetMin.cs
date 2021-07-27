using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MySetMin : MonoBehaviour
{
    public float minSlider = 0.5f;
    public Slider thisSlider;
    /*
    Slider test;
    public float thisvalue = 0f;
    // Start is called before the first frame update
    void Start()
    {
        test = GetComponent<Slider>();
        //bottom = rectTransform.childCount;
        
        thisvalue = test.value;
    }
    */
    // Update is called once per frame
    void Update()
    {
        thisSlider.minValue = minSlider;
    }
}
