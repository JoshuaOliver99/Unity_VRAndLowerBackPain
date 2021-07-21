/* SceneHandler.cs*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Valve.VR.Extras;

public class SceneHandler : MonoBehaviour
{
    public SteamVR_LaserPointer laserPointer;

    // NOTE:
    // Inefficient possibly but quick testing workaround
    [SerializeField] List<GameObject> buttons;
    [SerializeField] List<string> names = new List<string>();

    void Awake()
    {
        laserPointer.PointerIn += PointerInside;
        laserPointer.PointerOut += PointerOutside;
        laserPointer.PointerClick += PointerClick;

        foreach (GameObject g in buttons)
            names.Add(g.name);
    }

    public void PointerClick(object sender, PointerEventArgs e)
    {
        // NOTE: TEST (maybe use tags e.g. 'button')
        foreach (string name in names)
            if (e.target.name == name)
                e.target.GetComponent<Button>().onClick.Invoke();

        // NOTE: IDEA:
        // Maybe just call onClick() in for the gameobject

        //if (e.target.name == "Cube")
        //{
        //    Debug.Log("Cube was clicked");
        //}
        //else if (e.target.name == "Button")
        //{
        //    Debug.Log("Button was clicked");
        //}
    }

    public void PointerInside(object sender, PointerEventArgs e)
    {
        //foreach (string name in names)
        //    if (e.target.name == name)
        //    {
        //        Debug.Log(e.target.name); // NOTE: this works
        //        //e.target.GetComponent<Image>().color = Color.red;
        //    }

        //if (e.target.name == "Cube")
        //{
        //    Debug.Log("Cube was entered");
        //}
        //else if (e.target.name == "Button")
        //{
        //    Debug.Log("Button was entered");
        //}
    }

    public void PointerOutside(object sender, PointerEventArgs e)
    {
        //if (e.target.name == "Cube")
        //{
        //    Debug.Log("Cube was exited");
        //}
        //else if (e.target.name == "Button")
        //{
        //    Debug.Log("Button was exited");
        //}
    }
}

/*
public class SceneHandler : MonoBehaviour
{
    public SteamVR_LaserPointer laserPointer;

    void Awake()
    {
        laserPointer.PointerIn += PointerInside;
        laserPointer.PointerOut += PointerOutside;
        laserPointer.PointerClick += PointerClick;
    }

    public void PointerClick(object sender, PointerEventArgs e)
    {
        if (e.target.name == "Cube")
        {
            Debug.Log("Cube was clicked");
        }
        else if (e.target.name == "Button")
        {
            Debug.Log("Button was clicked");
            e.target.GetComponent<Button>().onClick.Invoke();
        }
    }

    public void PointerInside(object sender, PointerEventArgs e)
    {
        if (e.target.name == "Cube")
        {
            Debug.Log("Cube was entered");
        }
        else if (e.target.name == "Button")
        {
            Debug.Log("Button was entered");
        }
    }

    public void PointerOutside(object sender, PointerEventArgs e)
    {
        if (e.target.name == "Cube")
        {
            Debug.Log("Cube was exited");
        }
        else if (e.target.name == "Button")
        {
            Debug.Log("Button was exited");
        }
    }
}
*/

