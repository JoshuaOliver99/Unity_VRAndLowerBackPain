using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyInputSlider : MonoBehaviour
{
    References references;
    [SerializeField, Tooltip("Max stage this slider fills for")] int maxActiveStage; 

    // public float inputSlider = 0.3f;
    public Slider Slider;
    float sliderMax;
    void Start()
    {
        if (references == null)
            references = GameObject.FindGameObjectWithTag("GameController").GetComponent<References>();
        if (references == null)
            Debug.Log("References.cs not found");

        Slider = gameObject.GetComponent<Slider>();
    }

    void Update()
    {
        // Get this sliders max value
        if (references.Exerciser.Stage > maxActiveStage)
            sliderMax = references.ManipulatedFollowHead.getDegree();
            
        // Update the slider if it's in range    
        if (references.Exerciser.Stage <= maxActiveStage    || Slider.value < sliderMax)
            Slider.value = references.ManipulatedFollowHead.getDegree(); // Update slider value



        
        //thisSlider.value = inputSlider;
        //Slider.value = references.ManipulatedFollowHead.getDegree();
    }
}
