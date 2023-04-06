using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartDialog : MonoBehaviour
{
    public GameObject panel;

    void Start()
    {
        panel.SetActive(false);
    }

    public void ShowPanel()
    {
        panel.SetActive(true);
    }
}
