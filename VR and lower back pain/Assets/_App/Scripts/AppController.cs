using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Moves the application through each stage
/// </summary>
public class AppController : MonoBehaviour
{
    [SerializeField] int stage = 0;
    [SerializeField] int stageDisplaying = 0;
    [SerializeField] GameObject[] controls;
    [SerializeField] GameObject[] introduction;
    [SerializeField] GameObject[] familiarization;
    [SerializeField] GameObject[] calibration;
    [SerializeField] GameObject[] calibration2;
    [SerializeField] GameObject[] prePainLog;
    [SerializeField] GameObject[] prePainLog2;
    [SerializeField] GameObject[] preExercise;
    [SerializeField] GameObject[] Exercise;
    [SerializeField] GameObject[] Exercise2;
    [SerializeField] GameObject[] postPainLog;
    [SerializeField] GameObject[] postPainLog2;
    [SerializeField] GameObject[] debrief;

    GameObject[][] stages = new GameObject[13][]; // Each stage of this application

    void Start()
    {
        //stages[0] = introduction;
        //stages[1] = familiarization;
        //stages[2] = calibration;
        //stages[3] = calibration2;
        //stages[4] = prePainLog;
        //stages[5] = prePainLog2;
        //stages[6] = preExercise;
        //stages[7] = Exercise;
        //stages[8] = Exercise2;
        //stages[9] = postPainLog;
        //stages[10] = postPainLog2;
        //stages[11] = debrief;

        stages[0] = controls;
        stages[1] = introduction;
        stages[2] = familiarization;
        stages[3] = calibration;
        stages[4] = calibration2;
        stages[5] = prePainLog;
        stages[6] = prePainLog2;
        stages[7] = preExercise;
        stages[8] = Exercise;
        stages[9] = Exercise2;
        stages[10] = postPainLog;
        stages[11] = postPainLog2;
        stages[12] = debrief;
        
        // Set all stages to inactive 
        for (int i = 0; i < stages.Length; i++)
            for (int j = 0; j < stages[i].Length; j++)
                stages[i][j].SetActive(false);

        // OLD can be removed
        // Set all of first stage to active;
        for (int i = 0; i < stages[0].Length; i++)
            stages[0][i].SetActive(true);
    }

    void Update()
    {
        // Developer means to increse stage
        if (Input.GetKeyDown(KeyCode.Space))
            IncreaseStage(1);
    }

    void updateDisplaying()
    {
        stageDisplaying = stage;

        // Set the previous stage inactive
        for (int i = 0; i < stages[stage-1].Length; i++)
            stages[stage-1][i].SetActive(false);

        // Set this stage active
        for (int i = 0; i < stages[stage].Length; i++)
            stages[stage][i].SetActive(true);
    }

    /// <summary>
    /// Increases the stage number of the application
    /// </summary>
    /// <param name="amount"> 1 for the next stage.</param>
    public void IncreaseStage(int amount)
    {
        stage += amount;

        if (stageDisplaying != stage && stage > 0)
            updateDisplaying();
    }
}
