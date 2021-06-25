using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
