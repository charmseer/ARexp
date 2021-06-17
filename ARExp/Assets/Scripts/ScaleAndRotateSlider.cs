﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScaleAndRotateSlider : MonoBehaviour
{
    //Access Two Slider Objects from scene

    private Slider scaleSlider;
    private Slider rotateSlider;

    private Button IncreaseButton;
    private Button DecreaseButton;

    // Variables to set min and max values of Scale and Rotate
    public float scaleMinValue;
    public float scaleMaxValue;
    public float rotMinValue;
    public float rotMaxValue;
    
    // Start is called before the first frame update
    void Start()
    {

        scaleSlider = GameObject.Find("ScaleSlider").GetComponent<Slider>();
        scaleSlider.minValue = scaleMinValue;
        scaleSlider.maxValue = scaleMaxValue;

        //Syntax is ui.onValueChanged.AddListener(Functioncall)
        scaleSlider.onValueChanged.AddListener(ScaleSliderUpdate);

        rotateSlider = GameObject.Find("RotateSlider").GetComponent<Slider>();
        rotateSlider.minValue = rotMinValue;
        rotateSlider.maxValue = rotMaxValue;

        rotateSlider.onValueChanged.AddListener(RotateSliderUpdate);

        //Find Buttons from Scene
        IncreaseButton = GameObject.Find("IncreaseButton").GetComponent<Button>();
        IncreaseButton.onClick.AddListener(IncreaseButtonUpdate);

        DecreaseButton = GameObject.Find("DecreaseButton").GetComponent<Button>();
        DecreaseButton.onClick.AddListener(DecreaseButtonUpdate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ScaleSliderUpdate(float value)
    {
        transform.localScale = new Vector3(value, value, value);
    }

    public void IncreaseButtonUpdate()
    {
        
        transform.localScale = new Vector3(transform.localScale.x + 0.2f , transform.localScale.y + 0.2f, transform.localScale.z + 0.2f);

    }

    public void DecreaseButtonUpdate()
    {

        transform.localScale = new Vector3(transform.localScale.x - 0.2f, transform.localScale.y - 0.2f, transform.localScale.y - 0.2f);

    }

    void RotateSliderUpdate(float value)
    {
        transform.localEulerAngles = new Vector3(transform.rotation.x, value, transform.rotation.z);
    }
}
