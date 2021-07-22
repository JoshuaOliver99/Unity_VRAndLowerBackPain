using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PainUI : MonoBehaviour
{
    [Header("References")]
    [SerializeField] Logger logger;

    [Header("UI References")]
    [SerializeField] GameObject intensityPanel;
    [SerializeField] GameObject areaPanel;

    [SerializeField] GameObject areaButtonConfirm;

    [SerializeField] GameObject intensityMarker;
    //[SerializeField] GameObject areaMarker;

    [Header("Data - (debug serialization)")]
    [SerializeField] string selectedArea;
    [SerializeField] int selectedIntensity;


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

        if (areaButtonConfirm.activeSelf == false)
            areaButtonConfirm.SetActive(true);

        areaPanel.transform.Find("Selected").GetComponent<TMP_Text>().text = selectedArea;
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
        gameObject.SetActive(false); // Demo action
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

    // NOTE:
    // BUG: This is called twice when pressing?
    public void Btn_IntensityConfirm()
    {
        // Reset to area select panel...
        intensityPanel.SetActive(false);
        areaPanel.SetActive(true);
        areaButtonConfirm.SetActive(false);
        selectedArea = "Make a selection or press 'Finished'";

        logger.Write2File(selectedArea + " pain = " + selectedIntensity);
    }

    public void Btn_IntensityCancel()
    {
        // Reset to area select panel...
        intensityPanel.SetActive(false);
        areaPanel.SetActive(true);
        areaButtonConfirm.SetActive(false);
        selectedArea = "Make a selection or press 'Finished'";

    }

    // ----- Logging -----
    void LogPainAndIntensity()
    {
        logger.Write2File(selectedArea + " pain = " + selectedIntensity);
    }
}
