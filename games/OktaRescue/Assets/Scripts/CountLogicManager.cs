using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountLogicManager : MonoBehaviour
{
    public GameObject newOkta;
    public Vector2 initalPos = new Vector2(-9.4f, 3f);
    // public int test = 11;

    private float addX = 1.7f;
    private float addY = -1.8f;
    // Start is called before the first frame update
    void Start()
    {
        // PlayerPrefs.SetInt("totalSaved", test);
        // insitiate start at inital position
        // add 1.7 to inital position x axis at each incrementation to spawn
        // only -1.8 to inital position y axis when number of okta % 10 is 0 which means there is one full line
        Vector2 spawnPos = initalPos;

        for (int i = 0; i < PlayerPrefs.GetInt("totalSaved"); i++) {
            if (i % 10 == 0 && i != 0) {
                spawnPos = initalPos;
                spawnPos.y = spawnPos.y + addY;
                addY += addY;
            }
            spawnPos.x = spawnPos.x + addX;
            Instantiate(newOkta, spawnPos, Quaternion.Euler(0,0,7.935f));

        }
      
        Debug.Log("from last " + PlayerPrefs.GetInt("totalSaved"));


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
