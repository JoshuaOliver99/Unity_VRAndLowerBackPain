using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MySetMin : MonoBehaviour
{
    References references;

    public float minSlider = 0.5f;
    public Slider thisSlider;

    void Start()
    {
        if (references == null)
            references = GameObject.FindGameObjectWithTag("GameController").GetComponent<References>();
        if (references == null)
            Debug.Log("References.cs not found");
    }


    void Update()
    {
        thisSlider.minValue = minSlider;
    }
}
