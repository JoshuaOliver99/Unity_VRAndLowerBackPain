using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class VRMap
{
    public Transform vrTarget;
    [SerializeField] Transform rigTarget;
    [SerializeField] Vector3 trackingPositionOffset;
    [SerializeField] Vector3 trackingRotationOffset;

    public void Map()
    {
        rigTarget.position = vrTarget.TransformPoint(trackingPositionOffset);
        rigTarget.rotation = vrTarget.rotation * Quaternion.Euler(trackingRotationOffset);
    }
}

public class VRRig : MonoBehaviour
{
    [Header("Debug - Tick if used")]
    [SerializeField] bool useHead = true;
    [SerializeField] bool useLHand = true;
    [SerializeField] bool useRHand = true;
    [SerializeField] bool useHips = true;
    [SerializeField] bool useLFoot = true;
    [SerializeField] bool useRFoot = true;

    [Header("Settings")]
    [SerializeField] float turnSmoothness;

    [SerializeField] raaTrackers RaaTrackers; // Reference to detected Trackers

    [Header("Constraint settings")]
    [SerializeField] VRMap head;
    [SerializeField] VRMap leftHand;
    [SerializeField] VRMap rightHand;
    [SerializeField] VRMap hips;
    [SerializeField] VRMap leftFoot;
    [SerializeField] VRMap rightFoot;

    [SerializeField] Transform headConstraint;
    [SerializeField] Vector3 headBodyOffset;


    void Start()
    {
        headBodyOffset = transform.position - headConstraint.position;

        //if (RaaTrackers ==null)
            //RaaTrackers = GameObject.FindObjectOfType<raaTrackers>();

        // Get Tracker targets
        //head.vrTarget = RaaTrackers.trackerHead.transform;
        //leftHand.vrTarget = RaaTrackers.trackerHandLeft.transform;
        //rightHand.vrTarget = RaaTrackers.trackerHandRight.transform;
        //hips.vrTarget = RaaTrackers.trackerHip.transform;
    }

    void Update()
    {
        // Update body position
        transform.position = headConstraint.position + headBodyOffset;

        // Update head position smoothly
        transform.forward = Vector3.Lerp(transform.forward, Vector3.ProjectOnPlane(headConstraint.up, Vector3.up).normalized, Time.deltaTime * turnSmoothness);

        if (useHead)    head.Map();
        if (useLHand)   leftHand.Map();
        if (useRHand)   rightHand.Map();
        if (useHips)    hips.Map();     // NOTE: Maybe undeeded implementation for hips. Maybe .position is enough
        if (useLFoot)   leftFoot.Map();
        if (useRFoot)   rightFoot.Map();
    }
}
