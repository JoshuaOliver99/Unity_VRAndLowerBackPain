using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PainUI : MonoBehaviour
{
    [Header("References")]
    [SerializeField] Logger logger;

    [Header("Intensity Panel References")]
    [SerializeField] GameObject areaPanel;

    [Header("Intensity Panel References")]
    [SerializeField] GameObject intensityPanel;
    [SerializeField] TMP_Text SelectedAreaText;
    [SerializeField] TMP_Text SelectedIntensityText;

    [Header("Data - (debug serialization)")]
    [SerializeField] string selectedArea;
    [SerializeField] int selectedIntensity;
    [Tooltip("For checking one or more pains selected.")] public int numPains;
    [Tooltip("For checking a selected intensity.")] public bool intensitySelected;



    void OnEnable()
    {
        logger.Write2File("----- Pain Chart & Logging -----");

        selectedArea = "";
        selectedIntensity = 0;
    }


    // ----- Area select -----
    public void Btn_SelectArea(string area)
    {
        selectedArea = area;
        areaPanel.SetActive(false);
        intensityPanel.SetActive(true);
        updateAreaText(); 
    }


    // ------ Intensity select -----
    public void Btn_SelectIntensity(int intensity)
    {
        selectedIntensity = intensity;
        updateIntensityText();
        intensitySelected = true;
    }

    public void Btn_Retry()
    {
        intensityPanel.SetActive(false);
        areaPanel.SetActive(true);
        reset();
    }

    public void Btn_Next() // The Confirm button
    {
        LogPainAndIntensity();
        reset();
        numPains++;
    }

    void updateAreaText()
    {
        SelectedAreaText.text = "Select Intensity for: \n" + selectedArea;
    }
    void updateIntensityText()
    {
        SelectedIntensityText.text = "Intensity: " + selectedIntensity;

    }

    public void reset()
    {
        intensityPanel.SetActive(false);
        areaPanel.SetActive(true);

        selectedArea = "";
        selectedIntensity = 0;
        intensitySelected = false;

        SelectedAreaText.text = "Select Intensity for: \n" + selectedArea;
        SelectedIntensityText.text = "";
    }

    public void resetNumPain()
    {
        numPains = 0;
    }

    public void Btn_finish()
    {
        reset();
    }

    // ----- Logging -----
    void LogPainAndIntensity()
    {
        logger.Write2File(selectedArea + " pain = " + selectedIntensity);
    }
}
