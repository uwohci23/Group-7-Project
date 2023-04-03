using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class eventScript : MonoBehaviour
{
    public GameObject correctPop;
    public GameObject incorrectPop;


    // Start is called before the first frame update
    void Start()
    {
        correctPop.SetActive(false);
        incorrectPop.SetActive(false);
    }
    
    public void showCorrectPop() {
        correctPop.SetActive(true);
    }

    public void showIncorrectPop() {
        incorrectPop.SetActive(true);
    }
}
