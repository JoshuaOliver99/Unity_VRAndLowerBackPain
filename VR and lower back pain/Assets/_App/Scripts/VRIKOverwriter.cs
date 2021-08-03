using RootMotion.Demos;
using RootMotion.FinalIK;
using UnityEngine;
using Valve.VR;

/// <summary>
/// Calibrates VRIKCalibrationController for each avatar using VR input
/// </summary>
public class VRIKOverwriter : MonoBehaviour
{
    [Header("References")]
    [SerializeField] AppController appController;
    [SerializeField, Tooltip("The VRIKCalibrationController of each avatar")] VRIKCalibrationController[] VRIKCalibrationControllers;
    [SerializeField, Tooltip("The VRIK of each avatar")] VRIK[] VRIKs;

    [SerializeField] Transform leftFoot;
    [SerializeField] Transform rightFoot;

    [SerializeField, Tooltip("These should be disabled first")] GameObject[] objectsToEnable; // (player models)

    void Start()
    {
        // Disable objects which shouldnt be active yet
        //foreach (GameObject g in objectsToEnable)
        //    g.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) || SteamVR_Input.GetStateDown("GrabPinch", SteamVR_Input_Sources.LeftHand) || SteamVR_Input.GetStateDown("GrabPinch", SteamVR_Input_Sources.RightHand))
        {
            foreach (VRIKCalibrationController o in VRIKCalibrationControllers)
                o.Calibrate();
            
            foreach (VRIK o in VRIKs)
            {
                // Fix feet (plant, set locomotion weight)
                o.solver.plantFeet = true;
                o.solver.locomotion.weight = 1f;

                o.solver.leftLeg.target = leftFoot;
                o.solver.leftLeg.positionWeight = 1;
                o.solver.rightLeg.target = rightFoot;
                o.solver.rightLeg.positionWeight = 1;
            }

            // Enable all required objects...
            foreach (GameObject g in objectsToEnable)
                g.SetActive(true);

            // Move onto next stage
            appController.IncreaseStage(1);

            // Disable this script
            gameObject.GetComponent<VRIKOverwriter>().enabled = false;
        }

    }


}