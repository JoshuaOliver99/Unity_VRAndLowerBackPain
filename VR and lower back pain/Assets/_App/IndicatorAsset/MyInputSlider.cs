using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyInputSlider : MonoBehaviour
{
    References references;
    Slider slider;

    [SerializeField, Tooltip("Stage this slider fills for")] int ActiveStage;

    // TESTING ...
    //public float testInput = 0.0f;
    //public int testStage = 1;

    [SerializeField] float sliderMax = 10f; // (Initialised high max)    
    [SerializeField] bool atSliderMax = false;

    void Start()
    {
        if (references == null)
            references = GameObject.FindGameObjectWithTag("GameController").GetComponent<References>();
        if (references == null)
            Debug.Log("References.cs not found");

        slider = gameObject.GetComponent<Slider>();
    }

    void Update()
    {
        // DEBUG...
        Debug.Log("Stage " + references.Exerciser.Stage);



        // ---------- ACTUAL VERSION ----------
        // (in active stage)...
        if (references.Exerciser.Stage == ActiveStage)
        {
            Debug.Log(gameObject.name + " in active stage");
            sliderMax = references.ManipulatedFollowHead.getDegree(); // Allow max to change
        }
        


        // If (input less than or equal to max)...
        if (references.ManipulatedFollowHead.getDegree() <= sliderMax)
        {
            Debug.Log(gameObject.name + " slider can respond");

            // Allow the slider to respond to input...
            //atSliderMax = false; //                                               <<<<<<<<<<<<<<<< TEST DISABLE
            slider.value = references.ManipulatedFollowHead.getDegree();
        }
        // ELse if (input greater than max) && (atSliderMax not set)...
        else if (!atSliderMax)
        {
            Debug.Log(gameObject.name + " slider input greater than max value");

            // Ensure slider is at its max value...
            atSliderMax = true;
            slider.value = sliderMax;
        }



        // ---------- TESTING VERSION ----------
        //// (in active stage)...
        //if (testStage == ActiveStage)
        //    sliderMax = testInput;
        //
        //
        //// If (input less than max)...
        //if (testInput <= sliderMax)
        //{
        //    // Allow the slider to respond to input...
        //    atSliderMax = false;
        //    slider.value = testInput;
        //}
        //// ELse if (input greater than max) && (atSliderMax not set)...
        //else if (!atSliderMax)
        //{
        //    // Ensure slider is at its max value...
        //    atSliderMax = true;
        //    slider.value = sliderMax;
        //}

    }
}
