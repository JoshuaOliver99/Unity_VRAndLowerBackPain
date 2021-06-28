using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalibrateSize : MonoBehaviour
{
    public Transform UpperArmBoneLeft, LowerArmBoneLeft;
    public Transform UpperArmBoneRight, LowerArmBoneRight;
    public float scalePct = 0.05f;
    float scaleHeight, scaleArms;

    /// <summary>
    ///  DEBUG: Remove on build, for testing without using controller button presses
    /// </summary>
    private void Update()
    {
        if (Input.GetButtonDown(KeyCode.Q.ToString()))
            GrowHeight();
        if (Input.GetButtonDown(KeyCode.A.ToString()))
            ShrinkHeight();
        if (Input.GetButtonDown(KeyCode.W.ToString()))
            GrowArms();
        if (Input.GetButtonDown(KeyCode.S.ToString()))
            ShrinkArms();
    }
    // ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^ deactivate ^^^^^^^^^^^^^^^^^^

    public void GrowHeight()
    {
        scaleHeight = this.transform.localScale.y + scalePct;
        this.gameObject.transform.localScale = new Vector3(scaleHeight, scaleHeight, scaleHeight);
    }
    public void ShrinkHeight()
    {
        scaleHeight = this.transform.localScale.y - scalePct;
        this.gameObject.transform.localScale = new Vector3(scaleHeight, scaleHeight, scaleHeight);
    }
    public void GrowArms()
    {
        scaleArms = this.transform.localScale.y + scalePct;
        LowerArmBoneLeft.localScale = UpperArmBoneLeft.localScale = LowerArmBoneRight.localScale = UpperArmBoneRight.localScale = 
            new Vector3(scaleArms, scaleArms, scaleArms);
    }
    public void ShrinkArms()
    {
        scaleArms = this.transform.localScale.y - scalePct;
        LowerArmBoneLeft.localScale = UpperArmBoneLeft.localScale = LowerArmBoneRight.localScale = UpperArmBoneRight.localScale =
            new Vector3(scaleArms, scaleArms, scaleArms);
    }
}
