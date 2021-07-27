using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;

using UnityEngine.Networking;




public class ButtonHTTP : MonoBehaviour
{
    /*
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    */
    public void buttonPressed()
    {
        Debug.Log("HTTP Button pressed.");
        StartCoroutine(Upload());
    }
    IEnumerator Upload()
    {
        /*       List<IMultipartFormSection> formData = new List<IMultipartFormSection>();
               formData.Add(new MultipartFormDataSection("field1=foo&field2=bar"));
               formData.Add(new MultipartFormFileSection("my file data", "myfile.txt"));
       */
        WWWForm form = new WWWForm();
        form.AddField("myPost", "postData");
        form.AddField("myName", "Mario Kart");

        UnityWebRequest www = UnityWebRequest.Post("http://149.170.119.27/al/unity.php?test=1", form);
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("Form request complete: " + www.downloadHandler.text );
        }
    }
}
