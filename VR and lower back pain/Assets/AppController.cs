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
    [SerializeField] GameObject[] painChart1;
    [SerializeField] GameObject[] Exercise;
    [SerializeField] GameObject[] painChart2;
    [SerializeField] GameObject[] debrief;

    GameObject[][] stages = new GameObject[6][];

    void Start()
    {
        stages[0] = introduction;
        stages[1] = familiarization;
        stages[2] = painChart1;
        stages[3] = Exercise;
        stages[4] = painChart2;
        stages[5] = debrief;

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
        if (stageDisplaying != stage && stage > 0)
            updateDisplaying();
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
}
