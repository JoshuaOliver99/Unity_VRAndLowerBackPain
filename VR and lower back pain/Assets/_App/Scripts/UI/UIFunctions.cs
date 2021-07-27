using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFunctions : MonoBehaviour
{
    [SerializeField] AppController appController;
    public void Btn_Next()
    {
        appController.IncreaseStage(1);
    }
}
