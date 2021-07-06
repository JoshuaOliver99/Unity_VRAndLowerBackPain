using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformLocker : MonoBehaviour
{
    [SerializeField] bool lockTransform;
    [SerializeField] GameObject lockedObject;

    Vector3 lockedPos;
    Quaternion lockedRot;
   
    void Start()
    {
        // Retriev starting position & rotation
        lockedPos = lockedObject.transform.position;   
        lockedRot = lockedObject.transform.rotation;   
    }

    void Update()
    {
        if (lockTransform)
        {
            // Set the position & rotation
            lockedObject.transform.position = lockedPos;
            lockedObject.transform.rotation = lockedRot;
        }
    }
}
