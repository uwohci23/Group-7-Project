using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class sliderValueToText : MonoBehaviour {
    public Slider sliderUI;
    public TextMeshProUGUI textSliderValue;

    void Start(){
        sliderUI.onValueChanged.AddListener (delegate {ValueChangeCheck ();});
    }

    public void ValueChangeCheck()
    {
        textSliderValue.text = sliderUI.value.ToString();
        // Debug.Log(sliderUI.value.ToString());
    }

    public int getSliderValue() {
        return (int)sliderUI.value;
    }


    // public void ShowSliderValue () {
    // string sliderMessage = "Slider value = " + sliderUI.value;
    // textSliderValue.text = sliderMessage;
    // }
}