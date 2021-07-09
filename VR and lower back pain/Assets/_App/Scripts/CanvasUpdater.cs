using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CanvasUpdater : MonoBehaviour
{
    [Header("References")]
    Exerciser exerciser;
    Text exercise;
    Text repetition;
    Text stage;

    void Update()
    {
        // Stage
        if (exerciser.stage == 1)
            stage.text = "Stand upright & notify";
        else if (exerciser.stage == 2)
            stage.text = "begin leaning & notify when in discomfort";
        else if (exerciser.stage == 1)
            stage.text = "continue leaning & nofity when in pain";

        // Repetition
        repetition.text = "Repetion #" + exerciser.repetition.ToString();

        // Exercise
        if (exerciser.exercise == 1)
            exercise.text = "Exercise: Forward lean";
        else if (exerciser.exercise == 2)
            exercise.text = "Exercise: Left lean";
        else if (exerciser.exercise == 3)
            exercise.text = "Exercise: Right lean";
        else
        {
            exercise.text = "Activity over" +  '\n' + " Thank you for your participation";
            repetition.text = "";
            stage.text = "";
        }
    }
}
