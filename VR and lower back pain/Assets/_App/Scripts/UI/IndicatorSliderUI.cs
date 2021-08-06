using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class IndicatorSliderUI : MonoBehaviour
{
    [Header("Green Slider")]
    [SerializeField] Slider greenSlider;
    [SerializeField] int    greenActiveStage   = 1;
    [SerializeField] float  greenMax         = 10f; // (high to avoid complications)    
    [SerializeField] bool   greenAtMax        = false;

    [Header("Amber Slider")]
    [SerializeField] Slider amberSlider;
    [SerializeField] Slider amberMarker;
    [SerializeField] int    amberActiveStage   = 3;
    [SerializeField] float  amberMax         = 10f; // (high to avoid complications)    
    [SerializeField] bool   amberAtMax        = false;

    [Header("Red Slider")]
    [SerializeField] Slider redSlider;
    [SerializeField] Slider redMarker;
    [SerializeField] int    redActiveStage;
    [SerializeField] float  redMax           = 10f; // (high to avoid complications)    
    [SerializeField] bool   redAtMax          = false;

    [Header("References")]
    [SerializeField] References references;

    [Header("Data")]
    [SerializeField] int stage;
    [SerializeField] bool testing           = false;

    void Start()
    {
        if (references == null)
            references = GameObject.FindGameObjectWithTag("GameController").GetComponent<References>();
        if (references == null)
            Debug.Log("References.cs not found");

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

        slidersManager();
    }

    void slidersManager()
    {
        float bendAngle = references.ManipulatedFollowHead.getDegree();

        // ----- HANDLE STAGE CHANGES:
        if (stage != references.Exerciser.Stage)
        {
            if (stage == 1)
            {
                // Disable the markers:
                amberMarker.gameObject.SetActive(false);
                redMarker.gameObject.SetActive(false);
            }
            else if (stage == 2)
            {
                amberMarker.gameObject.SetActive(true);
                amberMarker.value = bendAngle; // Set red marker point

                greenSlider.value = bendAngle;
            }
            else if (stage == 3)
            {
                redSlider.value = 1f; // Red value is maxed...
                redMarker.gameObject.SetActive(true);
                redMarker.value = bendAngle; // Set red marker point

                amberSlider.value = bendAngle;
            }

            stage = references.Exerciser.Stage; // Update stage...
        }

        // ----- SET SLIDER MAX VALUES:
        if (references.Exerciser.Stage == 2)
        {  
            // Allow green to increase:
            greenMax = bendAngle;
            //greenSlider.value = bendAngle;
        }
        else if (references.Exerciser.Stage == 3)
        {
            // Allow amber to increase:
            amberMax = bendAngle;
            //amberSlider.value = bendAngle;
        }

        
        // ----- ALLOW SLIDER DECREASE :
        if (references.Exerciser.Stage != 1)
        {
            // GREEN:
            if (bendAngle <= greenMax)
            {
                greenAtMax = false;
                greenSlider.value = bendAngle;
            }
            else if (!greenAtMax)
            {
                greenAtMax = true;
                greenSlider.value = greenMax;
            }

            //  AMBER:
            if (bendAngle <= amberMax)
            {
                amberAtMax = false;
                amberSlider.value = bendAngle;
            }
            else if (!amberAtMax)
            {
                amberAtMax = true;
                amberSlider.value = amberMax;
            }

            // RED:
            if (bendAngle <= redMax)
            {
                redAtMax = false;
                redSlider.value = bendAngle;
            }
            else if (!greenAtMax)
            {
                redAtMax = true;
                redSlider.value = redMax;
            }

            // FORMAT:
            // If (input less than or equal to max)
                // change slider value...
            // Else if (input greater than max && and not set to max)
                // Ensure slider is at its max value...
        }
    }


}
