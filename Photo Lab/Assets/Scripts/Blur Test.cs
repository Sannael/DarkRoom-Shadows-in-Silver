using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlurTest : MonoBehaviour
{
    [Header("Scripts")]
    public NovaSamples.Effects.BlurEffect blurEffectScript;

    [Header("Blur Radius")]
    public bool changeBlurRadius;
    [Range(0f, 15f)]
    public float blurRadiusValue;

    [Header("Contrast")]
    public bool changeContrast;
    [Range(-1f, 1f)]
    public float contrastValue;

    [Header("Saturation")]
    public bool changeSaturation;
    [Range(-1f, 1f)]
    public float saturationValue;

    [Header("Brightness")]
    public bool changeBrightness;
    [Range(-1f, 1f)]
    public float brightnessValue;

    [Header("Color")]
    public bool changeBodyColor;
    public Color32 bodyColor;

    public Slider blurRadius, contrastRadius, saturationRadius, brightnessRadius;
    

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        blurRadiusValue = blurRadius.value;
        contrastValue = contrastRadius.value;
        saturationValue = saturationRadius.value;
        brightnessValue = brightnessRadius.value;


        if (changeBlurRadius) 
        {
            blurEffectScript.BlurRadius = blurRadiusValue;
        }

        if (changeContrast)
        {
            blurEffectScript.Contrast = contrastValue;
        }

        if (changeSaturation)
        {
            blurEffectScript.Saturation = saturationValue;
        }

        if (changeBrightness)
        {
            blurEffectScript.Brightness = brightnessValue;
        }

        if (changeBodyColor)
        {
            blurEffectScript.UIBlock.Color = bodyColor;
        }
    }

    public void Change(GameObject btn)
    {
        string var = btn.name;
        Color32 btnColor = btn.GetComponent<Image>().color;

        if (btnColor.r == 255)
        {
            btnColor.r = 0;
            btnColor.g = 255;
        }
        else
        {
            btnColor.g = 0;
            btnColor.r = 255;
        }

        btn.GetComponent<Image>().color = btnColor;

        switch (var)
        {
            case ("Blur"):
                changeBlurRadius = !changeBlurRadius;
                break;

            case ("Contrast"):
                changeContrast = !changeContrast;
                break;

            case ("Saturation"):
                changeSaturation = !changeSaturation;
                break;

            case ("Brightness"):
                changeBrightness = !changeBrightness;
                break;
        }
    }
}
