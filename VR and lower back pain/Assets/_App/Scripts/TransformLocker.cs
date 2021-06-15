using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformLocker : MonoBehaviour
{
    [SerializeField] GameObject lockedObject;

    Vector3 lockedPos;
    Quaternion lockedRot;
   
    void Start()
    {
        // Retriev starting transformation
        lockedPos = lockedObject.transform.position;   
        lockedRot = lockedObject.transform.rotation;   
    }

    void Update()
    {
        // Set the position & rotation
        lockedObject.transform.position = lockedPos;
        lockedObject.transform.rotation = lockedRot;
    }
}
