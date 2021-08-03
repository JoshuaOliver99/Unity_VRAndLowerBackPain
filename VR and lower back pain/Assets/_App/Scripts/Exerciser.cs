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
    public int Stage = 0; // Stage of repition (1 Moving to upright, 2 Moving to discomfort, 3 Moving to pain)
    public bool Manipulating;


    void Start()
    {
        if (references == null)
            Debug.LogError("References not retrieved");
    }

    void Update()
    {
        manipulator();

        if (Input.GetKeyDown(KeyCode.L) || SteamVR_Input.GetStateDown("GrabPinch", SteamVR_Input_Sources.LeftHand) || SteamVR_Input.GetStateDown("GrabPinch", SteamVR_Input_Sources.RightHand))
            increaseStage();

        exerciseUI.UpdateExerciseText();


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
        
        // -------------- TESTING -  Degree offset for setting indicator bar
        //GetDegreeOffset();
        //Debug.Log("degree offset " + references.ManipulatedFollowHead.getDegree());
        // ---------------------------

        
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
    /// FollowHead.cs on start alligns the manipulated head into the correct position
    /// </summary>
    void followHeadEnabler()
    {
        if (followHead.enabled == false && Stage > 1)
            followHead.enabled = true;
    }


    /// <summary>
    /// For repetiton 1 set the minimum and maximum
    /// </summary>
    //void GetDegreeOffset()
    //{
    //    if (Repetition == 1)
    //    {
    //        Debug.Log("degree offset " + references.ManipulatedFollowHead.getDegree());
    //
    //    }
    //
    //}

}
