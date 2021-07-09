using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
public class raaTrackers : MonoBehaviour
{
    [Header("VR Objects")]
    public Transform TransformHip;
    public Transform TransformHead;
    public Transform TransformHandLeft;
    public Transform TransformHandRight;

    public SteamVR_TrackedObject TrackerHip;
    public SteamVR_TrackedObject TrackerHead;
    public SteamVR_TrackedObject TrackerHandLeft;
    public SteamVR_TrackedObject TrackerHandRight;

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
