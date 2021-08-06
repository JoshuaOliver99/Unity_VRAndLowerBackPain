using RootMotion.FinalIK;
using UnityEngine;
using Valve.VR;

/// <summary>
/// Cycles through each stage of the exercises. Exercise 1-3, for a set number of repetitons of 3 stages each
/// Causes the avatar to switch between accurate and manipulated positions.
/// </summary>
public class Exerciser : MonoBehaviour
{
    [Header("References")]
    [SerializeField] References references;
    [SerializeField] VRIK vrik; // NOTE: Maybe make array to hold each models VRIK component
    [SerializeField] FollowHead followHead;
    [SerializeField] ExerciseUI exerciseUI;
    
    [Header("Settings")]
    [SerializeField] int numRepetitions = 10;
    [SerializeField] int manipulatedRep = 5;

    [Header("Data (do not change)")]
    public int Exercise = 1; // Movement direction (left, right, forward, back)
    public int Repetition = 1;
    public int Stage = 1; // Stage of repition (1 Moving to upright, 2 Moving to discomfort, 3 Moving to pain)
    public bool Manipulating;


    void OnEnable()
    {
        if (references == null)
            Debug.LogError("References not retrieved");

        exerciseUI.UpdateExerciseText();
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.L) || SteamVR_Input.GetStateDown("GrabPinch", SteamVR_Input_Sources.LeftHand) || SteamVR_Input.GetStateDown("GrabPinch", SteamVR_Input_Sources.RightHand))
        {
            // TEST:
            // Reset the standing head position


            //if (Stage == 1)
            //    zeroHeadDegree();
            // FAILED ^^^^ Does NOT zero the head positon



            // TEST:
            // FOR: IndicatorTableUI, Trying to set degree of movment Text
            if (Stage == 2) // (2 going to 3)
                references.IndicatorTableUI.SetDiscomfortText(getHeadAngle());
            if (Stage == 3) // (3 going to 1)
                references.IndicatorTableUI.SetPainText(getHeadAngle());

            increaseStage(); // Increase the stage...
            exerciseUI.UpdateExerciseText(); // Update UI...

            // TEST:
            // (was at the start of update)
            manipulator();
        }

    }

    void increaseStage()
    {
        Stage++; // Increase stage

        // If (max stage)...
        if (Stage > 3) 
        {
            Stage = 1; // Reset stage
            Repetition++; // Increase repetition

            // If (max repetition)...
            if (Repetition > numRepetitions) 
            {
                Repetition = 1; // Reset repetiton
                Exercise++; // Increase exercise
            }

            if (Exercise > 4)
            {
                FindObjectOfType<AppController>().IncreaseStage(1); // Move onto next stage of app...
                gameObject.GetComponent<Exerciser>().enabled = false; // Disable the exerciser...
            }
        }
        
    }

    void manipulator()
    {
        // If (in manipulated range     && in manipulated stage (standing upright)     && headTarget is not already manipulated position)...
        if (Repetition >= manipulatedRep && vrik.solver.spine.headTarget != references.ManipulatedHead)
        {
            Manipulating = true;
            vrik.solver.spine.headTarget = references.ManipulatedHead;
        }
        // If (out manipulated range    && headTarget is not already accurate positon)...
        else if (Repetition < manipulatedRep    && vrik.solver.spine.headTarget != references.OffsetTransformHead)
        {
            Manipulating = false;
            vrik.solver.spine.headTarget = references.OffsetTransformHead;
        }
    }

    void zeroHeadDegree()
    {
        // NOTE:
        // Does not work!

        // Reset/Zero the standing position
        // (Maybe...?)
        references.ActualFollowHead.alignToPoint1();
        references.ManipulatedFollowHead.alignToPoint1();
    }



    float getHeadAngle()
    {
        if (Manipulating)
            return references.ManipulatedFollowHead.getDegree();
        else
            return references.ActualFollowHead.getDegree();
    }
}
