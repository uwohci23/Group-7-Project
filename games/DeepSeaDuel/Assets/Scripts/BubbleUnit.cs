using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BubbleUnit : MonoBehaviour
{
    // reference to BattleSystem
    public BattleSystem system;

    // Variables for the bubble's value and text
    public int value;
    public TMP_Text text_value;

    // Variables for dragging mechanicms
    private bool dragging = false;
    private Vector3 offset;
    private Vector3 startPosition;

    public BoxCollider2D myCollider;

    // Get and set methods
    public void setValue(int new_value)
    {
        value = new_value;
        text_value.SetText(new_value.ToString());
    }

    public int getValue()
    {
        return value;
    }

    void Start()
    {
        startPosition = transform.position;
        myCollider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if (dragging)
        {
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
        }
    }

    private void OnMouseDown()
    {
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        dragging = true;
    }

    private void OnMouseUp()
    {
        dragging = false;
        bool foundBeach = false;
        Collider2D[] colliders = Physics2D.OverlapBoxAll(transform.position, myCollider.size * 0.5f, 0f);
        foreach (Collider2D collider in colliders)
        {
            if (collider == myCollider)
            {
                continue;
            }
            if (collider.gameObject.layer == LayerMask.NameToLayer("Beach"))
            {
                foundBeach = true;
                system.ChangeTurn(value);
            }
        }
        if (!foundBeach)
        {
            transform.position = startPosition;
        }
    }

}
