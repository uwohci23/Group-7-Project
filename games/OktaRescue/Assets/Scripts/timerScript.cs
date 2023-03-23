using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class timerScript : MonoBehaviour
{
    public float timerLeft;
    public bool timerOn = false;
    public TextMeshProUGUI Timer;

    // Start is called before the first frame update
    void Start()
    {
        timerOn = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timerOn) {
            if (timerLeft > 0) {
                timerLeft -= Time.deltaTime;
                Timer.text = timerLeft.ToString("0");
            }
            else {
                Debug.Log("Time is up!");
                timerLeft = 0;
                timerOn = false;
            }
        }
        
    }

}
