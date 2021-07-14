using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CanvasUpdater : MonoBehaviour
{
    [Header("References")]
    [SerializeField] Exerciser exerciser;
    [SerializeField] TMP_Text exerciseText;
    [SerializeField] TMP_Text repetitionText;
    [SerializeField] TMP_Text stageText;

    void Update()
    {
        // Stage
        if (exerciser.stage == 1)
            stageText.text = "Stand upright & notify";
        else if (exerciser.stage == 2)
            stageText.text = "begin leaning. notify when in discomfort";
        else if (exerciser.stage == 1)
            stageText.text = "continue leaning & nofity when in pain";

        // Repetition
        repetitionText.text = "Repetion #" + exerciser.repetition.ToString();

        // Exercise
        if (exerciser.exercise == 1)
            exerciseText.text = "Exercise: Forward lean";
        else if (exerciser.exercise == 2)
            exerciseText.text = "Exercise: Left lean";
        else if (exerciser.exercise == 3)
            exerciseText.text = "Exercise: Right lean";
        else
        {
            exerciseText.text = "Activity over" +  '\n' + " Thank you for your participation";
            repetitionText.text = "";
            stageText.text = "";
        }
    }
}
