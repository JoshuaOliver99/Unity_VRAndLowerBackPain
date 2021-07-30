using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using System.IO;
using Newtonsoft.Json;

/// <summary>
/// L or Left Trackpad logs positions and rotations of objectsToLog and writes to log file on desktop
/// </summary>
public class Logger : MonoBehaviour
{
    [Header("References")]
    [SerializeField] References references;
    [SerializeField] Exerciser exerciser;

    [Header("Logger Settings")]
    public GameObject[] objectsToLog;

    private Dictionary<string, Dictionary<string, float>> dict;

    //private readonly string pathFile = "Assets/Recordings/log.txt"; // OLD can be removed
    private readonly string pathFile = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop) + "/log.txt";

    void Start()
    {
        if (references == null)
            Debug.LogError("References.cs not retrieved");
        if (exerciser == null)
            Debug.LogError("Exerciser.cs not retrieved");


        dict = new Dictionary<string, Dictionary<string, float>>();

        foreach (GameObject obj in objectsToLog)
        {
            //Debug.Log("obj name: " + obj.name);
            dict.Add(obj.name, new Dictionary<string, float>() {
                { "px", 0f },
                { "py", 0f },
                { "pz", 0f },
                { "rx", 0f },
                { "ry", 0f },
                { "rz", 0f }
            });
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L) || SteamVR_Input.GetStateDown("GrabPinch", SteamVR_Input_Sources.LeftHand) || SteamVR_Input.GetStateDown("GrabPinch", SteamVR_Input_Sources.RightHand))
        {
            WriteExerciseStage();
            WriteLog();
        }


    }

    public void WriteExerciseStage()
    {
        if (exerciser.Stage == 1)
        {
            string txt = "Exercise: " + exerciser.Exercise + ", Repetiton: " + exerciser.Repetition;
            if (exerciser.Manipulating)
                txt += " **!** Manipulated **!**";

            Write2File(txt);
        }
    }

    public void WriteLog()
    {
        string json;

        foreach (GameObject obj in objectsToLog)
        {
            dict[obj.name]["px"] = obj.transform.position.x;
            dict[obj.name]["py"] = obj.transform.position.y;
            dict[obj.name]["pz"] = obj.transform.position.z;

            dict[obj.name]["rx"] = obj.transform.eulerAngles.x;
            dict[obj.name]["ry"] = obj.transform.eulerAngles.y;
            dict[obj.name]["rz"] = obj.transform.eulerAngles.z;
        }

        json = JsonConvert.SerializeObject(dict);
 
        Write2File(json);
    }

    public void Write2File(string txt = "")
    {
        if (!File.Exists(pathFile))
        {
            using (StreamWriter writetext = File.CreateText(pathFile))
            {
                writetext.WriteLine(System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ": File Created");
            }
        }
        using (StreamWriter writetext = File.AppendText(pathFile))
        {
            writetext.WriteLine(System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ", " + txt);
            writetext.Close();
        }
    }

}
