using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary
/// (to attatch to a parent of finish button)
/// Enables and Disables the FINISH button dependant on number of pains selected
/// </summary>
public class PainAreaSelected : MonoBehaviour
{
    References references;
    GameObject finishButton;

    void Start()
    {
        if (references == null)
            references = GameObject.FindGameObjectWithTag("GameController").GetComponent<References>();
        if (references == null)
            Debug.Log("References.cs not found");

        finishButton = transform.GetChild(0).gameObject;
        finishButton.SetActive(false);
    }

    void Update()
    {
        if (references.painUI.numPains > 0)
            finishButton.SetActive(true);
        else
            finishButton.SetActive(false);
            
    }
}
