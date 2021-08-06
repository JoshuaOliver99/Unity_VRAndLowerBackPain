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
            exerciseText.text = "1. Lean Left";
        else if (exerciser.Exercise == 2)
            exerciseText.text = "2. Lean Right";
        else if (exerciser.Exercise == 3)
            exerciseText.text = "3. Lean Back";
        else if (exerciser.Exercise == 4)
            exerciseText.text = "4. Lean Forward";
        exerciseText.text += "\n";


        exerciseText.text += "Repetition: " + exerciser.Repetition;
        exerciseText.text += "\n";

        if (exerciser.Stage == 1)
            exerciseText.text += "1. STAND UPRIGHT - SQUEEZE TRIGGER";
        else if (exerciser.Stage == 2)
            exerciseText.text += "2. IN DISCOMFORT - SQUEEZE TRIGGER";
        else if (exerciser.Stage == 3)
            exerciseText.text += "3. IN PAIN - SQUEEZE TRIGGER";

    }
}
