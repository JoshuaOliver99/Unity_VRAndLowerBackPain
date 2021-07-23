using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ExerciseUI : MonoBehaviour
{
    [Header("References")]
    [SerializeField] Exerciser exerciser;
    [SerializeField] TMP_Text exerciseText;

    void Update()
    {
        // ----- TEXT TO DISPLAY -----
        /*
        line 1:
        lateral flexion left
        lateral flexion right
        sagittal flexion
        sagittal extension

        line 2
        repetition X

        line 3
        Stand upright
        notify discomfort
        notify pain
         */


        //// Stage
        //if (exerciser.Stage == 1)
        //    stageText.text = "Stand upright & notify";
        //else if (exerciser.Stage == 2)
        //    stageText.text = "begin leaning. notify when in discomfort";
        //else if (exerciser.Stage == 1)
        //    stageText.text = "continue leaning & nofity when in pain";
        //
        //// Repetition
        //repetitionText.text = "Repetition #" + exerciser.Repetition.ToString();
        //
        //// Exercise
        //if (exerciser.Exercise == 1)
        //    exerciseText.text = "Exercise: Forward lean";
        //else if (exerciser.Exercise == 2)
        //    exerciseText.text = "Exercise: Left lean";
        //else if (exerciser.Exercise == 3)
        //    exerciseText.text = "Exercise: Right lean";
        //else
        //{
        //    exerciseText.text = "Activity over" +  '\n' + " Thank you for your participation";
        //    repetitionText.text = "";
        //    stageText.text = "";
        //}
    }
}
