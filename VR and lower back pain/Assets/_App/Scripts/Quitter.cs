using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

/// <summary>
/// Allows the plalyer to quit using the trackpad as a button
/// </summary>
public class Quitter : MonoBehaviour
{
    //[SerializeField] GameObject quitPanel;
    //int repetitions = 0;
    void Update()
    {
        if (SteamVR_Input.GetStateDown("PressTrackpad", SteamVR_Input_Sources.LeftHand) || SteamVR_Input.GetStateDown("PressTrackpad", SteamVR_Input_Sources.RightHand))
            Application.Quit();
                //quitPanel.SetActive(true);
    }
}
