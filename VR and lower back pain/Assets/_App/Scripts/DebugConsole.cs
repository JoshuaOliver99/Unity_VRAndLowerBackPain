using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Generic class with vairables to be used for testing
/// </summary>
public class DebugConsole : MonoBehaviour
{
    [Header("Sliders")]
    public bool DebugSliders;
    public int ActiveStage;
    public float HeadAngle;

    [Header("Identifiers - Only works on start!")]
    public bool toggleAll;
    public bool toggleHead;
    public bool toggleHips;
    public bool toggleLeftHand;
    public bool toggleRIghtHand;
    public GameObject[] HeadIdentifiers;
    public GameObject[] HipsIdentifiers;
    public GameObject[] LeftHandIdentifiers;
    public GameObject[] RightHandIdentifiers;

    void Start()
    {
        SetIdentifiers();
    }

    public void SetIdentifiers()
    {
        if (toggleAll)
        {
            foreach (GameObject g in HeadIdentifiers)
                g.SetActive(true);
            foreach (GameObject g in HipsIdentifiers)
                g.SetActive(true);
            foreach (GameObject g in LeftHandIdentifiers)
                g.SetActive(true);
            foreach (GameObject g in RightHandIdentifiers)
                g.SetActive(true);
        }
        else
        {
            // ----- Version 1:
            //if (toggleHead)
            //    foreach (GameObject g in HeadIdentifiers)
            //        g.SetActive(true);
            //if (toggleHips)
            //    foreach (GameObject g in HipsIdentifiers)
            //        g.SetActive(true);
            //if (toggleLeftHand)
            //    foreach (GameObject g in LeftHandIdentifiers)
            //        g.SetActive(true);
            //if (toggleRIghtHand)
            //    foreach (GameObject g in RightHandIdentifiers)
            //        g.SetActive(true);

            // ----- Version 2:
            foreach (GameObject g in HeadIdentifiers)
                g.SetActive(toggleHead);
            foreach (GameObject g in HipsIdentifiers)
                g.SetActive(toggleHips);
            foreach (GameObject g in LeftHandIdentifiers)
                g.SetActive(toggleLeftHand);
            foreach (GameObject g in RightHandIdentifiers)
                g.SetActive(toggleRIghtHand);
        }
    }

}
