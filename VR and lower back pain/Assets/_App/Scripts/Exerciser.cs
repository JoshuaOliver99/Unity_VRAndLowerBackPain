using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RootMotion.FinalIK;

/// <summary>
/// Cycles through each stage of the exercises. Exercise 1-3, for set repetitons of 3 stages each
/// Causes the avatar to switch between accurate and manipulated positions.
/// </summary>
public class Exerciser : MonoBehaviour
{
    [Header("References")]
    [SerializeField] raaTrackers raaTracker;
    [SerializeField] VRIK vrik;
    //[SerializeField] VRIK vrikMale;
    //[SerializeField] VRIK vrikFemale;

    [Header("Settings")]
    [SerializeField] int numRepetitions = 10;
    [SerializeField] int manipulatedRep = 5;

    [Header("Data")]
    public int exercise = 1; // Movement direction (forward, lateral)
    public int repetition = 1;
    public int stage = 1; // Stage of repition


    void Start()
    {
        raaTracker = GetComponent<raaTrackers>();
        if (raaTracker == null)
            Debug.LogError("Exerciser: raaTracker not assigned. Exerciser needs to be on same GameObject.");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
            increaseStage();

        manipulator();
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
        // If (in manipulated range     && headTarget is not manipulated position)...
        if (repetition >= manipulatedRep && vrik.solver.spine.headTarget != raaTracker.ManipulatedHead)
        {
            vrik.solver.spine.headTarget = raaTracker.ManipulatedHead;
        }
        // If (out manipulated range    && headTarget is not accurate positon)...
        else if (repetition < manipulatedRep && vrik.solver.spine.headTarget != raaTracker.OffsetTransformHead)
        {
            vrik.solver.spine.headTarget = raaTracker.OffsetTransformHead;
        }
    }
}
