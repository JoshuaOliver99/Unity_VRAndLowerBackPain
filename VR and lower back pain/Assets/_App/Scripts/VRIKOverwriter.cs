using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using RootMotion.Demos;
using RootMotion.FinalIK;

/// <summary>
/// Calibrates VRIKCalibrationController for each avatar using VR input
/// </summary>
public class VRIKOverwriter : MonoBehaviour
{
    [Header("References")]
    [SerializeField] raaTrackers raaTrackers;
    [SerializeField] [Tooltip("The VRIKCalibrationController of each avatar")] VRIKCalibrationController[] VRIKCalibrationControllers;
    [SerializeField] [Tooltip("The VRIKCalibrationController of each avatar")] VRIK[] VRIKs;

    [Header("Steam VR")]
    [SerializeField] SteamVR_Input_Sources leftHand;
    [SerializeField] SteamVR_Input_Sources rightHand;


    [SerializeField] Transform headStartingOffset;
    [SerializeField] Transform hipStartingOffset;
    [SerializeField] Transform leftHandStartingOffset;
    [SerializeField] Transform rightHandStartingOffset;

    void Start()
    {
        //headStartingOffset =        raaTrackers.OffsetTransformHead;
        //hipStartingOffset =         raaTrackers.OffsetTransformHip;
        //leftHandStartingOffset =    raaTrackers.OffsetTransformHandLeft;
        //rightHandStartingOffset =   raaTrackers.OffsetTransformHandRight;
        //
        //headStartingOffset.localPosition =      raaTrackers.OffsetTransformHead.localPosition       ;
        //hipStartingOffset.localPosition =       raaTrackers.OffsetTransformHip.localPosition        ;
        //leftHandStartingOffset.localPosition =  raaTrackers.OffsetTransformHandLeft.localPosition   ;
        //rightHandStartingOffset.localPosition = raaTrackers.OffsetTransformHandRight.localPosition  ;
        //
        //headStartingOffset.localRotation =      raaTrackers.OffsetTransformHead.localRotation       ;
        //hipStartingOffset.localRotation =       raaTrackers.OffsetTransformHip.localRotation        ;
        //leftHandStartingOffset.localRotation =  raaTrackers.OffsetTransformHandLeft.localRotation   ;
        //rightHandStartingOffset.localRotation = raaTrackers.OffsetTransformHandRight.localRotation  ;

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) || SteamVR_Input.GetStateDown("GrabPinch", leftHand))
        {
            foreach (VRIKCalibrationController o in VRIKCalibrationControllers)
            {
                o.Calibrate();
            }
            
            foreach (VRIK o in VRIKs)
            {
                // Plant feet
                o.solver.plantFeet = true;
                // Locomotion weight max
                o.solver.locomotion.weight = 1f;
            }

            // TEST:
            // Apply starting offsets
            //raaTrackers.OffsetTransformHead = headStartingOffset                            ;
            //raaTrackers.OffsetTransformHip = hipStartingOffset                              ;
            //raaTrackers.OffsetTransformHandLeft = leftHandStartingOffset                    ;
            //raaTrackers.OffsetTransformHandRight = rightHandStartingOffset                  ;
            //
            //raaTrackers.OffsetTransformHead.localPosition    = headStartingOffset.localPosition                            ;
            //raaTrackers.OffsetTransformHip.localPosition         = hipStartingOffset.localPosition                              ;
            //raaTrackers.OffsetTransformHandLeft.localPosition    = leftHandStartingOffset.localPosition                    ;
            //raaTrackers.OffsetTransformHandRight.localPosition  = rightHandStartingOffset.localPosition                  ;
            //
            //raaTrackers.OffsetTransformHead.localRotation       = headStartingOffset      .localRotation                      ;
            //raaTrackers.OffsetTransformHip.localRotation        = hipStartingOffset       .localRotation                       ;
            //raaTrackers.OffsetTransformHandLeft.localRotation   = leftHandStartingOffset  .localRotation                  ;
            //raaTrackers.OffsetTransformHandRight.localRotation  = rightHandStartingOffset .localRotation                 ;
        }

    }


}