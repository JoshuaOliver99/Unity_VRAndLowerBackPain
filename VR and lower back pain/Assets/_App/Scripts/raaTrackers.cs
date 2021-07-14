using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

/// <summary>
/// Reference to each VR transformation
/// </summary>
public class raaTrackers : MonoBehaviour
{
    [Header("VR Objects")]
    public Transform TransformHip;
    public Transform TransformHead;
    public Transform TransformHandLeft;
    public Transform TransformHandRight;

    public SteamVR_TrackedObject TrackerHip;            // NOTE: Just use transform instead? These are the gameobject as above
    public SteamVR_TrackedObject TrackerHead;           // NOTE: Just use transform instead? These are the gameobject as above
    public SteamVR_TrackedObject TrackerHandLeft;       // NOTE: Just use transform instead? These are the gameobject as above
    public SteamVR_TrackedObject TrackerHandRight;      // NOTE: Just use transform instead? These are the gameobject as above

    [Header("VR Offsets. (desired positons)")]
    public Transform OffsetTransformHip;
    public Transform OffsetTransformHead;
    public Transform OffsetTransformHandLeft;
    public Transform OffsetTransformHandRight;

    [Header("Manipulated Positons")]
    public Transform ManipulatedHead;

    void Update()
    {
        if (TrackerHip != null)
        {
            TransformHip = TrackerHip.transform;
        }
        if (TrackerHead != null)
        {
            TransformHead = TrackerHead.transform;
        }
        if (TrackerHandLeft != null)
        {
            TransformHandLeft = TrackerHandLeft.transform;
        }
        if (TrackerHandRight != null)
        {
            TransformHandRight = TrackerHandRight.transform;
        }
    }
}
