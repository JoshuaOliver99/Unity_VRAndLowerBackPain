using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyInputSlider : MonoBehaviour
{   
    [Header("References")]
    References references;
    Slider slider;

    [Header("Data")]
    [SerializeField, Tooltip("Stage this slider fills")] int ActiveStage;

    [Header("Debug Data...")]
    [SerializeField] float sliderMax = 10f; // (Initialised high max)    
    [SerializeField] bool atSliderMax = false;

    [Header("Testing...")]
    [SerializeField] bool testing = false;
    [SerializeField] float testInput = 0.0f;
    [SerializeField] int testStage = 1;

    void Start()
    {
        if (references == null)
            references = GameObject.FindGameObjectWithTag("GameController").GetComponent<References>();
        if (references == null)
            Debug.Log("References.cs not found");

        slider = gameObject.GetComponent<Slider>();

        // Decide if testing:
        if (references.DebugInput.DebugSliders)
            testing = true;
    }

    void Update()
    {
        // NOTES V1
        // 1 - pre exercise
        // pressing sets standing upright position (zeroing slider)
        // NO SLIDER SHOULD MOVE DURING THIS STAGE

        // 2 - moving to discomfort
        // pressing sets discomfort position

        // 3 - moving to pain
        // pressing sets pain positon



        // NOTES v2
        // nothing happens for 1

        // in 2 green bar is set, the marker on green is orange (to indicate where pain begins)

        // in 3 orange bar is set, the marker on orange is red (indicating the start of pain)
        // in 3 the remainder of the bar is coloured red



        // TEST:
        if (references.Exerciser.Stage > 1)
        {
            // Maybe run all in this? doesnt need to update on 1?

            // stage 1 sets the 0 positon?

            // stage 2 is indicated discomfort
            // stage 3 indicate pain
        }


        if (testing)
            testRunner();
        else
            runner();
    }

    void runner()
    {
        // ---------- ACTUAL VERSION ----------

        // (in active stage)...
        if (references.Exerciser.Stage <= ActiveStage)
        {
            sliderMax = references.ManipulatedFollowHead.getDegree(); // Allow max to change
        }

        // If (input less than or equal to max)...
        if (references.ManipulatedFollowHead.getDegree() <= sliderMax)
        {
            // Allow the slider to respond to input...
            atSliderMax = false; 
            slider.value = references.ManipulatedFollowHead.getDegree();
        }
        // ELse if (input greater than max) && (atSliderMax not set)...
        else if (!atSliderMax)
        {
            // Ensure slider is at its max value...
            atSliderMax = true;
            slider.value = sliderMax;
        }
    }

    void testRunner()
    {
        // ---------- TESTING VERSION ----------

        if (true)//(testStage > 1)
        {
            // Get global test input:
            testInput = references.DebugInput.HeadAngle;
            testStage = references.DebugInput.ActiveStage;


            // (in active stage)...
            if (testStage <= ActiveStage)
                sliderMax = testInput;


            // If (input less than max)...
            if (testInput <= sliderMax)
            {
                // Allow the slider to respond to input...
                atSliderMax = false;
                slider.value = testInput;
            }
            // ELse if (input greater than max) && (atSliderMax not set)...
            else if (!atSliderMax)
            {
                // Ensure slider is at its max value...
                atSliderMax = true;
                slider.value = sliderMax;
            }
            

        }
    }

}
