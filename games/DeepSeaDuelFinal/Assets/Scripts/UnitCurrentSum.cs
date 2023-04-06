using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UnitCurrentSum : MonoBehaviour
{
    public TextMeshPro text;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    public void ChangeText(string new_text)
    {
        text.text = new_text;
    }
}
