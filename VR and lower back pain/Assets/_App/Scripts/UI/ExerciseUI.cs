using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ExerciseUI : MonoBehaviour
{
    [Header("References")]
    [SerializeField] Exerciser exerciser;
    [SerializeField] TMP_Text exerciseText;

    private void Start()
    {
        UpdateExerciseText();
    }

    public void UpdateExerciseText()
    {
        exerciseText.text = "";

        if (exerciser.Exercise == 1)
            exerciseText.text = "Lean Left";
        else if (exerciser.Exercise == 2)
            exerciseText.text = "Lean Right";
        else if (exerciser.Exercise == 3)
            exerciseText.text = "Lean Back";
        else if (exerciser.Exercise == 4)
            exerciseText.text = "Lean Forward";
        exerciseText.text += "\n";


        exerciseText.text += "Repetition: " + exerciser.Repetition;
        exerciseText.text += "\n";

        if (exerciser.Stage == 1)
            exerciseText.text += "Stand upright & notify";
        else if (exerciser.Stage == 2)
            exerciseText.text += "begin leaning. notify when in discomfort";
        else if (exerciser.Stage == 3)
            exerciseText.text += "continue leaning & nofity when in pain";

    }
}
