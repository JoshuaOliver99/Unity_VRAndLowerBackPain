using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFunctions : MonoBehaviour
{
    [SerializeField] AppController appController;
    [SerializeField] GameObject EXITPanel;

    private void Update()
    {
        // ----- Manual EXIT -----
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (EXITPanel.activeSelf == true)
                Application.Quit();
            else
                EXITPanel.SetActive(true);
        }
    }




    public void Btn_Next()
    {
        appController.IncreaseStage(1);
    }


    // ----- EXIT -----
    public void Btn_Exit()
    {
        EXITPanel.SetActive(true);
    }

    public void Btn_CancelExit()
    {
        EXITPanel.SetActive(false);
    }

    public void Btn_ExitApp()
    {
        Application.Quit();
    }
}
