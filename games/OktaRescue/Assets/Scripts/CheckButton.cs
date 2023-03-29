using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class CheckButton : MonoBehaviour
{
    public Button checkB;
    public sliderValueToText slider;
    public eventScript eventM;

    // Start is called before the first frame update
    void Start()
    {
        // canot find the slider script???
        slider = GameObject.FindGameObjectWithTag("SliderManager").GetComponent<sliderValueToText>();
        eventM = GameObject.FindGameObjectWithTag("EventManager").GetComponent<eventScript>();
        Button btn = checkB.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TaskOnClick() {
        if(slider.getSliderValue() == PlayerPrefs.GetInt("totalSaved")) {
            eventM.showCorrectPop();
        }
        else {
            Debug.Log("try again");

        }
    }
}
