using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class CalibrateSize : MonoBehaviour
{
    public Transform UpperArmBoneLeft, LowerArmBoneLeft;
    public Transform UpperArmBoneRight, LowerArmBoneRight;
    public float scalePct = 0.05f;
    [SerializeField] float scaleHeight, scaleArms;

    [Header("Steam VR")]
    public SteamVR_Input_Sources leftHand;
    public SteamVR_Input_Sources rightHand;

    private void Update()
    {
        if (SteamVR_Input.GetStateDown("GrowArms", leftHand))
            GrowArms();
        if (SteamVR_Input.GetStateDown("ShrinkArms", leftHand))
            ShrinkArms();
        if (SteamVR_Input.GetStateDown("GrowHeight", rightHand))
            GrowHeight();
        if (SteamVR_Input.GetStateDown("ShrinkHeight", rightHand))
            ShrinkHeight();
    }

    public void GrowHeight()
    {
        Debug.Log("Grow Height");
        scaleHeight = this.transform.localScale.y + scalePct;
        this.gameObject.transform.localScale = new Vector3(scaleHeight, scaleHeight, scaleHeight);
    }
    public void ShrinkHeight()
    {
        Debug.Log("Shrink Height");
        scaleHeight = this.transform.localScale.y - scalePct;
        this.gameObject.transform.localScale = new Vector3(scaleHeight, scaleHeight, scaleHeight);
    }
    public void GrowArms()
    {
        Debug.Log("Grow Arms");
        scaleArms = this.transform.localScale.y + scalePct;
        LowerArmBoneLeft.localScale = UpperArmBoneLeft.localScale = LowerArmBoneRight.localScale = UpperArmBoneRight.localScale = 
            new Vector3(scaleArms, scaleArms, scaleArms);
    }
    public void ShrinkArms()
    {
        Debug.Log("Shrink Arms");
        scaleArms = this.transform.localScale.y - scalePct;
        LowerArmBoneLeft.localScale = UpperArmBoneLeft.localScale = LowerArmBoneRight.localScale = UpperArmBoneRight.localScale =
            new Vector3(scaleArms, scaleArms, scaleArms);
    }
}
