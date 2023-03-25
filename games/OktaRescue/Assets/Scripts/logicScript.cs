using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class logicScript : MonoBehaviour
{

    // totalSavedNum need to be passed to the count scene
    static int totalSavedNum;
    public int savedNum;
    public int needToSaveNum;
    public TextMeshProUGUI savedNumText;
    public TextMeshProUGUI needToSavedNumText;

    // Start is called before the first frame update
    void Start()
    {
        totalSavedNum = 0;
        needToSaveNum = Random.Range(0, 10);
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

    public int getScore() {
        return savedNum;
    }
}
