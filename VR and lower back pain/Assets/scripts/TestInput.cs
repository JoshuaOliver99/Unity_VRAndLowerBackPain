using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestInput : MonoBehaviour
{
    public Slider green;
    public float test;
    public Slider testSlider;
    
    // Start is called before the first frame update
    void Start()
    {
        float value = testSlider.value;
        test = value;
    }

    // Update is called once per frame
    void Update()
    {
        test = testSlider.value;
        green.value = test;
    }
}
