using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using RootMotion.FinalIK; // Final IK

public class raaTrackers : MonoBehaviour
{
    public Transform transformHip;
    public Transform transformHead;
    public Transform transformHandLeft;
    public Transform transformHandRight;

    public SteamVR_TrackedObject trackerHip;
    public SteamVR_TrackedObject trackerHead;
    public SteamVR_TrackedObject trackerHandLeft;
    public SteamVR_TrackedObject trackerHandRight;

    void Start()
    {
        // TESTS: for potentially setting FinalIK elements through this script automatically
        //VRIK avatarVRIK;
        ///avatarVRIK.solver.spine.headTarget = ...
        
    }
    
    void Update()
    {
        if (trackerHip != null)
        {
            transformHip = trackerHip.transform;
        }
        if (trackerHead != null)
        {
            transformHead = trackerHead.transform;
        }
        if (trackerHandLeft != null)
        {
            transformHandLeft = trackerHandLeft.transform;
        }
        if (trackerHandRight != null)
        {
            transformHandRight = trackerHandRight.transform;
        }
    }
}
