using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NumberGenerator : MonoBehaviour
{

    public TextMeshPro score;
    int counter;

    // Start is called before the first frame update
    void Start()
    {
        int randomNumber = Random.Range(0, 11);
        score.text = randomNumber.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        //counter++;
        //score.text = counter.ToString();
    }
}
