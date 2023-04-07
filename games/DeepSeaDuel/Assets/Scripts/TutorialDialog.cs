using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialDialog : MonoBehaviour
{
    public GameObject panel;
    private float timeRemaining = 2.5f;

    void Start()
    {
        panel.SetActive(true);
    }

    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining = timeRemaining - Time.deltaTime;
        }
        else
        {
            HidePanel();
        }
    }

    public void HidePanel()
    {
        panel.SetActive(false);
    }
}
