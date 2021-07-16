using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Holds the UI finctions for the PainSelection UI
/// </summary>
public class PainSelectionUI : MonoBehaviour
{

    public void Pain(string pain)
    {
        Debug.Log(pain + " " + Time.time.ToString());
    }

}
