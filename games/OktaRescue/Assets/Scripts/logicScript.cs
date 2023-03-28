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

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("totalSaved", 0);
        totalSavedNum = 0;
        needToSaveNum = UnityEngine.Random.Range(1, 5);
        needToSavedNumText.text = needToSaveNum.ToString();
    }

    // Update is called once per frame
    void Update()
    {

        
    }


    [ContextMenu("Increase Score")]
    public void addNum(int score) {
        savedNum = savedNum + score;
        // totalSavedNum = totalSavedNum + score;
        savedNumText.text = savedNum.ToString();
    }

    public void subtractNum(int score) {
        savedNum = savedNum - score;
        savedNumText.text = savedNum.ToString();
    }

    public void addToTotal() {
        totalSavedNum = savedNum + totalSavedNum;
        Debug.Log("total saved okta: " + totalSavedNum);
        PlayerPrefs.SetInt("totalSaved", totalSavedNum);
    }

    public void resetSavedNum() {
        savedNum = 0;
    }

    public int getScore() {
        return savedNum;
    }
    

    public bool savedNumEqual() {
        int tempNeedToSave = stringConvertInt(needToSavedNumText.text);
        int tempSaved = stringConvertInt(savedNumText.text);

        return tempNeedToSave == tempSaved;
    }

    public int stringConvertInt(string text) {
        int value = Convert.ToInt32(text);
        return value;
    }


}
