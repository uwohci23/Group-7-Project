using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleGridManager : MonoBehaviour
{
    public GameObject bubble;
    private Vector2 initalPos = new Vector2(-3.5f, 1f);

    private float addX = 1.7f;
    private float addY = -1.8f;

    public List<GameObject> allBubbles; // maintains a reference to each element for deletion

    void Awake()
    {
        allBubbles = new List<GameObject>();
        Vector2 spawnPos = initalPos;
        List<int> numberList = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        for (int i = 0; i < 9; i++)
        {
            if (i % 3 == 0 && i != 0)
            {
                spawnPos = initalPos;
                spawnPos.y = spawnPos.y + addY;
                addY += addY;
            }
            spawnPos.x = spawnPos.x + addX;
            GameObject new_bubble = Instantiate(bubble, spawnPos, Quaternion.Euler(0, 0, 0));
            allBubbles.Add(new_bubble);
            BubbleUnit curr_bubble = new_bubble.GetComponent<BubbleUnit>();
            int index = Random.Range(0, numberList.Count);
            curr_bubble.setValue(numberList[index]);
            numberList.RemoveAt(index);
        }

        getBubbles();
    }

    public List<GameObject> getBubbles()
    {
        return allBubbles;
    }

    public void DeleteBubble(int value)
    {
        Debug.Log(value);
        GameObject bubble = null;
        for (int i = 0; i < allBubbles.Count; i++)
        {
            GameObject curr_bubble = allBubbles[i];
            BubbleUnit curr_values = curr_bubble.GetComponent<BubbleUnit>();
            int curr_value = curr_values.getValue();
            if (curr_value == value) {
                bubble = curr_bubble;
            }
        }
        allBubbles.Remove(bubble);
        Destroy(bubble);
    }

}