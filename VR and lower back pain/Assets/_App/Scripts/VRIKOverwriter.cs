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
    References references;
    [SerializeField] [Tooltip("The VRIKCalibrationController of each avatar")] VRIKCalibrationController[] VRIKCalibrationControllers;
    [SerializeField] [Tooltip("The VRIKCalibrationController of each avatar")] VRIK[] VRIKs;

     Transform headStartingOffset;
     Transform hipStartingOffset;
     Transform leftHandStartingOffset;
     Transform rightHandStartingOffset;

    void Start()
    {
        if (!(references = GetComponent<References>()))
            Debug.LogError("References not retrieved");

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
        if (Input.GetKeyDown(KeyCode.C) || SteamVR_Input.GetStateDown("GrabPinch", references.leftHand))
        {
            foreach (VRIKCalibrationController o in VRIKCalibrationControllers)
                o.Calibrate();
            
            foreach (VRIK o in VRIKs)
            {
                // Fix feet (plant, set locomotion weight)
                o.solver.plantFeet = true;
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