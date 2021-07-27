using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyGrad : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    public GradientMode getMode;
    public GradientColorKey[] ck;

    GradientColorKey[] colorKey;
    GradientAlphaKey[] alphaKey;
    private void Start()
    {
        getMode = gradient.mode;
        ck = gradient.colorKeys;
        foreach ( GradientColorKey k in ck)
        {
            //k.color = Color.black;
               
            Debug.Log(k.color + ": " + k.time );
        }

        // set up a new gradient
        gradient = new Gradient();

        // Populate the color keys at the relative time 0 and 1 (0 and 100%)
        colorKey = new GradientColorKey[4];
        colorKey[0].color = Color.green;
        colorKey[0].time = 0.5f;
        colorKey[1].color = Color.yellow;
        colorKey[1].time = 0.7f;
        colorKey[2].color = Color.magenta;
        colorKey[2].time = 0.8f;
        colorKey[3].color = Color.red;
        colorKey[3].time = 1.0f;

        // Populate the alpha  keys at relative time 0 and 1  (0 and 100%)
        alphaKey = new GradientAlphaKey[4];
        alphaKey[0].alpha = 1.0f;
        alphaKey[0].time = 0.5f;
        alphaKey[1].alpha = 1.0f;
        alphaKey[1].time = 0.7f;
        alphaKey[2].alpha = 0f;
        alphaKey[2].time = 0.8f;
        alphaKey[3].alpha = 1.0f;
        alphaKey[3].time = 1.0f;

        gradient.SetKeys(colorKey, alphaKey);
        gradient.mode = GradientMode.Fixed;
    }
    void Update()
    {
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
