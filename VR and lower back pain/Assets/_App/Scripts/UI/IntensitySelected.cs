using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary
/// (to attatch to a parent of confirm button)
/// Enables and Disables the CONFIRM button if an intensity is selected
/// </summary>
public class IntensitySelected : MonoBehaviour
{
    References references;
    GameObject nextButton;

    void Start()
    {
        if (references == null)
            references = GameObject.FindGameObjectWithTag("GameController").GetComponent<References>();
        if (references == null)
            Debug.Log("References.cs not found");

        nextButton = transform.GetChild(0).gameObject;
        nextButton.SetActive(false);
    }

    void Update()
    {
        if (references.PainUI.intensitySelected)
            nextButton.SetActive(true);
        else
            nextButton.SetActive(false);

    }
}
