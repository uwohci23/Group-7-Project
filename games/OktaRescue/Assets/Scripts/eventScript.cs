using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class eventScript : MonoBehaviour
{
    public GameObject correctPop;

    // Start is called before the first frame update
    void Start()
    {
        correctPop.SetActive(false);
    }
    
    public void showCorrectPop() {
        correctPop.SetActive(true);
    }
}
