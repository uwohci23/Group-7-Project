using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class okta : MonoBehaviour
{
    public float speed = 200f;
    public logicScript logic;

    private Color startcolor;
	private SpriteRenderer oktaSR;
    private Vector3 targetPosition;
    private Vector3 startPos;

	private bool isDown = false;


    // Start is called before the first frame update
    void Start()
    {
        oktaSR = GetComponent<SpriteRenderer>();
        targetPosition = new Vector3(8, -4, 0);
        startPos = transform.position;
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<logicScript>();

    }

    // Update is called once per frame
    void Update()
    {
        if (isDown) {
            startPos = Vector3.MoveTowards(startPos, targetPosition, speed * Time.deltaTime);
            transform.position = startPos;
        }
        if (transform.position == targetPosition) {
            oktaSR.color = Color.green;
        }

    }


    public void MoveTo(Vector3 position)
    {
        targetPosition = position;
    }

    // change the object to yellow when mouse hover
    void OnMouseEnter()
    {
        startcolor = oktaSR.color;
        oktaSR.color = Color.yellow;
    }

    void OnMouseExit()
    {
        oktaSR.color = startcolor;
    }

    // maybe in easy level let okta gets flushed
    // change the object to yellow when user click okta and okta will automatically move to a left position
    // change okta tag to selected after user click one
	void OnMouseDown() {
		isDown = true;
        oktaSR.color = Color.yellow;
	}

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Tube") {
            logic.addNum(1);
        }
    }

        
}
