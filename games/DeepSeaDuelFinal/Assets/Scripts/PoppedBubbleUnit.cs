using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PoppedBubbleUnit : MonoBehaviour
{

    public int value;
    public TMP_Text text_value;

    public void setValue(int new_value)
    {
        Debug.Log("update popped bubble value");
        value = new_value;
        text_value.SetText(new_value.ToString());
    }
}
