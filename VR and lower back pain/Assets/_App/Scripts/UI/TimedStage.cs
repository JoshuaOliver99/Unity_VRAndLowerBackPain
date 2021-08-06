using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Deactivates gameObject and moves to next stage of application
/// </summary>
public class TimedStage : MonoBehaviour
{
    References references;

    float timer = 0;
    [SerializeField] float maxTime = 1.5f;

    private void Start()
    {
        if (references == null)
            references = GameObject.FindGameObjectWithTag("GameController").GetComponent<References>();
        if (references == null)
            Debug.Log("References.cs not found");
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer > maxTime)
        {
            gameObject.SetActive(false);
            references.AppController.IncreaseStage(1);
        }
    }
}
