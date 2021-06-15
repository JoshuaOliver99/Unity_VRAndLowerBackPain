using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class VRMap
{
    [SerializeField] Transform vrTarget;
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
    [SerializeField] float turnSmoothness;
    
    [SerializeField] VRMap head;
    [SerializeField] VRMap leftHand;
    [SerializeField] VRMap rightHand;

    [SerializeField] Transform headConstraint;
    [SerializeField] Vector3 headBodyOffset;


    void Start()
    {
        headBodyOffset = transform.position - headConstraint.position;
    }

    void Update()
    {
        transform.position = headConstraint.position + headBodyOffset;
        //transform.forward = Vector3.ProjectOnPlane(headConstraint.up, Vector3.up).normalized;
        transform.forward = 
            Vector3.Lerp(transform.forward, Vector3.ProjectOnPlane(headConstraint.up, Vector3.up).normalized, Time.deltaTime * turnSmoothness);

        head.Map();
        leftHand.Map();
        rightHand.Map();
    }
}
