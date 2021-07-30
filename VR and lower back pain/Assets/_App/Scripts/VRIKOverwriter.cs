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
    [SerializeField] [Tooltip("The VRIKCalibrationController of each avatar")] VRIKCalibrationController[] VRIKCalibrationControllers;
    [SerializeField] [Tooltip("The VRIK of each avatar")] VRIK[] VRIKs;

    [SerializeField] Transform leftFoot;
    [SerializeField] Transform rightFoot;

     //Transform headStartingOffset;
     //Transform hipStartingOffset;
     //Transform leftHandStartingOffset;
     //Transform rightHandStartingOffset;

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




            // Move onto next stage
            appController.IncreaseStage(1);

            // Disable this script
            gameObject.GetComponent<VRIKOverwriter>().enabled = false;


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