using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPoppedBubbleGrid : MonoBehaviour
{
    public GameObject bubble;
    private Vector2 spawnPosition = new Vector2(7f, 3f);
    private float addY = -1.5f;

    void Start()
    {
    }

    public void AddBubble(int value)
    {
        GameObject new_bubble = Instantiate(bubble, spawnPosition, Quaternion.Euler(0, 0, 0));
        PoppedBubbleUnit curr_bubble = new_bubble.GetComponent<PoppedBubbleUnit>();
        curr_bubble.setValue(value);
        spawnPosition.y = spawnPosition.y + addY;
    }
}