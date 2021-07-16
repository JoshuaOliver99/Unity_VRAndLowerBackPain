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
    References references;
    [SerializeField] VRIK vrik; // NOTE: Make array to hold each models VRIK component
    [SerializeField] FollowHead followHead;
    
    [Header("Settings")]
    [SerializeField] int numRepetitions = 10;
    [SerializeField] int manipulatedRep = 5;

    [Header("Data - DEBUG")]
    public int Exercise = 1; // Movement direction (forward, lateral left, lateral right)
    public int Repetition = 1;
    public int Stage = 0; // Stage of repition (1 Moving to upright, 2 Moving to discomfort, 3 Moving to pain)
    public bool Manipulating;


    void Start()
    {
        if (!(references = GetComponent<References>()))
            Debug.LogError("References not retrieved");
    }

    void Update()
    {
        manipulator();

        if (Input.GetKeyDown(KeyCode.L) || SteamVR_Input.GetStateDown("PressTrackpad", references.leftHand))
            increaseStage();

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
    /// FollowHead.cs on start alligns the manipulated head into the correct position
    /// </summary>
    void followHeadEnabler()
    {
        if (followHead.enabled == false && Stage > 1)
            followHead.enabled = true;
    }
}
