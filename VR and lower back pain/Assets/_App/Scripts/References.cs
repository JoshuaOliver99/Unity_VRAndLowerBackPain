using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

/// <summary>
/// Reference to each VR transformation
/// </summary>
public class References : MonoBehaviour
{
    [Header("VR Objects")]
    public Transform TransformHead;
    public Transform TransformHip;
    public Transform TransformHandLeft;
    public Transform TransformHandRight;

    //public SteamVR_TrackedObject TrackerHip;            // NOTE: Just use transform instead? These are the gameobjects above
    //public SteamVR_TrackedObject TrackerHead;           // NOTE: Just use transform instead? These are the gameobjects above
    //public SteamVR_TrackedObject TrackerHandLeft;       // NOTE: Just use transform instead? These are the gameobjects above
    //public SteamVR_TrackedObject TrackerHandRight;      // NOTE: Just use transform instead? These are the gameobjects above

    [Header("VR Offsets (desired positons)")]
    public Transform OffsetTransformHead;
    public Transform OffsetTransformHip;
    public Transform OffsetTransformHandLeft;
    public Transform OffsetTransformHandRight;

    [Header("Manipulated Positon")]
    [Tooltip("Child of the VR head object.")] public Transform ManipulatedHead;

    [Header("scripts")]
    public AppController AppController;
    public FollowHead ManipulatedFollowHead;
    public Exerciser Exerciser;
    public PainUI painUI;

    [Header("References")]
    public SteamVR_Input_Sources leftHand;
    public SteamVR_Input_Sources rightHand;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();

        //if (TrackerHip != null)
        //{
        //    TransformHip = TrackerHip.transform;
        //}
        //if (TrackerHead != null)
        //{
        //    TransformHead = TrackerHead.transform;
        //}
        //if (TrackerHandLeft != null)
        //{
        //    TransformHandLeft = TrackerHandLeft.transform;
        //}
        //if (TrackerHandRight != null)
        //{
        //    TransformHandRight = TrackerHandRight.transform;
        //}
    }
}
