using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using RootMotion.Demos;

/// <summary>
/// Calibrates VRIKCalibrationController for each avatar using VR input
/// </summary>
public class VRIKCalibrationCaller : MonoBehaviour
{
    [SerializeField] [Tooltip("The VRIKCalibrationController of each avatar")] VRIKCalibrationController[] VRIKCalibrationControllers;

    [Header("Steam VR")]
    [SerializeField] SteamVR_Input_Sources leftHand;
    [SerializeField] SteamVR_Input_Sources rightHand;

    void Update()
    {
        if (SteamVR_Input.GetStateDown("GrabPinch", leftHand))
            foreach (VRIKCalibrationController calibrator in VRIKCalibrationControllers)
                calibrator.Calibrate();
    }
}