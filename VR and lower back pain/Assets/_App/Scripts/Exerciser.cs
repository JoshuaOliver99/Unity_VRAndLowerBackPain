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


    void Start()
    {
        if (references == null)
            Debug.LogError("References not retrieved");
    }

    void Update()
    {
        manipulator();
        exerciseUI.UpdateExerciseText();

        if (Input.GetKeyDown(KeyCode.L) || SteamVR_Input.GetStateDown("GrabPinch", SteamVR_Input_Sources.LeftHand) || SteamVR_Input.GetStateDown("GrabPinch", SteamVR_Input_Sources.RightHand))
        {
            // TEST:
            // Resetting follow head scripts
            if (Stage == 1)
                zeroHeadDegree();
            // FAILED ^^^^ Does NOT zero the head positon



            // TEST:
            // FOR: IndicatorTableUI, Trying to set degree of movment Text
            if (Stage == 2) // (2 going to 3)
                references.IndicatorTableUI.SetDiscomfortText(getHeadAngle());
            if (Stage == 3) // (3 going to 1)
                references.IndicatorTableUI.SetPainText(getHeadAngle());

            increaseStage();
        }

        followHeadEnabler();
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

            // Disable the exerciser when 4 exercises completed
            if (Exercise > 4)
            {
                FindObjectOfType<AppController>().IncreaseStage(1);
                gameObject.GetComponent<Exerciser>().enabled = false;
            }
        }
        
    }

    void manipulator()
    {
        // If (in manipulated range     && in manipulated stage (standing upright)     && headTarget is not already manipulated position)...
        //OLD:  if (Repetition >= manipulatedRep    && Stage > 1    && vrik.solver.spine.headTarget != references.ManipulatedHead)
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

    /// <summary>
    /// Enables the FollowHead.cs script providing it is not enabled and the stage has been progressed once
    /// FollowHead.cs on Start() alligns the manipulated head into the correct position
    /// </summary>
    void followHeadEnabler()
    {
        if (followHead.enabled == false && Stage > 1)
            followHead.enabled = true;
    }
    // NOTE:
    // ^^^^^ DOES THIS EVEN WORK?


    void zeroHeadDegree()
    {
        // Reset/Zero the standing position
        // Maybe...
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
