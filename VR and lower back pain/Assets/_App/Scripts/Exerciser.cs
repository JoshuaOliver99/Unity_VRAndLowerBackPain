using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using RootMotion.FinalIK;

/// <summary>
/// Cycles through each stage of the exercises. Exercise 1-3, for a set number of repetitons of 3 stages each
/// Causes the avatar to switch between accurate and manipulated positions.
/// </summary>
public class Exerciser : MonoBehaviour
{
    [Header("References")]
    [SerializeField] References references;
    [SerializeField] VRIK vrik; // NOTE: Make array to hold each models VRIK component
    [SerializeField] FollowHead followHead;
    //[SerializeField] VRIK vrikMale;
    //[SerializeField] VRIK vrikFemale;

    [Header("Steam VR")]
    [SerializeField] SteamVR_Input_Sources leftHand;
    [SerializeField] SteamVR_Input_Sources rightHand;

    [Header("Settings")]
    [SerializeField] int numRepetitions = 10;
    [SerializeField] int manipulatedRep = 5;

    [Header("Data - DEBUG")]
    public int exercise = 1; // Movement direction (forward, lateral left, lateral right)
    public int repetition = 1;
    public int stage = 1; // Stage of repition (1 Moving to upright, 2 Moving to discomfort, 3 Moving to pain)


    void Start()
    {
        if (!(references = GetComponent<References>()))
            Debug.LogError("References not retrieved");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L) || SteamVR_Input.GetStateDown("PressTrackpad", leftHand))
            increaseStage();

        manipulator();

        followHeadEnabler();
    }

    void increaseStage()
    {
        stage++; // Increase stage

        // If (max stage)...
        if (stage > 3) 
        {
            stage = 1; // Reset stage
            repetition++; // Increase repetition

            // If (max repetition)...
            if (repetition > numRepetitions) 
            {
                repetition = 1; // Reset repetiton
                exercise++; // Increase exercise
            }
        }
    }

    void manipulator()
    {
        // If (in manipulated range     && in manipulated stage (standing upright)     && headTarget is not already manipulated position)...
        if (repetition >= manipulatedRep 
            && stage > 1
            && vrik.solver.spine.headTarget != references.ManipulatedHead)
        {
            vrik.solver.spine.headTarget = references.ManipulatedHead;
        }
        // If (out manipulated range    && headTarget is not already accurate positon)...
        else if (repetition < manipulatedRep 
            && vrik.solver.spine.headTarget != references.OffsetTransformHead)
        {
            vrik.solver.spine.headTarget = references.OffsetTransformHead;
        }
    }

    /// <summary>
    /// Enables the FollowHead.cs script providing it is not enabled and the stage has been progressed once
    /// FollowHead.cs on start alligns the manipulated head into the correct position
    /// </summary>
    void followHeadEnabler()
    {
        if (followHead.enabled == false && stage > 1)
            followHead.enabled = true;
    }
}
