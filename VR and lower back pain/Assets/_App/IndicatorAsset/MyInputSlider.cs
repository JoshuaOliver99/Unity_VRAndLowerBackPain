using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyInputSlider : MonoBehaviour
{
    public float inputSlider = 0.3f;
    public Slider thisSlider;
/*
    // Start is called before the first frame update
    void Start()
    {
        
    }
*/
    // Update is called once per frame
    void Update()
    {
        thisSlider.value = inputSlider;
    }
}
