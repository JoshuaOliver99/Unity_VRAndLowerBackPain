using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PainUI : MonoBehaviour
{
    [Header("References")]
    [SerializeField] GameObject intensityPanel;
    [SerializeField] GameObject areaPanel;

    [SerializeField] GameObject areaButtonConfirm;

    [SerializeField] GameObject intensityMarker;
    //[SerializeField] GameObject areaMarker;

    [Header("Data")]
    [SerializeField] string selectedArea;
    [SerializeField] int selectedIntensity;

    // ----- Area select -----
    public void Btn_SelectArea(string area)
    {
        selectedArea = area;

        if (areaButtonConfirm.activeSelf == false)
            areaButtonConfirm.SetActive(true);
        
        // NOTE: TO DO
        //if (areaMarker.activeSelf == false)
        //    areaMarker.SetActive(true);
        
        // Also move the areaMarker to the position of the pressed button
    }

    public void Btn_AreaConfirm()
    {
        areaPanel.SetActive(false);

        intensityMarker.SetActive(false);
        intensityPanel.SetActive(true);
        intensityPanel.transform.Find("Title").GetComponent<TMP_Text>().text = selectedArea;
    }

    public void Btn_AreaFinished()
    {
        // NOTE: TO DO
        Debug.Log("Finished identifying pains");
        gameObject.SetActive(false); // Demo action
        // moves the user from the pain selection stage onto the exercise stage
    }


    // ----- Intensity Select -----
    public void Btn_SelectIntensity(int intensity)
    {
        selectedIntensity = intensity;

        if (intensityMarker.activeSelf == false)
            intensityMarker.SetActive(true);   

        // NOTE: TO DO
        // Also move the intensityMarker to the position of the pressed button
    }
    public void Btn_IntensityConfirm()
    {
        // Reset to area select panel...
        intensityPanel.SetActive(false);
        areaPanel.SetActive(true);
        areaButtonConfirm.SetActive(false);

        LogPainAndIntensity();
    }

    public void Btn_IntensityCancel()
    {
        // Reset to area select panel...
        intensityPanel.SetActive(false);
        areaPanel.SetActive(true);
        areaButtonConfirm.SetActive(false);

    }

    void LogPainAndIntensity()
    {
        // Log the data to file
        Debug.Log(selectedArea + ", Pain intensity: " + selectedIntensity);
    }
}
