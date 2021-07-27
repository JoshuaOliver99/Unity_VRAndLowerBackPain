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

    GameObject[][] stages = new GameObject[11][];

    void Start()
    {
        stages[0] = introduction;
        stages[1] = familiarization;
        stages[2] = calibration;
        stages[3] = calibration2;
        stages[4] = prePainLog;
        stages[5] = prePainLog2;
        stages[6] = preExercise;
        stages[7] = Exercise;
        stages[8] = Exercise2;
        stages[9] = postPainLog;
        stages[10] = postPainLog2;
        stages[11] = debrief;

        // Set all non current stages to inactive
        for (int i = 0; i < stages.Length; i++)
        {
            for (int j = 0; j < stages[i].Length; j++)
            {
                if (i != 0) // (not first stage)...
                    stages[i][j].SetActive(false);
            }
        }

        
    }

    void Update()
    {
        //if (stageDisplaying != stage && stage > 0)
        //    updateDisplaying();

        if (Input.GetKeyDown(KeyCode.Space))
            IncreaseStage(1);
    }

    void updateDisplaying()
    {
        stageDisplaying = stage;

        // Set the previous stage inactive
        for (int i = 0; i < stages[stage-1].Length; i++)
            stages[stage-1][i].SetActive(false);
        // NOTE: TESTING: Not tested (trying to disable all other stages)
        //for (int i = 0; i < stages[stage-1].Length; i++)
        //    stages[i][0].SetActive(false);

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
        stage =+ amount;

        if (stageDisplaying != stage && stage > 0)
            updateDisplaying();
    }
}
