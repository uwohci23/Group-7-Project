using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class CheckButton : MonoBehaviour
{
    public Button checkB;
    public sliderValueToText silderScript;

    // Start is called before the first frame update
    void Start()
    {
        silderScript = GameObject.FindGameObjectWithTag("Slider").GetComponent<sliderValueToText>();
        Button btn = checkB.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TaskOnClick() {
        if(silderScript.getSliderValue() == PlayerPrefs.GetInt("totalSaved")) {
            Debug.Log("good job!!");
        }
    }
}
