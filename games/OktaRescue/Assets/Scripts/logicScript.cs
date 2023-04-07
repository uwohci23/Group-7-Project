using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System;



public class logicScript : MonoBehaviour
{

    // totalSavedNum need to be passed to the count scene
    public int totalSavedNum;
    public int savedNum;
    public int needToSaveNum;
    public TextMeshProUGUI savedNumText;
    public TextMeshProUGUI needToSavedNumText;
    public TextMeshProUGUI textCue;

    public oktaSpawn oktaSpawner;


    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("totalSaved", 0);
        totalSavedNum = 0;
        randomGenerator();
        
        needToSavedNumText.text = needToSaveNum.ToString();
        oktaSpawner = GameObject.FindGameObjectWithTag("OktaSpawner").GetComponent<oktaSpawn>();
        if (PlayerPrefs.GetString("difficulty") ==  "easy") {
            oktaSpawner.generateOutlineOkta(needToSaveNum);
        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    public int randomGenerator() {
        if (PlayerPrefs.GetString("difficulty") ==  "easy") {
            needToSaveNum = UnityEngine.Random.Range(1, 5);
        }
        else if (PlayerPrefs.GetString("difficulty") ==  "medium") {
            needToSaveNum = UnityEngine.Random.Range(5, 9);
        }
        else if (PlayerPrefs.GetString("difficulty") ==  "difficulty") {
            needToSaveNum = UnityEngine.Random.Range(7, 10);
        }
        return needToSaveNum;
    }


    [ContextMenu("Increase Score")]
    public void addNum(int score)
    {
        savedNum = savedNum + score;
        // totalSavedNum = totalSavedNum + score;
        savedNumText.text = savedNum.ToString();
    }

    public void subtractNum(int score)
    {
        savedNum = savedNum - score;
        savedNumText.text = savedNum.ToString();
    }

    // if they preforman one action right
    // savedNum = 1 print text of good job
    public void savedOne()
    {
        textCue.text = "good job";
    }

    public void resetText()
    {
        textCue.text = "keep going";

    }

    public void addToTotal()
    {
        totalSavedNum = savedNum + totalSavedNum;
        Debug.Log("total saved okta: " + totalSavedNum);
        PlayerPrefs.SetInt("totalSaved", totalSavedNum);
    }

    public string getNeedToSavedNum()
    {
        return needToSavedNumText.text;
    }

    public void resetSavedNum()
    {
        savedNum = 0;
    }

    public int getScore()
    {
        return savedNum;
    }

    public int getNeedToSave()
    {
        return needToSaveNum;
    }


    public bool savedNumEqual()
    {
        int tempNeedToSave = stringConvertInt(needToSavedNumText.text);
        int tempSaved = stringConvertInt(savedNumText.text);

        return tempNeedToSave == tempSaved;
    }

    public int stringConvertInt(string text)
    {
        int value = Convert.ToInt32(text);
        return value;
    }


}
