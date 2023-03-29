using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class countSceneButton : MonoBehaviour
{
    public Button checkB;
    public Button playAgainB;
    public Button moveOnB;
    public Button exitB;
    public sliderValueToText slider;
    public eventScript eventM;

    // Start is called before the first frame update
    void Start()
    {
        // canot find the slider script???
        slider = GameObject.FindGameObjectWithTag("SliderManager").GetComponent<sliderValueToText>();
        eventM = GameObject.FindGameObjectWithTag("EventManager").GetComponent<eventScript>();
        Button btn = checkB.GetComponent<Button>();
        btn.onClick.AddListener(checkBTaskOnClick);
        btn = playAgainB.GetComponent<Button>();
        btn.onClick.AddListener(playAgainBTaskOnClick);
        btn = exitB.GetComponent<Button>();
        btn.onClick.AddListener(exitBTaskOnClick);
        // btn = moveOnB.GetComponent<Button>();
        // btn.onClick.AddListener(moveOnBTaskOnClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void checkBTaskOnClick() {
        if(slider.getSliderValue() == PlayerPrefs.GetInt("totalSaved")) {
            eventM.showCorrectPop();
        }
        else {
            Debug.Log("try again");

        }
    }

    void playAgainBTaskOnClick() {
        SceneManager.LoadScene("MainGame");
    }

    void exitBTaskOnClick() {
        SceneManager.LoadScene("DifficultyMenu");
    }

    // move on to the next difficulty level
    // void moveOnBTaskOnClick() {

    // }
}
