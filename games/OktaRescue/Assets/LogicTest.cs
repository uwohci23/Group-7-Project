using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicTest : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(loadNum());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public int loadNum() {
        return PlayerPrefs.GetInt("totalSaved");
    }
}
